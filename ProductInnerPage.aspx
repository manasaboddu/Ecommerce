<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true"
    CodeFile="ProductInnerPage.aspx.cs" Inherits="ProductInnerPage" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/jquery.etalage.min.js"></script>
    <script>
        jQuery(document).ready(function ($) {

            $('#etalage').etalage({
                thumb_image_width: 300,
                thumb_image_height: 400,
                source_image_width: 900,
                source_image_height: 1200,
                show_hint: true,
                click_callback: function (image_anchor, instance_id) {
                    alert('Callback example:\nYou clicked on an image with the anchor: "' + image_anchor + '"\n(in Etalage instance: "' + instance_id + '")');
                }
            });

        });


    </script>
 
    <asp:HiddenField ID="hdnvideopath" runat="server" Value="" />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8" style="background-color: #FFFFFF;">
                <div class=" single_top">
                    <div class="single_grid">
                        <div class="grid images_3_of_2">
                            <asp:PlaceHolder ID="PlhThumbimg" runat="server"></asp:PlaceHolder>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="desc1 span_3_of_2">
                                <asp:DataList ID="datalistfzimages" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                    OnItemDataBound="datalistfzimages_ItemDataBound">
                                    <ItemTemplate>
                                        <h4>
                                            <asp:Label ID="lblprname" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                                        </h4>
                                        <div class="cart-b">
                                            <div class="left-n ">
                                                
                                                <asp:Label ID="lblprc" runat="server" Text='<% #Eval("CountryPrice")%>'></asp:Label>
                                            </div>
                                          
                                            <div class="clearfix">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>

                                <br>
                                <div class="share">
                                    <h5>
                                        Share Product :</h5>
                                    <ul class="share_nav">
                                        <li><a href="#">
                                            <img src="images/facebook.png" title="facebook"></a></li>
                                        <li><a href="#">
                                            <img src="images/twitter.png" title="Twiiter"></a></li>
                                        <li><a href="#">
                                            <img src="images/rss.png" title="Rss"></a></li>
                                        <li><a href="#">
                                            <img src="images/gpluse.png" title="Google+"></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                    </div>
                    
                </div>
            </div>
            <div class="col-md-4">
                <div class="cart-b">
                    <h3 style="margin: 5px;">
                        General Specifications
                    </h3>
                </div>
                <asp:PlaceHolder ID="PLH" runat="server"></asp:PlaceHolder>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
 
</asp:Content>
