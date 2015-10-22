<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookGUI.aspx.cs" Inherits="Lab4_Group1.GUI.BookGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            font-size: large;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <strong>&nbsp;&nbsp;&nbsp;&nbsp; <span class="style1">List of books </span>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp; The number of books:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:Label ID="numberBook" runat="server" Text="0"></asp:Label>
        <br /> <strong>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" DataKeyNames="bookNumber" DataSourceID="ObjectDataSource1" 
            Height="20px" Width="417px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;&nbsp; </strong>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DataObjectTypeName="Lab4_Group1.DTL.Book" DeleteMethod="Delete" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="SelectDS" 
            TypeName="Lab4_Group1.BLL.BookBL"></asp:ObjectDataSource>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBookAdd" runat="server" Text="Add" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBookEdit" runat="server" Text="Edit" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btBookCopy" runat="server" Text="Copy" />
        &nbsp;<br />
        <br />
        <br />
        <br />
    </asp:Panel>
</asp:Content>
