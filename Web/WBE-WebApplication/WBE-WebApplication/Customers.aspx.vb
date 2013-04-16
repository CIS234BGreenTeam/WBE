Public Class Customer
    Inherits System.Web.UI.Page

    'These arrays store the dynamically created inventory items
    Dim txtDesired() As TextBox
    Dim txtActual() As TextBox
    Dim cboItem() As DropDownList
    Dim lblDesired() As Label
    Dim lblActual() As Label
    Dim lblSelected() As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillInventoryItems() 'Creates dynamic list of inventory items for the customer
        FillOrders() 'Creates listbox of customer orders
        lblSelected(1).Visible = True 'Identifies which inventory item is selected

    End Sub
    Private Sub FillInventoryItems()
        'Dynamically create list of inventory items for the customer

        Dim i As Integer
        Dim iNoLines As Integer = 2 'This will be dynamic

        pnlInventory.Controls.Clear()

        ReDim txtDesired(iNoLines)
        ReDim txtActual(iNoLines)
        ReDim cboItem(iNoLines)
        ReDim lblDesired(iNoLines)
        ReDim lblActual(iNoLines)
        ReDim lblSelected(iNoLines)

        For i = 1 To iNoLines
            'Dropdownlist for Baked Good items
            cboItem(i) = New DropDownList
            FillBakedItemList(cboItem(i)) 'This function will fill the drop-down list of available items
            pnlInventory.Controls.Add(cboItem(i))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))

            'Label for "desired" textbox
            lblDesired(i) = New Label
            lblDesired(i).Text = "Desired"
            lblDesired(i).Width = 50
            pnlInventory.Controls.Add(lblDesired(i))

            'Textbox for desired quantity
            txtDesired(i) = New TextBox
            txtDesired(i).Width = 25
            pnlInventory.Controls.Add(txtDesired(i))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))

            'Label for "actual" textbox
            lblActual(i) = New Label
            lblActual(i).Text = "Actual"
            lblActual(i).Width = 40
            pnlInventory.Controls.Add(lblActual(i))

            'Textbox for "actual" quantity
            txtActual(i) = New TextBox
            txtActual(i).Width = 25
            pnlInventory.Controls.Add(txtActual(i))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))

            'Label to show selected item
            lblSelected(i) = New Label
            lblSelected(i).Text = "*"
            lblSelected(i).Visible = False
            pnlInventory.Controls.Add(lblSelected(i))

            'Add next item on next line
            pnlInventory.Controls.Add(New LiteralControl("<br />"))
        Next
    End Sub

    Private Sub FillBakedItemList(ByVal cboItem As DropDownList)
        'This function will add the actual available baked goods
        cboItem.Items.Add("Baked Good 1")
        cboItem.Items.Add("Baked Good 2")
    End Sub

    Private Sub FillOrders()
        'This function will add existing client orders
        lstOrders.Items.Clear()
        lstOrders.Items.Add("Order: 1234, Date: 1/1/2013")
        lstOrders.Items.Add("Order: 1235, Date: 1/2/2013")
    End Sub
End Class