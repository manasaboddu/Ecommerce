<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true"
    CodeFile="ProductPage.aspx.cs" Inherits="ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function MutExChkList(chk) {
            var chkList = chk.parentNode.parentNode.parentNode;
            var chks = chkList.getElementsByTagName("input");
            for (var i = 0; i < chks.length; i++) {
                if (chks[i] != chk && chk.checked) {
                    chks[i].checked = false;
                }
            }

        }
        function MutExChkListprice(chk) {


            var chkList = chk.parentNode.parentNode.parentNode;
            var chks = chkList.getElementsByTagName("input");
            for (var i = 0; i < chks.length; i++) {
                //  alert('i value' + i);
                if (chks[i] != chk && chk.checked) {
                    chks[i].checked = false;
                }
            }
            $get('ContentPlaceHolder1_btncheck').click();
        }
    
    </script>
    <%--<asp:Button runat="server" ID="btncart" Style="display: none;" />--%>
    <asp:Button runat="server" ID="btncheck" OnClick="btncheck_Click" Style="display: none;" />
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2 col-md-3  pad0">
                <div class="list-group">
                    <a href="#" class="list-group-item"><strong>CATEGORIES</strong> </a>
                    <asp:CheckBoxList ID="CheckBoxList3" runat="server" class="list-group" Style="width: 100%;
                        color: #919191; font-weight: normal;">
                        <asp:ListItem Text="Pukhraj Yellow Sapphire" Value="33" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Neelam Blue Sapphire" Value="34" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Manik-Ruby Stone" Value="35" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Lapis Lazuli" Value="36" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Emerald" Value="37" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Tiger Eye GemStone" Value="38" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="SunStone GemsStone" Value="39" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Healing AgateStone" Value="40" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Tiger Eye Healling Stone" Value="41" class="list-group-item"
                            onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                    </asp:CheckBoxList>
                    <a href="#" class="list-group-item"><strong>PRICE RANGE</strong> </a>
                    <asp:CheckBoxList ID="CheckBoxList1" class="list-group" runat="server" Style="width: 100%;
                        color: #919191; font-weight: normal;">
                        <asp:ListItem Text="Rs.0-Rs.9999" Value="1" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Rs.10000-Rs.19999" Value="2" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Rs.20000-Rs.29999" Value="3" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Rs.30000-Rs.39999" Value="4" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="Rs.40000-Rs.49999" Value="5" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="More than Rs.50000" Value="6" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                    </asp:CheckBoxList>
                    <a href="#" class="list-group-item"><strong>GEM SIZE </strong></a>
                    <asp:CheckBoxList ID="CheckBoxList2" class="list-group" runat="server" Style="width: 100%;
                        color: #919191; font-weight: normal;">
                        <asp:ListItem Text="1 ct" Value="1" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="3 - 5 ct" Value="35" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="5 - 8 ct" Value="58" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="8 - 10 ct" Value="810" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="10 - 15 ct" Value="1015" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="15 - 20 ct" Value="1520" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                        <asp:ListItem Text="20 ct and Above" Value="20" class="list-group-item" onclick="MutExChkListprice(this);">
                        </asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="col-md-9 col-lg-10">
                <div class="row" style="padding-right: 20px;">
                    <asp:GridView ID="PcGridview" runat="server" AutoGenerateColumns="false" GridLines="None"
                        OnRowDataBound="PcGridview_RowDataBound" Font-Size="Medium">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <h3>
                                        &nbsp;&nbsp;
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ProductCategoryName") %>'></asp:Label></h3>
                                    <asp:HiddenField ID="HiddProductCategoryID" runat="server" Value='<%# Eval("ProductCategoryID") %>' />
                                    <asp:DataList ID="Datalist1" runat="server" RepeatColumns="5" OnItemCommand="Datalist1_ItemCommand"
                                        RepeatDirection="Horizontal" CssClass="col-md-12  table-striped table-condensed cf grdBackColor">
                                        <ItemTemplate>
                                            <div class="col-md-12 padr0">
                                                <div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
                                                    <div class="new-top" align="center">
                                                        <a href="ProductInnerPage.aspx">
                                                            <asp:ImageButton ID="img1" CssClass="img-responsive" Height="350px" Width="350px"
                                                                CommandName="imageprodutdetails" CommandArgument='<%#Eval("ProductID") %>' runat="server"
                                                                ImageUrl='<%# Eval("PicturePath") %>' />
                                                        </a>
                                                        <div class="new-text">
                                                            <ul>
                                                                <li>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" class='viewdetails' CommandName="produtdetails"
                                                                        CommandArgument='<%#Eval("ProductID") %>'>Quick View</asp:LinkButton></li>
                                              
                                                                <li>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="item_add" CommandName="AddtoCart"
                                                                        CommandArgument='<%#Eval("ProductID") %>'>ADD To Cart</asp:LinkButton></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                    <div class="new-bottom" style="height: 90px;">
                                                        <a class="name" href="ProductInnerPage.aspx">
                                                            <asp:LinkButton ID="linkbtnpname" CommandName="productdetails" runat="server" Text='<%#Eval("ProductName") %>'
                                                                ForeColor="#7BD1A9" CommandArgument='<%#Eval("ProductID") %>' Font-Underline="false"></asp:LinkButton>
                                                        </a>
                                                        <div class="ofr">
                                                            <!--	<p class="pric1"><del>$2000.00</del></p>-->
                                                            <p>
                                                                <span class="item_price"><asp:LinkButton ID="lblprice" Font-Underline="false"
                                                                    runat="server" CommandName="productcostdetails" CommandArgument='<%#Eval("ProductID") %>'
                                                                    ForeColor="#FF5200" Text='<%# Eval("CountryPrice")%>'></asp:LinkButton>
                                                                </span>
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <%--  <div class="row" style="padding-right:20px;">

 
  <h3 >
                 &nbsp;&nbsp;   Pukhraj Yellow Sapphire </h3>
 
            

