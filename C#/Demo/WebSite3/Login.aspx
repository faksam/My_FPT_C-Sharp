<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 90px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 22%;">
            <tr>
                <td class="auto-style1">UserName</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Password</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
                    <asp:Button ID="Button2" runat="server" Text="Reset" />
                    <asp:Button ID="Button3" runat="server" Text="Send" PostBackUrl="~/Default.aspx" OnClientClick="return doConfirm()"/>

                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
<script language="javascript">
    function doConfirm() {
        if (confirm("Ready to send data?"))
            return true;
        else
            return false;
        }
</script>