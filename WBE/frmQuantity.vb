Imports libWBEBR
''' <summary>
''' This form is used by the user to update the desired quantity of the custstock item
''' Also used to update quantity in Order form
''' </summary>
''' <remarks></remarks>
Public Class frmQuantity

    Dim CustStock As CustStock 'Store the CustStock item
    Public Property frmOrderLevels As frmOrderLevels 'Store the form to return the data to
    Public Property frmOrder As frmOrder 'Store order form
    Public Property InvCount As Boolean

    'This is called by frmOrderLevels and frmOrder to set beginning values
    Public Sub SetCustStock(ByVal objCustStock As CustStock)
        CustStock = objCustStock
        lblBakedGood.Text = CustStock.Name
        If InvCount = True Then
            txtQuantity.Text = CustStock.StockQty.ToString
        Else
            txtQuantity.Text = CustStock.DesiredQty.ToString
        End If

    End Sub

    'Update data in calling form when closing this form. Cancel closing
    'if user data is bad
    'todo: Improve error messages when user inputs bad data
    Private Sub frmQuantity_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        epQuantity.Clear()
        Try
            If InvCount = True Then
                CustStock.StockQty = txtQuantity.Text
            Else
                CustStock.DesiredQty = txtQuantity.Text
            End If

            'Call the form that has been set (is not nothing)
            If Not frmOrderLevels Is Nothing Then
                frmOrderLevels.SetQuantityLevel(CustStock)
            ElseIf Not frmOrder Is Nothing Then
                frmOrder.SetQuantityLevel(CustStock)
            End If

        Catch ex As Exception
            epQuantity.SetError(txtQuantity, ex.Message)
            e.Cancel = True
        End Try

    End Sub

End Class