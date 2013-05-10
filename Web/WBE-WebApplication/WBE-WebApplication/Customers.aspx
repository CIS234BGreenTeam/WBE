<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Customers.aspx.vb" Inherits="WBE_WebApplication.CustomerTab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style4
    {
        height: 58px;
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
    .style12
    {
            width: 25px;
            height: 26px;
            text-align: right;
        }
    .style22
    {
        width: 81px;
        height: 2px;
    }
    .style23
    {
        width: 74px;
        height: 2px;
    }
    .style27
    {
        width: 74px;
    }
        .style33
        {
            width: 26px;
            height: 26px;
        }
        .style34
        {
            height: 26px;
            width: 13px;
        }
        .style35
        {
            width: 13px;
        }
        .style36
        {
            height: 2px;
            width: 13px;
        }
        .style54
        {
            height: 26px;
        }
        .style55
        {
        }
        .style56
        {
            height: 2px;
            }
        .style57
        {
            height: 26px;
            width: 90px;
        }
        .style58
        {
            height: 26px;
            width: 3px;
        }
        .style59
        {
            width: 3px;
        }
        .style60
        {
            height: 2px;
            width: 3px;
        }
        .style62
        {
            font-size: x-large;
            font-family: Verdana;
        }
        .style64
        {
            width: 94px;
        }
        .style67
        {
            width: 76px;
        }
        .style68
        {
            width: 5px;
        }
        .panelcontrols
        {  
            font-size:small;
            margin-right:10em;
        }
 
        .style75
        {
            font-size: large;
        }
 
        .style76
        {
            height: 26px;
            width: 65px;
        }
        .style77
        {
            width: 65px;
        }
        .style78
        {
            height: 2px;
            width: 65px;
        }
 
        .style82
        {
            height: 26px;
            width: 268435456px;
        }
        .style83
        {
            width: 268435456px;
        }
        .style84
        {
            height: 2px;
            width: 268435456px;
        }
        .style85
        {
            height: 4px;
        }
        .style86
        {
            width: 74px;
            height: 4px;
        }
        .style87
        {
            height: 4px;
            width: 13px;
        }
        .style88
        {
            height: 4px;
            width: 3px;
        }
        .style89
        {
            height: 4px;
            width: 65px;
        }
        .style90
        {
            height: 4px;
            width: 268435456px;
        }
        .style91
        {
            width: 81px;
            height: 58px;
        }
        .style92
        {
            height: 4px;
            width: 81px;
        }
        .style94
        {
            width: 81px;
        }
        .style95
        {
            height: 26px;
            width: 81px;
        }
        .style97
        {
            width: 4px;
        }
         
        .auto-style1
        {
            height: 4px;
            width: 151px;
        }
        .auto-style2
        {
            width: 151px;
        }
        .auto-style3
        {
            height: 26px;
            width: 151px;
        }
        .auto-style4
        {
            height: 2px;
            width: 151px;
        }
        .auto-style5
        {
            height: 4px;
            width: 268435312px;
        }
        .auto-style6
        {
            width: 268435312px;
        }
        .auto-style7
        {
            height: 26px;
            width: 268435312px;
        }
        .auto-style8
        {
            height: 2px;
            width: 268435312px;
        }
        .auto-style13
        {
            width: 124px;
        }
        .auto-style14
        {
            width: 81px;
            height: 9px;
        }
        .auto-style15
        {
            width: 74px;
            height: 9px;
        }
        .auto-style16
        {
            width: 13px;
            height: 9px;
        }
        .auto-style17
        {
            width: 3px;
            height: 9px;
        }
        .auto-style18
        {
            width: 151px;
            height: 9px;
        }
        .auto-style19
        {
            width: 268435312px;
            height: 9px;
        }
        .auto-style20
        {
            height: 9px;
        }
        .auto-style21
        {
            width: 81px;
            height: 12px;
        }
        .auto-style22
        {
            width: 74px;
            height: 12px;
        }
        .auto-style23
        {
            width: 13px;
            height: 12px;
        }
        .auto-style24
        {
            width: 3px;
            height: 12px;
        }
        .auto-style25
        {
            width: 151px;
            height: 12px;
        }
        .auto-style26
        {
            width: 268435312px;
            height: 12px;
        }
        .auto-style27
        {
            height: 12px;
        }
         
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">
    <tr>
        <td class="style91">
        </td>
        <td class="style62" colspan="7">
                Customer Information
        </td>
        <td class="style4">
        </td>
    </tr>
    <tr>
        <td class="style92">
            Selection</td>
        <td class="style86" colspan="3">
            <asp:DropDownList ID="ddlCustomer" runat="server" Width="165px">
            </asp:DropDownList>
        </td>
        <td class="style87">
            &nbsp;</td>
        <td class="style88">
            &nbsp;</td>
        <td class="auto-style1">
            &nbsp;</td>
        <td class="auto-style5">
            &nbsp;</td>
        <td class="style85">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style92">
            &nbsp;</td>
        <td class="style86" colspan="3">
            &nbsp;</td>
        <td class="style87">
            &nbsp;</td>
        <td class="style88">
            &nbsp;</td>
        <td class="auto-style1">
            &nbsp;</td>
        <td class="auto-style5">
            &nbsp;</td>
        <td class="style85">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style92">
            Name</td>
        <td class="style86" colspan="3">
            <asp:TextBox ID="txtName" runat="server" Width="160px" Height="18px"></asp:TextBox>
        </td>
        <td class="style87">
            </td>
        <td class="style88">
            Phone</td>
        <td class="auto-style1">
            <asp:TextBox ID="txtPhone" runat="server" Width="128px"></asp:TextBox>
        </td>
        <td class="auto-style5">
            &nbsp;</td>
        <td class="style85">
            </td>
    </tr>
    <tr>
        <td class="auto-style21">
        </td>
        <td class="auto-style22" colspan="3">
            <asp:Label ID="lblValName" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
        </td>
        <td class="auto-style23">
        </td>
        <td class="auto-style24">
        </td>
        <td class="auto-style25">
            <asp:Label ID="lblValPhone" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
        </td>
        <td class="auto-style26">
        </td>
        <td class="auto-style27">
        </td>
    </tr>
    <tr>
        <td class="style95">
            Address1</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtAddress1" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
            &nbsp;</td>
        <td class="style58">
            Fax</td>
        <td class="auto-style3">
            <asp:TextBox ID="txtFax" runat="server" Width="131px"></asp:TextBox>
        </td>
        <td class="auto-style7">
            &nbsp;</td>
        <td class="style54">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style14">
        </td>
        <td class="auto-style15" colspan="3">
            <asp:Label ID="lblValAddress1" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
        </td>
        <td class="auto-style16">
        </td>
        <td class="auto-style17">
        </td>
        <td class="auto-style18">
            <asp:Label ID="lblValFax" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
        </td>
        <td class="auto-style19">
        </td>
        <td class="auto-style20">
        </td>
    </tr>
    <tr>
        <td class="style95">
            Address2</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtAddress2" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
            </td>
        <td class="style58">
            Email</td>
        <td class="auto-style3">
            <asp:TextBox ID="txtEmail" runat="server" Width="137px"></asp:TextBox>
        </td>
        <td class="auto-style7">
            </td>
        <td class="style9">
            </td>
    </tr>
    <tr>
        <td class="style22">
        </td>
        <td class="style23" colspan="3">
            <asp:Label ID="lblValAddress2" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
        </td>
        <td class="style36">
        </td>
        <td class="style60">
        </td>
        <td class="auto-style4">
            <asp:Label ID="lblValEmail" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
        </td>
        <td class="auto-style8">
        </td>
        <td class="style56">
        </td>
    </tr>
    <tr>
        <td class="style95">
            City</td>
        <td class="style7" colspan="3">
            <asp:TextBox ID="txtCity" runat="server" Width="160px" height="18px"></asp:TextBox>
        </td>
        <td class="style34">
        </td>
        <td class="style58">
            Driver</td>
        <td class="auto-style3">
            <asp:DropDownList ID="ddlDriver" runat="server" Height="24px" Width="145px">
            </asp:DropDownList>
        </td>
        <td class="auto-style7">
        </td>
        <td class="style54">
        </td>
    </tr>
    <tr>
        <td class="style94">
        </td>
        <td class="style27" colspan="3">
            <asp:Label ID="lblValCity" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
        </td>
        <td class="style35">
        </td>
        <td class="style59">
        </td>
        <td class="auto-style2">
        </td>
        <td class="auto-style6">
        </td>
        <td class="style55">
        </td>
    </tr>
    <tr>
        <td class="style95">
            State</td>
        <td class="style33">
            <asp:TextBox ID="txtState" runat="server" Width="35px" Height="18px"></asp:TextBox>
        </td>
        <td class="style12">
            Zip </td>
        <td class="style57">
            <asp:TextBox ID="txtZip" runat="server" Width="87px" Height="18px" 
                style="text-align: left"></asp:TextBox>
        </td>
        <td class="style34">
            &nbsp;</td>
        <td class="style10" colspan="3">
            <asp:CheckBox ID="chkInactive" runat="server" Text="Inactive" />
        </td>
        <td class="style9">
            &nbsp;</td>
    </tr>
    </table>
    <asp:Label ID="lblValState" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
    <asp:Label ID="lblValZip" runat="server" ForeColor="Red" Visible="False" Width="160px"></asp:Label>
&nbsp;<table class="style1">
        <tr>
            <td class="auto-style13">
                <asp:Button ID="btnSaveCustomer" runat="server" Text="Save Customer" Width="112px" />
            </td>
            <td>
                <asp:Button ID="btnNewCustomer" runat="server" Text="New Customer" Width="112px" />
            </td>
        </tr>
    </table>
    <br />
    <span class="style75">Inventory<br />
    <asp:Panel ID="pnlInventory" runat="server" cssclass="panelcontrols">
    </asp:Panel>
    </span>&nbsp;<table class="style1">
        <tr>
            <td class="style64">
                <asp:Button ID="btnSaveItem" runat="server" Text="Save Inventory" Height="26px" 
                    Width="117px" />
            </td>
            <td class="style97">
                &nbsp;</td>
            <td class="style67">
                <asp:Button ID="btnAdd" runat="server" Text="Add Item" height="26px" 
                    width="109px" />
            </td>
            <td class="style68">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnDeleteItem" runat="server" Text="Delete Item" height="26px" 
                    width="102px" />
            </td>
        </tr>
        </table>
        <hr />
        <span class="style75">
    <br />
    </span>
    </asp:Content>
