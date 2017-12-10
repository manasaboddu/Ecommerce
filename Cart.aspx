<%@ Page Title="My Cart" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function CheckCode()
        {
            var txtcode = document.getElementById("ContentPlaceHolder1_txtPromocode").value;
            if (txtcode != "")
            {
                var Qry = "select OfferAmount from OfferMaster where  OfferCode='" + txtcode + "'";
                WebService.GetResultfromQry(Qry, onSuccess, OnFail);
            }
        }
        function onSuccess(result)
        {
            debugger;
            if (result != null && result != "") {
              
                var lblAmt = document.getElementById("ContentPlaceHolder1_lblTotalAmt");

                var LblMsg = document.getElementById("ContentPlaceHolder1_lblTotalMsg");
                var hdnPromAmt = document.getElementById("ContentPlaceHolder1_hdnPromAmt");
                if (result != "") {
                    hdnPromAmt.value = (parseFloat(lblAmt.innerHTML) * (parseFloat(result) / 100));
                    var FinalAmt = (parseFloat(lblAmt.innerHTML) * ((100 - parseFloat(result)) / 100));
                    
                    LblMsg.innerHTML = result + "% Discount applied <br /> Final Amount : " + FinalAmt.toFixed(2) + " $";
                    // lblAmt.style.textDecoration = "line-through";
                }
            }
            else
            {
                document.getElementById("ContentPlaceHolder1_lblTotalMsg").innerHTML = "No promo code available";
            }
        }
        function OnFail(err)
        {
            alert(err);
        }


    </script>


    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12" style="background-color: #FFFFFF; min-height: 750px;">
                <div class="container">
