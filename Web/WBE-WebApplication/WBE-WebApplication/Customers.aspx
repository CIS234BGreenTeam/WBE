<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Customers.aspx.vb" Inherits="WBE_WebApplication.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 63px;
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
    .style5
    {
        height: 58px;
        font-family: "Segoe UI";
        font-size: xx-large;
    }
    .style6
    {
        text-align: left;
        width: 395px;
        font-size: medium;
        font-family: "Segoe UI";
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
    .style11
    {
        height: 26px;
    }
    .style12
    {
        width: 47px;
        height: 26px;
    }
    .style13
    {
        width: 17px;
        height: 26px;
    }
    .style14
    {
        width: 63px;
        height: 10px;
    }
    .style15
    {
        width: 74px;
        height: 10px;
    }
    .style16
    {
        width: 17px;
        height: 10px;
    }
    .style17
    {
        height: 10px;
    }
    .style18
    {
        width: 63px;
        height: 11px;
    }
    .style19
    {
        width: 74px;
        height: 11px;
    }
    .style20
    {
        width: 17px;
        height: 11px;
    }
    .style21
    {
        height: 11px;
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
    .style24
    {
        width: 17px;
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
    .style28
    {
        width: 17px;
    }
    .style30
    {
        height: 26px;
        width: 45px;
    }
    .style31
    {
        text-align: left;
        width: 395px;
        font-size: medium;
        font-family: "Segoe UI";
    }
        .style32
        {
            width: 87px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    <tr>
        <td class="style3">
        </td>
        <td class="style5" colspan="7">
            <p class="style6">
                Customer Information</p>
        </td>
        <td class="style4">
        </td>
    </tr>
    <tr>
        <td class="style2">
            Name</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtName" runat="server" Width="171px"></asp:TextBox>
        </td>
        <td class="style13">
            &nbsp;</td>
        <td class="style9" colspan="2">
            Phone</td>
        <td class="style9">
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </td>
        <td class="style9">
        </td>
    </tr>
    <tr>
        <td class="style14">
        </td>
        <td class="style15" colspan="3">
        </td>
        <td class="style16">
        </td>
        <td class="style17" colspan="2">
        </td>
        <td class="style17">
        </td>
        <td class="style17">
        </td>
    </tr>
    <tr>
        <td class="style2">
            Address 1</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtAddress1" runat="server" Width="168px"></asp:TextBox>
        </td>
        <td class="style13">
            &nbsp;</td>
        <td class="style9" colspan="2">
            Fax</td>
        <td class="style9">
            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style18">
        </td>
        <td class="style19" colspan="3">
        </td>
        <td class="style20">
        </td>
        <td class="style21" colspan="2">
        </td>
        <td class="style21">
        </td>
        <td class="style21">
        </td>
    </tr>
    <tr>
        <td class="style2">
            Address 2</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtAddress2" runat="server" Width="167px"></asp:TextBox>
        </td>
        <td class="style13">
            &nbsp;</td>
        <td class="style9" colspan="2">
            Email</td>
        <td class="style9">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style22">
        </td>
        <td class="style23" colspan="3">
        </td>
        <td class="style24">
        </td>
        <td class="style25" colspan="2">
        </td>
        <td class="style25">
        </td>
        <td class="style25">
        </td>
    </tr>
    <tr>
        <td class="style2">
            City</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtCity" runat="server" Width="166px"></asp:TextBox>
        </td>
        <td class="style13">
        </td>
        <td class="style9" colspan="2">
        </td>
        <td class="style9">
        </td>
        <td class="style9">
        </td>
    </tr>
    <tr>
        <td class="style26">
        </td>
        <td class="style27" colspan="3">
        </td>
        <td class="style28">
        </td>
        <td colspan="2">
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td class="style2">
            State</td>
        <td class="style30">
            <asp:TextBox ID="txtState" runat="server" Width="35px"></asp:TextBox>
        </td>
        <td class="style12">
            Zip</td>
        <td class="style32">
            <asp:TextBox ID="txtZip" runat="server" Width="59px"></asp:TextBox>
        </td>
        <td class="style13">
            &nbsp;</td>
        <td class="style10" colspan="3">
            <asp:CheckBox ID="chkInactive" runat="server" Text="Inactive" />
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style30">
            &nbsp;</td>
        <td class="style12">
            &nbsp;</td>
        <td class="style32">
            &nbsp;</td>
        <td class="style13">
            &nbsp;</td>
        <td class="style10" colspan="3">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style11" colspan="7">
            <p class="style31">
                Current Inventory</p>
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style11" colspan="7">
            <asp:PlaceHolder ID="phInventory" runat="server"></asp:PlaceHolder>
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style11" colspan="7">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style11" colspan="3">
            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" />
        </td>
        <td class="style11" colspan="2">
            <asp:Button ID="btnDelete" runat="server" Text="Delete Item" />
        </td>
        <td class="style11" colspan="2">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style11" colspan="7">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style11" colspan="7">
            <p class="style6">
                Orders</p>
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style11" colspan="7">
            <asp:ListBox ID="lstOrders" runat="server" Width="501px"></asp:ListBox>
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
