Imports libWBEData
Imports libWBEBR

Public Class frmMain
    'This is the master control that contains the navigation to all other forms in the project.
    'No real work has been put into making this look nice, obviously.

    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        Dim frmCustomer As New frmCustomer
        frmCustomer.Show()
    End Sub

    Private Sub btnOrderLevels_Click(sender As Object, e As EventArgs) Handles btnOrderLevels.Click
        Dim frmOrderLevels As New frmOrderLevels
        frmOrderLevels.SetFormType(False)
        frmOrderLevels.Show()
    End Sub

    Private Sub btnEditOrders_Click(sender As Object, e As EventArgs) Handles btnEditOrders.Click
        Dim frmOrder As New frmOrder
        frmOrder.Show()
    End Sub

    Private Sub btnCount_Click(sender As System.Object, e As System.EventArgs) Handles btnCount.Click
        Dim frmOrderLevels As New frmOrderLevels
        frmOrderLevels.SetFormType(True)
        frmOrderLevels.Show()
    End Sub

    Private Sub btnBakedGoods_Click(sender As Object, e As EventArgs) Handles btnBakedGoods.Click
        Dim frmBakedGood As New frmBakedGood
        frmBakedGood.Show()
    End Sub

    Private Sub btnGenerateOrders_Click(sender As Object, e As EventArgs) Handles btnGenerateOrders.Click
        Dim _colCustomers As New colCustomers
        Dim _colCustStock As New colCustStock
        Dim _colOrders As New colOrders
        Dim _colOrderItems As New colOrderItems
        Dim _colBakedGoods As New colBakedGoods

        FillCustomers(_colCustomers)
        FillBakedGoods(_colBakedGoods)

        For Each Customer As Customer In _colCustomers
            'Only generate orders for active customers
            If Customer.IsInactive = False Then

                'Fill the collection of custstock items for customer
                FillCustStock(Customer, _colCustStock)

                'Remove any baked goods from baked goods collection that are inactive
                modFillCollections.RemoveInactiveBakedGoods(_colBakedGoods)

                'Remove any custstock items that have inactive baked goods
                modFillCollections.RemoveInactiveCustStock(_colCustStock, _colBakedGoods)

                'Add prices to the custstock items for ease of calculations later
                modFillCollections.AddCustStockPrices(_colCustStock, _colBakedGoods)

                'Generate the order for the customer
                GenerateOrder(_colCustStock, _colOrders, _colOrderItems, Customer)
                Customer.LastOrderDate = Today
                _colCustomers.Change(Customer)
            End If
        Next
        CustomerDB.Update()
        MessageBox.Show("Orders generated for today.")
    End Sub

    ''' <summary>
    ''' Fill the customer collection
    ''' </summary>
    ''' <param name="colCustomers"></param>
    ''' <remarks></remarks>
    Private Sub FillCustomers(ByVal colCustomers As colCustomers)
        Dim sError As String = ""
        CustomerDB.SetupAdapter()

        colCustomers.Clear()
        If colCustomers.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If
    End Sub

    ''' <summary>
    ''' Fill the CustStock collection for the customer
    ''' </summary>
    ''' <param name="Customer"></param>
    ''' <param name="colCustStock"></param>
    ''' <remarks></remarks>
    Private Sub FillCustStock(ByVal Customer As Customer, ByVal colCustStock As colCustStock)
        Dim sError As String = ""

        CustStockDB.CustomerID = Customer.CustomerID
        CustStockDB.SetupAdapter()

        colCustStock.Clear()
        If colCustStock.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If

    End Sub

    ''' <summary>
    ''' Fill the baked good collection
    ''' </summary>
    ''' <param name="colBakedGoods"></param>
    ''' <remarks></remarks>
    Private Sub FillBakedGoods(ByVal colBakedGoods As colBakedGoods)
        Dim sError As String = ""

        BakedGoodDB.SetupAdapter()
        colBakedGoods.Clear()
        If colBakedGoods.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If
    End Sub

    ''' <summary>
    ''' Generate the order for the customer
    ''' </summary>
    ''' <param name="colCustStock"></param>
    ''' <param name="colOrders"></param>
    ''' <param name="colOrderItems"></param>
    ''' <param name="Customer"></param>
    ''' <remarks></remarks>
    Private Sub GenerateOrder(ByVal colCustStock As colCustStock,
                              ByVal colOrders As colOrders,
                              ByVal colOrderItems As colOrderItems,
                              ByVal Customer As Customer)

        Dim objOrder As New Order
        Dim sError As String = ""
        OrdersDB.CustomerID = Customer.CustomerID
        OrdersDB.SetupAdapter()

        'Fill the order collection with the most recent order. We might not actually have to do
        'this but it's a way of making sure the connection to the database is working
        colOrders.Clear()
        If colOrders.Fill(sError) = False Then
            MessageBox.Show(sError)
        Else

            'Fill order details
            objOrder.CustomerID = Customer.CustomerID
            objOrder.OrderDate = Today
            objOrder.Status = Order.eStatus.NewOrder

            'Add new order to the database and update to get the order number
            colOrders.Add(objOrder)
            OrdersDB.Update()
            colOrders.Clear()
            colOrders.Fill(sError)

            'Generate order items for the order
            GenerateOrderItems(colOrders(0), colOrderItems, colCustStock)
        End If

    End Sub

    ''' <summary>
    ''' Generate order items for the order
    ''' </summary>
    ''' <param name="order"></param>
    ''' <param name="colOrderItems"></param>
    ''' <param name="colCustStock"></param>
    ''' <remarks></remarks>
    Private Sub GenerateOrderItems(ByVal order As Order,
                                   ByVal colOrderItems As colOrderItems,
                                   ByVal colCustStock As colCustStock)
        Dim sError As String = ""
        OrderItemDB.OrderID = order.OrderID
        OrderItemDB.SetupAdapter()

        colOrderItems.Clear()

        'Fill the collection. This should have a count of 0 since there are no item yet
        If colOrderItems.Fill(sError) = False Then
            MessageBox.Show(sError)
        Else
            'Generate a new order item for each item in the custstock collection
            For Each CustStock As CustStock In colCustStock
                Dim objOrderItem As New OrderItem
                Dim quantity As Integer

                quantity = CustStock.DesiredQty - CustStock.StockQty

                'If the quantity is greater than minimum, allow the orderitem
                'If the quantity is less than minimum, we will skip the item.
                If quantity >= OrderItem.iMinQuantity Then

                    'if quantity is greater than max, set quantity to max
                    If quantity >= OrderItem.iMaxQuantity Then
                        quantity = OrderItem.iMaxQuantity
                    End If

                    'Set the order item details
                    objOrderItem.Quantity = quantity
                    objOrderItem.OrderID = order.OrderID
                    objOrderItem.BakedGoodID = CustStock.BakedGoodID
                    objOrderItem.UnitPrice = CustStock.UnitPrice

                    colOrderItems.Add(objOrderItem)
                End If
            Next

            OrderItemDB.Update()
        End If
    End Sub

End Class