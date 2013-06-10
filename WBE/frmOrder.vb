Imports libWBEData
Imports libWBEBR

Public Class frmOrder
    Private _colCustomers As New colCustomers
    Private _colOrders As New colOrders
    Private _colOrderItems As New colOrderItems
    Private _colBakedGoods As New colBakedGoods

    Private Sub frmOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sError As String = ""

        CustomerDB.SetupAdapter()
        BakedGoodDB.SetupAdapter()

        If _colBakedGoods.Fill(sError) Then

            'Remove any baked goods that are inactive
            modFillCollections.RemoveInactiveBakedGoods(_colBakedGoods)

            'sort the baked good list
            _colBakedGoods.Sort()
        Else
            MessageBox.Show(sError)
        End If

        'Fill the data collections

        If _colCustomers.Fill(sError) Then
            FillCustomerSelection()
        Else
            MessageBox.Show(sError)
        End If

    End Sub

    ''' <summary>
    ''' Fills Customer cbo for selecting the customer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillCustomerSelection()
        Dim sError As String = ""

        cboCustomer.Items.Clear()

        _colCustomers.Sort()

        For Each objCustomer As Customer In _colCustomers
            cboCustomer.Items.Add(objCustomer)
        Next

        cboCustomer.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Show latest order for the customer
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <remarks></remarks>
    Private Sub ShowOrder(ByVal CustomerID As Integer)
        Dim sError As String = ""

        'Fill the collection of customer items
        lstOrderItems.Items.Clear()
        _colOrders.Clear()
        _colOrderItems.Clear()
        ClearForm()
        lblOrderNumber.Text = "No Order"
        lblStatus.Text = "No Orders"
        lblDate.Text = "No Date"

        'load cust stock items for selected customer only
        OrdersDB.CustomerID = CustomerID
        OrdersDB.SetupAdapter()

        If _colOrders.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If

        'Make sure that there is an order for the customer
        If _colOrders.Count > 0 Then

            'Get order items for the order
            OrderItemDB.OrderID = _colOrders.Item(0).OrderID
            OrderItemDB.SetupAdapter()

            If _colOrderItems.Fill(sError) = False Then
                MessageBox.Show(sError)
            End If

            'Fill out order details
            SetOrderDetails(_colOrders.Item(0))

            'Add order items to the listbox
            modFillCollections.RemoveInactiveOrderItems(_colOrderItems, _colBakedGoods)
            FillOrderItems()

            If lstOrderItems.Items.Count > 0 Then
                lstOrderItems.SelectedIndex = 0
            End If

        Else
            cboItem.Items.Clear()
            FillItemList()
        End If
    End Sub

    ''' <summary>
    ''' Add all existing order items to the listbox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillOrderItems()
        'Make sure there are order items
        If _colOrderItems.Count > 0 Then
            For Each OrderItem As OrderItem In _colOrderItems
                lstOrderItems.Items.Add(OrderItem)
            Next
        Else
            'If no items exist, add one automatically
            CallAddItemForm()
        End If
    End Sub

    ''' <summary>
    ''' Change the customer selection and update order/order items
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomer.SelectedIndexChanged
        ShowOrder(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)
    End Sub

    ''' <summary>
    ''' Change the quantity of the order item selected or create a new item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstOrderItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrderItems.SelectedIndexChanged
        Dim CustStock As New CustStock
        Dim OrderItem As OrderItem

        'Get selected order item
        cboItem.Items.Clear()
        FillItemList()
        RemoveUsedBakedGoods()

        If lstOrderItems.SelectedIndex <> -1 Then
            OrderItem = DirectCast(lstOrderItems.SelectedItem, OrderItem)
            SetItemSelection(OrderItem)
            txtPrice.Text = OrderItem.UnitPrice.ToString("f")
            txtQuantity.Text = OrderItem.Quantity.ToString
        End If
    End Sub

    ''' <summary>
    ''' Create new line item by calling frmAddItem
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CallAddItemForm()
        ClearForm()
    End Sub

    ''' <summary>
    ''' Clear the form and deselect listbox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        txtPrice.Text = ""
        txtQuantity.Text = ""
        lstOrderItems.SelectedIndex = -1
        cboItem.SelectedIndex = -1
    End Sub
    ''' <summary>
    ''' Create new order and update database
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNewOrder()
        Dim Order As New Order
        Dim sError As String = ""

        Order.CustomerID = DirectCast(cboCustomer.SelectedItem, Customer).CustomerID
        Order.OrderDate = Today
        Order.Status = libWBEBR.Order.eStatus.NewOrder

        _colOrders.Add(Order)
        OrdersDB.Update()

        _colOrders.Clear()
        If _colOrders.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If

        SetOrderDetails(_colOrders.Item(0))

    End Sub

    ''' <summary>
    ''' Update order details in form
    ''' </summary>
    ''' <param name="Order"></param>
    ''' <remarks></remarks>
    Private Sub SetOrderDetails(ByVal Order As Order)
        With Order
            lblOrderNumber.Text = .OrderID
            lblStatus.Text = .StatusDesc
            lblDate.Text = .OrderDate.ToString("d")
        End With
    End Sub

    ''' <summary>
    ''' Adds all available baked goods to the combobox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillItemList()
        For Each BakedGood As BakedGood In _colBakedGoods
            cboItem.Items.Add(BakedGood)
        Next
    End Sub
    ''' <summary>
    ''' Removes baked good items that are already listed in order (except current selected baked good item)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveUsedBakedGoods()
        For i As Integer = cboItem.Items.Count - 1 To 0 Step -1
            Dim objBakedGood As BakedGood = DirectCast(cboItem.Items(i), BakedGood)
            If IsBakedGoodInOrder(objBakedGood) Then
                If lstOrderItems.SelectedIndex <> -1 Then
                    If objBakedGood.BakedGoodID <> DirectCast(lstOrderItems.SelectedItem, OrderItem).BakedGoodID Then
                        cboItem.Items.Remove(objBakedGood)
                    End If
                Else
                    cboItem.Items.Remove(objBakedGood)
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Determines whether or not a type of baked good is in an order
    ''' </summary>
    ''' <param name="objBakedGood"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsBakedGoodInOrder(ByVal objBakedGood As BakedGood) As Boolean
        For Each objOrderItem As OrderItem In _colOrderItems
            If objOrderItem.BakedGoodID = objBakedGood.BakedGoodID Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Set the cboItem equal to the Baked Good with ID matching the order item
    ''' </summary>
    ''' <param name="OrderItem"></param>
    ''' <remarks></remarks>
    Private Sub SetItemSelection(ByVal OrderItem As OrderItem)
        For i As Integer = 0 To cboItem.Items.Count - 1
            If DirectCast(cboItem.Items(i), BakedGood).BakedGoodID = OrderItem.BakedGoodID Then
                cboItem.SelectedIndex = i
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim objOrderItem As OrderItem

        If lblStatus.Text = "No Orders" Then
            CreateNewOrder()
        End If

        'Get orderitem from list box or create a new one
        If lstOrderItems.SelectedIndex <> -1 Then
            objOrderItem = DirectCast(lstOrderItems.SelectedItem, OrderItem)
        Else
            objOrderItem = New OrderItem
        End If

        'Check user input is valid
        If IsValid(objOrderItem) Then

            'Get IDs
            objOrderItem.OrderID = Convert.ToInt32(lblOrderNumber.Text)

            'If OrderItemID not zero, then existing orderitem
            If objOrderItem.OrderItemID <> 0 Then
                _colOrderItems.Change(objOrderItem)
            Else  'If OrderItemID = 0, then new orderitem.
                _colOrderItems.Add(objOrderItem)
            End If

            'To update data in listbox, we need to save and refresh data
            OrderItemDB.Update()

            'Reset listbox
            lstOrderItems.Items.Clear()
            ShowOrder(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)
            btnAdd.Text = "&Add Item"
        End If
        
    End Sub

    ''' <summary>
    ''' Check that user input is valid
    ''' </summary>
    ''' <param name="objOrderItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValid(ByVal objOrderItem As OrderItem) As Boolean
        epOrder.Clear()

        If IsValidPrice(objOrderItem) And
            IsValidQuantity(objOrderItem) And
            IsValidItem(objOrderItem) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Check that user input of quantity is valid
    ''' </summary>
    ''' <param name="objOrderItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidQuantity(ByVal objOrderItem As OrderItem) As Boolean
        Try
            objOrderItem.Quantity = Convert.ToInt32(txtQuantity.Text)
            Return True

        Catch ex As FormatException
            epOrder.SetError(txtQuantity, objOrderItem.QuantityError)
            Return False

        Catch ex As Exception
            epOrder.SetError(txtQuantity, ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Check that user input of price is valid
    ''' </summary>
    ''' <param name="objOrderItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidPrice(ByVal objOrderItem As OrderItem) As Boolean
        Try
            objOrderItem.UnitPrice = Convert.ToDecimal(txtPrice.Text)
            Return True

        Catch ex As FormatException
            epOrder.SetError(txtPrice, objOrderItem.UnitPriceError)
            Return False

        Catch ex As Exception
            epOrder.SetError(txtPrice, ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' This function makes sure an item is selected in the listbox
    ''' </summary>
    ''' <param name="objOrderItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidItem(ByVal objOrderItem As OrderItem) As Boolean
        Try
            objOrderItem.BakedGoodID = DirectCast(cboItem.SelectedItem, BakedGood).BakedGoodID
            Return True

        Catch ex As Exception
            epOrder.SetError(cboItem, "An item must be selected.")
            Return False

        End Try
    End Function
    ''' <summary>
    ''' Allow user to add new line item
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "&Add Item" Then
            ClearForm()
            btnAdd.Text = "&Cancel"
        Else
            btnAdd.Text = "&Add Item"
            lstOrderItems.SelectedIndex = 0
        End If

    End Sub

    ''' <summary>
    ''' When you change the item selection, input the default price for the selected baked good
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItem.SelectedIndexChanged
        If lstOrderItems.SelectedIndex = -1 And cboItem.SelectedIndex <> -1 Then
            txtPrice.Text = DirectCast(cboItem.SelectedItem, BakedGood).UnitPrice.ToString("f")
        End If
    End Sub

    ''' <summary>
    ''' Delete a line item in an order
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        If lstOrderItems.SelectedIndex = -1 Then
            MessageBox.Show("You must select an item to delete in the listbox.")
        Else
            Dim objOrderItem As OrderItem

            objOrderItem = DirectCast(lstOrderItems.SelectedItem, OrderItem)
            _colOrderItems.Remove(objOrderItem)
            OrderItemDB.Update()

            'Reset listbox
            lstOrderItems.Items.Clear()
            ShowOrder(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)
            btnAdd.Text = "&Add Item"
        End If
    End Sub

    ''' <summary>
    ''' Deletes the entire order
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDeleteOrder_Click(sender As Object, e As EventArgs) Handles btnDeleteOrder.Click
        Dim iOrderID As Integer
        Dim objOrder As Order

        Try
            iOrderID = lblOrderNumber.Text
            objOrder = _colOrders.Find(iOrderID)
            _colOrders.Remove(objOrder)
            OrdersDB.Update()
            ShowOrder(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)
            ClearForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class