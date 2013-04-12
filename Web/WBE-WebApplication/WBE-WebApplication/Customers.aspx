<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Customers.aspx.vb" Inherits="WBE_WebApplication.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        height: 26px;
    }
    .style3
    {
        width: 63px;
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
        width: 63px;
        height: 2px;
    }
    .style23
    {
        width: 74px;
        height: 2px;
    }
    .style25
    {
        height: 2px;
    }
    .style26
    {
        width: 63px;
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
        .style66
        {
            width: 25px;
        }
        .style67
        {
            width: 76px;
        }
        .style68
        {
            width: 15px;
        }
        .panelcontrols
        {  
            font-size:small;
            
        }
 
        .style75
        {
            font-size: large;
        }
 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    <tr>
        <td class="style3">
        </td>
        <td class="style62" colspan="7">
                Customer Information
        </td>
        <td class="style4">
        </td>
    </tr>
    <tr>
        <td class="style2">
            Name</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtName" runat="server" Width="160px" Height="18px"></asp:TextBox>
        </td>
        <td class="style34">
            &nbsp;</td>
        <td class="style58">
            Phone</td>
        <td class="style2">
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </td>
        <td class="style54" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style26">
        </td>
        <td class="style27" colspan="3">
        </td>
        <td class="style35">
        </td>
        <td class="style59">
        </td>
        <td>
        </td>
        <td class="style55" colspan="2">
        </td>
    </tr>
    <tr>
        <td class="style2">
            Address 1</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtAddress1" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
            &nbsp;</td>
        <td class="style58">
            Fax</td>
        <td class="style2">
            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
        </td>
        <td class="style54" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style26">
        </td>
        <td class="style27" colspan="3">
        </td>
        <td class="style35">
        </td>
        <td class="style59">
        </td>
        <td>
        </td>
        <td class="style55" colspan="2">
        </td>
    </tr>
    <tr>
        <td class="style2">
            Address 2</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtAddress2" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
            &nbsp;</td>
        <td class="style58">
            Email</td>
        <td class="style2">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>
        <td class="style54" colspan="2">
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
        <td class="style25">
        </td>
        <td class="style56" colspan="2">
        </td>
    </tr>
    <tr>
        <td class="style2">
            City</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtCity" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
        </td>
        <td class="style58">
        </td>
        <td class="style2">
        </td>
        <td class="style54" colspan="2">
        </td>
    </tr>
    <tr>
        <td class="style26">
        </td>
        <td class="style27" colspan="3">
        </td>
        <td class="style35">
        </td>
        <td class="style59">
        </td>
        <td>
        </td>
        <td class="style55" colspan="2">
        </td>
    </tr>
    <tr>
        <td class="style2">
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
                <asp:Button ID="btnSaveItem" runat="server" Text="Save Inventory" />
            </td>
            <td class="style66">
                &nbsp;</td>
            <td class="style67">
                <asp:Button ID="btnAdd" runat="server" Text="Add Item" />
            </td>
            <td class="style68">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnDeleteItem" runat="server" Text="Delete Item" />
            </td>
        </tr>
        </table>
        <hr />
        <span class="style75">Orders<br />
    <asp:ListBox ID="lstOrders" runat="server" Width="431px"></asp:ListBox>
    </span>
</asp:Content>
