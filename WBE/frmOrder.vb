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
        lblOrderNumber.Text = "No Order"
        lblStatus.Text = "No Orders"

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
            RemoveInactiveOrderItems()
            FillOrderItems()
            FillItemSelection()
        Else
            'If no order exists, create one and update
            CreateNewOrder()
            ShowOrder(CustomerID)
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

        'Get selected orer item
        cboItem.Items.Clear()
        FillItemList()
        RemoveUsedBakedGoods()

        OrderItem = DirectCast(lstOrderItems.SelectedItem, OrderItem)
        SetItemSelection(OrderItem)
        txtPrice.Text = OrderItem.UnitPrice.ToString("f")
        txtQuantity.Text = OrderItem.Quantity.ToString
        
    End Sub

    ''' <summary>
    ''' Create new line item by calling frmAddItem
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CallAddItemForm()
        ClearForm()
    End Sub

    Private Sub ClearForm()
        'FillItemSelection()
        txtPrice.Text = ""
        txtQuantity.Text = ""
        lstOrderItems.SelectedIndex = -1
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

        If _colOrders.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If

        SetOrderDetails(_colOrders.Item(0))

    End Sub

    ''' <summary>
    ''' Add new line item. This is called by frmAddItem
    ''' </summary>
    ''' <param name="objOrderItem"></param>
    ''' <remarks></remarks>
    Public Sub AddNewItem(ByVal objOrderItem As OrderItem)
        objOrderItem.OrderID = Convert.ToInt32(lblOrderNumber.Text)
        _colOrderItems.Add(objOrderItem)
        lstOrderItems.Items.Add(objOrderItem)
        OrderItemDB.Update()
    End Sub

    ''' <summary>
    ''' This is called by frmQuantity to set new OrderItem quantity level
    ''' </summary>
    ''' <param name="objCustStock"></param>
    ''' <remarks></remarks>
    Public Sub SetQuantityLevel(ByVal objCustStock As CustStock)
        Dim OrderItem As OrderItem
        OrderItem = DirectCast(lstOrderItems.SelectedItem, OrderItem)

        OrderItem.Quantity = objCustStock.DesiredQty

        'If OrderItemID not zero, then existing orderitem
        If OrderItem.OrderItemID <> 0 Then
            _colOrderItems.Change(OrderItem)
        Else  'If OrderItemID = 0, then new orderitem.
            _colOrderItems.Add(OrderItem)
        End If

        'To update data in listbox, we need to save and refresh data
        OrderItemDB.Update()
        lstOrderItems.Items.Clear()
        ShowOrder(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)

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
            dtDate.Text = .OrderDate
        End With
    End Sub

    Private Sub FillItemSelection()
        Dim sError As String = ""

        _colBakedGoods.Clear()
        If _colBakedGoods.Fill(sError) Then
            RemoveInactiveBakedGoods()
            _colBakedGoods.Sort()

            If lstOrderItems.Items.Count > 0 Then
                lstOrderItems.SelectedIndex = 0
            End If

            cboItem.Items.Clear()

            FillItemList()
            RemoveUsedBakedGoods()
        End If
    End Sub
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

    Private Function IsBakedGoodInOrder(ByVal objBakedGood As BakedGood) As Boolean
        For Each objOrderItem As OrderItem In _colOrderItems
            If objOrderItem.BakedGoodID = objBakedGood.BakedGoodID Then
                Return True
            End If
        Next

        Return False
    End Function
    ''' <summary>
    ''' Remove baked good items that are inactive from the collection
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveInactiveBakedGoods()
        For i As Integer = _colBakedGoods.Count - 1 To 0 Step -1
            If _colBakedGoods(i).IsInactive = True Then
                _colBakedGoods.RemoveAt(i)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Removes order items that correspond to inactive baked goods
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveInactiveOrderItems()
        For i As Integer = _colOrderItems.Count - 1 To 0 Step -1
            Dim objBakedGood As BakedGood
            objBakedGood = _colBakedGoods.Find(_colOrderItems(i).BakedGoodID)

            If objBakedGood Is Nothing Then
                _colOrderItems.Remove(_colOrderItems(i))
            End If
        Next
    End Sub
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

End Class