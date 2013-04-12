Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim txtDesired() As TextBox
    Dim txtActual() As TextBox
    Dim cboItem() As DropDownList
    Dim lblDesired() As Label
    Dim lblActual() As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        Dim iNoLines As Integer = 2 'This will be dynamic

        phInventory.Controls.Clear()

        ReDim txtDesired(iNoLines)
        ReDim txtActual(iNoLines)
        ReDim cboItem(iNoLines)
        ReDim lblDesired(iNoLines)
        ReDim lblActual(iNoLines)

        For i = 1 To iNoLines
            cboItem(i) = New DropDownList
            FillBakedItemList(cboItem(i))
            phInventory.Controls.Add(cboItem(i))
            'call function to fill in items in dropdownlist 

            lblDesired(i) = New Label
            lblDesired(i).Text = "Desired"
            phInventory.Controls.Add(lblDesired(i))

            txtDesired(i) = New TextBox
            phInventory.Controls.Add(txtDesired(i))

            lblActual(i) = New Label
            lblActual(i).Text = "Actual"
            phInventory.Controls.Add(lblActual(i))

            txtActual(i) = New TextBox
            phInventory.Controls.Add(txtActual(i))

            phInventory.Controls.Add(New LiteralControl("<br />"))

        Next
    End Sub

    Private Sub FillBakedItemList(ByVal cboItem As DropDownList)
        'This function will add the actual available baked goods
        cboItem.Items.Add("Baked Good 1")
        cboItem.Items.Add("Baked Good 2")
    End Sub

End Class