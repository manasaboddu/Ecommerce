<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master"
    AutoEventWireup="true" CodeFile="ProductCategory.aspx.cs" Inherits="ProductCategory"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <style type="text/css">

        
 
        
        .styled-button-7
        {
            background: #A2BCD8;
            background: -moz-linear-gradient(top,#A2BCD8 0%,#A2BCD8 A2BCD8%);
            background: -webkit-gradient(linear,left top,left bottom,color-stop(0%,#25A6E1),color-stop(100%,#188BC0));
            background: -webkit-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
            background: -o-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
            background: -ms-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
            background: linear-gradient(top,#25A6E1 0%,#188BC0 100%);
            -webkit-filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#25A6E1',endColorstr='#188BC0',GradientType=0);
            -moz-filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#25A6E1',endColorstr='#188BC0',GradientType=0);
            padding: 8px 13px;
            color: #fff;
            font-family: Arial;
            font-size: 17px;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border: 1px solid #1A2BCD8;
        }
        
        .stdMainMsg
{
width:995px;height:25px; margin-top:10px; padding-top:5px;text-align:center;background-color:#F1EFE2;color:#000; font-size:13px;font-weight:bold;border-radius:10px; 
}
    </style>
    <div class="clearfix">
    </div>
        <div id="DivMsg" runat="server" style="display: none;width:100%;" class="stdMainMsg">
                        <asp:Label ID="lblMsg" runat="server" Text="Record Saved Successfully !"></asp:Label>
            </div>
    <div class="container" style="vertical-align: middle;">
        <div class="col-lg-12" style="padding-top: 2%;">
            
                <div class="col-lg-6" style="text-align: right; padding-top: 0.5%; font-size: medium;">
                <div class="col-lg-12" style="padding: 0%;">
                <div class="col-lg-2" style="text-align: right; padding-top: 0.5%; font-size: 12px;">
                Search
                </div>
                <div class="col-lg-6">
                <asp:DropDownList ID="ddlPCategorytypes" runat="server" CssClass="form-control">
                    </asp:DropDownList>    
                </div>
                <div class="col-lg-1">
                <asp:Button ID="BtnGo" runat="server" CssClass="btn btn-primary" Text="Go" OnClick="BtnGo_Click" />
                </div>
                <div class="col-lg-3"></div>
                </div>
                    
                
                    
                </div>
                <div class="col-lg-5">
                    
                </div>
                <div class="col-lg-1">
                    ADD <asp:ImageButton ID="linkaddproductcategory" Height="27px" runat="server" ImageUrl="~/Images/icons/add_imageicon.png" />
                </div>
            
        </div>
        <table align="center" width="98%">
           
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="GridProdCategery" runat="server" AutoGenerateColumns="false" Width="100%"
                        CellPadding="4" ForeColor="#333333" GridLines="Both" OnRowCommand="GridProdCategery_RowCommand">
                        <EmptyDataTemplate>
                            <div style="color: Red; font-size: 12px;">
                                <span style="text-align: center">No Data Found!!!</span>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                <ItemStyle Width="5%" CssClass="ItemRow1" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Category Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblpcn" runat="server" Text='<%#Eval("ProductCategoryName")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="40%" CssClass="HeaderRow1" />
                                <ItemStyle Width="40%" CssClass="ItemRow1" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblpn" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="45%" CssClass="HeaderRow1" />
                                <ItemStyle Width="45%" CssClass="ItemRow1" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <span style="padding-top: 2px;">
                                        <asp:ImageButton ID="btnedit" ImageUrl="~/Images/icons/edit_image icon.png" runat="server"
                                            Width="27px" CausesValidation="false" CommandName="EditPcategory" CssClass="yes"
                                            CommandArgument='<%#Eval("ProductCategoryID")%>' /></span>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                <ItemStyle Width="5%" CssClass="ItemRow1" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <span style="padding-top: 2px;">
                                        <asp:ImageButton ID="btndelete" OnClientClick="return confirm('Are you sure you want to delete this Record?');"
                                            ImageUrl="~/Images/icons/delete_imageicon.png" runat="server" Width="27px" CausesValidation="false"
                                            CommandName="DeletePcategory" CssClass="yes" CommandArgument='<%#Eval("ProductCategoryID")%>' /></span>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                <ItemStyle Width="5%" CssClass="ItemRow1" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#F2F6F9" />
                        <AlternatingRowStyle BackColor="#EAEEDF" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                    <asp:Panel ID="SavePanel" runat="server" Style="height: auto; display: none;" Width="35%"
                        CssClass="modalPopup">
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="SavePanel"
                            TargetControlID="linkaddproductcategory" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                        <div class="header" style="background-color: #11A7A1; font-size: large;">
                            Add Product Category
                        </div>
                        <div style="padding-top: 2%;">
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <div class="col-lg-4">
                                    Product Category Name
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtprodcatname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                        ForeColor="Red" ControlToValidate="txtprodcatname" ValidationGroup="vgSavePanel"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4">
                                    Description
                                </div>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtprodcatdescri" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-4">
                                </div>
                                <div class="col-lg-8">
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <div class="col-lg-6" style="text-align: right;">
                                    <asp:Button ID="BtnSave" ValidationGroup="vgSavePanel" runat="server" CssClass="btn btn-success"
                                        OnClick="BtnSave_Click" Text="Save" />
                                </div>
                                <div class="col-lg-6">
                                    <asp:Button ID="btnNo" CssClass="btn btn-danger" runat="server" Text="Cancel" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                </div>
                                <div class="col-lg-6">
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table align="center">
            <tr>
                <td class="style1" colspan="3">
                    <asp:Panel ID="PanelUpdate" runat="server" Style="height: auto; display: none;" Width="486px"
                        CssClass="modalPopup">
                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text=""></asp:LinkButton>
                        <cc1:ModalPopupExtender ID="mpeUpdate" CancelControlID="BtnCancel" BackgroundCssClass="modalBackground"
                            PopupControlID="PanelUpdate" TargetControlID="lnkbtnUpdate" runat="server">
                        </cc1:ModalPopupExtender>
                        <div class="header" style="background-color: #11A7A1; font-size: large;">
                            Update Product Category
                        </div>
                        <div style="padding-top: 1%;">
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="col-lg-4" style="text-align: left;">
                                        Product Category Name
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextPcname" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            ForeColor="Red" ControlToValidate="TextPcname" ValidationGroup="vgPanelUpdate"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="col-lg-4" style="text-align: left;">
                                        Description
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="TextDesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-top: 2%;">
                                    <div class="col-lg-6" style="text-align: right;">
                                        <asp:Button ID="BtnUpdate" CssClass="btn btn-success" ValidationGroup="vgPanelUpdate"
                                            CausesValidation="false" runat="server" Text="Update" OnClick="BtnUpdate_Click1" />
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger" Height="33px" runat="server"
                                            Width="90px" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-top: 2%;">
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
 <div style="padding-bottom:7%;"></div>
         <div class="clearfix"></div>
</asp:Content>
