<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true" CodeFile="DeliveryAddressPage.aspx.cs" Inherits="DeliveryAddressPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">

        function ValidateTextBoxValues(ctrl) {
            var btnsave = document.getElementById("ContentPlaceHolder1_BtnSaveContinue");
            var control = document.getElementById(ctrl);
            var controllength = control.value;


            if (ctrl.search("ContentPlaceHolder1_txtphoneno") != "-1") {
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
            if (ctrl.search("ContentPlaceHolder1_txtpincode") != "-1") {
                if (control.value != "") {
                    if (controllength.length == 5) {
                        btnsave.style.display = "block";
                    }
                    else {
                        btnsave.style.display = "none";
                        alert("Enter Valid Pincode...");
                        setTimeout(function () { control.focus(); }, 1);
                    }
                }
            }
        }
        function onlyNumbers(event) {
            var valid = false;
            var charCode = (event.which) ? event.which : event.keyCode
            if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode != 46) {
                valid = false;
            }
            else {
                valid = true;
            }
            return valid;
        }
        function ValidateCheckBoxSelection(ctrl) {
            var hdnRowCount = document.getElementById("ContentPlaceHolderBody_hdnRowCount");
            var hdnDLID_S = document.getElementById("ContentPlaceHolderBody_hdnDLID_S");
            var chkControl = document.getElementById(ctrl);
            for (i = 0; i < parseFloat(hdnRowCount.value); i++) {
                var chkid = document.getElementById("ContentPlaceHolder1_dlLocations_chkAddress_" + i);
                var hdnDLID = document.getElementById("ContentPlaceHolder1_dlLocations_hdnDLID_" + i);
                if (chkid != null) {
                    if (chkid.checked) {
                        hdnDLID_S.value = hdnDLID.value;
                    }
                }
            }
        }

        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtname").attr("autocomplete", "off");
            $("#ContentPlaceHolder1_txtLName").attr("autocomplete", "off");

            $("#ContentPlaceHolder1_txtstreet1").attr("autocomplete", "off");
            $("#ContentPlaceHolder1_txtstreet2").attr("autocomplete", "off");
            $("#ContentPlaceHolder1_txtcity").attr("autocomplete", "off");
            $("#ContentPlaceHolder1_txtpincode").attr("autocomplete", "off");
            $("#ContentPlaceHolder1_txtphoneno").attr("autocomplete", "off");
        });

        function CleareCheckBoxSelection(ctrl) {
            debugger;
            var hdnRowCount = document.getElementById("ContentPlaceHolder1_hdnRowCount");
            var hdnDLID_S = document.getElementById("ContentPlaceHolder1_hdnDLID_S");
            var txtname = document.getElementById("ContentPlaceHolder1_txtname");
            var txtdoorno = document.getElementById("ContentPlaceHolder1_txtLName");
            var txtstreet1 = document.getElementById("ContentPlaceHolder1_txtstreet1");
            var txtstreet2 = document.getElementById("ContentPlaceHolder1_txtstreet2");
            var txtcity = document.getElementById("ContentPlaceHolder1_txtcity");
            var txtpincode = document.getElementById("ContentPlaceHolder1_txtpincode");
            var txtphoneno = document.getElementById("ContentPlaceHolder1_txtphoneno");
            
            var chkControl = document.getElementById(ctrl);
            for (i = 0; i < parseFloat(hdnRowCount.value); i++) {
                var chkid = document.getElementById("ContentPlaceHolder1_dlLocations_chkAddress_" + i);
                var hdnDLID = document.getElementById("ContentPlaceHolder1_dlLocations_hdnDLID_" + i);
                var lblName_ = document.getElementById("ContentPlaceHolder1_dlLocations_lblName_" + i);
                var lblLName_ = document.getElementById("ContentPlaceHolder1_dlLocations_lblLName_" + i);
             //   var lblApartmentName_ = document.getElementById("ContentPlaceHolder1_dlLocations_lblApartmentName_" + i);
                var lblStreet1_ = document.getElementById("ContentPlaceHolder1_dlLocations_lblStreet1_" + i);
                var lblStreet2_ = document.getElementById("ContentPlaceHolder1_dlLocations_lblStreet2_" + i);
                var lblCity_ = document.getElementById("ContentPlaceHolder1_dlLocations_lblCity_" + i);
                var lblPincode_ = document.getElementById("ContentPlaceHolder1_dlLocations_lblPincode_" + i);
                var lblPhone_ = document.getElementById("ContentPlaceHolder1_dlLocations_lblPhone_" + i);
                if (chkid != null) {

                    if (chkControl.id == chkid.id) {
                        chkid.checked = chkControl.checked;
                        if (chkid.checked) {
                            hdnDLID_S.value = hdnDLID.value;
                            txtname.value = lblName_.innerHTML;
                            txtdoorno.value = lblLName_.innerHTML;
                            txtstreet1.value = lblStreet1_.innerHTML;
                            txtstreet2.value = lblStreet2_.innerHTML;
                            txtcity.value = lblCity_.innerHTML;
                            txtpincode.value = lblPincode_.innerHTML;
                            txtphoneno.value = lblPhone_.innerHTML;
                        }
                        else {
                            hdnDLID_S.value = "0";
                            txtname.value = "";
                            txtdoorno.value = "";
                         //   txtapartmentname.value = "";
                            txtstreet1.value = "";
                            txtstreet2.value = "";
                            txtcity.value = "";
                            txtpincode.value = "";
                            txtphoneno.value = "";
                        }
                    }
                    else {
                        chkid.checked = false;
                    }
                }
            }
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

    </script>

    <div class="container" style="text-align: center;">
    <div align="center" style="width:100%;">
        <table align="center" style="position: relative; top: 12px; left: 0px;width:100%;">
            <tr>
                <td colspan="3" style="color: #005387; font-size: medium;" align="left">
                    DELIVERY ADDRESS
                    <hr style="color: #8E8989; font-size: xx-small; line-height: 0.001;" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div class="col-md-12" style="padding:0px;width:100%;">
                    <asp:HiddenField runat="server" ID="hdnRowCount" />
                    <asp:HiddenField runat="server" ID="hdnDLID_S" />
                        <asp:DataList runat="server" ID="dlLocations" RepeatColumns="3" RepeatDirection="Vertical" ItemStyle-Width="33%" ItemStyle-CssClass="AddressCss" style="width:100%;">
                            <ItemTemplate>
                                <div class="col-md-12" style="border:solid 1px gray;border-radius:0%;">
                                    <div class="col-md-2" style="padding:0px;">
                                        <asp:CheckBox runat="server" ID="chkAddress" onclick="CleareCheckBoxSelection(this.id);" />
                                    </div>
                                    <div class="col-md-10" style="padding:0px;">
                                        <asp:Label runat="server" ID="lblName" Text='<%#Eval("FName") %>'></asp:Label>,<br />
                                        <asp:Label runat="server" ID="lblLName" Text='<%#Eval("LName") %>'></asp:Label>,
                                        <br />
                                        <asp:Label runat="server" ID="lblStreet1" Text='<%#Eval("Street1") %>'></asp:Label>,
                                        <asp:Label runat="server" ID="lblStreet2" Text='<%#Eval("Street2") %>'></asp:Label><br />
                                        <asp:Label runat="server" ID="lblCity" Text='<%#Eval("City") %>'></asp:Label>,<br />
                                        <asp:Label runat="server" ID="lblPincode" Text='<%#Eval("PostalCode") %>'></asp:Label>,<br />
                                        <asp:Label runat="server" ID="lblPhone" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                                        <asp:HiddenField runat="server" ID="hdnDLID" Value='<%#Eval("DeliveryLocationsID") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 10px;">
                <td colspan="3" style="color: #005387; font-size: medium;" align="left">
                New Delivery Location
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; vertical-align: top;">
                    <asp:Label ID="lblname" ForeColor="Black" runat="server" Text=" First Name"></asp:Label><asp:Label
                        ID="namest" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td align="left" class="style1" style="">
                    <asp:TextBox ID="txtname" MaxLength="40" Width="300px" Height="28px" runat="server" onkeypress="return onlyAlphabets(event,this);" ></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvname" runat="server" ControlToValidate="txtname" ValidationGroup="vgd"
                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td align="right">
                </td>
            </tr>
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; vertical-align: top;">
                    <asp:Label ID="lbldoorno" ForeColor="Black" runat="server" Text="Last Name"></asp:Label><asp:Label
                        ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label><br />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="txtLName" Width="300px" Height="28px" runat="server" MaxLength="30" onkeypress="return onlyAlphabets(event,this);" > </asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvLname" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtLName"
                        ValidationGroup="vgd"></asp:RequiredFieldValidator>
                </td>
                <td align="right">
                </td>
            </tr>
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; vertical-align: top;">
                    <asp:Label ID="lblapartmentname" ForeColor="Black" Text="Address Line 1" runat="server"></asp:Label><asp:Label  ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="txtstreet1" Width="300px" Height="28px" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtstreet1"
                        ValidationGroup="vgd"></asp:RequiredFieldValidator>
                </td>
                <td align="right">
                </td>
            </tr>
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; vertical-align: top;">
                    <asp:Label ID="lblstreet1" ForeColor="Black" runat="server" Text="Address line 2"></asp:Label><asp:Label
                        ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="txtstreet2" Width="300px" Height="28px" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvstreet1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtstreet1"
                        ValidationGroup="vgd"></asp:RequiredFieldValidator>
                </td>
                <td align="right">
                </td>
            </tr>
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; vertical-align: top;">
                    <asp:Label ID="lblcity" ForeColor="Black" Text="City" runat="server"></asp:Label><asp:Label
                        ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="txtcity" Width="300px" Height="28px" runat="server" onkeypress="return onlyAlphabets(event,this);" ></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvcity" runat="server" ErrorMessage="*" ControlToValidate="txtcity" ForeColor="Red"
                        ValidationGroup="vgd" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td align="right">
                </td>
            </tr>
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
                        
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; vertical-align: top;">
                    <asp:Label ID="lblpincode" runat="server" ForeColor="Black" Text="ZIP code"></asp:Label><asp:Label
                        ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="txtpincode" Width="300px" Height="28px" runat="server" MaxLength="5" onkeypress="return onlyNumbers(event)"
                        onblur="ValidateTextBoxValues(this.id);"></asp:TextBox><asp:RequiredFieldValidator
                            ID="rfvpincode" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgd"
                            ControlToValidate="txtpincode"></asp:RequiredFieldValidator>
                </td>
                <td align="right">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; vertical-align: top;">
                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="Phone No"></asp:Label><asp:Label
                        ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="txtphoneno" Width="300px" MaxLength="10" Height="28px" runat="server" onkeypress="return onlyNumbers(event)"
                        onblur="ValidateTextBoxValues(this.id);"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgd"
                            ControlToValidate="txtphoneno"></asp:RequiredFieldValidator>
                </td>
                <td align="right">
                    <br />
                    <br />
                </td>
            </tr>
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Button ID="BtnSaveContinue" runat="server" ValidationGroup="vgd" CssClass="styled-button-8"
                        Text="SAVE & CONTINUE " Width="175px" Height="38" OnClick="BtnSaveContinue_Click" />
                </td>
            </tr>
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
            <tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr><tr style="height: 6px;">
                <td colspan="3">
                </td>
            </tr>
        </table>

        <div class="col-md-12" style="height:50px;"></div>
    </div>
    
    </div>
    
</asp:Content>

