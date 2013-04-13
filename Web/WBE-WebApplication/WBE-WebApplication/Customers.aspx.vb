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

        pnlInventory.Controls.Clear()

        ReDim txtDesired(iNoLines)
        ReDim txtActual(iNoLines)
        ReDim cboItem(iNoLines)
        ReDim lblDesired(iNoLines)
        ReDim lblActual(iNoLines)

        For i = 1 To iNoLines
            cboItem(i) = New DropDownList
            FillBakedItemList(cboItem(i))
            pnlInventory.Controls.Add(cboItem(i))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            'call function to fill in items in dropdownlist 

            lblDesired(i) = New Label
            lblDesired(i).Text = "Desired"
            lblDesired(i).Width = 50
            pnlInventory.Controls.Add(lblDesired(i))

            txtDesired(i) = New TextBox
            txtDesired(i).Width = 25
            pnlInventory.Controls.Add(txtDesired(i))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))


            lblActual(i) = New Label
            lblActual(i).Text = "Actual"
            lblActual(i).Width = 40
            pnlInventory.Controls.Add(lblActual(i))

            txtActual(i) = New TextBox
            txtActual(i).Width = 25
            pnlInventory.Controls.Add(txtActual(i))

            pnlInventory.Controls.Add(New LiteralControl("<br />"))

            FillOrders()

        Next
    End Sub

    Private Sub FillBakedItemList(ByVal cboItem As DropDownList)
        'This function will add the actual available baked goods
        cboItem.Items.Add("Baked Good 1")
        cboItem.Items.Add("Baked Good 2")
    End Sub

    Private Sub FillOrders()
        'This function will add existing client orders
        lstCustomerOrders.Items.Clear()
        lstCustomerOrders.Items.Add("Order: 1234, Date: 1/1/2013")
        lstCustomerOrders.Items.Add("Order: 1235, Date: 1/2/2013")
    End Sub
End Class