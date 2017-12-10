<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master"
    AutoEventWireup="true" CodeFile="ProductPictures.aspx.cs" Inherits="ProductPictures"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <script>
        function ShowHideDiv() {

            document.getElementById("ContentPlaceHolderBody_lblmsge").innerHTML = '';
            document.getElementById("ContentPlaceHolderBody_txtvideolinkpath").value = '';

            var Video = document.getElementById("Video");
            var divappname = document.getElementById("divimage");
            divappname.style.display = no.checked ? "block" : "none";
            var Image = document.getElementById("Image");
            var div = document.getElementById("divvideo");
            div.style.display = yes.checked ? "block" : "none";

            // document.getElementById("ContentPlaceHolderBody_lblmsg").value = '';
            //        var gobtn = document.getElementById("ContentPlaceHolderBody_imgbtnGo")
            //        gobtn.style.display = "block";


        }

        function validateSave() {


            if (document.getElementById("ContentPlaceHolderBody_txtvideolinkpath").value == "") {
                alert("Please Enter Video Link Path");
                return false;
            }

        }
    </script>
    <div>
        <br />
    </div>
    <div>
        <table style="text-align: center; width: 70%;">
            <tr>
                <td colspan="2" style="text-align: center; color: Red; font-family: Arial; font-size: small;">
                    <asp:Label ID="lblmsge" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
            <tr id='trappnoyn' runat="server">
                <td style="text-align: right;">
                    Please Select Upload File Type:
                </td>
                <td style="width: 50%; vertical-align: top; padding-left: 10px; text-align: left;"
                    align="left">
                    <label for="no">
                        <input type="radio" id="no" name="chkapplicant" onclick="ShowHideDiv()" />
                        Image
                    </label>
                    <label for="yes">
                        <input type="radio" id="yes" name="chkapplicant" onclick="ShowHideDiv()" />
                        Video
                    </label>
                </td>
            </tr>
        </table>
    </div>
    <div id="divimage" style="display: none;">
        <h3 align="center" style="font-family: Arial; font-size: medium; font-style: normal;
            color: #0E59AB;">
            Add Product Image Below</h3>
        <table align="center" style="padding-left: 200px; width: 100%;">
            <%--  <tr>
<td>ProductID:</td>
<td><asp:TextBox ID="txtproductid" runat="server"></asp:TextBox></td>
</tr>--%>
            <tr>
                <td style="width: 100px;">
                </td>
                <td style="padding-top: 20px; font-family: Arial; font-size: medium; font-style: normal;
                    color: #0E5AAB; text-align: right; width: 200px;">
                    Select ProductImage:
                </td>
                <td style="padding-right: 100px;" align="left">
                    <cc1:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="jpg,jpeg,png,gif"
                        MaximumNumberOfFiles="10" Width="500px" OnUploadComplete="AjaxFileUpload1_UploadComplete" />
                    <%--      <asp:FileUpload ID="File1" runat="server" >
        </asp:FileUpload>--%>
                    <%--  <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click">
      </asp:Button>--%>
                    <%--<asp:Label ID="Label1" runat="server" Text="">
</asp:Label>--%>
                    <%--<asp:Image ID="Img" runat="server"/>--%>
                </td>
            </tr>
            <tr>
                <td style="width: 150px;">
                </td>
                <td>
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </td>
                <td style="padding-left: 100px; padding-top: 10px; width: 200px;" align="left">
                    <asp:Button ID="btnsave" Text="Save" CssClass="styled-button-8" Height="33px" Width="90px"
                        runat="server" OnClick="btnsave_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <%--<asp:Label ID="lblmsg" runat="server"></asp:Label>--%>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <div id="fileupload">
            <table align="center">
                <tr>
                    <td>
                        <div>
                            <asp:DataList ID="DatalistPimage" runat="server" BackColor="Info" BorderColor="#666666"
                                BorderStyle="None" ForeColor="Black" RepeatDirection="Horizontal" CellSpacing="1"
                                OnItemCommand="DatalistPimage_ItemCommand" Visible="false">
                                <ItemTemplate>
                                    <div id="cssmenu1">
                                        <asp:ImageButton ID="productimage" runat="server" Width="100px" Height="150px" ImageUrl='<%# Eval("PicturePath") %>'
                                            Style="padding-top: 3px; padding-bottom: 3px; padding-left: 3px; padding-right: 3px;"
                                            CausesValidation="false" />
                                        <asp:HiddenField ID="hdnproductid" runat="server" Value='<%# Eval("ProductID") %>' />
                                        <asp:LinkButton ID="linkremove" runat="server" CommandName="Removes" CommandArgument='<%# Eval("ProductPictureID") %>'>
                                            <img id="logoimage" runat="server" src="~/Images/icons/Close_Box_Red.png" style="width: 10px;
                                                height: 10px; vertical-align: top;" />
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:DataList ID="DatalistThumb" runat="server" BackColor="Info" BorderColor="#666666"
                                BorderStyle="None" ForeColor="Black" RepeatDirection="Horizontal" CellSpacing="1"
                                OnItemCommand="DatalistThumb_ItemCommand">
                                <ItemTemplate>
                                    <div id="cssmenu1">
                                        <asp:ImageButton ID="productthumbimage" runat="server" Width="100px" Height="150px"
                                            ImageUrl='<%# Eval("PictureThumbPath") %>' Style="padding-top: 3px; padding-bottom: 3px;
                                            padding-left: 3px; padding-right: 3px;" CausesValidation="false" />
                                        <asp:HiddenField ID="hdnproductid" runat="server" Value='<%# Eval("ProductPictureID") %>' />
                                        <asp:LinkButton ID="linkremove" runat="server" CommandName="Remove" CommandArgument='<%# Eval("PictureThumbnailsID") %>'>
                                            <img id="logoimage" runat="server" src="~/Images/icons/Close_Box_Red.png" style="width: 10px;
                                                height: 10px; vertical-align: top;" />
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="divvideo" style="display: none;">
        <div class="col-lg-12" style="padding-top: 2%;">
            <div class="form-group">
                <div class="col-lg-5" style="text-align: right; padding-top: 0.5%; font-size: 12px;">
                    Enter Video Link Path <span style="color: Red;">*</span>
                </div>
                <div class="col-lg-3">
                    <asp:TextBox ID="txtvideolinkpath" CssClass="form-control" runat="server" Text=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ForeColor="Red" ValidationGroup="vgPanel1" ControlToValidate="txtvideolinkpath"></asp:RequiredFieldValidator>
                </div>
                <div class="col-lg-4">
                    <asp:Button ID="BtnGo" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSaveVideopath_Click"
                        OnClientClick="return validateSave();" ValidationGroup="vgPanel1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
