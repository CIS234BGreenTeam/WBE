<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BakedGoodMenu.aspx.vb"
Inherits="WBE_WebApplication.BakedGoodMenu" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table class="style1">
        <tr>
            <td class="style50" colspan="3">
                <strong>Screen Name:</strong> BakedGoodMenu.
                <br />
                <strong>Designer:</strong> Ken Baker 4/12/2013.
                <br />
                <strong>Purpose:</strong>&nbsp; Allow the Customer to view a list of available 
                (non-discontinued) baked goods for sale.<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Allow the 
                customer to select Items and quantities to be added to an order.<br />
                <br />
                <strong>BakedGoodMenu: Form_Load</strong><br />
                Set to modal on load<br />
                <br />
                <strong>&quot;AddItems&quot; button: Click</strong><br />
                If customer input is valid, creates an OrderItem object and associates it with 
                the Order object that issued the call.<br />
                Closes the form.<br />
                <br />
                <strong>&quot;Select an Item to order&quot; listbox:<br />
                </strong>The Customer may select only one object from the list at a time, 
                however, the &quot;Select Item&quot; checkbox may be selected
                <br />
                and &quot;Quantity&quot; may be entered for each item selected in the listbox in turn.<br />
                The values are 
                displayed in the associated textbox controls.<br />
                <br />
                <strong>&quot;Select Item&quot; checkbox(selected = true): </strong>
                <br />
                If selected , the the item will be included in the order; enables the &quot;Quantity&quot; 
                Textbox and &quot;Add Item(s)&quot; button.<br />
                If de-selected, disable same.<br />
                <br />
                <strong>&quot;Cancel&quot; button: Click<br />
                </strong>Clears all values entered by the customer and closes the form.<br />
                <br />
                <strong>Product ID, Name, Price textboxes:</strong><br />
                Always disabled.&nbsp; The values in these controls are passed from the associated 
                baked good object.<br />
            </td>
        </tr>
        <tr>
            <td class="style2" rowspan="3">
            </td>
            <td class="style6" colspan="2">
                Customer
                Baked Good Menu</td>
        </tr>
        <tr>
            <td class="style11">
                Select an Item to order</td>
            <td class="style25" valign="middle">
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:ListBox ID="lstMenu_Items" runat="server" Height="136px" Width="277px">
                </asp:ListBox>
            </td>
            <td class="style20">
                <table class="style46">
                    <tr>
                        <td class="style44">
                            Product ID&nbsp;&nbsp;&nbsp;</td>
                        <td class="style45">
                            <asp:TextBox ID="txtMenu_ProductID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style51">
                            Name 
                        </td>
                        <td class="style52">
                            <asp:TextBox ID="txtMenu_ItemName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            Price
                        </td>
                        <td>
                            <asp:TextBox ID="txtMenu_Price" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            Select Item</td>
                        <td>
                            <asp:CheckBox ID="chkMenu_ItemSelect" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            Quantity</td>
                        <td>
                            <asp:TextBox ID="txtMenu_Quantity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
    <table class="style1">
        <tr>
            <td class="style47">
                &nbsp;</td>
            <td class="style48">
                <asp:Button ID="btnMenu_AddItem" runat="server" Text="Add Item" />
                        </td>
            <td class="style49">
                <asp:Button ID="btnMenu_Cancel" runat="server" Text="Cancel" />
                        </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-family: Verdana;
            font-size: x-large;
            width: 31px;
            }
        .style6
        {
            font-family: Verdana;
            font-size: x-large;
            height: 33px;
            text-align: left;
        }
        .style9
        {
            width: 218px;
            height: 149px;
        }
        .style11
        {
            font-family: Verdana;
            font-size: small;
            width: 218px;
            height: 6px;
        }
        .style15
        {
            width: 88px;
        }
        .style20
        {
            width: 506px;
            height: 149px;
        }
        .style25
        {
            width: 506px;
            height: 6px;
        }
        .style44
        {
            width: 88px;
            height: 20px;
        }
        .style45
        {
            height: 20px;
        }
        .style46
        {
            width: 100%;
            height: 129px;
        }
        .style47
        {
            width: 36px;
        }
        .style48
        {
            width: 138px;
        }
        .style49
        {
            width: 162px;
            text-align: left;
        }
        .style50
        {
            font-family: Verdana;
            font-size: small;
            height: 33px;
        }
        .style51
        {
            width: 88px;
            height: 26px;
        }
        .style52
        {
            height: 26px;
        }
        </style>
</asp:Content>