<div class="col-md-3 padr0">
				<div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
					<div class="new-top" align="center">
						<a href="ProductInnerPage.aspx"><img src="images/g1.jpg" class="img-responsive" alt=""/></a>
						<div class="new-text">
							<ul>
								<li><a href="ProductInnerPage.aspx">Quick View </a></li>
								<li><input type="number" class="item_quantity" min="1" value="1"></li>
								<li><a class="item_add" href=""> Add to cart</a></li>
							</ul>
						</div>
					</div>
					<div class="new-bottom">
						<h5><a class="name" href="ProductInnerPage.aspx"> 7.17 Ct Natural Untreated Yellow Sapphire Gemstone</a></h5>
						
						<div class="ofr">
						<!--	<p class="pric1"><del>$2000.00</del></p>-->
							<p><span class="item_price"> Rs.6453/- </span></p>
						</div>
					</div>
				</div>
     </div>           
                
               
               
               
               
               
               <div class="col-md-3 padr0">
				<div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
					<div class="new-top" align="center">
						<a href="ProductInnerPage.aspx"><img src="images/g2.jpg" class="img-responsive"  alt=""/></a>
						<div class="new-text">
							<ul>
								<li><a href="ProductInnerPage.aspx">Quick View </a></li>
								<li><input type="number" class="item_quantity" min="1" value="1"></li>
								<li><a class="item_add" href=""> Add to cart</a></li>
							</ul>
						</div>
					</div>
					<div class="new-bottom">
						<h5><a class="name" href="ProductInnerPage.aspx"> 912 Carat Statue of Ganesha Tigher Eye Gemstone</a></h5>
						
						<div class="ofr">
<!--							<p class="pric1"><del>$2000.00</del></p>
-->							<p><span class="item_price"> Rs.6453/- </span></p>
						</div>
					</div>
				</div>
     </div>
     
     
     
     
               
 
   
               <div class="col-md-3 padr0">
				<div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
					<div class="new-top" align="center">
						<a href="ProductInnerPage.aspx"><img src="images/g3.jpg" class="img-responsive"  alt=""/></a>
						<div class="new-text">
							<ul>
								<li><a href="ProductInnerPage.aspx">Quick View </a></li>
								<li><input type="number" class="item_quantity" min="1" value="1"></li>
								<li><a class="item_add" href=""> Add to cart</a></li>
							</ul>
						</div>
					</div>
					<div class="new-bottom">
						<h5><a class="name" href="ProductInnerPage.aspx"> 912 Carat Statue of Ganesha Tigher Eye Gemstone</a></h5>
						
						<div class="ofr">
<!--							<p class="pric1"><del>$2000.00</del></p>
-->							<p><span class="item_price"> Rs.6453/- </span></p>
						</div>
					</div>
				</div>
     </div>
     
     
     
    
               <div class="col-md-3 padr0">
				<div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
					<div class="new-top" align="center">
						<a href="ProductInnerPage.aspx"><img src="images/g4.jpg" class="img-responsive"  alt=""/></a>
						<div class="new-text">
							<ul>
								<li><a href="ProductInnerPage.aspx">Quick View </a></li>
								<li><input type="number" class="item_quantity" min="1" value="1"></li>
								<li><a class="item_add" href=""> Add to cart</a></li>
							</ul>
						</div>
					</div>
					<div class="new-bottom">
						<h5><a class="name" href="ProductInnerPage.aspx"> 912 Carat Statue of Ganesha Tigher Eye Gemstone</a></h5>
						
						<div class="ofr">
