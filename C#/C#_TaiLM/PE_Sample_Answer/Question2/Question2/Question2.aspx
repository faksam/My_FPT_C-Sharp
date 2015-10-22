<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question2.aspx.cs" Inherits="Question2.Question2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: large;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 560px">
    
        <br class="style1" />
        <span class="style1">Add a new Flower</span><br />
        <br />
        Flower name&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFlowerName" runat="server" MaxLength="50"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtFlowerName" ErrorMessage="Please enter name of flower" 
            ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <br />
        Color&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="ddlColorID" runat="server">
        </asp:DropDownList>
        <br />
        <br />
       Unit price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="txtUnitPrice" ErrorMessage="Please enter unit price" 
            ForeColor="#FF3300" Operator="GreaterThanEqual" Type="Double" 
            ValueToCompare="0"></asp:CompareValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
        <br />
        <br />
        <br />
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="Flower name:"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtFlower" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
            Text="Search" />
        <br />
        The number of records:
        <asp:Label ID="lblNo" runat="server" Text="0"></asp:Label>
&nbsp;<asp:GridView ID="GridView1" runat="server" ondatabound="GridView1_DataBound">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
