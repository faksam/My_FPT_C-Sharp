<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Question2.aspx.cs" Inherits="Question2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        Search Water Heaters information<br />
        <asp:CheckBox ID="CheckBox1" runat="server" style="font-size: medium" Text="Select Type" />
&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
        <br />
        <asp:Label ID="Label1" runat="server" style="font-size: medium"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="Data is Empty" style="font-size: medium">
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
