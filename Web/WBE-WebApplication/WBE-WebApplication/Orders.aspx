<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Orders.aspx.vb"
Inherits="WBE_WebApplication.Orders" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">

    <table class="style1">
        <tr>
            <td class="style30" colspan="4">
            </td>
        </tr>
        <tr>
            <td class="style2" rowspan="5">
                &nbsp;</td>
            <td class="style11">
                Customer Order</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style34">
                <table class="style28">
                    <tr>
                        <td class="style5" valign="middle">
                            Order ID</td>
                        <td valign="middle">
                            <asp:TextBox ID="txtO_OrderID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Order Date</td>
                        <td valign="middle">
                            <asp:TextBox ID="txtO_OrderDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Order Baked</td>
                        <td valign="middle">
                            <asp:CheckBox ID="chkO_OrderShipped" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Total Charge</td>
                        <td class="style19" valign="middle">
                            <asp:TextBox ID="txtO_TotalCharge" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style35">
            </td>
            <td class="style35">
                </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;<span class="style36">Items</span></td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:ListBox ID="lstOrderItems" runat="server" Height="105px" Width="273px">
                </asp:ListBox>
            </td>
            <td>
                <table class="style29">
                    <tr>
                        <td class="style33" valign="middle">
                            Item Name</td>
                        <td class="style32" valign="middle" colspan="3">
                            <asp:TextBox ID="txtOI_ItemName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style33" valign="middle">
                            Quantity Ordered</td>
                        <td class="style32" valign="middle" colspan="3">
                            <asp:TextBox ID="txtOI_QuantityOrdered" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style33" valign="middle">
                            Unit Price</td>
                        <td class="style32" valign="middle" colspan="3">
                            <asp:TextBox ID="txtOI_UnitPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style33" valign="middle">
                            Extended Price</td>
                        <td class="style20" valign="middle">
                            <asp:TextBox ID="txtOI_ExtendPrice" runat="server"></asp:TextBox>
                        </td>
                        <td class="style25" valign="middle">
                            &nbsp;</td>
                        <td class="style6" valign="middle">
                            &nbsp;</td>
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
                            <asp:Button ID="btnOI_UpdateItem" runat="server" Text="Update Item" 
                                Width="103px" />
                        </td>
                        <td class="style9">
                            <asp:Button ID="btnIO_DeleteItem" runat="server" Text="Delete Item" 
                                Width="97px" />
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
            width: 89px;
            height: 30px;
        }
        .style18
        {
            width: 110px;
            height: 30px;
        }
        .style19
        {
        }
        .style20
        {
            width: 196px;
        }
        .style25
        {
            width: 246px;
        }
        .style28
        {
            width: 100%;
            height: 117px;
        }
        .style29
        {
            width: 100%;
            height: 114px;
        }
        .style30
        {
            height: 1px;
        }
        .style32
        {
            width: 510px;
        }
        .style33
        {
            width: 168px;
        }
        .style34
        {
            width: 273px;
            height: 102px;
        }
        .style35
        {
            height: 102px;
        }
        .style36
        {
            font-family: Verdana;
            font-size: large;
        }
    </style>
</asp:Content>
