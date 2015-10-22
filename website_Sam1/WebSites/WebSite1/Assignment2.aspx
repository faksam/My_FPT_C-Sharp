<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Assignment2.aspx.cs" Inherits="Assignment2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment 2</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p> Add A New Flower:</p>
        <p> Flower Name:
            <asp:TextBox ID="TextBox1" runat="server" name ="TextBox1"></asp:TextBox>
           <font color="red"> <a runat="server" id="changed_text" /> </font>
        </p>
        <p> Color:<asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </p>
        <p> Unit Price:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <font color="red">  <a runat="server" id="Span1_text" /></font> 
        </p>
        <p> 
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save" />          
                     
           <font color="green"> <a runat="server" id="Span2_text" /></font> 
        </p>
    </div>
    </form>
</body>
</html>
