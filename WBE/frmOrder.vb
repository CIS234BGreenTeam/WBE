Imports libWBEData
Imports libWBEBR

Public Class frmOrder
    Private _colCustomers As New colCustomers
    Private _colOrders As New colOrders
    Private _colOrderItems As New colOrderItems

    Private Sub frmOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sError As String = ""

        CustomerDB.SetupAdapter()

        'Fill the data collections

        If _colCustomers.Fill(sError) Then
            FillCustomerSelection()
        Else
            MessageBox.Show(sError)
        End If

        'Load the current selected customer data
        ShowOrder(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)
    End Sub

    ''' <summary>
    ''' Fills Customer dropdownmenu for selecting the customer
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

        If _colOrders.Count > 0 Then
            OrderItemDB.OrderID = _colOrders.Item(0).OrderID
            OrderItemDB.SetupAdapter()

            If _colOrderItems.Fill(sError) = False Then
                MessageBox.Show(sError)
            End If

            With _colOrders.Item(0)
                lblOrderNumber.Text = .OrderID
                lblStatus.Text = .StatusDesc
                dtDate.Text = .OrderDate
            End With

            FillOrderItems()
        Else
            CreateNewOrder()
            ShowOrder(CustomerID)
        End If
    End Sub

    Private Sub FillOrderItems()

        If _colOrderItems.Count > 0 Then
            For Each OrderItem As OrderItem In _colOrderItems
                lstOrderItems.Items.Add(OrderItem)
            Next
        Else
            CallAddItemForm()
        End If
    End Sub

    Private Sub cboCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomer.SelectedIndexChanged
        ShowOrder(DirectCast(cboCustomer.SelectedItem, Customer).CustomerID)
    End Sub

    Private Sub lstOrderItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrderItems.SelectedIndexChanged
        Dim CustStock As New CustStock
        Dim OrderItem As OrderItem
        Dim frmQuantity As New frmQuantity

        OrderItem = DirectCast(lstOrderItems.SelectedItem, OrderItem)
        If Not OrderItem Is Nothing Then
            CustStock.Name = OrderItem.Name
            CustStock.DesiredQty = OrderItem.Quantity

            frmQuantity.frmOrder = Me
            frmQuantity.SetCustStock(CustStock)
            frmQuantity.ShowDialog()
        Else
            CallAddItemForm()
        End If
        
    End Sub

    Private Sub CallAddItemForm()
        Dim frmAddItem As New frmAddItem
        frmAddItem.SetOrderItem(_colOrderItems)
        frmAddItem.frmOrder = Me
        frmAddItem.ShowDialog()
    End Sub

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

    Private Sub SetOrderDetails(ByVal Order As Order)
        With Order
            lblOrderNumber.Text = .OrderID
            lblStatus.Text = .StatusDesc
            dtDate.Text = .OrderDate
        End With
    End Sub
End Class