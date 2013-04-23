Public Class Inventory
    Inherits System.Web.UI.Page
    'These arrays store the dynamically created inventory items

    Dim txtCount() As TextBox
    Dim lblItem() As Label
    Dim cboItem() As DropDownList
    Dim lblCount() As Label
    Dim lblSelected() As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillInventoryItems() 'Creates dynamic list of inventory items for the customer
    End Sub

    Private Sub FillInventoryItems()
        'Dynamically create list of inventory items for the customer

        Dim i As Integer
        Dim iNoLines As Integer
        Dim BakedGoodList As List(Of String)

        BakedGoodList = GetBakedGoodList()
        iNoLines = BakedGoodList.Count

        pnlInventory.Controls.Clear()

        ReDim lblItem(iNoLines)
        ReDim txtCount(iNoLines)
        ReDim cboItem(iNoLines)
        ReDim lblCount(iNoLines)
        ReDim lblSelected(iNoLines)

        For i = 0 To iNoLines - 1
            'Dropdownlist for Baked Good items
            lblItem(i) = New Label
            lblItem(i).Text = BakedGoodList(i)
            pnlInventory.Controls.Add(lblItem(i))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))
            pnlInventory.Controls.Add(New LiteralControl("&nbsp;"))

            'Label for "count" textbox
            lblCount(i) = New Label
            lblCount(i).Text = "Count"
            lblCount(i).Width = 40
            pnlInventory.Controls.Add(lblCount(i))

            'Textbox for "count" quantity
            txtCount(i) = New TextBox
            txtCount(i).Width = 25
            pnlInventory.Controls.Add(txtCount(i))
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

    Private Function GetBakedGoodList() As List(Of String)
        'This function will add the actual available baked goods
        Dim List As New List(Of String)
        List.Add("Baked Good 1")
        List.Add("Baked Good 2")
        Return List
    End Function
End Class