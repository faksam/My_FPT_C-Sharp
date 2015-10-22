<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookAddGUI.aspx.cs" Inherits="Lab4_Group3.GUI.BookAddGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 170px;
        }
        .style3
        {
            height: 26px;
        }
        .style4
        {
            width: 170px;
            height: 26px;
        }
        .style5
        {            color: #000000;
        }
        .style6
        {
            height: 26px;
            color: #000000;
        }
        .style7
        {
            width: 136px;
            color: #000000;
        }
        .style8
        {
            width: 136px;
            height: 26px;
            color: #000000;
        }
        .style9
        {            text-align: center;
        }
        .style10
        {
            height: 26px;
            width: 197px;
        }
        .style11
        {
            text-align: center;
            color: #000000;
        }
        .style12
        {
            text-align: center;
            color: #000000;
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style12" colspan="4">
                    Add a book<br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style7">
        Book number:&nbsp;&nbsp;&nbsp;</td>
                <td class="style2">
        <asp:TextBox ID="tb_bookNumber" runat="server" Enabled="False" Width="161px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    </td>
                <td class="style8">
                    Title:&nbsp;&nbsp;</td>
                <td class="style4">
        <asp:TextBox ID="tb_title" runat="server" Width="164px"></asp:TextBox>
                </td>
                <td class="style3">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tb_title" ErrorMessage="Must not be empty!" 
            ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    </td>
                <td class="style8">
                    Authors:&nbsp;&nbsp;</td>
                <td class="style4">
        <asp:TextBox ID="tb_authors" runat="server" Width="166px"></asp:TextBox>
                </td>
                <td class="style3">
                    </td>
            </tr>
            <tr>
                <td class="style11" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style7">
&nbsp;Publisher:</td>
                <td class="style2">
        <asp:TextBox ID="tb_publisher" runat="server" Width="159px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td colspan="3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bt_save" runat="server" onclick="btnSave_Click" Text="Save" 
            Width="61px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bt_cancel" runat="server" onclick="txtCancel_Click" 
            Text="Cancel" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
