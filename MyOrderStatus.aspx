<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true"
    CodeFile="MyOrderStatus.aspx.cs" Inherits="MyOrderStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .modalBackground1
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border: 6px solid #A3CBEE;
            border-radius: 1px;
            padding: 0;
        }
        .modalPopup .header
        {
            background-color: #89B40E;
            height: 30px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
            border-top-left-radius: 1px;
            border-top-right-radius: 1px;
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .footer
        {
            padding: 6px;
        }
        .modalPopup .yes, .modalPopup .no
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: left;
            font-weight: bold;
            cursor: pointer;
            border-radius: 1px;
        }
        .modalPopup .yes
        {
            background-color: #014E9E;
            border: 1px solid #0DA9D0;
            top: 0px;
            left: 13px;
            position: relative;
            width: 60px;
        }
        .modalPopup .no
        {
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
            top: 0px;
            left: 74px;
            position: relative;
        }
        
        
        .styled-button-7
        {
            background: #1876BC;
            background: -moz-linear-gradient(top,#1876BC 0%,#1876BC 1876BC%);
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
        }
         .HeaderRow2
        {
            border: 1px solid #CECECE;
            height: 30px;
            background-color: #11A7A1;
            color: white;
            font-family: Arial;
            font-size: small;
            font-style: normal;
            text-align: center;
            vertical-align: middle;
        }
        .FooterRow1
        {
            border: 1px solid #CECECE;
            height: 30px;
            font-family: Arial;
            font-style: normal;
            font-size: small;
            padding-top: 2px;
            text-align: center;
            vertical-align: middle;
        }
        .ItemRowAmount
        {
            text-align: right;
        }
    </style>
    <div class="container" style="text-align: center;">
        <table style="width: 100%;">
            <tr>
                <td align="center">
                    <asp:Label runat="server" ID="lblMsg" Style="font-weight: bold; font-size: 14px;color:Red;"></asp:Label>
                </td>
            </tr>
            <td style="padding-top: 30px; width: 100%;">
                <div id="divb" class="styled-button-7" style="width: 140px; height: 30px; vertical-align: top;
                    border-top-left-radius: 15px; border-top-right-radius: 15px; margin-bottom: 0px;
                    margin-left: 2px;" align="center">
                    <asp:Label ID="lblCartCount" runat="server" Text="My Orders"></asp:Label>
                </div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:GridView ID="MyOrderStatusGridview" AutoGenerateColumns="false" Width="100%" ShowHeader="false" ShowFooter="false"
                                GridLines="Both" runat="server" OnRowCommand="MyOrderStatusGridview_RowCommand"
                                OnRowDataBound="MyOrderStatusGridview_RowDataBound">
                                <EmptyDataTemplate>
                                    <div style="color: Red; font-size: 12px;">
                                        <span>No Orders!!!</span>
                                    </div>
                                </EmptyDataTemplate>
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="col-md-12 OrdersCss">
                                        <div class="col-md-4" style="text-align:left;">
                                            Order No : <asp:Label runat="server" ID="lborderno" Text='<%#Eval("OrderNo") %>'></asp:Label>
                                            <asp:HiddenField runat="server" ID="hdnGOrderID" Value='<%#Eval("OrderID") %>' />
                                        </div>
                                        <div class="col-md-4" style="text-align:left;">
                                            Order Date : <asp:Label runat="server" ID="lblOrderDate" Text='<%#Eval("OrderDateTime","{0:dd/MM/yyyy HH:mm}") %>'></asp:Label>
                                        </div>
                                         <div class="col-md-2" style="text-align:left;">
                                         Status : <asp:Label runat="server" ID="lblStatus" Text='<%#Eval("Status") %>'></asp:Label>
                                         </div>
                                        <div class="col-md-2" style="text-align:right;">
                                            <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel Order" OnClientClick="showPopup(this.id);return false;" Visible="false"></asp:LinkButton>
                                        </div>                                        
                                    </div>
                                    <div class="col-md-12" style="padding:0%;">
                                        <asp:GridView runat="server" ID="grdItemDetails" GridLines="None" AutoGenerateColumns="false" style="width:100%;" ShowHeader="false" ShowFooter="false">
                                            <Columns>
                                                <asp:TemplateField><ItemTemplate>
                                                    <div class="col-md-12" style="padding:0%;padding-bottom:1%;">
                                                        <div class="col-md-2">
                                                            <asp:Image runat="server" ID="itemimage" ImageUrl='<%#Eval("PicturePath") %>' style="height:100px;width:100px;" />
                                                        </div>
                                                        <div class="col-md-4" style="text-align:left;">
                                                            <asp:Label runat="server" ID="Label3" Text='<%#Eval("ProductName") %>'></asp:Label>
                                                        </div>
                                                        <div class="col-md-2" style="text-align:left;">
                                                        Qty:
                                                            <asp:Label runat="server" ID="Label4" Text='<%#Eval("Quantity") %>'></asp:Label>
                                                        </div>
                                                        <div class="col-md-2" style="text-align:left;">
                                                        Rs.
                                                            <asp:Label runat="server" ID="Label5" Text='<%#Eval("Price") %>'></asp:Label>
                                                        </div>
                                                        <div class="col-md-2" style="text-align:right;">                                                            
                                                            Rs. <asp:Label runat="server" ID="Label6" Text='<%#Eval("Amount","{0:0.00}") %>'></asp:Label><%--+<asp:Label runat="server" ID="Label7" Text='<%#Eval("DeliveryCharges") %>'></asp:Label><br />
                                                          <span style="font-size:10px;"> (Delivery Charges)</span>--%>
                                                        </div>
                                                    </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            </asp:GridView>
                                    </div>
                                    <div class="col-md-12 OrdersAmountCss" style="text-align:right;font-weight:bold;">
                                        Order Amount : <asp:Label runat="server" ID="Label2" Text='<%#Eval("OrderAmount","{0:0.00}") %>'></asp:Label>
                                    </div>
                                    <div class="col-md-12">
                                        
                                    </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle Width="5%" CssClass="HeaderRow2" />
                                        <ItemStyle Width="5%" CssClass="ItemRow1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order RefNo" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lborderno" runat="server" Text='<%#Eval("OrderNo") %>' ForeColor="#333333"
                                                CommandName="OrderRefNo" CommandArgument='<%#Eval("OrderID") %>'></asp:LinkButton>
                                            <asp:HiddenField ID="hdnID" Value='<%#Eval("OrderID") %>' runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="15%" CssClass="HeaderRow2" />
                                        <ItemStyle Width="15%" Height="30px" CssClass="ItemRow1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OrderDateTime">
                                        <ItemTemplate>
                                            <asp:Label ID="lblorderedtime" runat="server" Text='<%#Eval("OrderDateTime","{0:dd/MM/yyyy HH:mm}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                        <ItemStyle Width="20%" Height="30px" CssClass="ItemRow1" />
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="ItemRow1" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DeliveryAddress">
                                        <ItemTemplate>
                                            <div style="font-family: Arial; font-size: small; font-style: normal;">
                                                <asp:Label ID="labeladdress" Text='<%#Eval("Address") %>' runat="server"></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                        <FooterStyle CssClass="ItemRow1" />
                                        <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                        <ItemStyle Width="20%" Height="30px" CssClass="ItemRow2" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OrderAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblorderamount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                        <ItemStyle Width="20%" Height="30px" CssClass="ItemRowAmount" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CurrentStatus" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                            <asp:LinkButton ID="lnkCancel" runat="server" Text="(Cancel Order)" OnClientClick="showPopup(this.id);;return false;"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                        <ItemStyle Width="20%" Height="30px" CssClass="ItemRow1" />
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
            </tr></table>
        <table width="100%">
            <tr>
                <td align="right" style="vertical-align: baseline;">
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btndummy" Style="display: none;" />
        <cc1:ModalPopupExtender ID="mpebtnEdit" runat="server" PopupControlID="PopPanel"
            TargetControlID="btndummy" CancelControlID="btnNo" BackgroundCssClass="modalBackground1"
            BehaviorID="mpe">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="PopPanel" runat="server" Width="40%" CssClass="modalPopup">
            <div style="margin-top: -27px; text-align: right; margin-right: -25px;">
                <asp:ImageButton ID="btnNo" Width="40" Height="40" border="0" runat="server" ImageUrl="~/Images/icons/feedclose.png"
                    AlternateText="modalclose" />
            </div>
            <div style="float: left; color: #1876BC; font-weight: bold; font-size: 17px; margin-left: 5px;">
                Cancel Order</div>
            <br />
            <div class="body" style="height: 300px;">
                <br />
                <div style="float: left; margin-left: 20px; font-size: 13px; width: 100%;" align="left">
                    Please read terms and conditions before cancel order.
                    <br />
                    Cancellation will be done according to policy terms.<br />
                    Charges and refund will be according to the given terms.<br />
                    If you accept the term and condition click on cancel order.
                </div>
                <br />
                <br />
                <asp:Button class="styled-button-8" Text="Cancel Order" ID="btnCancelOrder" OnClick="btnCancelOrder_Click"  OnClientClick="return confirm('Are you sure to cancel this order ?');"
                    runat="server" />
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hdnOrderid" runat="server" />
        <asp:HiddenField ID="hdnOrderNo" runat="server" />
    </div>
    <div class="clearfix">
    </div>
    <div style="padding-bottom: 7%;">
    </div>
    <script type="text/jscript">
        function showPopup(ctrlid) {
            var hdnid = document.getElementById(ctrlid.replace("lnkCancel", "hdnGOrderID"));
            var OrderNo = document.getElementById(ctrlid.replace("lnkCancel", "lborderno"));
            document.getElementById("ContentPlaceHolder1_hdnOrderid").value = hdnid.value;
            document.getElementById("ContentPlaceHolder1_hdnOrderNo").value = OrderNo.innerHTML;
            $find("mpe").show();
        }

    </script>
</asp:Content>
