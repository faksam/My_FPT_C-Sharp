<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="Question2.Question2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        Search Camera information
    </h1>
        <p>
            Enter price from&nbsp;
            <asp:TextBox ID="txtMin" runat="server"></asp:TextBox>
&nbsp; to&nbsp;
            <asp:TextBox ID="txtMax" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="btSearch" runat="server" onclick="btSearch_Click" 
                Text="Search" />
    </p>
        <p>
            &nbsp;<asp:Label ID="Label1" runat="server" Text="Number of Records : " Visible="False"></asp:Label>
            <asp:Label ID="lbCount" runat="server" Text="0" Visible="False"></asp:Label>
    </p>
        <p>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
    </p>
    </div>
    </form>
</body>
</html>
