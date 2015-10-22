<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BorrowBook.aspx.cs" Inherits="Lab4_Group3.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: large;
        }
        .style2
        {
            font-size: large;
            text-align: center;
        }
        .style3
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p class="style2">
        <span class="style3">
        <strong>Borrow a Book
</strong>
</p>
<p>
    Borrower Number :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:TextBox ID="tbBorrowerNumber" runat="server"></asp:TextBox>
    <span class="style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Check Member" />
    <span class="style3">&nbsp;
        </span>
        <span class="style1"><span class="style3">&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <asp:Label ID="lbMemberError" runat="server" ForeColor="Red" 
        CssClass="style3"></asp:Label>
        </span>
</p>
<p>
    <span class="style3">Name :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:TextBox ID="tbName" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
    <span class="style3">Copy Number :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:TextBox ID="tbCopyNumber" runat="server"></asp:TextBox>
    <span class="style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Check Condition" />
    <span class="style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <span class="style1">
        <asp:Label ID="lbConditionError" runat="server" ForeColor="Red" 
        CssClass="style3"></asp:Label>
        </span>
</p>
<p>
    <span class="style3">Borrow Date :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:TextBox ID="tbBorrowDate" runat="server" Enabled="False"></asp:TextBox>
    <span class="style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Borrow" 
        Enabled="False" />
</p>
<p>
    <span class="style3">Due Date :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </span>
    <asp:TextBox ID="tbDueDate" runat="server" Enabled="False"></asp:TextBox>
</p>
<p>
        <span class="style1">
        <asp:Label ID="lbBorrowedBook" runat="server" ForeColor="Black" 
            CssClass="style3"></asp:Label>
        </span>
    <br class="style3" />
</p>
<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="copyNumber" DataSourceID="SqlDataSource1" CellPadding="4" 
        ForeColor="#333333" GridLines="None" AllowPaging="True" CssClass="style3">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="copyNumber" HeaderText="copyNumber" 
                ReadOnly="True" SortExpression="copyNumber" />
            <asp:BoundField DataField="bookNumber" HeaderText="bookNumber" 
                SortExpression="bookNumber" />
            <asp:BoundField DataField="sequenceNumber" HeaderText="sequenceNumber" 
                SortExpression="sequenceNumber" />
            <asp:BoundField DataField="type" HeaderText="type" 
                SortExpression="type" />
            <asp:BoundField DataField="price" HeaderText="price" 
                SortExpression="price" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LibraryConnectionString %>" 
        SelectCommand="SELECT * FROM [Copy]" 
        DeleteCommand="DELETE FROM [Copy] WHERE [copyNumber] = @copyNumber" 
        InsertCommand="INSERT INTO [Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (@copyNumber, @bookNumber, @sequenceNumber, @type, @price)" 
        
        
        UpdateCommand="UPDATE [Copy] SET [bookNumber] = @bookNumber, [sequenceNumber] = @sequenceNumber, [type] = @type, [price] = @price WHERE [copyNumber] = @copyNumber">
        <DeleteParameters>
            <asp:Parameter Name="copyNumber" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="copyNumber" Type="Int32" />
            <asp:Parameter Name="bookNumber" Type="Int32" />
            <asp:Parameter Name="sequenceNumber" Type="Int32" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="price" Type="Double" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="bookNumber" Type="Int32" />
            <asp:Parameter Name="sequenceNumber" Type="Int32" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="price" Type="Double" />
            <asp:Parameter Name="copyNumber" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</p>
<p class="style3">
    &nbsp;</p>
</asp:Content>
