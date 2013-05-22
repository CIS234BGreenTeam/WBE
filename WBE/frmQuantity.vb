Imports libWBEBR
''' <summary>
''' This form is used by the user to update the desired quantity of the custstock item
''' </summary>
''' <remarks></remarks>
Public Class frmQuantity

    Dim CustStock As CustStock 'Store the CustStock item
    Public Property frmOrderLevels As frmOrderLevels 'Store the form to return the data to
    Public Property frmOrder As frmOrder

    'This is called by frmOrderLevels to set beginning values
    Public Sub SetCustStock(ByVal objCustStock As CustStock)
        CustStock = objCustStock
        lblBakedGood.Text = CustStock.Name
        txtQuantity.Text = CustStock.DesiredQty.ToString
    End Sub

    'Update CustStock in frmOrderLevels when closing this form. Cancel closing
    'if user data is bad
    'todo: Improve error messages when user inputs bad data
    Private Sub frmQuantity_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        epQuantity.Clear()
        Try
            CustStock.DesiredQty = txtQuantity.Text
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