<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Lab4_Group3.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            font-size: large;
        }
        .style2
        {
            color: #000000;
            margin-left: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <span class="style2">
    <strong><span class="style1">List of Members&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></strong>&nbsp;</span></p>
    <p>
        <strong>
    <asp:Label ID="lbError" runat="server" ForeColor="Red" CssClass="style2"></asp:Label>
        </strong><span class="style2">
    <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbNumberofBorrower" runat="server" style="color: #FF0000"></asp:Label>
    <br />
        </span>
    </p>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="borrowerNumber" DataSourceID="SqlDataSource2" 
    ForeColor="#333333" GridLines="None" PageSize="5" CssClass="style2">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="borrowerNumber" HeaderText="borrowerNumber" 
                ReadOnly="True" SortExpression="borrowerNumber" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="sex" HeaderText="sex" 
                SortExpression="sex" />
            <asp:BoundField DataField="address" HeaderText="address" 
                SortExpression="address" />
            <asp:BoundField DataField="telephone" HeaderText="telephone" 
                SortExpression="telephone" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LibraryConnectionString2 %>" 
        DeleteCommand="DELETE FROM [Borrower] WHERE [borrowerNumber] = @borrowerNumber" 
        InsertCommand="INSERT INTO [Borrower] ([borrowerNumber], [name], [sex], [address], [telephone], [email]) VALUES (@borrowerNumber, @name, @sex, @address, @telephone, @email)" 
        SelectCommand="SELECT * FROM [Borrower]" 
        UpdateCommand="UPDATE [Borrower] SET [name] = @name, [sex] = @sex, [address] = @address, [telephone] = @telephone, [email] = @email WHERE [borrowerNumber] = @borrowerNumber">
        <DeleteParameters>
            <asp:Parameter Name="borrowerNumber" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="borrowerNumber" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="sex" Type="String" />
            <asp:Parameter Name="address" Type="String" />
            <asp:Parameter Name="telephone" Type="String" />
            <asp:Parameter Name="email" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="sex" Type="String" />
            <asp:Parameter Name="address" Type="String" />
            <asp:Parameter Name="telephone" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="borrowerNumber" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br class="style2" />
    <span class="style2">&nbsp;&nbsp;
    </span>
    <asp:Button ID="Button1" runat="server" Text="Add" Width="55px" 
        onclick="Button1_Click" />
    <span class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:Button ID="Button2" runat="server" Text="Edit" Width="51px" 
        onclick="Button2_Click" />
    <br class="style2" />
</asp:Content>
