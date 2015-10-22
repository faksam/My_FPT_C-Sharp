<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="Q2.Question2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:CheckBox ID="cbGenre" runat="server" Text="Genre" />
        <asp:DropDownList ID="dropList" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Search" onclick="Button1_Click" />
    <div id="searchbox" runat="server" visible="False">
        Number of results: <asp:Label ID="nums" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="result0" runat="server">
        </asp:GridView>
    </div>
    </form>
    </body>
</html>
