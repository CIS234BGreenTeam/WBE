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
                <asp:ListBox ID="lstBakedGoods" runat="server" Height="162px" Width="280px">
                </asp:ListBox>
            </td>
            <td class="style20">
                <table class="style1">
                    <tr>
                        <td class="style44">
                            Product ID&nbsp;&nbsp;&nbsp;</td>
                        <td class="style45">
                <asp:TextBox ID="txtBG_ID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
                        <td class="style42">
                            </td>
                        <td class="style43">
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
        <tr>
            <td class="style39">
                </td>
            <td class="style40">
                &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <table class="style32">
                    <tr>
                        <td class="style34">
                <asp:Button ID="btnAddBG_Item" runat="server" Text="Add Item" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="style31">
                <asp:Button ID="btnUpdateBG_Item" runat="server" Text="Update Item" />
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style41">
                </td>
        </tr>
        <tr>
            <td class="style26">
                </td>
            <td class="style27">
                &nbsp;&nbsp;&nbsp;
                </td>
            <td class="style28">
                </td>
        </tr>
        </table>
    <br />
    <p>
    </p>
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
            width: 254px;
            height: 33px;
        }
        .style8
        {
            width: 34px;
            height: 150px;
        }
        .style9
        {
            width: 254px;
            height: 150px;
        }
        .style11
        {
            font-family: Verdana;
            font-size: small;
            width: 254px;
            height: 6px;
        }
        .style15
        {
            width: 88px;
        }
        .style20
        {
            width: 506px;
            height: 150px;
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
        .style26
        {
            width: 34px;
            height: 2px;
        }
        .style27
        {
            width: 254px;
            height: 2px;
        }
        .style28
        {
            width: 506px;
            height: 2px;
        }
        .style31
        {
            width: 63px;
        }
        .style32
        {
            width: 109%;
        }
        .style34
        {
            width: 97px;
        }
        .style39
        {
            width: 34px;
        }
        .style40
        {
            width: 254px;
        }
        .style41
        {
            width: 506px;
        }
        .style42
        {
            width: 88px;
            height: 21px;
        }
        .style43
        {
            height: 21px;
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
    </style>
</asp:Content>





