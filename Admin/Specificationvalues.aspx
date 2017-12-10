<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master" AutoEventWireup="true" CodeFile="Specificationvalues.aspx.cs" Inherits="Specificationvalues" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" Runat="Server">

<div>
<table align="center" style=" width:100%" >
<tr>
<td style="font-family:Arial; font-size:medium; font-style:normal; padding-top:20px; padding-left:50px; text-align:right;">
Your Currently Viewing :
</td>
<td style="font-family:Arial; font-size:medium; font-style:normal; color:#0E59AB;padding-top:20px; text-align:left; vertical-align:middle;">
<asp:Label ID="lblplantname" runat="server" Text="" ></asp:Label>
</td>
</tr>
</table>


</div>
      <div>
  <table>
  <tr>
<td colspan="3" style=" height:10px;"></td>
</tr>
<tr>
<td align="right" class="style1" width="40%">Select SpecificationCategory:</td>
<td align="left" width="30%"><asp:DropDownList ID="ddlspecificationCategoryname" runat="server" Height="31px" Width="200px"></asp:DropDownList></td>
<td align="left">
<asp:ImageButton ID="BtnGo" runat="server" Width="60px"  Height="26px"
        ImageUrl="~/Images/icons/go_imageicon.gif" onclick="BtnGo_Click"   /></td>
</tr>
  </table>
  <table align="center" width="50%">
  <tr>
  <td colspan="2" align="left"><asp:Label ID="lblspecvalues" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
  <td colspan="2">
  <asp:GridView ID="gridview1" runat="server" align="center" AutoGenerateColumns="false" width="450px"  CellPadding="1" ForeColor="#333333" GridLines="None"> 
  <EmptyDataTemplate>
 <div style="color: Red; font-size: 12px; width:100%;">
 <span>No Data Found!!! </span>
  <span style="color: #8A8A8A; font-family:Arial; font-style:normal; font-size:small;">Please ADD SpecificationCategory and SpecificationMaster for this Product. </span>
 </div>
</EmptyDataTemplate>
             
  <Columns>  
      
 <asp:TemplateField HeaderText ="S.No" HeaderStyle-HorizontalAlign="Center" >
 <ItemTemplate >
<%-- <asp:Label ID="lblspecmasterid" runat ="server" Text ='<%#Eval("SpecificationMasterID") %>'></asp:Label>--%>
<%#Container.DataItemIndex+1 %>
 </ItemTemplate>
 <Headerstyle Width="5%" CssClass="HeaderRow1"/>
 <ItemStyle Width="5%" CssClass="ItemRow1" />
 </asp:TemplateField>      

  <asp:TemplateField HeaderText ="SpecificationCategoryName" HeaderStyle-HorizontalAlign="Center">
 <ItemTemplate >
 <asp:HiddenField ID="hdnspeccategid" runat="server"  Value='<%#Eval("SpecificationCategoryID") %>' Visible="false" />
 <asp:Label ID="lblspeccategname" runat ="server" Text ='<%#Eval("SpecificationCategoryName") %>' ></asp:Label>
 </ItemTemplate>
  <Headerstyle Width="10%" CssClass="HeaderRow1" />
 <ItemStyle Width="10%" CssClass="ItemRow1" />
 </asp:TemplateField>



  <asp:TemplateField HeaderText ="SpecificationMasterName" HeaderStyle-HorizontalAlign="Center">
 <ItemTemplate >
 <asp:HiddenField ID="hdnspecmasterid" runat="server" Value='<%#Eval("SpecificationMasterID") %>' Visible="false" />
 <asp:Label ID="lblspecmastername" runat ="server" Text ='<%#Eval("SpecificationMasterName") %>'></asp:Label>
 </ItemTemplate>
  <Headerstyle Width="10%" CssClass="HeaderRow1" />
 <ItemStyle Width="10%" CssClass="ItemRow1" />
 </asp:TemplateField>

 <asp:TemplateField HeaderText="SpecificationValueName" HeaderStyle-HorizontalAlign="Center">
 <ItemTemplate>
<asp:TextBox ID="txtspec" Text='<%# Eval("SpecificationValueName") %>' runat="server"></asp:TextBox>
 </ItemTemplate>
 <EditItemTemplate>
 <asp:TextBox ID="edittxtspec" Text='<%# Eval("SpecificationValueName") %>' runat="server"></asp:TextBox>
 </EditItemTemplate>
  <Headerstyle Width="5%" CssClass="HeaderRow1" />
 <ItemStyle Width="5%" CssClass="ItemRow1" />
 </asp:TemplateField>
</Columns>
 <RowStyle BackColor="#F2F6F9" />
<AlternatingRowStyle BackColor="#EAEEDF" />
 </asp:GridView>
 </td>
 </tr>
 
  <tr>
  <td></td>
  <td align="right" style="padding-right:20px;" >
  <asp:Button ID="btnsaveGriddata" runat ="server" Width="80px"  CssClass="styled-button-8" Height="36px" Text="Save" 
          onclick="btnsaveGriddata_Click" />
  </td>
  </tr>
  </table>
  </div>
</asp:Content>


