<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member_Add.aspx.cs" Inherits="Lab4_Group3.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            color: #000000;
        }
        .style2
        {
            width: 176px;
        }
        .style5
        {
            font-size: large;
        }
        .style7
        {
            color: #000000;
            width: 236px;
        }
        .style8
        {
            height: 21px;
            text-align: center;
        }
        .style9
        {
            color: #000000;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style9" colspan="4">
    <strong><span class="style5">&nbsp; Add a Member</span><br />
                </strong>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style1">
                Borrower Number :</td>
            <td class="style2">
    <asp:TextBox ID="tbBorrowerNum" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="tbName" ErrorMessage="Name of borrower can not be empty!" 
        ForeColor="Red" CssClass="style1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style1">
                Name :</td>
            <td class="style2">
    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style1">
                Sex :&nbsp;</td>
            <td class="style2">
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>F</asp:ListItem>
        <asp:ListItem>M</asp:ListItem>
    </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style1">
                Address :&nbsp;</td>
            <td class="style2">
    <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style1">
                Telephone :&nbsp;</td>
            <td class="style2">
    <asp:TextBox ID="tbTelephone" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style1">
                Email :&nbsp;&nbsp;</td>
            <td class="style2">
    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8" colspan="4">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;<span class="style1"><asp:Button ID="Button1" runat="server" Text="Save" Width="57px" 
        onclick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="False" 
        onclick="Button2_Click" />
&nbsp;&nbsp;&nbsp; </span>
            </td>
        </tr>
    </table>
</asp:Content>
