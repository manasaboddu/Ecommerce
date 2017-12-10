<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="Pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <!-- If you're using Stripe for payments -->
<%--<link href="bootstrap.min.css" rel="stylesheet" type="text/css" />--%>


        
<style>
/* The Modal (background) */
.modal {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 10px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgb(12, 4, 4); /* Black w/ opacity */
}

/* Modal Content */
.modal-content {
    position: relative;
    background-color: #fefefe;
    margin: auto;
    padding: 0;
    border: 1px solid #888;
    width: 50%;
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
    -webkit-animation-name: animatetop;
    -webkit-animation-duration: 0.4s;
    animation-name: animatetop;
    animation-duration: 0.4s
}

/* Add Animation */
@-webkit-keyframes animatetop {
    from {top:-300px; opacity:0} 
    to {top:0; opacity:1}
}

@keyframes animatetop {
    from {top:-300px; opacity:0}
    to {top:0; opacity:1}
}

/* The Close Button */
.close {
    color: white;
    float: right;
    font-size: 28px;
    font-weight: bold;
}

.close:hover,
.close:focus {
    color: #000;
    text-decoration: none;
    cursor: pointer;
}

.modal-header {
    padding: 2px 16px;
    background-color: #5cb85c;
    color: white;
}

.modal-body {padding: 2px 16px;}

.modal-footer {
    padding: 2px 16px;
    background-color: #5cb85c;
    color: white;
}
</style>

    <div style="width: 600px; padding: 5%;display:block;margin-left:300px;" class="modal-body" align="center" id="divReedem">
        <table style="width: 100%;">
            <tr>

                <td class="form-group">
                    <h3>Total Order Amount:</h3>
                </td>
                <td class="form-group">
                    <h4>
                        <asp:Label runat="server" ID="lblOrderAmt" Text="0"></asp:Label>
                    </h4>
                </td>
            </tr>
            <tr>
                <td class="form-group">
                    <h4>Available Reedem points:
                        <br />
                        (10 points = 1$)</h4>
                </td>
                <td class="form-group">
                    <h4>
                        <asp:Label runat="server" ID="lblPoints"></asp:Label>
                    </h4>
                </td>
            </tr>
            <tr>
                <td class="form-group">
                    <h4>
                        <asp:CheckBox ID="Chk" runat="server" Text="Click to use Reedem points" AutoPostBack="true" OnCheckedChanged="Chk_CheckedChanged" />
                    </h4>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="form-group">
                    <h4>Payment Amount:</h4>
                </td>
                <td class="form-group">
                    <h4>
                        <asp:Label ID="lblPaymentAmt" runat="server"></asp:Label>
                    </h4>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button runat="server" Text="Proceed Next" ID="btnProceed" CssClass="btn btn-success btn-lg" OnClick="Unnamed2_Click" OnClientClick="ShowConversion();return false;" />
                </td>
            </tr>
        </table>           
        </div>


    
    <div style="width: 600px; padding: 5%;display:none;margin-left:300px;" class="modal-body" align="center" id="divConversion">
        <table style="width: 100%;">
            <tr>

                <td class="form-group">
                    <h3>Pay in your currency:</h3>
                </td>
                <td class="form-group">
                    <h4>
                   
                    </h4>
                </td>
            </tr>
            <tr>
                <td class="form-group">
                    <h4> Amount:</h4>
                </td>
                <td class="form-group">
                    <h4>
                        <asp:Label ID="lblAmount" runat="server" Text="0" ></asp:Label>$
                    </h4>
                </td>
            </tr>
            <tr>
                <td class="form-group">
                    <h4>    Select Country : </h4>
                </td>
                <td class="form-group">
                    <h4>
                        <asp:DropDownList runat="server" ID="ddlCountry" onchange="ConvAmt();" CssClass="form-control"></asp:DropDownList>
                    </h4>
                </td>
            </tr>
            <tr>
                <td class="form-group">
                    <h4>
                    </h4>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="form-group">
                    <h4>Payment Amount:</h4>
                </td>
                <td class="form-group">
                    <h4>
                        <asp:Label ID="lblConvAmt" runat="server"></asp:Label>
                    </h4>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input type="button" id="btnBack" value="Back" onclick="BackToReedem();" class="btn btn-success btn-lg" />
                    <asp:Button runat="server" Text="Make Payment" ID="Button1" CssClass="btn btn-success btn-lg" OnClientClick="ShowPop(); return false;" />
                </td>
            </tr>
        </table>
        </div>

<!-- The Modal -->
<div id="myModal" class="modal">

  <!-- Modal content -->
  <div class="modal-content">
    <div class="modal-header">
      <span class="close">&times;</span>
      <h2><asp:Label runat="server" Text=" Pay" ID="lblHeadAmt"></asp:Label></h2>
    </div>
    <div class="modal-body">
      <p> Enter card details to confirm booking</p>
      
        <div class="container">
        
        <div class="row">
            <!-- You can make it whatever width you want. I'm making it full width
