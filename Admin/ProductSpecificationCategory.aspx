<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="ProductSpecificationCategory.aspx.cs"
    Inherits="Admin_ProductSpecificationCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <style>
        .pagination1
        {
            line-height: 30px;
        }
        .pagination1 span
        {
            padding: 5px;
            border: solid 1px #14C9EC;
            text-decoration: none;
            white-space: nowrap;
            background: White;
            border-radius: 10px;
        }
        .pagination1 a, .pagination1 a:visited
        {
            text-decoration: none;
            padding: 6px;
            white-space: nowrap;
            color: #142F8A;
        }
        .pagination1 a:hover, .pagination1 a:active
        {
            padding: 5px;
            border: solid 1px gray;
            text-decoration: none;
            white-space: nowrap;
            background: #14C9EC;
            color: White;
            border-radius: 10px;
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
                Category
                </div>
                <div class="col-lg-6">
                <asp:DropDownList ID="ddlPCname" runat="server" CssClass="form-control">
                    </asp:DropDownList> 
                </div>
                <div class="col-lg-1">
                <asp:Button ID="BtnGo" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="BtnGo_Click" />
                </div>
                <div class="col-lg-3"></div>
                </div>
                    
                
                    
                </div>
                <div class="col-lg-5">
                    
                </div>
                <div class="col-lg-1">
                    ADD <asp:ImageButton ID="linkaddspec" Height="27px" runat="server" ImageUrl="~/Images/icons/add_imageicon.png" />
                </div>
            
        </div>
        <div>            
            <table align="center" width="98%">
                <tr>
                    <td colspan="3">
                        <%--<asp:HiddenField ID="hiddenpid" runat="server" />--%>
                        <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle-BackColor="#EAEEDF"
                            AutoGenerateColumns="false" Width="100%" CellPadding="4" ForeColor="#333333"
                            GridLines="None" DataKeyNames="ProductCategoryID" OnRowCommand="GridView1_RowCommand"
                            AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_OnPageIndexChanging">
                            <PagerStyle HorizontalAlign="right" CssClass="pagination1" />
                            <EmptyDataTemplate>
                                <div style="color: Red; font-size: 12px;">
                                    <span>No Data Found!!!</span>
                                </div>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="S. No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                    <ItemStyle Width="5%" CssClass="ItemRow1" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ProductName">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelPCName" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="40%" CssClass="HeaderRow1" />
                                    <ItemStyle Width="40%" CssClass="ItemRow1" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Specification Category Name">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelSpecName" runat="server" Text='<%#Eval("SpecificationCategoryName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="45%" CssClass="HeaderRow1" />
                                    <ItemStyle Width="45%" CssClass="ItemRow1" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <span style="padding-top: 2px;">
                                            <asp:ImageButton ID="BtnEdit" ImageUrl="~/Images/icons/edit_image icon.png" runat="server"
                                                Width="27px" CausesValidation="false" CommandName="ButtonEdit" CssClass="yes"
                                                CommandArgument='<%#Eval("SpecificationCategoryID") %>' /></span>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                    <ItemStyle Width="5%" CssClass="ItemRow1" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <span style="padding-top: 2px;">
                                            <asp:ImageButton ID="BtnDelete" OnClientClick="return confirm('Are you sure you want to delete this Record?');"
                                                ImageUrl="~/Images/icons/delete_imageicon.png" runat="server" Width="27px" CausesValidation="false"
                                                CommandName="ButtonDelete" CssClass="yes" CommandArgument='<%#Eval("SpecificationCategoryID")%>' /></span>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                    <ItemStyle Width="5%" CssClass="ItemRow1" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="style1" colspan="3" rowspan="2">
                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"
                            TargetControlID="linkaddspec" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="Panel1" runat="server" Style="height: auto; display:none;" Width="486px" CssClass="modalPopup">
                            <div class="header" style="background-color: #11A7A1;">
                                Add Specification Category
                            </div>
                            <div style="padding-top: 1%;">
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding: 0%;padding-top: 2%;">
                                        <div class="col-lg-6">
                                            Product Category Name
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:DropDownList ID="ddlproductcategory" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                            <cc1:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlproductcategory"
                                                PromptText="--Select Product Category--" PromptValue="" ServicePath="~/WebService.asmx"
                                                ServiceMethod="GetCategories" Category="ProductCategoryID" LoadingText="Loading..." />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding: 0%;padding-top: 2%;">
                                        <div class="col-lg-6">
                                            Product Name
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:DropDownList ID="ddlproducts" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                            <cc1:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlproducts"
                                                PromptText="--Select Product--" PromptValue="" ParentControlID="ddlproductcategory"
                                                ServicePath="~/WebService.asmx" ServiceMethod="GetCategories" Category="ProductID"
                                                LoadingText="Loading..." />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12"  style="padding: 0%;padding-top: 2%;">
                                        <div class="col-lg-6">
                                            Specification Category Name
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtsmastername" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red"
                                                ValidationGroup="vgsave" ControlToValidate="txtsmastername"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding-top: 2%;">
                                        <div class="col-lg-6" style="text-align: right;">
                                            <asp:Button ID="btnYes" runat="server" CssClass="btn btn-success" Text="Save" ValidationGroup="vgsave"
                                                OnClick="btnYes_Click" />
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:Button ID="btnNo" runat="server" CssClass="btn btn-danger" Text="Cancel" />
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
        <table align="center">
            <tr align="center">
                <td class="style1" colspan="3" rowspan="2">
                    <asp:Panel ID="UpdatePanel" runat="server" Style="height: auto; display:none;" Width="486px" CssClass="modalPopup">
                        <asp:LinkButton ID="lnkBtnmpe" runat="server" Text=""></asp:LinkButton>
                        <cc1:ModalPopupExtender ID="mpeUpdate" TargetControlID="lnkBtnmpe" PopupControlID="UpdatePanel"
                            CancelControlID="BtnCancel" runat="server" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                        <div class="header" style="background-color: #11A7A1;">
                            Update Specification Category
                        </div>
                        <div style="padding-top: 1%;">
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <div class="col-lg-12" style="padding: 0%;">
                                    <div class="col-lg-6" style="text-align:left;">
                                        Product Name
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="Textpcname" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Textpcname"
                                            runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgupdate"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="padding: 0%;">
                                    <div class="col-lg-6" style="text-align:left;">
                                        Specification Category Name
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:TextBox ID="TextSpecMname" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            ForeColor="Red" ValidationGroup="vgupdate" ControlToValidate="TextSpecMname"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="col-lg-6" style="text-align: right;">
                                        <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-success" Text="Update"
                                            ValidationGroup="vgupdate" OnClick="BtnUpdate_Click" />
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" />
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
        <div class="clearfix">
        </div>
        <div style="padding-bottom: 7%;">
        </div>
</asp:Content>
