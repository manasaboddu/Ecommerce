<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master"
    AutoEventWireup="true" CodeFile="TotalOrders.aspx.cs" Inherits="Admin_TotalOrders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
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
    </style>
    <div class="container" style="vertical-align: middle;">
        <table style="width: 96%; padding-left: 120px;">
            <tr>
                <td style="padding-top: 30px; width: 100%;">
                    <div id="divb" class="styled-button-7" style="width: 150px; height: 32px; vertical-align: middle;"
                        align="center">
                        <asp:Label ID="lblCartCount" runat="server" Text="Total Orders"></asp:Label>
                    </div>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:GridView ID="MyOrderStatusGridview" AutoGenerateColumns="false" Width="100%"
                                    GridLines="Both" runat="server" OnRowCommand="MyOrderStatusGridview_RowCommand">
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
                                            <HeaderStyle Width="5%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order RefNo" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lborderno" runat="server" Text='<%#Eval("OrderNo") %>' ForeColor="#333333"
                                                    CommandName="OrderRefNo" CommandArgument='<%#Eval("OrderID") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="15%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="15%" Height="30px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OrderDateTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblorderedtime" runat="server" Text='<%#Eval("OrderDateTime","{0:dd/MM/yyyy HH:mm}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="20%" Height="30px" />
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
                                            <ItemStyle Width="20%" Height="30px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OrderAmount" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblorderamount" runat="server" Text='<%#Eval("CountryPrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="20%" Height="30px" CssClass="ItemRowAmount" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CurrentStatus" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20%" CssClass="HeaderRow2" />
                                            <ItemStyle Width="20%" Height="30px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="right" style="vertical-align: baseline;">
                </td>
            </tr>
        </table>
    </div>
    <div class="clearfix">
    </div>
    <div style="padding-bottom: 7%;">
    </div>
</asp:Content>
