Imports libWBEData
Imports libWBEBR

Public Class frmMain
    'This is the master control that contains the navigation to all other forms in the project.
    'This is just a rough draft that will need to be improved.

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
            If Customer.IsInactive = False Then
                FillCustStock(Customer, _colCustStock)
                modFillCollections.RemoveInactiveBakedGoods(_colBakedGoods)
                modFillCollections.RemoveInactiveCustStock(_colCustStock, _colBakedGoods)
                modFillCollections.AddCustStockPrices(_colCustStock, _colBakedGoods)
                GenerateOrder(_colCustStock, _colOrders, _colOrderItems, Customer)
                Customer.LastOrderDate = Today
                _colCustomers.Change(Customer)
            End If
        Next
        CustomerDB.Update()
    End Sub

    Private Sub FillCustomers(ByVal colCustomers As colCustomers)
        Dim sError As String = ""
        CustomerDB.SetupAdapter()

        colCustomers.Clear()
        If colCustomers.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If
    End Sub

    Private Sub FillCustStock(ByVal Customer As Customer, ByVal colCustStock As colCustStock)
        Dim sError As String = ""

        CustStockDB.CustomerID = Customer.CustomerID
        CustStockDB.SetupAdapter()

        colCustStock.Clear()
        If colCustStock.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If

    End Sub

    Private Sub FillBakedGoods(ByVal colBakedGoods As colBakedGoods)
        Dim sError As String = ""

        BakedGoodDB.SetupAdapter()
        colBakedGoods.Clear()
        If colBakedGoods.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If
    End Sub

    Private Sub GenerateOrder(ByVal colCustStock As colCustStock,
                              ByVal colOrders As colOrders,
                              ByVal colOrderItems As colOrderItems,
                              ByVal Customer As Customer)

        Dim objOrder As New Order
        Dim sError As String = ""
        OrdersDB.CustomerID = Customer.CustomerID
        OrdersDB.SetupAdapter()

        colOrders.Clear()
        If colOrders.Fill(sError) = False Then
            MessageBox.Show(sError)
        Else
            objOrder.CustomerID = Customer.CustomerID
            objOrder.OrderDate = Today
            objOrder.Status = Order.eStatus.NewOrder
            colOrders.Add(objOrder)
            OrdersDB.Update()
            colOrders.Clear()
            colOrders.Fill(sError)
            GenerateOrderItems(colOrders(0), colOrderItems, colCustStock)
        End If

    End Sub

    Private Sub GenerateOrderItems(ByVal order As Order,
                                   ByVal colOrderItems As colOrderItems,
                                   ByVal colCustStock As colCustStock)
        Dim sError As String = ""
        OrderItemDB.OrderID = order.OrderID
        OrderItemDB.SetupAdapter()

        colOrderItems.Clear()
        If colOrderItems.Fill(sError) = False Then
            MessageBox.Show(sError)
        Else
            For Each CustStock As CustStock In colCustStock
                Dim objOrderItem As New OrderItem
                Dim quantity As Integer

                quantity = CustStock.DesiredQty - CustStock.StockQty

                'If the quantity is greater than minimum, allow the order for item.
                'If the quantity is less than minimum, we will skip the item.
                If quantity >= OrderItem.iMinQuantity Then
                    'if quantity is greater than max, set quantity to max
                    If quantity >= OrderItem.iMaxQuantity Then
                        quantity = OrderItem.iMaxQuantity
                    End If

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