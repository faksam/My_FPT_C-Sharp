<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="Q2.Question2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        <strong>Search Customers information<br />
        </strong>
        <asp:CheckBox ID="checkBox1" runat="server" style="font-size: large" 
            Text="Select Contact Title" />
&nbsp;<asp:DropDownList ID="ddContact" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;
        <asp:Button ID="btSearch" runat="server" onclick="btSearch_Click" 
            Text="Search" />
        <br />
        <asp:Label ID="lbNumber" runat="server" style="font-size: large"></asp:Label>
        <asp:GridView ID="gvContact" runat="server" style="font-size: large">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
