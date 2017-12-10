<%@ Page Title="Products" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="Product.aspx.cs"
    Inherits="Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <script type="text/javascript">

        function isNumberKey(evt) {
            var charCode = (evt.charCode) ? evt.which : event.keyCode


            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;
            else {
                var input = document.getElementById("txtgemsize").value;
                var len = document.getElementById("txtgemsize").value.length;
                var index = document.getElementById("txtgemsize").value.indexOf('.');

                if (index > 0 && charCode == 46) {
                    return false;
                }
                if (index > 0 || index == 0) {
                    var CharAfterdot = (len + 1) - index;
                    if (CharAfterdot > 2) {

                        return false;
                    }

                }

                if (charCode == 46 && input.split('.').length > 1) {
                    return false;
                }


            }
            return true;
        }
        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32 || charCode == 8)
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }
    </script>
    <div class="clearfix">
    </div>
            <div id="DivMsg" runat="server" style="display: none;width:100%;" align="center" class="stdMainMsg">
                        <asp:Label ID="lblMsg" runat="server" Text="Record Saved Successfully !" ForeColor="Green"></asp:Label>
            </div>
    <div class="container" style="vertical-align: middle;">
        <div class="col-lg-12" style="padding-top: 2%;">
            <div class="form-group">
                <div class="col-lg-1" style="text-align: left; padding-top: 0.5%; font-size: 12px;">
                    Category
                </div>
                <div class="col-lg-3">
                    <asp:DropDownList ID="ddlpcategorylist" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <cc1:CascadingDropDown ID="CascadingDropDownPClist" runat="server" TargetControlID="ddlpcategorylist"
                        PromptText="Select Product Category" PromptValue="-1" ServicePath="~/WebService.asmx"
                        ServiceMethod="GetPCategories" Category="ProductCategoryID" LoadingText="Loading..." />
                </div>
                <div class="col-lg-1" style="text-align: left; padding-top: 0.5%; font-size: 12px;">
                    Product
                </div>
                <div class="col-lg-3">
                    <asp:DropDownList ID="ddlproductlist" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <cc1:CascadingDropDown ID="CascadingDropDownPlist" runat="server" TargetControlID="ddlproductlist"
                        PromptText="Select Product" PromptValue="-1" ServicePath="~/WebService.asmx"
                        ServiceMethod="GetPCategories" Category="ProductID" ParentControlID="ddlpcategorylist"
                        LoadingText="Loading..." />
                </div>
                <div class="col-lg-1">
                    <asp:Button ID="BtnGo" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="BtnGo_Click" />
                </div>
                <div class="col-lg-2">
                </div>
                <div class="col-lg-1">
                ADD <asp:ImageButton ID="linkaddproduct" Height="27px" runat="server" ImageUrl="~/Images/icons/add_imageicon.png" />
                </div>
            </div>
        </div>
        
        <table align="center" width="98%">
            <tr>
                <td colspan="2">
                    <%--<asp:HiddenField ID="hiddenpid" runat="server" />--%>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%"
                        CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand"
                        DataKeyNames="ProductCategoryID">
                        <EmptyDataTemplate>
                            <div style="color: Red; font-size: 12px;">
                                <span>No Data Found!!!</span>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                <ItemStyle Width="5%" CssClass="ItemRow1" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Category Name" >
                                <ItemTemplate >
                                    <asp:Label ID="lblpcn" runat="server" Text='<%#Eval("ProductCategoryName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="25%" CssClass="HeaderRow1" />
                                <ItemStyle Width="25%" CssClass="ItemRow1" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblpn" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="36%" CssClass="HeaderRow1" />
                                <ItemStyle Width="36%" CssClass="ItemRow1" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("ProductCategoryID")%>' />
                                    <span style="padding-top: 2px;">
                                        <asp:ImageButton ID="btnEdit" runat="server" Height="27px" ImageUrl="~/Images/icons/edit_image icon.png"
                                            CommandArgument='<%#Eval("ProductID") %>' CommandName="EditProduct" /></span>
                                   
                                </ItemTemplate>
                                <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                <ItemStyle Width="5%" CssClass="ItemRow1" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("ProductCategoryID")%>' />
                                    <span style="padding-top: 2px;">
                                        <asp:ImageButton ID="btnDelete" runat="server" Height="27px" OnClientClick="return confirm('Are you sure you want to delete this Record?');"
                                            ImageUrl="~/Images/icons/delete_imageicon.png" CommandArgument='<%#Eval("ProductID") %>'
                                            CommandName="DeleteProduct" /></span>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" CssClass="HeaderRow1" />
                                <ItemStyle Width="5%" CssClass="ItemRow1" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="Add Specification">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hidenpcid" runat="server" Value='<%#Eval("ProductCategoryID") %>' />
                                    <span style="padding-top: 2px;">
                                        <asp:ImageButton ID="plusimage1" runat="server" Height="30px" CommandName="Addspec"
                                            CausesValidation="false" ImageUrl="~/Images/icons/plus1.png" CommandArgument='<%#Eval("ProductID") %>' /></span>
                                </ItemTemplate>
                                <HeaderStyle Width="14%" CssClass="HeaderRow1" />
                                <ItemStyle Width="14%" CssClass="ItemRow1" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Add Image">
                                <ItemTemplate>
                                    <span style="padding-top: 2px;">
                                        <asp:ImageButton ID="addimage" runat="server" Height="30px" CommandName="Addimage"
                                            CausesValidation="false" ImageUrl="~/Images/icons/plus1.png" CommandArgument='<%#Eval("ProductID") %>' /></span>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" CssClass="HeaderRow1" />
                                <ItemStyle Width="10%" CssClass="ItemRow1" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle ForeColor="#000099" Width="5px" />
                        <RowStyle BackColor="#F2F6F9" />
                        <AlternatingRowStyle BackColor="#EAEEDF" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="3" rowspan="2">
                    <asp:Panel ID="Panel1" runat="server" Style="height: auto; display:none;" Width="510px" CssClass="modalPopup">
                        <cc1:ModalPopupExtender ID="mpelinkaddproduct" runat="server" PopupControlID="Panel1"
                            TargetControlID="linkaddproduct" CancelControlID="btnNo" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                        <div class="header" style="background-color: #11A7A1; font-size: large;">
                            Add Component
                        </div>
                        <div style="padding-top: 1%;">
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="col-lg-4">
                                        Product Category Name
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:DropDownList ID="ddlproductcategory" runat="server" CssClass="form-control">                                         
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="col-lg-4">
                                        ProductName
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtproductname" runat="server" CssClass="form-control" onkeypress="return onlyAlphabets(event,this);"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                            ForeColor="Red" ValidationGroup="vgPanel1" ControlToValidate="txtproductname"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="col-lg-4">
                                        Description
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtdescription" runat="server" CssClass="form-control" onkeypress="return onlyAlphabets(event,this);" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-top: 2%;">
                                    <div class="col-lg-4">
                                         Size
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="txtgemsize" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-top: 2%;">
                                    <div class="col-lg-4">
                                        Price
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="textproductprice" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-top: 2%;">
                                    <div class="col-lg-4">
                                        DeliveryCharges
                                    </div>
                                    <div class="col-lg-8">
                                        <asp:TextBox ID="textdeliverycharges" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12" style="padding-top: 2%;">
                                    <div class="col-lg-6" style="text-align: right;">
                                        <asp:Button ID="btnYes" runat="server" CssClass="btn btn-success" OnClick="btnYes_Click"
                                            ValidationGroup="vgPanel1" Text="Save" />
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
        <table align="center">
            <tr>
                <td class="style1" colspan="3" rowspan="2">
                    <asp:Panel ID="UpdatePanel" runat="server" Style="display:none;" Width="486px" CssClass="modalPopup">
                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text=""></asp:LinkButton>
                        <cc1:ModalPopupExtender ID="mpebtnEdit" runat="server" PopupControlID="UpdatePanel"
                            CancelControlID="BtnCan" TargetControlID="lnkbtnUpdate" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                        <div class="header" style="background-color: #11A7A1; font-size: large;">
                            Update Product
                        </div>
                        <div class="body">
                            <div style="padding-top: 1%;">
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4" style="text-align: left;">
                                            Product Category Name
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:DropDownList ID="ddlProductCategoryu" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4" style="text-align: left;">
                                            ProductName
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextProductName" runat="server" CssClass="form-control" onkeypress="return onlyAlphabets(event,this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                ForeColor="Red" ValidationGroup="vgUpdate" ControlToValidate="TextProductName"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                               
                                <div class="form-group">
                                    <div class="col-lg-12">
                                        <div class="col-lg-4" style="text-align: left;">
                                            Description
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="TextDescription" runat="server" CssClass="form-control" onkeypress="return onlyAlphabets(event,this);" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding-top: 2%;">
                                        <div class="col-lg-4" style="text-align: left;">
                                            Gem Size
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="textGemSize" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding-top: 2%;">
                                        <div class="col-lg-4" style="text-align: left;">
                                            Price
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="txtproductprice" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding-top: 2%;">
                                        <div class="col-lg-4" style="text-align: left;">
                                            DeliveryCharges
                                        </div>
                                        <div class="col-lg-8">
                                            <asp:TextBox ID="txtdeliverycharges" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding-top: 2%;">
                                        <div class="col-lg-6" style="text-align: right;">
                                            <asp:Button ID="BtnUpdate" runat="server" ValidationGroup="vgUpdate" CssClass="btn btn-success"
                                                Text="Update" OnClick="BtnUpdate_Click" />
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:Button ID="btnCan" runat="server" CssClass="btn btn-danger" Text="Cancel" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-12" style="padding-top: 2%;">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
                     <div class="clearfix"></div>
 <div style="padding-bottom:7%;"></div>
</asp:Content>