<!--							<p class="pric1"><del>$2000.00</del></p>
-->							<p><span class="item_price"> Rs.6453/- </span></p>
						</div>
					</div>
				</div>
     </div>  
     
     
     
        <div class="col-md-3 padr0">
				<div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
					<div class="new-top" align="center">
						<a href="ProductInnerPage.aspx"><img src="images/g5.jpg" class="img-responsive"  alt=""/></a>
						<div class="new-text">
							<ul>
								<li><a href="ProductInnerPage.aspx">Quick View </a></li>
								<li><input type="number" class="item_quantity" min="1" value="1"></li>
								<li><a class="item_add" href=""> Add to cart</a></li>
							</ul>
						</div>
					</div>
					<div class="new-bottom">
						<h5><a class="name" href="ProductInnerPage.aspx"> 912 Carat Statue of Ganesha Tigher Eye Gemstone</a></h5>
						
						<div class="ofr">
<!--							<p class="pric1"><del>$2000.00</del></p>
-->							<p><span class="item_price"> Rs.6453/- </span></p>
						</div>
					</div>
				</div>
     </div> 
     
     
     
     
     
     
     
     
        <div class="col-md-3 padr0">
				<div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
					<div class="new-top" align="center">
						<a href="ProductInnerPage.aspx"><img src="images/g6.jpg" class="img-responsive"  alt=""/></a>
						<div class="new-text">
							<ul>
								<li><a href="ProductInnerPage.aspx">Quick View </a></li>
								<li><input type="number" class="item_quantity" min="1" value="1"></li>
								<li><a class="item_add" href=""> Add to cart</a></li>
							</ul>
						</div>
					</div>
					<div class="new-bottom">
						<h5><a class="name" href="ProductInnerPage.aspx"> 912 Carat Statue of Ganesha Tigher Eye Gemstone</a></h5>
						
						<div class="ofr">
<!--							<p class="pric1"><del>$2000.00</del></p>
-->							<p><span class="item_price"> Rs.6453/- </span></p>
						</div>
					</div>
				</div>
     </div>
     
     
     
   
      <div class="col-md-3 padr0">
				<div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
					<div class="new-top" align="center">
						<a href="ProductInnerPage.aspx"><img src="images/g7.jpg" class="img-responsive"  alt=""/></a>
						<div class="new-text">
							<ul>
								<li><a href="ProductInnerPage.aspx">Quick View </a></li>
								<li><input type="number" class="item_quantity" min="1" value="1"></li>
								<li><a class="item_add" href=""> Add to cart</a></li>
							</ul>
						</div>
					</div>
					<div class="new-bottom">
						<h5><a class="name" href="ProductInnerPage.aspx"> 912 Carat Statue of Ganesha Tigher Eye Gemstone</a></h5>
						
						<div class="ofr">
<!--							<p class="pric1"><del>$2000.00</del></p>
-->							<p><span class="item_price"> Rs.6453/- </span></p>
						</div>
					</div>
				</div>
     </div>  
     
     
     
        <div class="col-md-3 padr0">
				<div class="product-grids simpleCart_shelfItem wow fadeInUp animated" data-wow-delay=".5s">
					<div class="new-top" align="center">
						<a href="ProductInnerPage.aspx"><img src="images/g8.jpg" class="img-responsive"  alt=""/></a>
						<div class="new-text">
							<ul>
								<li><a href="ProductInnerPage.aspx">Quick View </a></li>
								<li><input type="number" class="item_quantity" min="1" value="1"></li>
								<li><a class="item_add" href=""> Add to cart</a></li>
							</ul>
						</div>
					</div>
					<div class="new-bottom">
						<h5><a class="name" href="ProductInnerPage.aspx"> 912 Carat Statue of Ganesha Tigher Eye Gemstone</a></h5>
						
						<div class="ofr">
<!--							<p class="pric1"><del>$2000.00</del></p>
-->							<p><span class="item_price"> Rs.6453/- </span></p>
						</div>
					</div>
				</div>
     </div>
   			 
 </div> --%>
            </div>
        </div>
    </div>
</asp:Content>
