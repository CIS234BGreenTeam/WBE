'Screen Name: Customers

'Designer: Kristina Frye

'Purpose: Allow Customer/WBE personnel to view profile and update 
'customer contact information.

'Also allow customer to maintain stock of goods including desired and
'actual inventory levels. 

'Inactive: When a customer record is set to "inactive", orders will not be
'generated for that customer.

'Baked Good item: The customer can maintain an inventory of baked goods.
'Use the Baked Good drop-down menu to modify the item selection.
'Use the "Desired" and "Actual" inventory textboxes to input the desired
'and current inventory of the item listed. When an order is generated,
'a quantity equal to desired minus actual will be created as a line item
'on the order.

'Add Item: This will add another line to the inventory area. The customer can
'selected from any active baked good offered by WBE (available in the 
'drop-down menu)

'Delete Item: This will delete the selected inventory line item. The selected line
'item is indicated with a "*" to the right of the "Actual" inventory textbox. When
'the user changes the screen focus to one of the line item text boxes or 
'drop-down list, the list will be selected. (The "*" will become visible to denote
'the selection)

'Save Inventory: This saves all changes made to the inventory line items to the
'database.

'Orders: This displays all existing orders (current and past) of the customer.
'By selecting a row in the listbox, the customer can open an order
'to view the details.

'Save Customer: Save any changes to the customer contact information
'to the database.

'Open Order: Open the order selected in the textbox.

'New Customer: Create a new customer record (clear form)

'Note: Customers cannot be deleted from the WBE database. They
'can only be made inactive.

Public Class Customer
    Inherits System.Web.UI.Page

    'These arrays store the dynamically created inventory items
    Dim txtDesired() As TextBox
    Dim txtActual() As TextBox
    Dim cboItem() As DropDownList
    Dim lblDesired() As Label
    Dim lblSelected() As Label

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillInventoryItems() 'Creates dynamic list of inventory items for the customer
        lblSelected(1).Visible = True 'Identifies which inventory item is selected

    End Sub
    Private Sub FillInventoryItems()
        'Dynamically create list of inventory items for the customer

        Dim i As Integer
        Dim iNoLines As Integer = 2 'This will be dynamic

        pnlInventory.Controls.Clear()

        ReDim txtDesired(iNoLines)
        ReDim cboItem(iNoLines)
        ReDim lblDesired(iNoLines)
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

End Class