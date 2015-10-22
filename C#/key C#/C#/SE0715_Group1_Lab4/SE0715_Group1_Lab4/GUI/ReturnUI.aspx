<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReturnUI.aspx.cs" Inherits="SE0715_Group1_Lab4.GUI.ReturnUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p class="style1">
        <strong>Return a book&nbsp;&nbsp;&nbsp; </strong>
        <asp:Label ID="lbError" runat="server" ForeColor="Red" style="font-size: small" 
            Text="Label" Visible="False"></asp:Label>
    </p>
    <p class="style1">
        <asp:Label ID="Label1" runat="server" style="font-size: small" 
            Text="Borrower number : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textBox1" runat="server" Width="155px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="button1" runat="server" onclick="button1_Click" 
            Text="Check member" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="style1">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:Label ID="Label2" runat="server" style="font-size: small" Text="Name : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textBox2" runat="server" Enabled="False" Width="155px"></asp:TextBox>
    </p>
    <p class="style1">
        <asp:Label ID="Label3" runat="server" style="font-size: small" 
            Text="The number of borrowed copies : "></asp:Label>
        <asp:Label ID="Label4" runat="server" style="font-size: small" Text="0"></asp:Label>
    </p>
    <p class="style1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" 
            onrowdatabound="GridView1_RowDataBound">
            <SelectedRowStyle BackColor="Yellow" BorderColor="White" />
        </asp:GridView>
    </p>
    <p class="style1">
        <asp:Label ID="Label5" runat="server" style="font-size: small" 
            Text="Returned Date : "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textBox3" runat="server" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" style="font-size: small" 
            Text="Fine Amount : "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textBox4" runat="server" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;
    </p>
    <p class="style1">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="button3" runat="server" Enabled="False" onclick="button3_Click" 
            Text="Confirm Fine" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="button2" runat="server" Enabled="False" onclick="button2_Click" 
            Text="Return" Width="69px" />
    </p>
    <p class="style1">
        &nbsp;</p>
</asp:Content>
