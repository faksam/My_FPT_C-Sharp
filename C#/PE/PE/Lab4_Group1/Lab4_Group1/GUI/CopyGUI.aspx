<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CopyGUI.aspx.cs" Inherits="Lab4_Group3.GUI.CopyGUI" %>
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
        <span class="style1">List of copies&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
        <asp:Label ID="lbError" runat="server" style="color: #FF0000; font-weight: 700"></asp:Label>
        <br />
    </p>
    <p class="style2">
        Book number:
        <asp:TextBox ID="txtBookNumber" runat="server" Enabled="False"></asp:TextBox>
&nbsp;</p>
    <p class="style2">
        &nbsp;Title:
        <asp:TextBox ID="txtTitle" runat="server" Enabled="False"></asp:TextBox>
    </p>
    <p class="style2">
        The number of copies:
        <asp:Label ID="lblNo" runat="server" Text="0"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" DataSourceID="SqlDataSource1" 
            ondatabound="GridView1_DataBound" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="copyNumber" 
            CssClass="style3">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="copyNumber" HeaderText="copyNumber" ReadOnly="True" 
                    SortExpression="copyNumber" />
                <asp:BoundField DataField="bookNumber" HeaderText="bookNumber" 
                    SortExpression="bookNumber" />
                <asp:BoundField DataField="sequenceNumber" HeaderText="sequenceNumber" 
                    SortExpression="sequenceNumber" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
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
            DeleteCommand="DELETE FROM [Copy] WHERE [copyNumber] = @copyNumber" 
            InsertCommand="INSERT INTO [Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (@copyNumber, @bookNumber, @sequenceNumber, @type, @price)" 
            SelectCommand="SELECT * FROM [Copy]" 
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
    <p>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="Lab4_Group4.DTL.Copy" DeleteMethod="Delete" 
            FilterExpression="bookNumber = {0}" 
            SelectMethod="SelectDS" TypeName="Lab4_Group4.BLL.CopyBL">
            <FilterParameters>
                <asp:ControlParameter ControlID="txtBookNumber" Name="newparameter" 
                    PropertyName="Text" />
            </FilterParameters>
        </asp:ObjectDataSource>
    </p>
    <p class="style2">
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="67px" 
            onclick="btnAdd_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="57px" 
            onclick="btnEdit_Click" />
    </p>
</asp:Content>