on <= small devices and 4/12 page width on >= medium devices -->
            <div class="col-xs-12 col-md-5">
                <!-- CREDIT CARD FORM STARTS HERE -->
                <div class="panel panel-default credit-card-box">
                    <div class="panel-heading display-table">
                        <div class="">
                            <h3 class="panel-title display-td">
                                 Payment Details</h3>
                            <div class="display-td">
                                <img class="img-responsive pull-right" src="accepted_c22e0.png">
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                       
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label for="cardNumber">
                                        CARD NUMBER</label>
                                    <div class="input-group">
                                        <input type="text" id="txtCardNo" class="form-control" name="cardNumber" placeholder="Valid Card Number"  autocomplete="off"    onkeypress="return onlyNumbers(event);" maxlength="16"/>
                                     
                                        <span class="input-group-addon"><i class="fa fa-credit-card"></i></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-7 col-md-7">
                                <div class="form-group">
                                    <label for="cardExpiry">
                                        <span class="hidden-xs">EXPIRATION</span><span class="visible-xs-inline">EXP</span>
                                        DATE</label>
                                    <input type="text" id="txtExpiry" class="form-control" name="cardExpiry" autocomplete="off" placeholder="MM / YY"
                                        maxlength="5"   onkeypress="return onlyNumbers(event);" />
                                </div>
                            </div>
                            <div class="col-xs-5 col-md-5 pull-right">
                                <div class="form-group">
                                    <label for="cardCVC">
                                        CVV CODE</label>
                                    <input type="text" id="txtCVV" autocomplete="off" class="form-control" name="cardCVC" placeholder="CVC"     onkeypress="return onlyNumbers(event);" maxlength="3"/>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label for="couponCode">
                                        Name on Card</label>
                                    <input type="text" id="txtName" class="form-control" autocomplete="off" name="name" onkeypress="return onlyAlphabets(event,this);" maxlength="30"/>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">

                                <asp:Button runat="server" ID="btnSubmit" Text="Make Payment" OnClick="btnSubmit_Click" CssClass="btn btn-success btn-lg btn-block"  OnClientClick="return Check();"/>

                            </div>
                        </div>
                        <div class="row" style="display: none;">
                            <div class="col-xs-12">
                                <p class="payment-errors">
                                </p>
                            </div>
                        </div>
                      
                    </div>
                </div>
                <!-- CREDIT CARD FORM ENDS HERE -->
            </div>
        </div>
    </div>


    </div>
  </div>

</div>

<script type="text/javascript">
    function Check()
    {
        debugger;
        var txtNo = document.getElementById("txtCardNo").value;
        if (document.getElementById("txtCardNo").value == "")
        {
            alert('Enter Card No')
            return false;
        }
        if (document.getElementById("txtCardNo").value.length != 16) {
            alert('Enter 16 digit Card No')
            return false;
        }
        if (document.getElementById("txtExpiry").value == "") {
            alert('Enter Expiry details')
            return false;
        }
        if (document.getElementById("txtCVV").value == "") {
            alert('Enter CVV Number')
            return false;
        }
        if (document.getElementById("txtName").value == "") {
            alert('Enter Name on Card')
            return false;
        }
    }

    function ConvAmt()
    {
        debugger;
        var ddl = document.getElementById("ContentPlaceHolder1_ddlCountry");
        var USamt = document.getElementById("ContentPlaceHolder1_lblAmount").innerHTML;

        var displayAmt = document.getElementById("ContentPlaceHolder1_lblConvAmt");
        var ConAmout = (parseFloat(ddl.value) * parseFloat(USamt)).toFixed(2);
        displayAmt.innerHTML = ConAmout + " " + ddl.options[ddl.selectedIndex].innerHTML;
        document.getElementById("ContentPlaceHolder1_lblHeadAmt").innerHTML = "Pay Amount : " + ConAmout + " " + ddl.options[ddl.selectedIndex].innerHTML;
    }
    function onlyNumbers(event) {
        var valid = false;
        var charCode = (event.which) ? event.which : event.keyCode
        if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode != 46 && charCode != 47) {
            //  alert('Enter Only Numbers..!');
            valid = false;
        }
        else {
            valid = true;
        }
        return valid;
    }

    function onlyAlphabets(e, t) {
        try {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32 || charCode == 8)
                return true;
            else
                return false;
        }
        catch (err) {
            alert(err.Description);
        }
    }
// Get the modal
var modal = document.getElementById('myModal');

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

function ShowPop()
{
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
</script>

    
    <script type="text/javascript">

        function ShowConversion()
        {
            document.getElementById("divConversion").style.display = "block";
            document.getElementById("divReedem").style.display = "none";
        }
        function BackToReedem()
        {

            document.getElementById("divConversion").style.display = "none";
            document.getElementById("divReedem").style.display = "block";
        }

    </script>
    
</asp:Content>

