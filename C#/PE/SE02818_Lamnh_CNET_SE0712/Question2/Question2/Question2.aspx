﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="Question2.Question2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1> Search 
        Customers information </h1><br />
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Select Region" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Search" />
        <br />
        Number of Record :
        <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
        <br />
    
    </div>
    <asp:GridView ID="GridView1" runat="server" ondatabound="GridView1_DataBound">
    </asp:GridView>
    </form>
</body>
</html>
