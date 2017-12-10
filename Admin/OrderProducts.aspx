<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master"
    AutoEventWireup="true" CodeFile="OrderProducts.aspx.cs" Inherits="Admin_OrderProducts" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <style>
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
        
        
        .myDiv
        {
            height: 150px;
            width: 160px;
        }
        .myDiv img
        {
            max-width: 100%;
            max-height: 100%;
            margin: auto;
            display: block;
        }
    </style>
    <style>
        .ItemRow2
        {
            border: 1px solid #CECECE;
            height: 30px;
            font-family: Arial;
            font-style: normal;
            font-size: smaller;
            padding-top: 2px;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
        }
        
        .ItemRow1
        {
            border: 1px solid #CECECE;
            height: 30px;
            font-family: Arial;
            font-style: normal;
            font-size: smaller;
            padding-top: 2px;
            text-align: right;
            text-decoration: none;
            vertical-align: middle;
        }
        
        .HeaderRow2
        {
            border: 1px solid #CECECE;
            height: 30px;
            background-color: #F5F8F9;
            color: Black;
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
    </style>
    <div class="container" style="text-align: center;">
        <div style="padding-top: 15px;">
            <table width="100%">
                <tr>
                    <td align="center" style="font-family: Arial; font-size: medium;">
                        <asp:Label ID="lablefororders" ForeColor="#8A8A8A" runat="server"></asp:Label><asp:Label
                            ID="lblrefno" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <%-- <tr>
        <td style=" font-family:Arial; font-size:medium; font-style:normal; text-align:center; padding-top:10px;"></td>
    </tr>--%>
            </table>
        </div>
        <table style="width: 90%; padding-left: 120px;">
            <tr>
                <td style="padding-top: 5px; width: 100%;">
                    <div id="divb" class="styled-button-7" style="width: 180px; height: 32px; vertical-align: middle;"
                        align="center">
                        <asp:Label ID="lblCartCount" runat="server" Text="Ordered Products"></asp:Label>
                        <asp:Label ID="lblValue" runat="server" Text=""></asp:Label>
                    </div>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:GridView ID="MyOrdersGridview" AutoGenerateColumns="false" Width="100%" GridLines="Horizontal"
                                    runat="server" OnRowCommand="MyOrdersGridview_RowCommand" OnRowDataBound="MyOrdersGridview_RowDataBound"
                                    ShowFooter="true">
                                    <EmptyDataTemplate>
                                        <div style="color: Red; font-size: 12px;">
                                            <span>No Data Found!!!</span>
                                        </div>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <div id="divimg" class="myDiv" runat="server" style="max-width: 150px; max-height: 160px;">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("PicturePath") %>' />
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="10%" Height="30px" CssClass="ItemRow1" />
                                            <FooterStyle CssClass="ItemRow1" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Products">
                                            <ItemTemplate>
                                                <div style="font-family: Arial; font-size: small; font-style: normal;">
                                                    <asp:Label ID="labelProductname" Text='<%#Eval("ProductName") %>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnproductid" runat="server" Value='<%#Eval("ProductID") %>' />
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                            <FooterStyle CssClass="ItemRow1" />
                                            <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="20%" Height="30px" CssClass="ItemRow2" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblstatusText" runat="server" Text='<%#Eval("Quantity") %>' Font-Underline="False"
                                                    ForeColor="#333333"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="5%" Height="30px" CssClass="ItemRow2" />
                                            <FooterStyle CssClass="ItemRow1" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" Width="100px" runat="server" Text='<%# Eval("PriceSymbl") %>'></asp:Label>
                                                <asp:HiddenField ID="HiddenField2" Value='<%#Eval("Price") %>' runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="10%" Height="30px" CssClass="ItemRow1" />
                                            <FooterStyle CssClass="ItemRow1" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order DateTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblorderedtime" runat="server" Text='<%#Eval("OrderDateTime","{0:dd/MM/yyyy HH:mm} ") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="20%" Height="30px" CssClass="ItemRow2" />
                                            <FooterTemplate>
                                                Grand Total
                                            </FooterTemplate>
                                            <FooterStyle CssClass="ItemRow2" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubtotal" runat="server" ForeColor="Black" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="10%" Height="30px" CssClass="ItemRow1" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotal" runat="server" />
                                            </FooterTemplate>
                                            <FooterStyle CssClass="ItemRow1" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <div width="90%" style="" align="right">
                        <table width="100%" style="padding-top: 1px; vertical-align: top;">
                            <tr>
                                <td align="right" style="">
                                    <asp:Button ID="lnkbtnBacktomyOrders" runat="server" Text="<< Back to Orders" Width="180px"
                                        CssClass="styled-button-8" Height="38px" OnClick="lnkbtnBacktomyOrders_Click"
                                        PostBackUrl="~/Admin/TotalOrders.aspx" />
                                    <%--<asp:LinkButton ID="lnkbtnBacktomyOrders" Text="< Back to Orders" 
           CssClass="styled-button-8"  runat="server" onclick="lnkbtnBacktomyOrders_Click" 
        ></asp:LinkButton>--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
