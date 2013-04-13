<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Orders.aspx.vb"
Inherits="WBE_WebApplication.WebForm1" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style11">
                Customer Orders</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td class="style3">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td class="style3">
                Orders</td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:ListBox ID="lstCustomerOrders" runat="server" Height="178px" Width="273px">
                </asp:ListBox>
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style5">
                            Order ID</td>
                        <td>
                            <asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Order Date</td>
                        <td>
                            <asp:TextBox ID="txtO_Date" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Transaction
                        </td>
                        <td rowspan="2">
                            <asp:CheckBox ID="chkO_TransactionComplete" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Complete</td>
                    </tr>
                    <tr>
                        <td class="style5">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5">
                            Total Charge</td>
                        <td>
                            <asp:TextBox ID="txtO_TotalCharge" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                Ordered Items</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:ListBox ID="lstOrderItems" runat="server" Height="210px" Width="277px">
                </asp:ListBox>
            </td>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style5" valign="middle">
                            Item Number</td>
                        <td class="style6" valign="middle">
                            <asp:TextBox ID="txtOI_ID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" height="3">
                        </td>
                        <td class="style6" height="3">
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Item Name</td>
                        <td class="style6" valign="middle">
                            <asp:TextBox ID="txtOI_Name" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" height="3">
                            &nbsp;</td>
                        <td class="style6" height="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Quantity Ordered</td>
                        <td class="style6" valign="middle">
                            <asp:TextBox ID="txtOI_Quantity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" height="3">
                            &nbsp;</td>
                        <td class="style6" height="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Unit Price</td>
                        <td class="style6" valign="middle">
                            <asp:TextBox ID="txtOI_UnitPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5" height="3">
                            &nbsp;</td>
                        <td class="style6" height="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5" valign="middle">
                            Extended Price</td>
                        <td class="style6" valign="middle">
                            <asp:TextBox ID="txtOI_ExtendPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td colspan="2">
                <table class="style1">
                    <tr>
                        <td class="style15">
                            <asp:Button ID="btnAddOI" runat="server" Text="Add Item" />
                        </td>
                        <td class="style15">
                            <asp:Button ID="btnUpdateOI" runat="server" Text="Update Item" />
                        </td>
                        <td class="style9">
                            <asp:Button ID="btnCreateInvoice" runat="server" Text="Create Invoice" />
                        </td>
                        <td class="style10">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
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
            width: 103px;
        }
        .style6
        {
            width: 467px;
        }
        .style9
        {
            width: 153px;
        }
        .style10
        {
            width: 106px;
        }
        .style11
        {
            width: 273px;
            font-family: Verdana;
            font-size: x-large;
        }
        .style15
        {
            width: 197px;
        }
    </style>
</asp:Content>
