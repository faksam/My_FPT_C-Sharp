<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Return.aspx.cs" Inherits="Lab4_Group3.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .style1
        {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Return a Copy</p>
    <p>
        Borrower Number :&nbsp;&nbsp;
        <asp:TextBox ID="tbBorrowerNumber" runat="server" Width="171px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            Text="Check Member" />
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Name :&nbsp;&nbsp;
        <asp:TextBox ID="tbName" runat="server" Enabled="False" Width="168px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span class="style1">
        <asp:Label ID="lbMemberError" runat="server" ForeColor="Red"></asp:Label>
        </span>
    </p>
    <p class="style1">
        <asp:Label ID="lbBorrowedBook" runat="server" ForeColor="Black" 
            style="color: #FF0000"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" AllowPaging="True" CssClass="style2" 
            PageSize="5">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="copyNumber" HeaderText="copyNumber" 
                    SortExpression="copyNumber" />
                <asp:BoundField DataField="borrowerNumber" HeaderText="borrowerNumber" 
                    SortExpression="borrowerNumber" />
                <asp:BoundField DataField="borrowedDate" HeaderText="borrowedDate" 
                    SortExpression="borrowedDate" />
                <asp:BoundField DataField="dueDate" HeaderText="dueDate" 
                    SortExpression="dueDate" />
                <asp:BoundField DataField="returnedDate" HeaderText="returnedDate" 
                    SortExpression="returnedDate" />
                <asp:BoundField DataField="fineAmount" HeaderText="fineAmount" 
                    SortExpression="fineAmount" />
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
            DeleteCommand="DELETE FROM [CirculatedCopy] WHERE [ID] = @ID" 
            InsertCommand="INSERT INTO [CirculatedCopy] ([copyNumber], [borrowerNumber], [borrowedDate], [dueDate], [returnedDate], [fineAmount]) VALUES (@copyNumber, @borrowerNumber, @borrowedDate, @dueDate, @returnedDate, @fineAmount)" 
            SelectCommand="SELECT * FROM [CirculatedCopy]" 
            
            UpdateCommand="UPDATE [CirculatedCopy] SET [copyNumber] = @copyNumber, [borrowerNumber] = @borrowerNumber, [borrowedDate] = @borrowedDate, [dueDate] = @dueDate, [returnedDate] = @returnedDate, [fineAmount] = @fineAmount WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="copyNumber" Type="Int32" />
                <asp:Parameter Name="borrowerNumber" Type="Int32" />
                <asp:Parameter Name="borrowedDate" Type="DateTime" />
                <asp:Parameter Name="dueDate" Type="DateTime" />
                <asp:Parameter Name="returnedDate" Type="DateTime" />
                <asp:Parameter Name="fineAmount" Type="Double" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="copyNumber" Type="Int32" />
                <asp:Parameter Name="borrowerNumber" Type="Int32" />
                <asp:Parameter Name="borrowedDate" Type="DateTime" />
                <asp:Parameter Name="dueDate" Type="DateTime" />
                <asp:Parameter Name="returnedDate" Type="DateTime" />
                <asp:Parameter Name="fineAmount" Type="Double" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Return Date :
        <asp:TextBox ID="tbReturnDate" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Fine Amount :<asp:TextBox ID="tbFineAmount" runat="server"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Confirm fine" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Enabled="False" onclick="Button2_Click" 
            Text="Return" />
    </p>
</asp:Content>
