<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditABook.aspx.cs" Inherits="SE0715_Group1_Lab4.GUI.EditABook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>Edit a book</b></p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Book number:&nbsp;&nbsp;
        <asp:TextBox ID="tbBookNum" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Tittle:&nbsp;&nbsp;
        <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
        <asp:Label ID="lbTitle" runat="server" ForeColor="Red" 
            Text="Must not be empty!" Visible="False"></asp:Label>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Authors:&nbsp;&nbsp;
        <asp:TextBox ID="tbAuthor" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Pulisher:&nbsp;&nbsp;
        <asp:TextBox ID="tbPulisher" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btSave" runat="server" onclick="btSave_Click" 
            style="height: 26px" Text="Save" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btCancel" runat="server" onclick="btCancel_Click" 
            Text="Cancel" />
    </p>
</asp:Content>
