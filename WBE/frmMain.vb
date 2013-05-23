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
End Class