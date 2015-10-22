<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookEditGUI.aspx.cs" Inherits="Lab4_Group3.GUI.BookEditGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            font-family: "Segoe UI";
            font-size: large;
            font-weight: bold;
            text-align: center;
        }
        .style2
        {
            color: #000000;
        }
        .style3
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p class="style1">
        <span class="style2">Edit a book</p>
    <p class="style3">
        Book number:&nbsp;&nbsp;&nbsp;
        </span>
        <asp:TextBox ID="txtBookNumber" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p class="style3">
        <span class="style2">&nbsp; Title:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</span><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <span class="style2">&nbsp;&nbsp;&nbsp; </span>
    </p>
    <p class="style3">
        <span class="style2">Authors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        </span>
        <asp:TextBox ID="txtAuthors" runat="server"></asp:TextBox>
    </p>
    <p class="style3">
        <span class="style2">Publisher:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        </span>
        <asp:TextBox ID="txtPublisher" runat="server"></asp:TextBox>
    </p>
    <p class="style3">
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
            Width="61px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="txtCancel" runat="server" onclick="txtCancel_Click" 
            Text="Cancel" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
