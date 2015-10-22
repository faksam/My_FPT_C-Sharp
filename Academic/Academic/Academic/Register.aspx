<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Academic.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #0000FF;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            text-align: left;
        }
        .auto-style4 {
            text-align: left;
            width: 293px;
        }
        .auto-style5 {
            text-align: left;
            width: 283px;
        }
        .auto-style6 {
            text-align: left;
            width: 293px;
            height: 24px;
        }
        .auto-style7 {
            text-align: left;
            width: 283px;
            height: 24px;
        }
        .auto-style8 {
            text-align: left;
            height: 24px;
        }
        .auto-style9 {
            text-align: left;
            width: 293px;
            height: 23px;
        }
        .auto-style10 {
            text-align: left;
            width: 283px;
            height: 23px;
        }
        .auto-style11 {
            text-align: left;
            height: 23px;
        }
    </style>
</head>
<body style="height: 129px">
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1 class="auto-style1">REGISTRATION FORM&nbsp;&nbsp; </h1>
    
    </div>
        <div style="text-align: center">
    
            <table class="auto-style2">
                <tr>
                    <td class="auto-style4">Name</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox1" runat="server" Width="280px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox2" runat="server" Width="271px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Choose your UserName</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox3" runat="server" Width="277px"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Check Availability</asp:LinkButton>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Create a Password</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox4" runat="server" Width="275px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Confirm a Password</td>
                    <td class="auto-style10"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox5" runat="server" Width="273px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style9">Birthday</td>
                    <td class="auto-style10"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox6" runat="server" Width="276px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">Gender</td>
                    <td class="auto-style7"></td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style10"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td class="auto-style4">Mobile Phone</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:TextBox ID="TextBox8" runat="server" Width="272px"></asp:TextBox>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">Location</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:DropDownList ID="DropDownList3" runat="server">
                            <asp:ListItem>Afghanistan</asp:ListItem>
                            <asp:ListItem>Albania</asp:ListItem>
                            <asp:ListItem>Algeria</asp:ListItem>
                            <asp:ListItem>Andorra</asp:ListItem>
                            <asp:ListItem>Angola</asp:ListItem>
                            <asp:ListItem>Antigua and Barbuda</asp:ListItem>
                            <asp:ListItem>Argentina</asp:ListItem>
                            <asp:ListItem>Armenia</asp:ListItem>
                            <asp:ListItem>Austria</asp:ListItem>
                            <asp:ListItem>Australia</asp:ListItem>
                            <asp:ListItem>Azerbaijan</asp:ListItem>
                            <asp:ListItem>Brazil</asp:ListItem>
                            <asp:ListItem>Brunei </asp:ListItem>
                            <asp:ListItem>China</asp:ListItem>
                            <asp:ListItem>Canada</asp:ListItem>
                            <asp:ListItem>Dominica</asp:ListItem>
                            <asp:ListItem>Ethiopia</asp:ListItem>
                            <asp:ListItem>USA</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
    
    </div>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="I agree to the registration terms of service and privacy policy" />
        <p>
            <asp:Button ID="Button1" runat="server" style="text-align: center" Text="Register" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>
