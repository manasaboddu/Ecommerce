<%@ Page Title="Online Gems" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row">
            
            <div class="col-md-12 col-lg-12 pad0">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <img src="images/b1.jpg" alt="Chania" width="100%">
                        </div>
                        <div class="item">
                            <img src="images/b2.jpg" alt="Chania" width="100%">
                        </div>
                        <div class="item">
                            <img src="images/b3.jpg" alt="Flower" width="100%">
                        </div>
                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span><span class="sr-only">
                                Previous</span> </a><a class="right carousel-control" href="#myCarousel" role="button"
                                    data-slide="next"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true">
                                    </span><span class="sr-only">Next</span> </a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12 container-fluid padr0">
          

           <marquee SCROLLDELAY="100"> <asp:Label ID="lblOffers" runat="server" ></asp:Label></marquee>
        </div>
        <div class="col-md-12 pad0">
        <div class="row" style="width:100%;">
        <%--<div class="col-lg-2 col-md-3  pad0">
                <div class="list-group">
                    <a href="#" class="list-group-item"><strong>CATEGORIES</strong> </a>
                    <asp:GridView ID="PCGridView" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeader="false" ShowFooter="false"
                        GridLines="None" OnRowCommand="PCGridView_RowCommand" OnPageIndexChanged="PCGridView_SelectedIndexChanged"
                        DataKeyNames="ProductCategoryID">
                        <EmptyDataTemplate>
                            
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("ProductCategoryID")%>' />
                                    
                                    <asp:LinkButton ID="lnkbtnproductcategory" class="list-group-item" runat="server"
                                        Text='<%#Eval("ProductCategoryName") %>' CommandArgument='<%#Eval("ProductCategoryID")%>'
                                        CommandName="GetProducts"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                </div>
            </div>--%>
            <div class="col-lg-12 col-md-9  pad0">
            <div class="product-model-sec" style="width:98%;">
                <h3>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblsectionhead" runat="server" Text="PRODUCTS"></asp:Label></h3>
                <asp:HiddenField ID="HiddProductCategoryID" runat="server" Value='<%# Eval("ProductCategoryID") %>' />
                <div class="row">
                    <div id="no-more-tables">
                        <asp:DataList ID="datalistproducts" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                            OnItemCommand="datalistproducts_ItemCommand" CssClass="col-md-12  table-striped table-condensed cf grdBackColor" OnItemDataBound="datalistproducts_ItemDataBound">
                            <ItemTemplate>
                                <div class="">
                                    <div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
                                        <div class="new-top" align="center">
                                            <a href="ProductInnerPage.aspx">
                                                <asp:ImageButton ID="img1" CssClass="img-responsive" Height="250px" Width="250px"
                                                    CommandName="imageprodutdetails" CommandArgument='<%#Eval("ProductID") %>' runat="server"
                                                    ImageUrl='<%# Eval("PicturePath") %>' />
                                            </a>
                                            <div class="new-text">
                                                <ul>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" class='viewdetails' CommandName="produtdetails"
                                                            CommandArgument='<%#Eval("ProductID") %>'>View Details</asp:LinkButton>
                                                    </li>
           
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton2" CssClass="item_add" runat="server" class='addtocartbutton'
                                                            CommandName="AddtoCart" CommandArgument='<%#Eval("ProductID") %>'>Add To Cart</asp:LinkButton></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="new-bottom" style="height: 75px;">
                                            <a class="name" href="ProductInnerPage.aspx">
                                                <asp:LinkButton ID="linkbtnpname" CommandName="productdetails" runat="server" Text='<%#Eval("ProductName") %>'
                                                    CommandArgument='<%#Eval("ProductID") %>'></asp:LinkButton></a>
                                            <div class="ofr">
                                                
                                                <p>
                                                    <asp:Label CssClass="item_price"  runat="server" ID="lblNewPrice"></asp:Label>
                                                    <asp:LinkButton ID="lblprice" Font-Underline="false"
                                                        runat="server" CommandName="productcostdetails" CommandArgument='<%#Eval("ProductID") %>' CssClass="item_price"
                                                        Text='<%# Eval("CountryPrice")%>'  ></asp:LinkButton>$
                                                       <asp:Label runat="server" ID="lblOffer" ForeColor="BlueViolet" Font-Size="Smaller"></asp:Label>
                                                </p>
                                             
                                            </div>
                                            <asp:HiddenField runat="server" ID="HiddenField2" Value='<%#Eval("ProductID") %>' />
                                            <asp:HiddenField runat="server" ID="hdnProductId" Value='<%#Eval("ProductID") %>' />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        
                    </div>
                </div>
            </div>
            <!--//row-->
            </div>
        </div></div>
        <!--//12-->
    </div>
    <span style="font-family: Arial; font-size: small; color: red; text-align: center;">
        <asp:Label ID="lblmessage" runat="server" Text="" Style="margin-left: 200px;" Font-Bold="true"></asp:Label></span>
   
    
</asp:Content>
