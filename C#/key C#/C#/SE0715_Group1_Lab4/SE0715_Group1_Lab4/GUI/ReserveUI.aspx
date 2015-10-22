<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReserveUI.aspx.cs" Inherits="SE0715_Group1_Lab4.GUI.ReserveUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" 
        style="font-weight: 700; font-size: large; font-family: 'Segoe UI'" 
        Text="Reserve Book"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbError" runat="server" ForeColor="Red" Text="Label" 
        Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Borrower number:  "></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" CssClass="newStyle1" 
        EnableTheming="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" CssClass="newStyle1" Enabled="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Check member" />
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="Book number:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server" CssClass="newStyle1" Enabled="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Title:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" runat="server" CssClass="newStyle1" Enabled="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Enabled="False" onclick="Button1_Click" 
        style="height: 26px" Text="Check condition" />
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" Text="Date:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" runat="server" CssClass="newStyle1" Enabled="False"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
        Text="Reserved" Enabled="False" />
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Number of reserved book: "></asp:Label>
    &nbsp;<asp:Label ID="Label8" runat="server" Text="0"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridViewReserved" runat="server" 
        AutoGenerateSelectButton="True" Height="135px" Width="427px">
        <SelectedRowStyle BackColor="Yellow" BorderColor="White" />
    </asp:GridView>
    <br />
    <br />
    <br />
</asp:Content>
