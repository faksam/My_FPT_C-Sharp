<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookGUI.aspx.cs" Inherits="Lab4_Group3.GUI.BookGUI" %>
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
            font-family: "Segoe UI";
            font-size: large;
        }
        .style3
        {
            font-family: "Segoe UI";
            font-size: medium;
        }
        .style5
        {
            color: #000000;
        }
        .style6
        {
            text-align: center;
        }
        .style7
        {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: large;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p class="style7">
        <span class="style5">List of books&nbsp;&nbsp;&nbsp;
        </span>
        <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" CssClass="style5"></asp:Label>
</p>
    <p class="style6">
        <span class="style5">Book number:
        </span>
        <asp:TextBox ID="txtBookNumber" runat="server"></asp:TextBox>
        <span class="style5">&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        </p>
    <p class="style6">
        <span class="style5">
        <span class="style3">
        The Number of Book :</span><span class="style2">
        </span>
        </span>
        <span class="style1">
        <asp:Label ID="lblNo" runat="server" ForeColor="#FF3300" CssClass="style5"></asp:Label>
        </span>
        <br />
</p>
<p class="style6">
    &nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="bookNumber" 
        DataSourceID="SqlDataSource1" PageSize="5" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Width="340px" style="color: #000000">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="bookNumber" HeaderText="bookNumber" ReadOnly="True" 
                SortExpression="bookNumber" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="authors" HeaderText="authors" 
                SortExpression="authors" />
            <asp:BoundField DataField="publisher" HeaderText="publisher" 
                SortExpression="publisher" />
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
        DeleteCommand="DELETE FROM [Book] WHERE [bookNumber] = @bookNumber" 
        InsertCommand="INSERT INTO [Book] ([bookNumber], [title], [authors], [publisher]) VALUES (@bookNumber, @title, @authors, @publisher)" 
        SelectCommand="SELECT * FROM [Book]" 
        
        
        UpdateCommand="UPDATE [Book] SET [title] = @title, [authors] = @authors, [publisher] = @publisher WHERE [bookNumber] = @bookNumber">
        <DeleteParameters>
            <asp:Parameter Name="bookNumber" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="bookNumber" Type="Int32" />
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="authors" Type="String" />
            <asp:Parameter Name="publisher" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="authors" Type="String" />
            <asp:Parameter Name="publisher" Type="String" />
            <asp:Parameter Name="bookNumber" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</p>
<p>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="Lab4_Group4.DTL.Book" DeleteMethod="Delete" 
        FilterExpression="bookNumber = {0}" SelectMethod="SelectDS" 
        TypeName="Lab4_Group4.BLL.BookBL">
        <FilterParameters>
            <asp:ControlParameter ControlID="txtBookNumber" Name="newparameter" 
                PropertyName="Text" />
        </FilterParameters>
    </asp:ObjectDataSource>
    </p>
    <p class="style6">
        &nbsp;&nbsp;<asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" 
            Width="53px" />
&nbsp;
        <asp:Button ID="btnEdit" runat="server" onclick="btnEdit_Click" Text="Edit" 
            Width="55px" />
&nbsp;&nbsp;
        <asp:Button ID="btnCopies" runat="server" Text="Copies" 
            onclick="btnCopies_Click" />
    </p>
</asp:Content>
