<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="BakedGood.aspx.vb"
Inherits="WBE_WebApplication.BakedGoodTab" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table class="style1">
        <tr>
            <td class="style50" colspan="4">
            </td>
        </tr>
        <tr>
            <td class="style2" rowspan="2">
            </td>
            <td class="auto-style1">
                Product Information</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style20" colspan="3">
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
                        <td class="style45">
                            &nbsp;</td>
                        <td class="auto-style3">
                            <asp:Label ID="lblBG_ID_Error" runat="server" Text="Label"></asp:Label>
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
                        <td>
                            &nbsp;</td>
                        <td class="auto-style4">
                            <asp:Label ID="lblBG_Name_Error" runat="server" Text="Label"></asp:Label>
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
                        <td>
                            &nbsp;</td>
                        <td class="auto-style4">
                            <asp:Label ID="lblBG_Price_Error" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style15">
                            &nbsp;
                            Discontinued</td>
                        <td>
                            <asp:CheckBox ID="chkActive" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtInactiveDate" runat="server"></asp:TextBox>
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
                <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
            </td>
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
            width: 151%;
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
        .auto-style1 {
            font-family: Verdana;
            font-size: x-large;
            height: 10px;
            text-align: left;
            width: 247px;
        }
        .auto-style2 {
            font-family: Verdana;
            font-size: x-large;
            height: 10px;
            text-align: left;
            width: 403px;
        }
        .auto-style3 {
            height: 20px;
            width: 317px;
        }
        .auto-style4 {
            width: 317px;
        }
        </style>
</asp:Content>





