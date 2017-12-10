<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true" CodeFile="Changeuserlogin.aspx.cs" Inherits="Changeuserlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="Styles/WaterMark.min.js" type="text/javascript"></script>
<style type="text/css">
    
   .btn {
    -moz-user-select: none;
    background-image: none;
    border: 1px solid transparent;
    border-radius: 0;
    cursor: pointer;
    display: inline-block;
    font-size: 14px;
    font-weight: normal;
    line-height: 1.42857;
    margin-bottom: 0;
    padding: 6px 12px;
    text-align: center;
    vertical-align: middle;
    white-space: nowrap;
}
.btn:focus {
    outline: thin dotted #333;
    outline-offset: -2px;
}
.btn:hover, .btn:focus {
    color: #ffffff ;
    text-decoration: none;
}

.btn-default {
    background-color: #ffffff;
    color: #ffffff;
}


    


</style>
<script type="text/javascript">

    function showhide() {
        //        var div = document.getElementById('chngediv');
        div = document.getElementById('<%=chngediv.ClientID%>')

        if (document.getElementById('chkchngepswrd').checked) {
            div.style.visibility = "visible";

        }
        else {
            div.style.visibility = "hidden";

        }

        chngediv
    }



    //    function showhide(chkchngepswrd, chngediv) {
    //        alert("hai");

    //        if ($get(chkchngepswrd).checked == true) {
    //            $get(chngediv).display = "none";
    //        }
    //        else {
    //            $get(chngediv).style.display = "";
    //        }
    //    }

    $(function () {
        $("[id*=txtcurrentpswrd], [id*=txtchngepswrd], [id*=txtrepswrd]").WaterMark();

    });
</script>
<table width="100%">
<tr>
<td colspan="4">
    <asp:Label ID="lblresult" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td colspan="2" align="left" style=" padding-left:90px;">
<h2> Personal Settings</h2>
</td>
<td colspan="2" align="center">
    &nbsp;</td>
</tr>
<div style="border-color:Gray;">
<tr>
<td rowspan="3" align="center" colspan="3">
<div style="vertical-align:middle;">
 <asp:TextBox ID="txtfirstname" runat="server" Height="30px" Width="450px"></asp:TextBox>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtfirstname" ErrorMessage="*" ForeColor="Red" 
        ValidationGroup="persnlstngs"></asp:RequiredFieldValidator>

    <br />
    <br />

    <asp:TextBox ID="txtlastname" runat="server" Height="30px" Width="450px"></asp:TextBox>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtlastname" ErrorMessage="*" ForeColor="Red" 
        ValidationGroup="persnlstngs"></asp:RequiredFieldValidator>

    <br />
    <br />

    <asp:TextBox ID="txtemailid" runat="server" Height="30px" Width="450px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtemailid" ErrorMessage="*" ForeColor="Red" 
        ValidationGroup="persnlstngs"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtemailid" ErrorMessage="Enter Valid Email-Id" 
        ForeColor="Red" ValidationGroup="persnlstngs" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
</div>
   
    </td>
<td>

    &nbsp;</td>
</tr>

<tr>
<td>

    &nbsp;</td>
</tr>

<tr>
<td>

    &nbsp;</td>
</tr>

<tr>
<td colspan="3">

    &nbsp;</td>
<td>

    &nbsp;</td>
</tr>

<tr>
<td  align="left" style="padding-left:90px;">

   
<input id="chkchngepswrd"  name="ChangePassword" type="checkbox" onclick="showhide()" />
<label for="chkchngepswrd">Change Password</label>
<%--
    <asp:CheckBox  Id="chkchngepswrd"  Font-Bold="True"  runat="server"
        ForeColor="Black" Text="Change Password"  OnCheckedChanged='' />--%>
    </td>
<td width="30%" colspan="2">

    &nbsp;</td>
<td>

    &nbsp;</td>
</tr>

<tr>
<td rowspan="3" align="center"  width="70%" colspan="3">
<div id="chngediv" runat="server">

        

        <asp:TextBox ID="txtcurrentpswrd" runat="server" ForeColor="Gray" Height="30px" Width="450px"
                  TextMode="Password" ToolTip="Enter Current Password" />


        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtcurrentpswrd" ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="persnlstngs"></asp:RequiredFieldValidator>


        <br />


        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>


    <br />

    <asp:TextBox ID="txtchngepswrd" runat="server" Height="30px" Width="450px"
        ForeColor="#666666"  TextMode="Password" ToolTip="Enter New Password" ></asp:TextBox>

   
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="txtchngepswrd" ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="persnlstngs"></asp:RequiredFieldValidator>

   
    <br />
    <br />

    <asp:TextBox ID="txtrepswrd" runat="server" Height="30px" Width="450px"
        ForeColor="#666666" TextMode="Password" ToolTip="Re-Enter New Password" ></asp:TextBox>


        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="txtrepswrd" ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="persnlstngs"></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txtchngepswrd" ControlToValidate="txtrepswrd" 
            ErrorMessage="Password Mis-Match" ForeColor="Red" ValidationGroup="persnlstngs"></asp:CompareValidator>


</div>
    
    </td>
<td>

    &nbsp;</td>
</tr>

<tr>
<td>

    &nbsp;</td>
</tr>

<tr>
<td>

    &nbsp;</td>
</tr>

<tr>
<td colspan="3">

    &nbsp;</td>
<td>

    &nbsp;</td>
</tr>

<tr>
<td align="center">

    <asp:Button ID="btnsavechanges" runat="server" Text="Save Changes" 
        CssClass="btn btn-default" BackColor="#008B83" onclick="btnsavechanges_Click" 
        ValidationGroup="persnlstngs" />
    </td>
<td width="30%" colspan="2">

    &nbsp;</td>
<td>

    &nbsp;</td>
</tr>
</div>
<tr>
<td colspan="3">

    &nbsp;</td>
<td>

    &nbsp;</td>
</tr>

<tr>
<td colspan="3">

    &nbsp;</td>
<td>

    &nbsp;</td>
</tr>
</table>

</asp:Content>

