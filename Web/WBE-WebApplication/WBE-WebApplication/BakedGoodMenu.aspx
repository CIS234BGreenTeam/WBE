<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BakedGoodMenu.aspx.vb"
Inherits="WBE_WebApplication.BakedGoodMenu" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table class="style1">
        <tr>
            <td class="style50" colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td class="style2" rowspan="3">
                &nbsp;</td>
            <td class="style6">
                Customer
                Baked Good Menu</td>
        </tr>
        <tr>
            <td class="style11">
                Select an Item to order&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style20">
                <table class="style46">
                    <tr>
                        <td class="style44" rowspan="5">
                <asp:ListBox ID="lstMenu_Items" runat="server" Height="127px" Width="194px" 
                                EnableTheming="False">
                </asp:ListBox>
                        </td>
                        <td class="style44">
                            &nbsp;
                            Product ID&nbsp;&nbsp;&nbsp;</td>
                        <td class="style45">
                            <asp:TextBox ID="txtMenu_ProductID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style51">
                            &nbsp;
                            Name 
                        </td>
                        <td class="style52">
                            <asp:TextBox ID="txtMenu_ItemName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            &nbsp;
                            Price
                        </td>
                        <td>
                            <asp:TextBox ID="txtMenu_Price" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            &nbsp;
                            Select Item</td>
                        <td>
                            <asp:CheckBox ID="chkMenu_ItemSelect" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            &nbsp;
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
                <asp:Button ID="btnMenu_AddItem" runat="server" Text="Add Item(s)" />
                        </td>
            <td class="style49">
                <asp:Button ID="btnMenu_Cancel" runat="server" Text="Cancel" />
                        </td>
            <td class="style53">
                &nbsp;</td>
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
            width: 17px;
            }
        .style6
        {
            font-family: Verdana;
            font-size: x-large;
            height: 33px;
            text-align: left;
        }
        .style11
        {
            font-family: Verdana;
            font-size: small;
            height: 6px;
        }
        .style15
        {
            width: 88px;
        }
        .style20
        {
            width: 506px;
            height: 127px;
        }
        .style44
        {
            width: 88px;
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
            width: 130px;
        }
        .style49
        {
            width: 82px;
            text-align: left;
        }
        .style50
        {
            font-family: Verdana;
            font-size: small;
            height: 1px;
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
        .style53
        {
            width: 82px;
        }
        </style>
</asp:Content>





