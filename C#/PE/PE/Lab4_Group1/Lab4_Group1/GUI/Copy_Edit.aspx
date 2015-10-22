<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Copy_Edit.aspx.cs" Inherits="Lab4_Group3.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            font-size: x-large;
            text-align: center;
        }
        .style2
        {
            color: #000000;
        }
        .style3
        {
            text-align: center;
            color: #000000;
        }
        .style4
        {
            height: 21px;
        }
        .style5
        {
            height: 21px;
            color: #000000;
            width: 218px;
        }
        .style6
        {
            width: 218px;
        }
        .style7
        {
            height: 21px;
            width: 218px;
        }
        .style8
        {
            text-align: center;
            color: #000000;
        }
        .style9
        {
            text-align: center;
        }
        .style10
        {
            height: 21px;
            width: 282px;
        }
        .style11
        {
            height: 21px;
            color: #000000;
            width: 282px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style8" colspan="3">
    <strong><span class="style1">Edit a Copy<br />
                </span></strong>
            </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style6">
                <span class="style2">Copy Number :&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
            <td>
                <span class="style2">
        <asp:TextBox ID="tbCopyNumber" runat="server"></asp:TextBox>
                </span>
            </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style6">
                <span class="style2">Book Number :&nbsp;&nbsp;&nbsp;</span></td>
            <td>
        <asp:TextBox ID="tbBookNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style7">
                <span class="style2">Sequence number :&nbsp;</span></td>
            <td class="style4">
        <asp:TextBox ID="tbSequenceNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="style5">
                Type:</td>
            <td class="style4">
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>R</asp:ListItem>
    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style6">
                <span class="style2">Price :&nbsp;&nbsp;</span></td>
            <td>
        <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style9" colspan="3">
                <asp:Button ID="Button3" runat="server" 
            CausesValidation="False" Text="Save" onclick="Button3_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Cancel" 
            CausesValidation="False" onclick="Button2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
