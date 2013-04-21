
'* Screen Name: BakedGoodMenu. 
'* Designer: Ken Baker 4/12/2013. 
'* Purpose:  Allow the Customer to view a list of available (non-discontinued) baked goods for sale.
'*                Allow the customer to select Items and quantities to be added to an order.
'* 
'* BakedGoodMenu: Form_Load
'* Set to modal on load
'* 
'* "AddItems" button: Click
'* If customer input is valid, creates an OrderItem object and associates it with the Order object that issued the call.
'* Closes the form.
'* 
'* "Select an Item to order" listbox:
'* The Customer may select only one object from the list at a time, however, the "Select Item" checkbox may be selected 
'* and "Quantity" may be entered for each item selected in the listbox in turn.
'* The values are displayed in the associated textbox controls.
'* 
'* "Select Item" checkbox(selected = true): 
'* If selected , the the item will be included in the order; enables the "Quantity" Textbox and "Add Item(s)" button.
'* If de-selected, disable same.
'* 
'* "Cancel" button: Click
'* Clears all values entered by the customer and closes the form.
'* 
'* Product ID, Name, Price textboxes:
'* Always disabled.  The values in these controls are passed from the associated baked good object.

Public Class BakedGoodMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtMenu_ProductID.Enabled = False
        txtMenu_ItemName.Enabled = False
        txtMenu_Price.Enabled = False

    End Sub

    Protected Sub btnMenu_AddItem_Click(sender As Object, e As EventArgs) Handles btnMenu_AddItem.Click
        Response.Redirect("Orders.aspx")
    End Sub

    Protected Sub btnMenu_Cancel_Click(sender As Object, e As EventArgs) Handles btnMenu_Cancel.Click
        Response.Redirect("Orders.aspx")
    End Sub
End Class