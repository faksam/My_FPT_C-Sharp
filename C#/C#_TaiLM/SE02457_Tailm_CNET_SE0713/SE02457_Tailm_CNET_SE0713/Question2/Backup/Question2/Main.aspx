<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Question2.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:CheckBox ID="CheckBoxSelect" runat="server" Text="Select Spinning Speed" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownListSpeed" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btSearch" runat="server" Text="Search" 
            onclick="btSearch_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Number of Records : " 
            Enabled="False"></asp:Label>
&nbsp;
        <asp:Label ID="tbNumber" runat="server" Text="0" Enabled="False"></asp:Label>
&nbsp;<asp:GridView ID="GridViewWashers" runat="server" 
            ondatabound="GridViewWashers_DataBound">
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
