<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Inventory.aspx.vb" Inherits="WBE_WebApplication.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 96px;
        }
        .style76
        {
            font-size: x-large;
            width: 300px;
        }
        .style77
        {
            width: 300px;
        }
        .style78
        {
            width: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style76">
                Customer Inventory</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style77">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Selection</td>
            <td class="style77">
                <asp:DropDownList ID="ddlCustomer" runat="server" Width="182px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style77">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="pnlInventory" runat="server">
    </asp:Panel>
    <table class="style1">
        <tr>
            <td class="style78">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style78">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="54px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
