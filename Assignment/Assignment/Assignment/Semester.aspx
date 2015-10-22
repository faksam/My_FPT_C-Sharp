<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Semester.aspx.cs" Inherits="Assignment.Semester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #CC3300;
        }
        .auto-style2 {
            color: #0000FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; background-color: #E4F709">
    
        <h1><span class="auto-style1"><strong>WELCOME TO FU PORTAL</strong></span></h1>
        <span class="auto-style2"><strong>SELECT SEMESTER</strong></span><br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go" />
        <br />
        <br />
        <br />
        <br />
    
        <p style="height: 316px; background-color: #009900">
            &nbsp;</p>
    
    </div>
    </form>
</body>
</html>
