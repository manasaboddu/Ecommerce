<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMasterPage.master" AutoEventWireup="true" CodeFile="MyBooking.aspx.cs" Inherits="MyBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <table style=" width:100%;"   >
<tr><td>
<div class="cartpage-tabs">

<div id=""  style=" padding-top:30px; padding-bottom:30px;" align="center" >
<asp:Label ID="lblorderreference" runat="server" ForeColor="#299AD2" Text=""></asp:Label><br /><br />

          <asp:Label ID="lblorderrefvalue" runat="server" Text='<%#Eval("OrderNo") %>' Font-Size="Large" ></asp:Label><br /><br />
                    <asp:Label ID="Label2" runat="server" ForeColor="#299AD2" Text="Your order will be delivered soon"></asp:Label>&nbsp&nbsp Click here to <a href="MyOrderStatus.aspx">My Orders</a>


</div>
</div>
</td></tr>

</table>
</asp:Content>

