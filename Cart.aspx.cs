using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindtoGrid();

        }

    }

    List<Products> lstcartp = new List<Products>();
    public void BindtoGrid()
    {
        List<Products> newlist = new List<Products>();
        if (Session["pid"] != null)
        {
            string prid = Session["pid"].ToString();
            if (Session["count"] != null)
            {
                LinkButton lblcount = (LinkButton)Master.FindControl("lblcount");
                lblcount.Text = Session["count"].ToString();
            }
            
            string userid = "";
            if (Session["UserAccountID"] != null)
            {
                userid = Session["UserAccountID"].ToString();
            }
            string OrderId = "";
            if (Session["OrderId"] != null)
            {
                OrderId = Session["OrderId"].ToString();
            }

            List<Orders> lstOrder = new Orders().GetOrders(OrderId, userid, "", "", "", "", "", " order by OrderDateTime desc");

            if(lstOrder != null)
            {

                CartGridview.DataSource = lstOrder[0].lstDetails;
                CartGridview.DataBind();
                Session["lstfinalCartData"] = lstOrder[0].lstDetails;
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    double Tot =0;
    protected void CartGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSubtotal = (Label)e.Row.FindControl("lblSubtotal");
           // Label lblSubSymbol = (Label)e.Row.FindControl("lblSubSymbol");
          //  symbol = lblSubSymbol.Text;

            Tot += Convert.ToSingle(lblSubtotal.Text);
            int myInt = (int)Math.Ceiling(double.Parse(Tot.ToString()));
            Session["orderamount"] = myInt.ToString("0.00");
            lblTotalAmt.Text = myInt.ToString("0.00");

        }
    }
    

    protected void BtnContinue_Click(object sender, EventArgs e)
    {
        if (chkPromo.Checked)
        {
            Order_Offers objOF = new Order_Offers();
            objOF.UserID = long.Parse(Session["UserAccountID"].ToString());
            objOF.CaseNo = long.Parse(Session["OrderId"].ToString());
            objOF.CaseType = "Order";
            objOF.OfferCode = txtPromocode.Text;
            objOF.OfferAmount = float.Parse(hdnPromAmt.Value);
            objOF.AppliedOn = DateTime.Now;
            objOF.SaveOrder_Offers();

            Double Amt = Double.Parse(lblTotalAmt.Text) - double.Parse(hdnPromAmt.Value);
            Session["orderamount"] = Amt.ToString("0.00");
        }
        

        Response.Redirect("Pay.aspx");
        //  mpeLogin.Show();
    }
    

    protected void btnCheckPromo_Click(object sender, EventArgs e)
    {
        if (txtPromocode.Text != "")
        {
            string date = DateTime.Now.ToString("dd-MMM-yyyy");
            string str = new Utilities().GetResultForQueryfromDB("select OfferType + ','+ OfferAmount from OfferMaster where  OfferCode='" + txtPromocode.Text+ "'");
            if (str != "")
            {
                string[] Arr = str.Split(',');
                if (Arr[0] == "Percent")
                {
                    hdnPromAmt.Value = (double.Parse(lblTotalAmt.Text) * (double.Parse(Arr[1]) / 100)).ToString();
                    double Amt = (double.Parse(lblTotalAmt.Text) * ((100- double.Parse(Arr[1]))/100));
                    lblTotalMsg.Text = Arr[1] + " % discount applied </ br> Final Amount:" + Amt.ToString("0.00");
                    Session["orderamount"] = Amt.ToString("0.00");
                }
            }
            else
                lblTotalMsg.Text = "No promo code available";

        }
    }
}