<div style="width:48%; float:left;margin:10px;">
    <div id="divb" class="styled-button-7" style="width: 150px; height: 25px; vertical-align: middle;
                            border-top-left-radius: 15px; border-top-right-radius: 15px;" align="center">
                            <asp:Label ID="lblCartCount" runat="server" Text="Cart"></asp:Label>
                            <asp:Label ID="lblValue" runat="server" Text=""></asp:Label>
                        </div>
                    <asp:GridView ID="CartGridview" AutoGenerateColumns="false" Width="100%" GridLines="None" AllowPaging="false"
                        runat="server" OnRowDataBound="CartGridview_RowDataBound" ShowFooter="true" >

                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" style="border-collapse: collapse; width: 100%;">
                                        <tr style="color: #F7F7F7; background-color: #4A3C8C; font-weight: bold;">
                                            <td style="width: 20%" align="center"></td>
                                            <td style="width: 40%;" align="center">
                                                <span>Item </span>
                                            </td>
                                            <td style="width: 15%;" align="center">
                                                <span>Rate</span>
                                            </td>
                                            <td style="width: 15%;" align="center">
                                                <span>price</span>
                                            </td>

                                            <td style="width: 10%;"></td>
                                        </tr>
                                       

                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
                                        <tr style="color: #F7F7F7; font-weight: bold;">
                                            <td style="width: 20%;" align="center">
                                                <asp:Image ID="Image2" runat="server" Width="100px" Height="100px" Style="padding: 3px; border-radius: 10px;" ImageUrl='<%#Eval("PicturePath") %>' />
                                            </td>
                                            <td align="center" style="width: 40%; vertical-align:top;">
                                                <table>
                                                    <tr>
                                                        <td style="vertical-align: middle;">
                                                            <asp:Label ID="lblProductName" runat="server" ForeColor="Black" Text='<%#Eval("ProductName") %>' Style="margin-top:10px;"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td > <span style="color:darkblue;">Qty</span>  &nbsp;
                                                            <asp:TextBox ID="txtQuantity" Width="45px" runat="server" ForeColor="Black" Text='<%#Eval("Quantity") %>' onblur="blurSaveQuantity(this.id)" style="margin-top:15px;" ReadOnly="true" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                            <td align="center" style="width: 20%;">
                                                <%--<span style="color:black;">$</span>--%>
                                          &nbsp;
                                                <asp:Label ID="Label1" CssClass="deliverytext" ForeColor="Black" Width="100px" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                                            </td>
                                            <td align="center" style="width: 20%;">

                                                <asp:Label ID="lblSubSymbol" runat="server" ForeColor="Black" Text="$"></asp:Label>
                                                <asp:Label ID="lblSubtotal" runat="server" ForeColor="Black" Text='<%# Eval("Amount") %>'></asp:Label>
                                            </td>
                                            <td align="center" style="width: 10%;">

                                                <img align="middle" src='Images/icons/Delete_Icon.png' style="height: 35px; width: 35px;" />
                                            </td>

                                        </tr>
                                    </table>

                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
    <table  cellpadding="0" cellspacing="0" style="border-collapse: collapse; width: 100%;">
        <tr style="color: #F7F7F7; background-color: #4A3C8C; font-weight: bold;">
            <td style="width: 50%;"></td>
            <td style="width: 20%;">Total Amount

            </td>
            <td style="width: 20%;">
                <span>$ </span>
                <asp:Label runat="server" ID="lblTotalAmt" Text="3000"></asp:Label>
            </td>
        </tr>
        </table>
    
    <div style="margin:10px; font-weight:bold;"> <asp:CheckBox runat="server" ID="chkPromo" Text="Having Promo Code"  onchange="DisplayPromo();"  /></div>
    <asp:HiddenField runat="server" ID="hdnPromAmt" Value="0" />
    <table id="TblPromo" style="display:none;">
        
        <tr ">
            <td style="width: 20%;"></td>
            <td style="width: 50%;">
                <asp:TextBox runat="server" ID="txtPromocode" MaxLength="8"  AutoCompleteType="None"  placeholder="Enter Promocode"></asp:TextBox>
            </td>
            <td style="width: 30%;">
                                <asp:Button ID="btnCheckPromo" runat="server" ForeColor="White"
                    Text="Apply PROMO " CssClass="styled-button-8" BackColor="#ED8223" BorderColor="#ED8223"
                    Width="150px" Height="38px"  OnClick="btnCheckPromo_Click"  OnClientClick="CheckCode();return false;" />
            </td>
        </tr>
        <tr>
            <td style="width: 50%;"></td>
            <td>
                <asp:Label runat="server" ID="lblTotalMsg" ForeColor="Red"></asp:Label>
            </td>
            <td >
            </td>
        </tr>
    </table>
    <div align="center"> 
                <asp:Button ID="BtnContinue" runat="server" ForeColor="White"
                    Text="CONTINUE " CssClass="styled-button-8" BackColor="#ED8223" BorderColor="#ED8223"
                    Width="170px" Height="38px"  OnClick="BtnContinue_Click" /></div>

    </div>
                </div>
            </div>
        </div>
    </div>
     <script type="text/javascript">

         function DisplayPromo() {
             if (document.getElementById("ContentPlaceHolder1_chkPromo").checked)
             {
                 document.getElementById("TblPromo").style.display = "block";
             }
             else
                 document.getElementById("TblPromo").style.display = "none";
         }

     </script>
    

    <style type="text/css">

         .modalPopup
        {
            background-color: #FFFFFF;
            border: 6px solid #A3CBEE;
            border-radius: 1px;
            padding: 0;
            opacity: 10;
        }
       #overLayBackground{
     background-color: rgb(250, 250, 250);
     opacity: 0.7; /* Safari, Opera */
     -moz-opacity:0.25; /* FireFox */
     filter: alpha(opacity=70); /* IE */
     z-index: 200;
     height: 100%;
     width: 100%;
     background-repeat:repeat;
     position:fixed;
     top: 0px;
     left: 0px;
     text-align:center; 
         line-height: 240px; 
    }

    #overLayBackground>img {
        position:absolute; bottom:0; top:0; left:0; right:0; margin:auto;
    }
    
.modalBackground
{
	background-color:gray;
    filter:alpha(opacity=70);
    opacity:0.7; 
}   
    </style>

</asp:Content>

