<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Orders.aspx.vb"
Inherits="WBE_WebApplication.Orders" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">

    <table class="style1">
        <tr>
            <td class="style24" colspan="4">
                <strong>Screen Name:</strong> Orders.
                <br />
                <strong>Designer:</strong> Ken Baker 4/12/2013.
                <br />
                <strong>Purpose:</strong>&nbsp; Allow the customer to create, view, and alter 
                orders and and associated lineitems at a single glance.<br />
                <br />
                <strong>Create a new order (two methods): </strong>
                <br />
&nbsp;&nbsp;&nbsp;&nbsp; <span class="style23">1) <strong>&quot;Save As New&quot; button: Click
                </strong>
                </span>
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Allows the user to select and existing 
                order, make changes, and save it as a new order object (generates a new 
                OrderID).<br />
&nbsp;&nbsp;&nbsp;&nbsp; <span class="style23">2)&nbsp; <strong>&quot;Add Item&quot; button: Click.</strong></span>&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This will open a baked goods menu form 
                that contains a list of all Items currently produced by WBE.&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; When finished selecting the items and 
                quantities, the customer will be returned to this screen where the selected 
                items
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; will be displayed in the &quot;Ordered 
                Items&quot; listbox.&nbsp;
                <br />
&nbsp;<br />
                <strong>&quot;Recalculate Order&quot; button: Click</strong>
                <br />
                Recalculates the order &quot;Total Charge&quot; if the customer adds, deletes, or changes 
                the quantity of of an ordered item.<br />
                <br />
                <strong>&quot;Update Item&quot; button: Click</strong><br />
&nbsp;1) recalculates Extended Price to allow the customer to see the result of a change to the 
                quantity of an ordered item.<br />
&nbsp;2) Updates the Ordered Item object shown in the listbox.<br />
                <br />
                <strong>&quot;Delete Order&quot; button: Click<br />
                </strong>Deletes selected order. Enabled only if all associated orders items 
                have been removed.
                <br />
                Enabled only if &quot;Order Shipped&quot; = false (see below).<br />
                <br />
                <strong>&quot;Delete Item&quot; button: Click<br />
                </strong>Deletes selected &quot;Ordered Item(s). Enabled only if &quot;Order Shipped&quot; = 
                false (see below).<br />
                <br />
                <strong>&quot;Place Order&quot; button: Click </strong>
                <br />
                1) If new order: Inserts order into database (new OrderID generated)<br />
                2) If existing Order: Updates existing order with new data.<br />
                <br />
                <strong>&quot;Quantity Ordered&quot; textbox:<br />
                </strong>This is the only textbox control enabled for customer data manipulation 
                on this form.&nbsp; All other textboxes are disabled.<br />
                <br />
                <strong>&quot;Orders&quot; &amp; &quot;Ordered Items&quot; listboxes:<br />
                </strong>The customer may select an object from the list.&nbsp; The values are 
                displayed in the associated textbox controls.<br />
                <br />
                <strong>&quot;Order Shipped&quot; checkbox(selected = true): </strong>
                <br />
                If selected , the order has been shipped.&nbsp; as a result, no further 
                alterations can be made to the order by the customer.&nbsp;
                <br />
                The order may, however, be selected for use as a template, altered to match 
                current needs, and &quot;Saved as New&quot; to instantiate a new order.
                <br />
                Control of the &quot;Order Shipped&quot; checkbox resides with the driver who will select 
                the box at a designated time interval prior to departure.<br />
                This control is not enabled in this form. Its presense here serves two 
                functions:<br />
&nbsp;&nbsp;&nbsp;&nbsp; 1) Visual reference to the customer that signifies if an existing order 
                can still be modified prior to shipping.<br />
