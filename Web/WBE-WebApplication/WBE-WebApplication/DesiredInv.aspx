<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DesiredInv.aspx.vb" Inherits="WBE_WebApplication.DesiredInv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style91
        {
            width: 81px;
            height: 58px;
        }
        .style62
        {
            font-size: x-large;
            font-family: Verdana;
        }
        .style1
    {
        width: 100%;
    }
        .newStyle1
        {
            font-size: small;
        }
        .auto-style1
        {
            width: 55px;
        }
        .auto-style2
        {
            width: 58px;
            height: 57px;
        }
        .auto-style3
        {
            font-size: x-large;
            font-family: Verdana;
            height: 57px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    <tr>
        <td class="auto-style2">
        </td>
        <td class="auto-style3">
                Customer Desired Inventory
        </td>
    </tr>
    </table>
    &nbsp;<table class="style1">
        <tr>
            <td class="auto-style1">Selection</td>
            <td>
                <asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="True" Width="293px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlInventory" runat="server">
    </asp:Panel>
    &nbsp;<asp:Label ID="lblError" runat="server" Width="600px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" />
    </asp:Content>
