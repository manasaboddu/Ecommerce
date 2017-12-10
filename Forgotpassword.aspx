<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true" CodeFile="Forgotpassword.aspx.cs" Inherits="Forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style>

.styled-button-8 {
	background: #25A6E1;
	background: -moz-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
	background: -webkit-gradient(linear,left top,left bottom,color-stop(0%,#25A6E1),color-stop(100%,#188BC0));
	background: -webkit-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
	background: -o-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
	background: -ms-linear-gradient(top,#25A6E1 0%,#188BC0 100%);
	background: linear-gradient(top,#25A6E1 0%,#188BC0 100%);
	-webkit-filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#25A6E1',endColorstr='#188BC0',GradientType=0);
	-moz-filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#25A6E1',endColorstr='#188BC0',GradientType=0);
	padding:8px 13px;
	color:#fff;
	font-family:Arial;
	font-size:17px;
	-webkit-border-radius:4px;
	-moz-border-radius:4px;
	-webkit-border-radius:4px;
	border:1px solid #1A87B9;
} 
</style>
    <div align="left" style="margin-left:55px;width:70%;min-height:300px;" >
      
                    <table align="center" width="100%;">
                    <tr>
                    <td colspan="3" style="height:50px;vertical-align:middle;">
                      <asp:Label ID="lblforgotpassword" ForeColor="#13C5B7" Font-Size="20px" Text="Forgot Password"
                    runat="server"></asp:Label>
                    
                    </td>
                    
                    </tr>
                        <tr >
                            <td align="center" width="20%" style=" padding-left:150px;">
                                <asp:Label ID="lblemailid" runat="server" Text="EmailId"></asp:Label>
                            </td>
                            <td width="30%">
                                <asp:TextBox ID="txtemail" Width="360px" Height="35px" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td width="20%">
                                <asp:Label ID="lblresult" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style=" padding-top:10px;">
                                &nbsp &nbsp &nbsp &nbsp &nbsp<asp:Button ID="btnsave" runat="server" Text="Submit"
                                    CssClass="styled-button-8" Height="38px" OnClick="btnsave_Click" />
                            </td>
                            <td></td>
                        </tr>
                    </table>
           
</div>
</asp:Content>

