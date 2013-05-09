Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objWBE As New colOrders

    End Sub

    Private Sub btnTestOrders_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTestOrders.Click
        Dim objWBE As New colOrders
        Dim objOrder As New Orders
        Clear()
        'add good order test
        Try
            With objOrder
                .OrderID = 1
                .OrderDate = Today
                .Status = 1
                .CustomerID = 1
            End With

            lstGood.Items.Add("OrderID: " & objOrder.OrderID & " OrderDate: " & objOrder.OrderDate _
                              & " Status: " & objOrder.Status & " CustomerID: " & objOrder.CustomerID)

        Catch ex As Exception
            lstGoodError.Items.Add("add good order " & ex.Message)
        End Try

        'add Bad order test
        Try
            With objOrder
                .OrderID = -1
                .OrderDate = Today
                .Status = 1
                .CustomerID = 1
            End With

            lstGood.Items.Add("OrderID: " & objOrder.OrderID & " OrderDate: " & objOrder.OrderDate _
                              & " Status: " & objOrder.Status & " CustomerID: " & objOrder.CustomerID)

        Catch ex As Exception
            lstError.Items.Add("add bad order " & ex.Message)
        End Try



    End Sub
    Private Sub Clear()
        lstGood.Items.Clear()
        lstError.Items.Clear()
        lstGoodError.Items.Clear()
        lstErrorGood.Items.Clear()
    End Sub
End Class
