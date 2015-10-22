<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Convertion.aspx.cs" Inherits="Convertion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change To UpperCase</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;Change to UpperCase<br />
    
        <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged" 
            style="margin-right: 1px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Enter" onclick="Button1_Click" />
        <br />
        Result:
    <span runat="server" id="changed_text" />
    </div>
    </form>
    <p>
&nbsp;</p>
</body>
</html>
