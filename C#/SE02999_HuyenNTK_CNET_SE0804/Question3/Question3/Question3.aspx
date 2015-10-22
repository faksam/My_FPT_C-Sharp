<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question3.aspx.cs" Inherits="Question3.Question3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Search Assets</h1>
        <br />
        Choose search condition<br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Asset Type" />
&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBox2" runat="server" Text="Company" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        _________________________________________________<br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Search" />
    
    </div>
    </form>
</body>
</html>
