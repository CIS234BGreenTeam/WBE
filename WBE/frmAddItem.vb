Imports libWBEData
Imports libWBEBR

Public Class frmAddItem

    Private _colBakedGoods As New colBakedGoods
    Public frmOrder As frmOrder
    Private bCancel As Boolean = False

    Private Sub frmAddItem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim OrderItem As New OrderItem
        Dim BakedGood As BakedGood

        If bCancel = False Then
            epOrderItem.Clear()
            Try
                OrderItem.Quantity = Convert.ToInt32(txtQuantity.Text)
                BakedGood = DirectCast(cboBakedGood.SelectedItem, BakedGood)
                OrderItem.BakedGoodID = BakedGood.BakedGoodID
                OrderItem.Name = BakedGood.Name
                OrderItem.UnitPrice = BakedGood.UnitPrice
                frmOrder.AddNewItem(OrderItem)

            Catch ex As Exception
                epOrderItem.SetError(txtQuantity, ex.Message)
                e.Cancel = True
            End Try
        End If
    End Sub

    Public Sub SetOrderItem(ByVal colOrderItems As colOrderItems)
        Dim sError As String = ""
        BakedGoodDB.SetupAdapter()

        If _colBakedGoods.Fill(sError) = False Then
            MessageBox.Show(sError)
        End If

        'Remove all baked goods from list that already have a line item
        If colOrderItems.Count > 0 Then
            For i As Integer = _colBakedGoods.Count - 1 To 0 Step -1
                For j As Integer = colOrderItems.Count - 1 To 0 Step -1
                    If colOrderItems(j).BakedGoodID = _colBakedGoods.Item(i).BakedGoodID Then
                        _colBakedGoods.RemoveAt(i)
                    End If
                Next
            Next
        End If

        For Each BakedGood As BakedGood In _colBakedGoods
            cboBakedGood.Items.Add(BakedGood)
        Next

        cboBakedGood.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        bCancel = True
        Me.Close()
    End Sub
End Class