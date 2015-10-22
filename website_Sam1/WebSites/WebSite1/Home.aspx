<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #3333FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="get">
    <strong>Welcome to my Home Page<br />
    <asp:Label ID="Label1" runat="server" Text="Enter you name here: "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="162px"></asp:TextBox>
    </strong>
    <p>
        <strong>
        <asp:Button ID="Button1" runat="server" Height="22px" onclick="Button1_Click" 
            Text="Send" Width="41px" />
        </strong>
    </p>
    </form>
</body>
</html>
