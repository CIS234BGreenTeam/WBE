﻿
'* Screen Name: Orders. 
'* Designer: Ken Baker 4/12/2013. 
'* Purpose:  Allow the customer to create, view, and alter orders and and associated lineitems at a single glance.
'* 
'* Create a new order (two methods): 
'*      1) "Save As New" button: Click 
'*           Allows the user to select and existing order, make changes, and save it as a new order object (generates a new OrderID).
'*      2)  "Add Item" button: Click.  
'*           This will open a baked goods menu form that contains a list of all Items currently produced by WBE.  
'*           When finished selecting the items and quantities, the customer will be returned to this screen where the selected items 
'*            will be displayed in the "Ordered Items" listbox.  
'* 
'* "Recalculate Order" button: Click 
'* Recalculates the order "Total Charge" if the customer adds, deletes, or changes the quantity of of an ordered item.
'* 
'* "Update Item" button: Click
'* 1) recalculates Extended Price to allow the customer to see the result of a change to the quantity of an ordered item.
'* 2) Updates the Ordered Item object shown in the listbox.
'* 
'* "Delete Order" button: Click
'* Deletes selected order. Enabled only if all associated orders items have been removed. 
'* Enabled only if "Order Shipped" = false (see below).
'* 
'* "Delete Item" button: Click
'* Deletes selected "Ordered Item(s). Enabled only if "Order Shipped" = false (see below).
'* 
'* "Place Order" button: Click 
'* 1) If new order: Inserts order into database (new OrderID generated)
'* 2) If existing Order: Updates existing order with new data.
'* 
'* "Quantity Ordered" textbox:
'* This is the only textbox control enabled for customer data manipulation on this form.  All other textboxes are disabled.
'* 
'* "Orders" & "Ordered Items" listboxes:
'* The customer may select an object from the list.  The values are displayed in the associated textbox controls.
'* 
'* "Order Shipped" checkbox(selected = true): 
'* If selected , the order has been shipped.  as a result, no further alterations can be made to the order by the customer.  
'* The order may, however, be selected for use as a template, altered to match current needs, and "Saved as New" to instantiate a new order. 
'* Control of the "Order Shipped" checkbox resides with the driver who will select the box at a designated time interval prior to departure.
'* This control is not enabled in this form. Its presense here serves two functions:
'*      1) Visual reference to the customer that signifies if an existing order can still be modified prior to shipping.
'*      2) A form boolean value that will be used to disable all buttons except "Save As New" if true(checked) and enable all buttons 
'*          except "Save As New" if false(unchecked)., 
'* 
'* Order ID & Item ID textboxes:
'* Always disabled.  The ID numbers are autogenerated by the database when the new record is inserted.

Public Class Orders
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtO_OrderID.Enabled = False
        txtO_OrderDate.Enabled = False
        chkO_OrderShipped.Enabled = False
        txtO_TotalCharge.Enabled = False
        txtOI_ItemName.Enabled = False
        txtOI_UnitPrice.Enabled = False
        txtOI_ExtendPrice.Enabled = False

    End Sub

    Protected Sub btnOI_AddItem_Click(sender As Object, e As EventArgs) Handles btnOI_AddItem.Click
        Response.Redirect("BakedGoodMenu.aspx")
    End Sub
End Class