using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class CartProductDetailspage : System.Web.UI.Page
{
    public float total;
    public int qty;
    string orderno;
    List<Products> lstcartp = new List<Products>();
    protected void Page_Load(object sender, EventArgs e)
    {

        btnSaveC.Visible = false;
        continueshoppingimage.Visible = false;
        try
        {
            if (!IsPostBack)
            {

                BindtoGrid();
                lblValue.Text = Session["count"].ToString() + "-item(s)";
                if (Session["name"] != null && Session["emailid"] != null)
                {
                    btnSaveC.Visible = true;
                    BtnProceed.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx");
        }

    }

    public void BindtoGrid()
    {
      
        if (Session["pid"] != null)
        {
            string prid = Session["pid"].ToString();
            if (Session["count"] != null)
            {
                LinkButton lblcount = (LinkButton)Master.FindControl("lblcount");
                lblcount.Text = Session["count"].ToString();
            }
            if (prid != "")
            {
                List<Products> lstp = new Products().GetCartProductDetails(prid, 1);
                //foreach (Products spv in lstp)
                //{
                //    lstcartp.Add(spv);
                //}
                lstcartp = lstp;
            }
            hdnCount.Value = lstcartp.Count.ToString();
            CartGridview.DataSource = lstcartp;
            CartGridview.DataBind();
            Session["lstfinalCartData"] = lstcartp;

            
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void CartGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ProductName")
        {
        }
        else if (e.CommandName == "RemoveCartProduct")
        {
            long productid = long.Parse(e.CommandArgument.ToString());
            if (Session["pid"] != null)
            {
                string PNo = Session["pid"].ToString();
                List<String> lstitems = new List<String>();
                string[] values = PNo.Split(new char[] { ',' });

                for (int i = 0; i < values.Length; i++)
                {
                    lstitems.Add(values[i]);
                }
                string s = "";
                lstitems.Remove(productid.ToString());
                foreach (string item in lstitems)
                {
                    if (s != "")
                    {
                        s += "," + item;
                    }
                    else
                    {
                        s = item;
                    }
                }
                Session["pid"] = s;
                long pcount = long.Parse(Session["count"].ToString());

                pcount = pcount - 1;
                Session["count"] = pcount;
                if (pcount >= 1)
                {
                    lblValue.Text = pcount + "-item(s)";
                    BtnProceed.Visible = true;
                }
                BindtoGrid();

                if (pcount == 0)
                {
                    Session["count"] = 0;
                    Session["pid"] = null;
                    lblValue.Text = Session["count"].ToString() + "-item(s)";
                    BtnProceed.Visible = false;
                    btnSaveC.Visible = false;
                    lblnocartitems.Text = "There are no items in this cart";
                    continueshoppingimage.Visible = true;
                }
            }
            else
            {

            }
        }
    }
    string symbol = "";
    protected void CartGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPrice = (Label)e.Row.FindControl("lblPrice");
            Label lblSubtotal = (Label)e.Row.FindControl("lblSubtotal");
            HiddenField hdnproductid = (HiddenField)e.Row.FindControl("hdnproductid");
            HiddenField hdnItemRate = (HiddenField)e.Row.FindControl("hdnItemRate");
            HiddenField hdnGPrice = (HiddenField)e.Row.FindControl("hdnGPrice");
            Label lblMakingCharges = (Label)e.Row.FindControl("lblMakingCharges");
            if (hdnproductid != null)
            {
                string Percent = new Utilities().GetResultForQueryfromDB("select top 1 discount from productDiscounts where productid=" + hdnproductid.Value + " order by validfrom desc");

                if (Percent != "")
                {
                    lblPrice.Text = (double.Parse(lblSubtotal.Text) * ((100 - double.Parse(Percent)) / 100)).ToString("0.00");
                    hdnItemRate.Value = lblPrice.Text;
                    lblSubtotal.Text = (( double.Parse(lblSubtotal.Text) * ((100 - double.Parse(Percent)) / 100))+ double.Parse(lblMakingCharges.Text)).ToString("0.00");
                  
                    hdnGPrice.Value = lblSubtotal.Text;
                }
                else
                {


                }

            }
                total += Convert.ToSingle(lblSubtotal.Text);
            double myInt = double.Parse(total.ToString());
            Session["orderamount"] = myInt.ToString("0.00");  
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            HiddenField txt = (HiddenField)e.Row.FindControl("hdnttlamt");
            txt.Value = total.ToString();
            string oamount = txt.Value;
            Label lblamount = (Label)e.Row.FindControl("lblTotal");
          

            double myoamntInt = double.Parse(total.ToString());
            lblamount.Text = myoamntInt.ToString("0.00");
                    double mytotInt = double.Parse(oamount);
            Session["orderamount"] = myoamntInt.ToString("0.00");
            Session["oedertotalamount"] = mytotInt.ToString("0.00");
        }
    }
    Utilities objutilities = new Utilities();
    protected void btnSaveC_Click(object sender, EventArgs e)
    {
        HiddenField txt = (HiddenField)this.CartGridview.FooterRow.FindControl("hdnttlamt");
        string total = txt.Value;
        

        //Session["count"] = null;
        //Session["pid"] = null;
        //Session["emailid"] = null;
        Session["lstofprd"] = null;
        Session["name"] = null;

        Response.Redirect("Cart.aspx");

    }
    protected void BtnProceed_Click(object sender, EventArgs e)
    {
        Label lblTotal = (Label)CartGridview.FooterRow.FindControl("lblTotal");
        if (lblTotal != null)
        {
            Session["oedertotalamount"] = lblTotal.Text;
        }
        Orders objorders = new Orders();
        objorders.DeliveryMobileNo = 0123456789;
        objorders.DeliverToPersonName = "";

        if (Session["UserAccountID"] != null)
            objorders.UserAccountID = long.Parse(Session["UserAccountID"].ToString());
        else
            objorders.UserAccountID = 0;
        objorders.OrderAmount = float.Parse(Session["oedertotalamount"].ToString());
        objorders.DeliveryLocationsID = 0;
        objorders.Status = "Pending";
        long orderid = objorders.SaveOrders();
        Session["OrderId"] = orderid.ToString();


        string no = orderid.ToString();
        if (no.Length == 1)
            no = "0000" + no;
        if (no.Length == 2)
            no = "000" + no;
        if (no.Length == 3)
            no = "00" + no;
        if (no.Length == 4)
            no = "0" + no;
        // 021117 00113
        orderno = DateTime.Now.ToString("ddMMyy") + no;
        Session["orderno"] = orderno;

        objorders.OrderID = orderid;
        objorders.OrderNo = orderno;
        objorders.UpdateOrder();
        OrderDetails objodetails = null;
        foreach (GridViewRow row in CartGridview.Rows)
        {
            TextBox txtqty = (TextBox)row.FindControl("txtQuantity");
            HiddenField hdnproductid = (HiddenField)row.FindControl("hdnproductid");
            HiddenField hdnGPrice = (HiddenField)row.FindControl("hdnGPrice");
            DropDownList ddlQty = (DropDownList)row.FindControl("ddlQty");
            float qty = float.Parse(ddlQty.SelectedValue);
            float rate = float.Parse(hdnGPrice.Value);
            float amount = qty * rate;
            long pId = long.Parse(hdnproductid.Value);
            //Label lblSubtotal = (Label)row.FindControl("lblSubtotal");
            //string amnt = lblSubtotal.Text;
            objodetails = new OrderDetails();
            if (hdnproductid.Value != "" && hdnGPrice.Value != "")
            {
                objodetails.ProductID = long.Parse(hdnproductid.Value);
                objodetails.Quantity = qty;
                objodetails.OrderID = orderid;
                objodetails.SaleRate = rate;
                objodetails.SaveOrderDetails();
            }
        }

        

        if (Session["UserAccountID"] != null)
        {
            Response.Redirect("DeliveryAddressPage.aspx");
        }
        else
        {
            Response.Redirect("frmLogin.aspx?id=new");
        }
        
    }


    protected void BtnSaveContinue_Click(object sender, EventArgs e)
    {
        //string name, doorno, street1, street2, city, apartmentname, postalcode, phoneno;
        //name = Session["name"].ToString();
        //doorno = Session["doorno"].ToString();
        //street1 = Session["street1"].ToString();
        //street2 = Session["street2"].ToString();
        //city = Session["city"].ToString();
        //apartmentname = Session["apartmentname"].ToString();
        //postalcode = Session["postalcode"].ToString();
        //phoneno = Session["phoneno"].ToString();
        //btnSaveC.Visible = true;

        //List<OrderDetails> lstDetails = (List<OrderDetails>)Session["listfinalcartdetails"];

        //if (lstDetails.Count > 0)
        //{
        //    CartGridview.DataSource = lstDetails;
        //    CartGridview.DataBind();
     
    }
    protected void continueshoppingimage_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}