&nbsp;&nbsp;&nbsp;&nbsp; 2) A form boolean value that will be used to disable all buttons except 
                &quot;Save As New&quot; if true(checked) and enable all buttons
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; except &quot;Save As New&quot; if false(unchecked).,
                <br />
                <br />
                <strong>Order ID &amp; Item ID textboxes:</strong><br />
                Always disabled.&nbsp; The ID numbers are autogenerated by the database when the 
                new record is inserted.<br />
            </td>
        </tr>
        <tr>
            <td class="style2" rowspan="6">
                &nbsp;</td>
            <td class="style11">
                Customer Orders</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Orders</td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:ListBox ID="lstCustomerOrders" runat="server" Height="128px" Width="273px">
                </asp:ListBox>
            </td>
            <td>
                <table class="style28">
                    <tr>
                        <td class="style5" valign="middle">
                            Order ID</td>
                        <td colspan="3" valign="middle">
                            <asp:TextBox ID="txtO_OrderID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Order Date</td>
                        <td colspan="3" valign="middle">
                            <asp:TextBox ID="txtO_OrderDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Order Shipped
                        </td>
                        <td colspan="3" valign="middle">
                            <asp:CheckBox ID="chkO_OrderShipped" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Total Charge</td>
                        <td class="style19" valign="middle">
                            <asp:TextBox ID="txtO_TotalCharge" runat="server"></asp:TextBox>
                        </td>
                        <td class="style20">
                            <asp:Button ID="btnRecalcTotal" runat="server" Text="Recalculate Total" 
                                Width="139px" />
                        </td>
                        <td>
                            <asp:Button ID="btnO_DeleteOrder" runat="server" Text="Delete Order" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Ordered Items</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:ListBox ID="lstOrderItems" runat="server" Height="135px" Width="273px">
                </asp:ListBox>
            </td>
            <td>
                <table class="style29">
                    <tr>
                        <td class="style27" valign="middle" width="103">
                            Item ID</td>
                        <td class="style6" valign="middle" colspan="3">
                            <asp:TextBox ID="txtOI_ItemID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style27" valign="middle" width="103">
                            Item Name</td>
                        <td class="style6" valign="middle" colspan="3">
                            <asp:TextBox ID="txtOI_ItemName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style27" valign="middle" width="103">
                            Quantity Ordered</td>
                        <td class="style6" valign="middle" colspan="3">
                            <asp:TextBox ID="txtOI_QuantityOrdered" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style27" valign="middle" width="103">
                            Unit Price</td>
                        <td class="style6" valign="middle" colspan="3">
                            <asp:TextBox ID="txtOI_UnitPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style27" valign="middle" width="103">
                            Extended Price</td>
                        <td class="style20" valign="middle">
                            <asp:TextBox ID="txtOI_ExtendPrice" runat="server"></asp:TextBox>
                        </td>
                        <td class="style25" valign="middle">
                            <asp:Button ID="btnOI_UpdateItem" runat="server" Text="Update Item" 
                                Width="139px" />
                        </td>
                        <td class="style6" valign="middle">
                            <asp:Button ID="btnIO_DeleteItem" runat="server" Text="Delete Item" 
                                Width="109px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="style1">
                    <tr>
                        <td class="style17">
                            <asp:Button ID="btnOI_AddItem" runat="server" Text="Add Item" />
                        </td>
                        <td class="style18">
                            <asp:Button ID="btnOI_SaveAsNew" runat="server" Text="Save As New" />
                        </td>
                        <td class="style9">
                            <asp:Button ID="btnCreateInvoice" runat="server" Text="Place Order" />
                        </td>
                        <td class="style16">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 21px;
        }
        .style3
        {
            width: 273px;
        }
        .style5
        {
            width: 110px;
        }
        .style6
        {
            width: 467px;
        }
        .style9
        {
            width: 153px;
            height: 30px;
        }
        .style11
        {
            width: 273px;
            font-family: Verdana;
            font-size: x-large;
        }
        .style16
        {
            height: 30px;
        }
        .style17
        {
            width: 93px;
            height: 30px;
        }
        .style18
        {
            width: 124px;
            height: 30px;
        }
        .style19
        {
            width: 137px;
        }
        .style20
        {
            width: 159px;
        }
        .style23
        {
            text-decoration: underline;
        }
        .style24
        {
            height: 531px;
        }
        .style25
        {
            width: 246px;
        }
        .style27
        {
            width: 298px;
        }
        .style28
        {
            width: 100%;
            height: 117px;
        }
        .style29
        {
            width: 100%;
            height: 126px;
        }
    </style>
</asp:Content>
