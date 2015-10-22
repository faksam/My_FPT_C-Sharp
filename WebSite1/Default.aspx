<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-weight: 700; color: #3333FF; font-size: xx-large">
    
        <blockquote>
            Add New Flower</blockquote>
        <blockquote style="font-size: large">
            Flower Name:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
            </blockquote>
        <blockquote style="font-size: large">
            Color:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" Width="143px">
            </asp:DropDownList>
        </blockquote>
        <blockquote style="font-size: large">
            Unit Price:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;
            </blockquote>
        <blockquote style="font-size: large; margin-left: 120px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
        </blockquote>
    
    </div>
    </form>
</body>
</html>
