<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Total visitor(s): 0"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Total online user(s): 0 "></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Click me" />
        <br />
    
    </div>
    </form>
</body>
</html>
