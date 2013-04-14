<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BakedGood.aspx.vb"
Inherits="WBE_WebApplication.WebForm1" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table class="style1">
        <tr>
            <td class="style2">
            </td>
            <td class="style6">
                Product Information</td>
            <td class="style24">
                </td>
        </tr>
        <tr>
            <td class="style22">
            </td>
            <td class="style11">
                Available Baked Goods</td>
            <td class="style25" valign="middle">
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style9">
                <asp:ListBox ID="lstBakedGoods" runat="server" Height="132px" Width="259px">
                </asp:ListBox>
            </td>
            <td class="style20">
                <table class="style46">
                    <tr>
                        <td class="style44">
                            Product ID&nbsp;&nbsp;&nbsp;</td>
                        <td class="style45">
                <asp:TextBox ID="txtBG_ID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            Name 
                        </td>
                        <td>
                            <asp:TextBox ID="txtBGName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            Price
                        </td>
                        <td>
                            <asp:TextBox ID="txtBGPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            Discontinued</td>
                        <td>
                            <asp:CheckBox ID="chkBG_Discontinued" runat="server" />
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
                <asp:Button ID="btnAddBG_Item" runat="server" Text="Add Item" />
                        </td>
            <td class="style49">
                <asp:Button ID="btnUpdateBG_Item" runat="server" Text="Update Item" />
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
            width: 34px;
            height: 33px;
        }
        .style6
        {
            font-family: Verdana;
            font-size: x-large;
            width: 242px;
            height: 33px;
        }
        .style8
        {
            width: 34px;
            height: 149px;
        }
        .style9
        {
            width: 242px;
            height: 149px;
        }
        .style11
        {
            font-family: Verdana;
            font-size: small;
            width: 242px;
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
        .style22
        {
            font-family: Verdana;
            font-size: x-large;
            width: 34px;
            height: 6px;
        }
        .style24
        {
            width: 506px;
            height: 33px;
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
            width: 127px;
        }
        .style49
        {
            width: 124px;
            text-align: right;
        }
    </style>
</asp:Content>





