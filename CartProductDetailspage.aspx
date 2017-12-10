<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true"
    CodeFile="CartProductDetailspage.aspx.cs" Inherits="CartProductDetailspage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function ChangeDetails(ctrl)
        {
            
            // ContentPlaceHolder1_CartGridview_ddlQty_1 
            var hdnCount = document.getElementById("ContentPlaceHolder1_hdnCount");
            var Id_Arr = ctrl.split('_');
            var ddlQty = document.getElementById(ctrl).value;
            var hdnRate = document.getElementById(ctrl.replace("ddlQty", "hdnRate")).value;
            var hdnDeliveryCharges = document.getElementById(ctrl.replace("ddlQty", "hdnDeliveryCharges")).value;
            var hdnItemRate = document.getElementById(ctrl.replace("ddlQty", "hdnItemRate"));
            var lblPrice = document.getElementById(ctrl.replace("ddlQty", "lblPrice"));
            var lblMakingCharges = document.getElementById(ctrl.replace("ddlQty", "lblMakingCharges"));
            var lblSubtotal = document.getElementById(ctrl.replace("ddlQty", "lblSubtotal"));
            var hdnGPrice = document.getElementById(ctrl.replace("ddlQty", "hdnGPrice"));
            lblPrice.innerHTML = (parseFloat(hdnItemRate.value) * parseFloat(ddlQty)).toFixed(2);
            lblMakingCharges.innerHTML = (parseFloat(hdnDeliveryCharges) * parseFloat(ddlQty)).toFixed(2);
            if (parseFloat(ddlQty) > 2)
                lblMakingCharges.innerHTML = "0";
            lblSubtotal.innerHTML = (parseFloat(lblPrice.innerHTML) + parseFloat(lblMakingCharges.innerHTML)).toFixed(2);
            hdnGPrice.value = parseFloat(lblSubtotal.innerHTML) / parseFloat(ddlQty);
            var Total = 0;
            for (var i = 0; i < parseFloat(hdnCount.value) ; i++)
            {
                var subTotal = document.getElementById("ContentPlaceHolder1_CartGridview_lblSubtotal_" + i).innerHTML;
                Total += parseFloat(subTotal);
            }

            var TotalAmt = document.getElementById("ContentPlaceHolder1_CartGridview_lblTotal");
            TotalAmt.innerHTML = Total;

        }
    </script>
    <asp:HiddenField runat="server" ID="hdnCount" />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="background-color: #FFFFFF; min-height: 750px;">
                <div class="container">
  
                    <div id="cartPage" class="cart cartpage ">
                        <div class="cart_contents newvd">
                            <div class="cartpage-tabs">
                            </div>
                        </div>
                    </div>
                    <br />
                    <div style="width: 100%;">
                        <div id="divb" class="styled-button-7" style="width: 150px; height: 25px; vertical-align: middle;
                            border-top-left-radius: 15px; border-top-right-radius: 15px;" align="center">
                            <asp:Label ID="lblCartCount" runat="server" Text="Cart"></asp:Label>
                            <asp:Label ID="lblValue" runat="server" Text=""></asp:Label>
                        </div>
                        <asp:GridView ID="CartGridview" AutoGenerateColumns="false" Width="100%" GridLines="None"
                            runat="server" DataKeyNames="PicturePath,ProductID" OnRowCommand="CartGridview_RowCommand"
                            OnRowDataBound="CartGridview_RowDataBound" ShowFooter="true">
                            <Columns>
                                <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Image ID="Image2" runat="server" Width="100px" Height="100px" style="padding:2px;" ImageUrl='<%#Eval("PicturePath") %>' />
                                        <asp:HiddenField ID="Hdnpicturepath" Value='<%#Eval("PicturePath") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" CssClass="HeaderRow2" />
                                    <ItemStyle Width="5%" Height="30px" CssClass="ItemRow2" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="linkbtntxt" ID="linkbtnProductname" Width="250px" Text='<%#Eval("ProductName") %>'
                                            CommandArgument='<%#Eval("ProductID") %>' CommandName="ProductName" runat="server"></asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("ProductID") %>' runat="server" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <FooterStyle CssClass="ItemRow1" />
                                    <HeaderStyle Width="10%" CssClass="HeaderRow2" />
                                    <ItemStyle Width="10%" Height="30px" CssClass="ItemRow2" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQuantity" Width="45px" runat="server"  Enabled="false" Visible="false" Text='<%#Eval("InbuiltQty") %>'    onblur="blurSaveQuantity(this.id)" ></asp:TextBox>
                                        <asp:DropDownList runat="server" ID="ddlQty" onchange="ChangeDetails(this.id);">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:HiddenField ID="HiddenQNTY" Value='<%#Eval("InbuiltQty") %>' runat="server" />
                                        <asp:HiddenField ID="hdnfldpid" Value='<%# Eval("ProductID") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" CssClass="HeaderRow2" />
                                    <ItemStyle Width="2%" Height="30px" CssClass="ItemRow2" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                       $ <asp:Label ID="lblPrice" CssClass="deliverytext" Width="100px" runat="server" Text='<%#Eval("CountryPrice") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnItemRate" Value='<%#Eval("CountryPrice") %>' runat="server" />
                                        <asp:HiddenField ID="hdnGPrice" Value='<%#Eval("Price") %>' runat="server" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        Total Price
                                    </FooterTemplate>
                                    <FooterStyle CssClass="ItemRow1" />
                                    <HeaderStyle Width="5%" CssClass="HeaderRow2" />
                                    <ItemStyle Width="5%" Height="30px" CssClass="ItemRow2" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Making Charges">
                                    <ItemTemplate>
                                       $ <asp:Label ID="lblMakingCharges" CssClass="deliverytext" Width="100px" runat="server" Text='<%#Eval("DeliveryCharges") %>'></asp:Label>
                                        <asp:HiddenField ID="hdnDeliveryCharges" Value='<%# Eval("DeliveryCharges") %>' runat="server" />
                                                                          </ItemTemplate>
                                    <FooterTemplate>
                                       
                                    </FooterTemplate>
                                    <FooterStyle CssClass="ItemRow1" />
                                    <HeaderStyle Width="5%" CssClass="HeaderRow2" />
                                    <ItemStyle Width="5%" Height="30px" CssClass="ItemRow2" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubTotal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubSymbol" runat="server" ForeColor="Black" Font-Bold="false" Text='<%# Eval("Symbol") %>' />$
                                        <asp:Label ID="lblSubtotal" runat="server" ForeColor="Black" Font-Bold="false" Text='<%# Eval("Rates") %>'>
                                        </asp:Label>
                                        <asp:HiddenField ID="hdnRate" Value='<%# Eval("Rates") %>' runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" CssClass="HeaderRow2" />
                                    <ItemStyle Width="5%" Height="30px" CssClass="ItemRow2" />
                                    <FooterTemplate>
                                        $
                                        <asp:Label ID="lblTotal" runat="server" />
                                        <asp:HiddenField ID="hdnttlamt" runat="server" />
                                    </FooterTemplate>
                                    <FooterStyle CssClass="ItemRow1" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnproductid" runat="server" Value='<%#Eval("ProductID") %>' />
                                        <asp:LinkButton ID="lnkBtnRemove" Height="30px" Width="30px" CommandArgument='<%#Eval("ProductID") %>'
                                            CommandName="RemoveCartProduct" runat="server"><img align="middle" src='Images/icons/Delete_Icon.png'  style=" height:35px; width:35px;" /></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="3%" CssClass="HeaderRow2" />
                                    <ItemStyle Width="3%" Height="30px" CssClass="ItemRow2" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#1876BC" ForeColor="white" Font-Bold="true" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lblnocartitems" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnSaveC" runat="server" Width="180px" Text="SAVE&CONTINUE" CssClass="styled-button-8"
                                        Height="38px" OnClick="btnSaveC_Click" />
                                </td>
                                <td style="" align="center">
                                    <asp:ImageButton ID="continueshoppingimage" runat="server" CssClass="styled-button-8" AlternateText="Continue Shopping"
                                        OnClick="continueshoppingimage_Click" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="BtnProceed" runat="server" Text="PROCEED" CssClass="styled-button-8"
                                        BackColor="#ED8223" Width="120px" Height="38px" OnClick="BtnProceed_Click" />
                                </td>
                            </tr>
                        </table>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
