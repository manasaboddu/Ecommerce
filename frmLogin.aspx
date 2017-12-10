<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true"
    CodeFile="frmLogin.aspx.cs" Inherits="frmLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {

            $('#login-form-link').click(function (e) {
                $("#logindiv").delay(100).fadeIn(100);
                //  document.getElementById("logindiv").style.display = 'block';
                $("#register-form").fadeOut(100);
                $('#register-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });
            $('#register-form-link').click(function (e) {
                $("#register-form").delay(100).fadeIn(100);
                // $("#login-form").fadeOut(100);
                document.getElementById("logindiv").style.display = 'none';
                $('#login-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });

        });
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtMobile").attr("autocomplete", "off");
            $("#ContentPlaceHolder1_txtregfname").attr("autocomplete", "off");
            $("#ContentPlaceHolder1_txtreglname").attr("autocomplete", "off");
            $("#ContentPlaceHolder1_txtregemailid").attr("autocomplete", "off");
            $("#lgnemailid").attr("autocomplete", "off");
        });
        function BindLoginDetails() {
            // debugger;
            var emailid = $('#lgnemailid').val();
            var passwrd = $('#lgnpswrd').val();
            document.getElementById('ContentPlaceHolder1_hdnlgnemailid').value = emailid;
            document.getElementById('ContentPlaceHolder1_hdnlgnpswrd').value = passwrd;
            // alert(emailid);alert(passwrd);
        }
        function disableEnterKey(e) {
            //create a variable to hold the number of the key that was pressed      
            var key;
            //if the users browser is internet explorer 
            if (window.event) {
                //store the key code (Key number) of the pressed key 
                key = window.event.keyCode;
                //otherwise, it is firefox 
            } else {
                //store the key code (Key number) of the pressed key 
                key = e.which;
            }
            //if key 13 is pressed (the enter key) 
            if (key == 13) {
                //do nothing 
                return false;
                //otherwise 
            } else {
                //continue as normal (allow the key press for keys other than "enter") 
                return true;
            }
        }
        function ValidateTextBoxValues(ctrl) {
            var btnsave = document.getElementById("contentusermaster_btnregister");
            var control = document.getElementById(ctrl);
            var controllength = control.value;


            if (ctrl.search("contentusermaster_txtphnum") != "-1") {
                if (control.value != "") {
                    if (controllength.length == 10) {
                        btnsave.style.display = "block";
                    }
                    else {
                        btnsave.style.display = "none";
                        alert("Enter Valid Mobile Number...");
                        setTimeout(function () { control.focus(); }, 1);
                    }
                }
            }
        }

        function onlyNumbers(event) {
            var valid = false;
            var charCode = (event.which) ? event.which : event.keyCode
            if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode != 46) {
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
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32|| charCode == 8)
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }

        function ValidateTextBoxValues(ctrl) {
            debugger;
            var control = document.getElementById(ctrl);
            var controllength = control.value;
            if (ctrl.search("ContentPlaceHolder1_txtMobile") != "-1") {
                if (control.value != "") {
                    if (controllength.length == 10) {
                        document.getElementById("ContentPlaceHolder1_btnregister").style.display = "block";
                    }
                    else {
                        document.getElementById("ContentPlaceHolder1_btnregister").style.display = "none";
                        alert("Enter Valid Mobile Number...");                        
                        control.value = "";
                    }
                }
            }
        }


        function UserOrEmailAvailability() {

            var email = document.getElementById("ContentPlaceHolder1_txtregemailid");

            WebService.DoesEmailExist(email.value, onSuccess, onerror);
            // alert(email.value);
        }
        function onSuccess(result) {
            if (result == true) {
                alert('EMail-Id already Exists');
                //  document.getElementById("ContentPlaceHolder1_txtregemailid").focus();

                $('#ContentPlaceHolder1_txtregemailid').val('');
            }
        }
        function onerror() {
            alert("Error");
        }

        function PasswordValidate(ctrl) {
            var control = document.getElementById(ctrl);
            var controllength = control.value;
            var password = document.getElementById("ContentPlaceHolder1_txtPassword").value;
            var confirmPassword = document.getElementById("ContentPlaceHolder1_txtCnfPassword").value;
            if (password != confirmPassword) {
                alert("Passwords do not match.");
                document.getElementById("ContentPlaceHolder1_btnregister").style.display = "none";
                document.getElementById("ContentPlaceHolder1_txtCnfPassword").value = '';
                document.getElementById("ContentPlaceHolder1_txtPassword").value = '';
                setTimeout(function () { document.getElementById("ContentPlaceHolder1_txtPassword").focus(); }, 1);
                return false;
            }
            else {
                document.getElementById("ContentPlaceHolder1_btnregister").style.display = "block";
             }
            return true;
        }

        function validate(email) {

            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
            //var address = document.getElementById[email].value;
            if (reg.test(email) == false) {
                alert('Invalid Email Address');
                return (false);
            }
        }

        function testing() {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            var firstname = document.getElementById('ContentPlaceHolder1_txtregfname').value;
            var lastname = document.getElementById('ContentPlaceHolder1_txtreglname').value;
            var emailid = document.getElementById('ContentPlaceHolder1_txtregemailid').value;
            var mobileno = document.getElementById('ContentPlaceHolder1_txtMobile').value;
            // alert('');

            if (firstname != '' && lastname != '' && emailid != '' && mobileno != '') {
                if (reg.test(emailid) == true) {
                    WebService.SaveNewUser(firstname, lastname, emailid, "", mobileno, Onsuccess, onusererror);
                }
                else {
                    alert('Invalid Email Address');
                }
            }
            else {
                alert('Please fill all the Details..!');
                valid = false;
            }

            return false;
        }
        function Onsuccess(result) {
            if (result == "Success") {
                var firstname = document.getElementById('ContentPlaceHolder1_txtregfname');
                var lastname = document.getElementById('ContentPlaceHolder1_txtreglname');
                var emailid = document.getElementById('ContentPlaceHolder1_txtregemailid');
                var mobileno = document.getElementById('ContentPlaceHolder1_txtMobile');
                firstname.value = "";
                lastname.value = "";
                emailid.value = "";
                mobileno.value = "";

                alert(' Registration Completed Successfully..! Your account is credited with 50 points..');
            }
            else {
                alert("Your Registration is not completed.!Please try again..!");
            }
        }
        function onusererror() {
            alert('Invalid Emailid..!Please try again..!');
        }

    </script>
    <link href="css/logincss.css" rel="stylesheet" type="text/css" />
    <div class="container">
   <%-- <img src="images/Please Wait.gif" id="img" style="display:none"/ >--%>
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-6">
                                <a href="#" class="active" id="login-form-link">Login</a>
                            </div>
                            <div class="col-xs-6">
                                <a href="#" id="register-form-link">Register</a>
                            </div>
                        </div>
                        <hr>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div id="logindiv">
                                    <form id="login-form" action="" method="post" role="form" style="display: block;"
                                    class="form-inline">
                                    <div class="form-group">
                                        <input type="email" class="form-control input-sm" id="lgnemailid" name="txtloginemailid"
                                            placeholder="Email ID" required />
                                        <asp:HiddenField ID="hdnlgnemailid" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <input type="password" name="lgnpswrd" id="lgnpswrd" tabindex="2" class="form-control input-sm"
                                            placeholder="Password" required>
                                        <asp:HiddenField ID="hdnlgnpswrd" runat="server" />
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-6 col-sm-offset-3" style="text-align: center;">
                                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" TabIndex="4"
                                                    Text="Log In" OnClick="btnsignin_Click" OnClientClick="BindLoginDetails()" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="text-center">
                                                    <%--<a href="Forgotpassword.aspx" tabindex="5" class="forgot-password">Forgot Password?</a>--%>
                                                </div>
                                                <div class="text-center">
                                                    <asp:Label runat="server" ID="lblMsg" ForeColor="Red" Font-Bold="true"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    </form>
                                </div>
                                <form id="register-form" action="" method="post" role="form" style="display: none;">
                                <div class="form-group">
                                    <asp:TextBox ID="txtregfname" runat="server" ToolTip="First Name" CssClass="form-control"
                                        onkeypress="return onlyAlphabets(event,this);" TabIndex="1" placeholder="First Name"
                                        required></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtreglname" runat="server" ToolTip="Last Name" CssClass="form-control"
                                        onkeypress="return onlyAlphabets(event,this);" TabIndex="2" placeholder="Last Name"
                                        required></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtregemailid" ToolTip="Email-Id" runat="server" CssClass="form-control"
                                        onKeyPress="return disableEnterKey(event)" onblur="UserOrEmailAvailability()" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$"
                                        TabIndex="3" placeholder="Email-Id" required></asp:TextBox>
                                </div>
                              
                                <div class="form-group">
                                    <asp:TextBox runat="server" MaxLength="10" ID="txtMobile" CssClass="form-control" onkeypress="return onlyNumbers(event);" TabIndex="6" 
                                        onblur="ValidateTextBoxValues(this.id);"  placeholder="Mobile Number" />
<%--                                    <asp:RegularExpressionValidator ID="REPin" runat="server" ControlToValidate="TxtMobile"
                                        Display="Dynamic" ErrorMessage="Enter 10 digit Mobile Number" Font-Bold="False"
                                        Font-Size="Smaller" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{10}"
                                        ValidationGroup="forSave">Invalid Characters</asp:RegularExpressionValidator>--%>
                                </div>                                
                                <div class="form-group">
                                    <div class="row">
                                      <div class="col-sm-6 col-sm-offset-3">                                   
                                            <asp:Button ID="btnregister" runat="server" Text="Register Now" CssClass="form-control btn btn-register"
                                                TabIndex="7" ValidationGroup="forSave" OnClientClick="return testing();"/>
                                     </div>
                                    </div>
                                </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
