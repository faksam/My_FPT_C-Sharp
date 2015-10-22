<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
    
    <br /><asp:CheckBox ID="CheckBox1" runat="server" Text="All Semester" />                Semester<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>                    Status<asp:DropDownList ID="DropDownList2" runat="server"><asp:ListItem>Studying</asp:ListItem><asp:ListItem>Suspended</asp:ListItem><asp:ListItem>DropOut</asp:ListItem></asp:DropDownList>          Semester No  <asp:DropDownList ID="DropDownList3" runat="server"><asp:ListItem>1</asp:ListItem><asp:ListItem>2</asp:ListItem><asp:ListItem>3</asp:ListItem><asp:ListItem>4</asp:ListItem><asp:ListItem>5</asp:ListItem><asp:ListItem>6</asp:ListItem><asp:ListItem>7</asp:ListItem><asp:ListItem>8</asp:ListItem></asp:DropDownList>      <br /><br />Student Name<asp:TextBox ID="TextBox1" runat="server" Width="195px"></asp:TextBox><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" /><br /><br /><br /><br /><asp:GridView ID="GridView1" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None"><AlternatingRowStyle BackColor="White" ForeColor="#284775" /><EditRowStyle BackColor="#999999" /><FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /><HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="#F7F6F3" ForeColor="#333333" /><SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" /></asp:GridView><br /><br /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br /><br /><br /><br /><br /><br /><br /></div>
    </form>
</body>
</html>
