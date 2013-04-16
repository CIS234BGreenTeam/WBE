<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Customers.aspx.vb" Inherits="WBE_WebApplication.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style3
    {
        height: 58px;
    }
    .style4
    {
        height: 58px;
    }
    .style7
    {
        width: 74px;
        height: 26px;
    }
    .style9
    {
        height: 26px;
    }
    .style10
    {
        height: 26px;
    }
    .style12
    {
            width: 25px;
            height: 26px;
            text-align: right;
        }
    .style22
    {
        width: 81px;
        height: 2px;
    }
    .style23
    {
        width: 74px;
        height: 2px;
    }
    .style27
    {
        width: 74px;
    }
        .style33
        {
            width: 26px;
            height: 26px;
        }
        .style34
        {
            height: 26px;
            width: 13px;
        }
        .style35
        {
            width: 13px;
        }
        .style36
        {
            height: 2px;
            width: 13px;
        }
        .style54
        {
            height: 26px;
        }
        .style55
        {
        }
        .style56
        {
            height: 2px;
            }
        .style57
        {
            height: 26px;
            width: 90px;
        }
        .style58
        {
            height: 26px;
            width: 3px;
        }
        .style59
        {
            width: 3px;
        }
        .style60
        {
            height: 2px;
            width: 3px;
        }
        .style62
        {
            font-size: x-large;
            font-family: Verdana;
        }
        .style64
        {
            width: 94px;
        }
        .style67
        {
            width: 76px;
        }
        .style68
        {
            width: 5px;
        }
        .panelcontrols
        {  
            font-size:small;
            margin-right:10em;
        }
 
        .style75
        {
            font-size: large;
        }
 
        .style76
        {
            height: 26px;
            width: 65px;
        }
        .style77
        {
            width: 65px;
        }
        .style78
        {
            height: 2px;
            width: 65px;
        }
 
        .style79
        {
            width: 108px;
        }
        .style81
        {
            width: 114px;
        }
        .style82
        {
            height: 26px;
            width: 268435456px;
        }
        .style83
        {
            width: 268435456px;
        }
        .style84
        {
            height: 2px;
            width: 268435456px;
        }
        .style85
        {
            height: 4px;
        }
        .style86
        {
            width: 74px;
            height: 4px;
        }
        .style87
        {
            height: 4px;
            width: 13px;
        }
        .style88
        {
            height: 4px;
            width: 3px;
        }
        .style89
        {
            height: 4px;
            width: 65px;
        }
        .style90
        {
            height: 4px;
            width: 268435456px;
        }
        .style91
        {
            width: 81px;
            height: 58px;
        }
        .style92
        {
            height: 4px;
            width: 81px;
        }
        .style94
        {
            width: 81px;
        }
        .style95
        {
            height: 26px;
            width: 81px;
        }
        .style97
        {
            width: 4px;
        }
        .style98
        {
            width: 108px;
            height: 30px;
        }
        .style99
        {
            width: 114px;
            height: 30px;
        }
        .style100
        {
            height: 30px;
        }
 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    <tr>
        <td class="style3" colspan="9">
            <strong>Screen Name</strong>: Customers<br />
            <br />
            <strong>Designer</strong>: Kristina Frye<br />
            <br />
            <strong>Purpose</strong>: Allow Customer/WBE personnel to view profile and 
            update
            <br />
            customer contact information.<br />
            <br />
            Also allow customer to maintain stock of goods including desired and<br />
            actual inventory levels.
            <br />
            <br />
            Also displays order history for the customer. The
            <br />
            customer will be selected from a list of customers in the default screen.<br />
            <br />
            <strong>Inactive</strong>: When a customer record is set to &quot;inactive&quot;, orders 
            will not be<br />
            generated for that customer.<br />
            <br />
            <strong>Baked Good item</strong>: The customer can maintain an inventory of 
            baked goods.<br />
            Use the Baked Good drop-down menu to modify the item selection.<br />
            Use the &quot;Desired&quot; and &quot;Actual&quot; inventory textboxes to input the desired<br />
            and current inventory of the item listed. When an order is generated,<br />
            a quantity equal to desired minus actual will be created as a line item<br />
            on the order.<br />
            <br />
            <strong>Add Item</strong>: This will add another line to the inventory area. The 
            customer can<br />
            selected from any active baked good offered by WBE (available in the
            <br />
            drop-down menu)<br />
            <br />
            <strong>Delete Item</strong>: This will delete the selected inventory line item. 
            The selected line<br />
            item is indicated with a &quot;*&quot; to the right of the &quot;Actual&quot; inventory textbox. 
            When<br />
            the user changes the screen focus to one of the line item text boxes or
            <br />
            drop-down list, the list will be selected. (The &quot;*&quot; will become visible to 
            denote<br />
            the selection)<br />
            <br />
            <strong>Save Inventory</strong>: This saves all changes made to the inventory 
            line items to the<br />
            database.<br />
            <br />
            <strong>Orders</strong>: This displays all existing orders (current and past) of 
            the customer.<br />
            By selecting a row in the listbox, the customer can open an order<br />
            to view the details.<br />
            <br />
            <strong>Save Customer</strong>: Save any changes to the customer contact 
            information<br />
            to the database.<br />
            <br />
            <strong>Open Order</strong>: Open the order selected in the textbox.<br />
            <br />
            <strong>New Customer</strong>: Create a new customer record (clear form)<br />
            <br />
            Note: Customers cannot be deleted from the WBE database. They<br />
            can only be made inactive.<br />
        </td>
    </tr>
    <tr>
        <td class="style91">
        </td>
        <td class="style62" colspan="7">
                Customer Information
        </td>
        <td class="style4">
        </td>
    </tr>
    <tr>
        <td class="style92">
            Name</td>
        <td class="style86" colspan="3">
            <asp:TextBox ID="txtName" runat="server" Width="160px" Height="18px"></asp:TextBox>
        </td>
        <td class="style87">
            </td>
        <td class="style88">
            Phone</td>
        <td class="style89">
            <asp:TextBox ID="txtPhone" runat="server" Width="105px"></asp:TextBox>
        </td>
        <td class="style90">
            &nbsp;</td>
        <td class="style85">
            </td>
    </tr>
    <tr>
        <td class="style94">
        </td>
        <td class="style27" colspan="3">
        </td>
        <td class="style35">
        </td>
        <td class="style59">
        </td>
        <td class="style77">
        </td>
        <td class="style83">
        </td>
        <td class="style55">
        </td>
    </tr>
    <tr>
        <td class="style95">
            Address1</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtAddress1" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
            &nbsp;</td>
        <td class="style58">
            Fax</td>
        <td class="style76">
            <asp:TextBox ID="txtFax" runat="server" Width="105px"></asp:TextBox>
        </td>
        <td class="style82">
            &nbsp;</td>
        <td class="style54">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style94">
        </td>
        <td class="style27" colspan="3">
        </td>
        <td class="style35">
        </td>
        <td class="style59">
        </td>
        <td class="style77">
        </td>
        <td class="style83">
        </td>
        <td class="style55">
        </td>
    </tr>
    <tr>
        <td class="style95">
            Address2</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtAddress2" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
            &nbsp;</td>
        <td class="style58">
            Email</td>
        <td class="style76">
            <asp:TextBox ID="txtEmail" runat="server" Width="106px"></asp:TextBox>
        </td>
        <td class="style82">
            &nbsp;</td>
        <td class="style54">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style22">
        </td>
        <td class="style23" colspan="3">
        </td>
        <td class="style36">
        </td>
        <td class="style60">
        </td>
        <td class="style78">
        </td>
        <td class="style84">
        </td>
        <td class="style56">
        </td>
    </tr>
    <tr>
        <td class="style95">
            City</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtCity" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
        </td>
        <td class="style58">
        </td>
        <td class="style76">
        </td>
        <td class="style82">
        </td>
        <td class="style54">
        </td>
    </tr>
    <tr>
        <td class="style94">
        </td>
        <td class="style27" colspan="3">
        </td>
        <td class="style35">
        </td>
        <td class="style59">
        </td>
        <td class="style77">
        </td>
        <td class="style83">
        </td>
        <td class="style55">
        </td>
    </tr>
    <tr>
        <td class="style95">
            State</td>
        <td class="style33">
            <asp:TextBox ID="txtState" runat="server" Width="35px" Height="18px"></asp:TextBox>
        </td>
        <td class="style12">
            Zip </td>
        <td class="style57">
            <asp:TextBox ID="txtZip" runat="server" Width="87px" Height="18px" 
                style="text-align: left"></asp:TextBox>
        </td>
        <td class="style34">
            &nbsp;</td>
        <td class="style10" colspan="3">
            <asp:CheckBox ID="chkInactive" runat="server" Text="Inactive" />
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    </table>
    <hr />
    <span class="style75">Inventory<br />
    <asp:Panel ID="pnlInventory" runat="server" cssclass="panelcontrols">
    </asp:Panel>
    </span>&nbsp;<table class="style1">
        <tr>
            <td class="style64">
                <asp:Button ID="btnSaveItem" runat="server" Text="Save Inventory" Height="26px" 
                    Width="102px" />
            </td>
            <td class="style97">
                &nbsp;</td>
            <td class="style67">
                <asp:Button ID="btnAdd" runat="server" Text="Add Item" height="26px" 
                    width="102px" />
            </td>
            <td class="style68">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnDeleteItem" runat="server" Text="Delete Item" height="26px" 
                    width="102px" />
            </td>
        </tr>
        </table>
        <hr />
        <span class="style75">Orders<br />
    <asp:ListBox ID="lstOrders" runat="server" Width="431px"></asp:ListBox>
    <br />
    </span>
    <table class="style1">
        <tr>
            <td class="style98">
                <asp:Button ID="btnSaveCustomer" runat="server" Height="26px" 
                    Text="Save Customer" Width="103px" />
            </td>
            <td class="style99">
                <asp:Button ID="btnOpenOrder" runat="server" height="26px" Text="Open Order" 
                    width="103px" />
            </td>
            <td class="style99">
                <asp:Button ID="btnNewCustomer" runat="server" height="26px" 
                    Text="New Customer" width="103px" />
            </td>
            <td class="style100">
            </td>
        </tr>
        <tr>
            <td class="style79">
                &nbsp;</td>
            <td class="style81">
                &nbsp;</td>
            <td class="style81">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
