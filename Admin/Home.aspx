<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage2.master"
    AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
            text-align:right;
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
    <script type="text/javascript">

        function expandCollapse(ctrlID) {
            var imageCtrlid = ctrlID;
            var ctrlName = "#" + ctrlID.replace("TableExpandCollpse", "TableDetailsTable");
            $(ctrlName).slideToggle("slow");
            var imagesrc = document.getElementById(imageCtrlid);
            var searchcontent = imagesrc.src;
            if (searchcontent.search("Expand") != "-1") {
                imagesrc.src = "../images/Collapse.png";
            }
            else {
                imagesrc.src = "../images/Expand.png";
            }
        }

        function ShowDates() {
            document.getElementById("widgetCalendar").style.height = "160px";
            document.getElementById("widgetCalendar").children[0].style.height = "160px";
            document.getElementById("widgetCalendar").children[0].style.width = "200px";
            document.getElementById("widgetCalendar").style.zIndex = "1";

            var DateRange = document.getElementById('MainContent_txtDateRange').innerHTML;
            document.getElementById('MainContent_hdnDates').value = DateRange;
            var ActualDateToSplit = DateRange.split("-");
            document.getElementById('MainContent_hdnFromDate').value = ActualDateToSplit[0];
            document.getElementById('MainContent_hdnToDate').value = ActualDateToSplit[1];
        }

    </script>
    <div class="container" style="vertical-align:middle;">
    <table style="width:100%;text-align:center;">
        <tr>
            <td style="padding-top: 30px; width: 100%;">
                <div style="float: right; width: 100%;">
                <div class="col-md-3">
                        <div style="padding-top: 10px;" id="divsort" runat="server">

                            <asp:Label ID="Label10" runat="server" CssClass="" Text="Sort by" Width="60px"></asp:Label>
                            <asp:DropDownList ID="ddlSort" AutoPostBack="true" CssClass="stdSortFields" Width="150px"
                              runat="server" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                                <asp:ListItem Text="Order Date" Value="OrderDateTime"></asp:ListItem>
                                <asp:ListItem Text="Order No" Value="OrderID"></asp:ListItem>
                                <asp:ListItem Text="Status" Value="Status"></asp:ListItem>
                                <asp:ListItem Text="Amount" Value="OrderAmount"></asp:ListItem>
                                
                            </asp:DropDownList>
                            <asp:ImageButton ID="imgSort" ImageUrl="~/Images/descending.png" runat="server" OnClick="imgSort_Click" />
                        </div>
                    </div>
                <div class="col-md-6"></div>
                <div class="col-md-3">
                    
                    
                    <div id="divb" class="styled-button-7" style="width: 150px; height: 32px; vertical-align: middle;float:right;"
                    align="center">
                    <asp:Label ID="lblCartCount" runat="server" Text="Total Orders"></asp:Label>
                    </div>
                    <asp:Image runat="server" ID="imgSearch" ImageUrl="~/Images/search_icon.png" Style="float: right; cursor: pointer;" />
                    <%--<asp:ImageButton ID="ImgExcel" runat="server" ImageUrl="~/Images/Excel.png" OnClick="ImgExcel_Click" style="float:right;"  />--%>
                </div>
                <cc1:PopupControlExtender ID="PopEx" runat="server" TargetControlID="imgSearch" PopupControlID="Panel1"
                    Position="Bottom" />
                <asp:Panel ID="panel1" runat="server" CssClass="SearchPopUpNew" Style="width: 30%; display: none; margin-left: -28%;">
                    <div class="row">
                        <div class="col-md-12" style="text-align:left;">
                            <label>Date Range</label>
                            <div id="widget">
                                <div id="widgetField">
                                    <span id="txtDateRange" runat="server"></span><a id="aclick" runat="server" onclick="ShowDates();"
                                        href="#">Select date range</a>
                                </div>
                                <div id="widgetCalendar">
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnDates" runat="server" />
                            <asp:HiddenField ID="hdnFromDate" runat="server" />
                            <asp:HiddenField ID="hdnToDate" runat="server" />
                        </div>                        
                    </div>
                    <div class="row">
                        <div class="col-md-6" style="text-align:left;">            
                            <label>Order No</label><br />
                            <asp:TextBox runat="server" ID="txtOrderNo" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6" style="text-align:left;">            
                            <label>Mobile No</label><br />
                            <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control"></asp:TextBox>
                        </div>                        
                    </div>
                    <div class="row">
                        <div class="col-md-6" style="text-align:left;">            
                            <label>Status</label><br />
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Success" Value="Success"></asp:ListItem>
                                <asp:ListItem Text="Failure" Value="Pending"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <br />
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                                                        
                        </div>
                    </div>
                </asp:Panel>
            </div>



                <table style="width: 100%;text-align:center;">
                    <tr>
                        <td>
                            <asp:GridView ID="MyOrderStatusGridview" AutoGenerateColumns="false" Width="100%" OnRowDataBound="MyOrderStatusGridview_RowDataBound"
                                GridLines="none" runat="server" OnRowCommand="MyOrderStatusGridview_RowCommand">
                                <EmptyDataTemplate>
                                    <div style="color: Red; font-size: 12px;">
                                        <span>No Data Found!!!</span>
                                    </div>
                                </EmptyDataTemplate>
                                <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <table style="width:100%;border-collapse:collapse;" cellpadding="0" cellspacing="0">
                                            <tr style="height:30px;">
                                                <td style="width:5%;" align="center" class="stdBorderLeft">SNo</td>
                                                <td style="width:5%;" align="center" class="stdBorderLeft">---</td>
                                                <td style="width:10%;" align="center" class="stdBorderLeft">Order RefNo</td>
                                                <td style="width:10%;" align="center" class="stdBorderLeft">Order Date Time</td>
                                                <td style="width:10%;" align="center" class="stdBorderLeft">Order By</td>
                                                <td style="width:10%;" align="center" class="stdBorderLeft">User Mobile No</td>
                                                <td style="width:20%;" align="center" class="stdBorderLeft">Delivery Address</td>
                                                <td style="width:5%;" align="center" class="stdBorderLeft">Status</td>
                                                <td style="width:10%;" align="center" class="stdBorderRight">Order Amount</td>
                                                
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table style="width:100%;margin-top:-2px;border-collapse:collapse;" cellpadding="0" cellspacing="0" >
                                            <tr style="height:30px;">
                                                <td style="width:5%;" class="stdContentLeft"><asp:Label runat="server" ID="lblSNo" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hdnGOrderID" Value='<%#Eval("OrderID") %>' />
                                                </td>
                                                <td class="stdContentLeft" style="width: 5%;" align="center">
                                                    <asp:Image ID="TableExpandCollpse" Style="cursor: pointer;" onclick="expandCollapse(this.id);"
                                                        runat="server" ImageUrl="~/Images/Expand.png" />
                                                </td>
                                                <td style="width:10%;" class="stdContentLeft" align="left"><asp:LinkButton ID="lborderno" runat="server" Text='<%#Eval("OrderNo") %>' ForeColor="#333333"
                                                CommandName="OrderRefNo" CommandArgument='<%#Eval("OrderID") %>'></asp:LinkButton></td>
                                                <td style="width:10%;" class="stdContentLeft"><asp:Label ID="lblorderedtime" runat="server" Text='<%#Eval("OrderDateTime","{0:dd/MM/yyyy HH:mm}") %>'></asp:Label></td>
                                                <td style="width:10%;" class="stdContentLeft" align="left"><asp:Label ID="Label1" runat="server" Text='<%#Eval("UserName") %>'></asp:Label></td>
                                                <td style="width:10%;" class="stdContentLeft" align="left"><asp:Label ID="Label2" runat="server" Text='<%#Eval("UserMobileNo") %>'></asp:Label></td>
                                                <td style="width:20%;" class="stdContentLeft" align="left"><asp:Label ID="labeladdress" Text='<%#Eval("Address") %>' runat="server"></asp:Label></td>                                                
                                                <td style="width:5%;" class="stdContentLeft" align="left"><asp:Label ID="lblstatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label></td>
                                                <td style="width:10%;" class="stdContentRight" align="right"><asp:Label ID="lblorderamount" runat="server" Text='<%#Eval("OrderAmount","{0:0.00}") %>'></asp:Label></td>
                                            </tr>
                                        </table>
                                        <div class="col-md-12" style="padding:0%;">
                                        <div id="TableDetailsTable" runat="server" style="width: 100%;background-color: #E8E8E8;border-left:solid 1px black;border-right:solid 1px black;border-bottom:solid 1px black;display:none;">
                                            <div style="padding:1%;width: 100%;">
                                                <table style="border-bottom: solid 2px gray; font-weight: bold; width: 100%;">
                                                    <tr style="height: 30px;">
                                                        <td style="width: 10%;" align="left">
                                                            <asp:Label ID="Label26" Text="Image" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="width: 40%;" align="left">
                                                            <asp:Label ID="Label29" Text="Item Name" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="width: 10%;" align="right">
                                                            <asp:Label  ID="lblItemName" Text="Quantity" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="width: 10%;" align="right">
                                                            <asp:Label  ID="Label3" Text="Price" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="width: 10%;" align="right">
                                                            <asp:Label  ID="lblPackingUnit" Text="Amount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:GridView ID="grdItemDetails" runat="server" GridLines="None" ShowHeader="false"
                                                    ShowFooter="false" AutoGenerateColumns="false" style="width:100%;">
                                                    <EmptyDataTemplate>
                                                        <div style="float: left; height: 60px; width: 100%; padding-top: 40px; text-align: center;
                                                            color: Black; font-weight: bold; font-size: 15px;">
                                                            Item Details Not Found !
                                                        </div>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table style="width: 100%; border: none;">
                                                                    <tr style="height: 30px;">
                                                                        <td style="width: 10%;" align="left">
                                                                            <asp:Image runat="server" ID="itemimage" ImageUrl='<%#Eval("PicturePath") %>' style="height:100px;width:100px;" />
                                                                        </td>
                                                                        <td style="width: 40%;" align="left">
                                                                            <asp:Label runat="server" ID="Label3" Text='<%#Eval("ProductName") %>'></asp:Label>
                                                                        </td>
                                                                        <td style="width: 10%;" align="right">
                                                                            <asp:Label runat="server" ID="Label4" Text='<%#Eval("Quantity") %>'></asp:Label>
                                                                        </td>
                                                                        <td style="width: 10%;" align="right">
                                                                            <asp:Label runat="server" ID="Label5" Text='<%#Eval("Price") %>'></asp:Label>
                                                                        </td>
                                                                        <td style="width: 10%;" align="right">
                                                                            <asp:Label runat="server" ID="Label6" Text='<%#Eval("Amount","{0:0.00}") %>'></asp:Label><%--+<asp:Label runat="server" ID="Label7" Text='<%#Eval("DeliveryCharges") %>'></asp:Label><br />
                                                          <span style="font-size:10px;"> (Delivery Charges)</span>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="stdfooter" runat="server" id="divGrdMsg" style="display: none; padding-top: 25px;
        margin-bottom: 15px;">
        Page :
        <%= MyOrderStatusGridview.PageIndex + 1%>
        , Showing
        <%= MyOrderStatusGridview.PageIndex * MyOrderStatusGridview.PageSize + 1%>
        to
        <%= MyOrderStatusGridview.PageIndex * MyOrderStatusGridview.PageSize + MyOrderStatusGridview.Rows.Count%>
        of
        <asp:Label ID="lblTotalRowsCount" runat="server"></asp:Label>
        Records.
    </div>
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
                <div class="clearfix"></div>
 <div style="padding-bottom:7%;"></div>
</asp:Content>
