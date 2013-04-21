<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BakedGood.aspx.vb"
Inherits="WBE_WebApplication.BakedGood" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table class="style1">
        <tr>
            <td class="style50" colspan="2">
            </td>
        </tr>
        <tr>
            <td class="style2" rowspan="2">
            </td>
            <td class="style6">
                Product Information</td>
        </tr>
        <tr>
            <td class="style20">
                <table class="style46">
                    <tr>
                        <td class="style44" rowspan="4">
                <asp:ListBox ID="lstBakedGoods" runat="server" Height="104px" Width="189px">
                </asp:ListBox>
                        </td>
                        <td class="style44">
                            &nbsp;
                            Product ID&nbsp;&nbsp;&nbsp;</td>
                        <td class="style45">
                <asp:TextBox ID="txtBG_ID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            &nbsp;
                            Name 
                        </td>
                        <td>
                            <asp:TextBox ID="txtBGName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            &nbsp;
                            Price
                        </td>
                        <td>
                            <asp:TextBox ID="txtBGPrice" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            &nbsp;
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
                <asp:Button ID="btnBG_AddItem" runat="server" Text="Add Item" />
                        </td>
            <td class="style49">
                <asp:Button ID="btnBG_UpdateItem" runat="server" Text="Update Item" 
                    Width="94px" />
                        </td>
            <td class="style51">
                <asp:Button ID="btnBG_Close" runat="server" Text="Close" Width="61px" />
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
            width: 19px;
            }
        .style6
        {
            font-family: Verdana;
            font-size: x-large;
            height: 10px;
            text-align: left;
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
            width: 89%;
            height: 121px;
        }
        .style47
        {
            width: 36px;
        }
        .style48
        {
            width: 93px;
        }
        .style49
        {
            width: 110px;
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
            width: 155px;
        }
        </style>
</asp:Content>





