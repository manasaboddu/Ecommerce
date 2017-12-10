using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlCountry.DataSource = new CurrencyService().GetAllConverstions(false);
            ddlCountry.DataTextField = "ConversionTypeTo";
            ddlCountry.DataValueField = "ToValue";
            ddlCountry.DataBind();
           // double Amt = 0;
            if (Session["orderamount"] != null)
            {
                lblOrderAmt.Text = Session["orderamount"].ToString();
                lblPaymentAmt.Text = Session["orderamount"].ToString();
                lblAmount.Text = lblPaymentAmt.Text;
                lblConvAmt.Text = lblPaymentAmt.Text + " " + ddlCountry.SelectedItem.Text;
                lblHeadAmt.Text= "Pay Amount : "+ lblPaymentAmt.Text + " " + ddlCountry.SelectedItem.Text;
            }

            string userid = "0";
            if (Session["UserAccountID"] != null)
            {
                userid = Session["UserAccountID"].ToString();

                string Points = new Utilities().GetResultForQueryfromDB("select ISNULL(SUM(Points), 0) - (select  ISNULL(sum(Points), 0) from ReedemPoints where Type = 'Debit' and UserID = " + userid + ") from ReedemPoints where Type = 'credit' and UserID = " + userid);
                lblPoints.Text = Points;

                Label lblMasterPts = (Label)Master.FindControl("lblMPoints");
                if (lblMasterPts != null)
                {
                    lblMasterPts.Text = "Reedem Points : " + Points;
                }
            }

        }
    }



    protected void Unnamed2_Click(object sender, EventArgs e)
    {

    }

    protected void Chk_CheckedChanged(object sender, EventArgs e)
    {
        if (Chk.Checked)
        {
            double pointsDiscount = double.Parse(lblPoints.Text) / 10;

            double Tot = double.Parse(lblOrderAmt.Text) - pointsDiscount;
            lblPaymentAmt.Text = Tot.ToString("0.00");
            lblAmount.Text = Tot.ToString("0.00");
            lblConvAmt.Text = Tot.ToString("0.00") + " " + ddlCountry.SelectedItem.Text;
            lblHeadAmt.Text = "Pay Amount : " + Tot.ToString("0.00") + " " + ddlCountry.SelectedItem.Text;
        }
        else
        {
            lblPaymentAmt.Text = lblOrderAmt.Text;
            lblAmount.Text = lblOrderAmt.Text;

            lblConvAmt.Text = lblOrderAmt.Text + " " + ddlCountry.SelectedItem.Text;
            lblHeadAmt.Text = "Pay Amount : " + lblOrderAmt.Text + " " + ddlCountry.SelectedItem.Text;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["OrderId"] != null)
        {
            Orders objOrder = new Orders();
            objOrder.OrderID = long.Parse( Session["OrderId"].ToString());
            objOrder.Status = "Success";
            objOrder.OrderAmount = float.Parse(lblAmount.Text);
            objOrder.UpdateOrderStatus();

            if (Chk.Checked)
            {

                string Pts = new Utilities().GetResultForQueryfromDB("select ISNULL(SUM(Points), 0) - (select  ISNULL(sum(Points), 0) from ReedemPoints where Type = 'Debit' and UserID = " + Session["UserAccountID"].ToString() + ") from ReedemPoints where Type = 'credit' and UserID = " + Session["UserAccountID"].ToString());
                ReedemPoints objR = new ReedemPoints();
                objR.UserID = long.Parse(Session["UserAccountID"].ToString());
                objR.OrderType = "Booking";
                objR.Type = "Debit";
                objR.Points = long.Parse(Pts);
                objR.SaveRecord();
            }
            ReedemPoints objCR = new ReedemPoints();
            objCR.UserID = long.Parse(Session["UserAccountID"].ToString());
            objCR.OrderType = "Booking";
            objCR.Type = "Credit";
            objCR.Points =  long.Parse(Math.Round(double.Parse(lblPaymentAmt.Text)).ToString());
            objCR.SaveRecord();

            Session["OrderId"] = null;
            Session["count"] = null;
            Response.Redirect("MyOrderStatus.aspx");

        }

    }

}