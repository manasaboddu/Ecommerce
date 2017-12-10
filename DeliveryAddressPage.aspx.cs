using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeliveryAddressPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        long uid = 0;
        if (!IsPostBack)
        {
           // Session["deliverylocationid"] = null;
            if (Session["UserAccountID"] != null)
            {
                uid = long.Parse(Session["UserAccountID"].ToString());
                List<DeliveryLocations> lstLoctions = new DeliveryLocations().GetDeliveryDetails(uid);

                dlLocations.DataSource = lstLoctions;
                dlLocations.DataBind();
                hdnRowCount.Value = lstLoctions.Count.ToString();
            }
        }

    }
    protected void BtnSaveContinue_Click(object sender, EventArgs e)
    {
        
        DeliveryLocations objdlocation = new DeliveryLocations();

        objdlocation.FName = txtname.Text;
        objdlocation.LName =  txtLName.Text;
        objdlocation.Street1 = txtstreet1.Text;
        objdlocation.Street2 = txtstreet2.Text; ;
        objdlocation.City =  txtcity.Text;
        objdlocation.PostalCode =  txtpincode.Text;
        objdlocation.PhoneNo = txtphoneno.Text;
        objdlocation.UserAccountID = long.Parse(Session["UserAccountID"].ToString());
        long dlid = 0;
        if (hdnDLID_S.Value != "" && hdnDLID_S.Value != "0")
        {
            dlid = long.Parse(hdnDLID_S.Value);
            objdlocation.DeliveryLocationsID = long.Parse(hdnDLID_S.Value);
            objdlocation.UpdateDeliveryLocation();
        }
        else
        {
            dlid = objdlocation.SaveDeliveryDetails();

        }
        Session["deliverylocationid"] = dlid.ToString();

        if (dlid != 0)
        {
            Orders obj = new Orders();
            
            obj.OrderID = long.Parse(Session["OrderId"].ToString());
            obj.Status = "Pending";
            obj.Remarks = "";
            obj.UserAccountID = long.Parse(Session["UserAccountID"].ToString());
            obj.DeliveryLocationsID = dlid;
            obj.DeliveryMobileNo = long.Parse(txtphoneno.Text);
            obj.DeliverToPersonName = txtname.Text;
            obj.UpdateOrderDetails();
        }      
        Response.Redirect("Cart.aspx");
    }
}