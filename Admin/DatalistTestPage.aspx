<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master" AutoEventWireup="true" CodeFile="DatalistTestPage.aspx.cs" Inherits="Admin_DatalistTestPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">
<asp:DataList ID="DataList1" runat="server">
    <ItemTemplate>
    Name :
        <asp:TextBox ID="txtName" Text="" runat="server" />
        <br />
        Email :
        <asp:TextBox ID="txtEmail" runat="server"  Text="" />
    </ItemTemplate>
</asp:DataList>
<hr />
<asp:Button ID="Button1" Text="Save" OnClick="Save" runat="server" />
</asp:Content>

