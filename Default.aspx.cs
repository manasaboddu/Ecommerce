using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Net.Mail;
using System.Text;
using System.Web.Routing;

public partial class _Default : System.Web.UI.Page
{
    
    string productid;
    long i;
    ProductCategories objpccat = new ProductCategories();
    Products objproducts = new Products();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Session["Country"] = "USD";
        if (!IsPostBack)
        {
            bindGrid();
          //  BindAllCategories();
        }
       

    }

    public void bindGrid()
    {
        if (Request.Params["srch"] != null)
        {
            datalistproducts.DataSource = objproducts.GetAllProductRecords("", Request.Params["srch"].ToString(), true);
            datalistproducts.DataBind();
            lblmessage.Text = "Searched Items on '" + Request.Params["srch"].ToString() + "'";

        }
        else
        {
            datalistproducts.DataSource = objproducts.GetAllProductRecords("", "", true);
            datalistproducts.DataBind();
        }

        lblOffers.Text = "Flat 10% Discount, Use Promocode OFF10";
    }

    protected void datalistproducts_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "produtdetails")
        {
            long proid = long.Parse(e.CommandArgument.ToString());
            Session["prid"] = long.Parse(e.CommandArgument.ToString());
            //long proid=long .Parse(Session["prid"].ToString());
            if (Session["prid"].ToString() != "")
            {
                Response.Redirect("ProductInnerpage.aspx?prid=" + proid + "");
            }

        }
        else if (e.CommandName == "imageprodutdetails")
        {
            long proid = long.Parse(e.CommandArgument.ToString());
            Session["prid"] = long.Parse(e.CommandArgument.ToString());
            //long proid=long .Parse(Session["prid"].ToString());
            if (Session["prid"].ToString() != "")
            {
                Response.Redirect("ProductInnerpage.aspx?prid=" + proid + "");
            }

        }
        else if (e.CommandName == "productdetails")
        {
            long proid = long.Parse(e.CommandArgument.ToString());
            Session["prid"] = long.Parse(e.CommandArgument.ToString());
            
            if (Session["prid"].ToString() != "")
            {
                Response.Redirect("ProductInnerpage.aspx?prid=" + proid + "");
            }

        }
        else if (e.CommandName == "productcostdetails")
        {
            long proid = long.Parse(e.CommandArgument.ToString());
         //   Session["prid"] = long.Parse(e.CommandArgument.ToString());
            if (proid != 0)
            {
                Response.Redirect("ProductInnerpage.aspx?prid=" + proid + "");
            }

        }
        else if (e.CommandName == "AddtoCart")
        {
            string prid = "";
            long pid = long.Parse(e.CommandArgument.ToString());
            if(Session["pid"] != null)
             prid = Session["pid"].ToString();
            string[] productsid = prid.Split(new char[] { ',' });

            if (! productsid.Contains(pid.ToString()))
            {
                if (productsid.Length == 0 || prid == "")
                {
                    Session["pid"] = pid.ToString();
                    Session["count"] = 1;
                }
                else
                {
                    Session["pid"] += "," + pid.ToString();
                    Session["count"] = productsid.Length + 1;
                }

                
                LinkButton lblcount = (LinkButton)Master.FindControl("lblcount");
                lblcount.Text = Session["count"].ToString();
            }
            
        }
    }

    //public void BindAllCategories()
    //{
    //    List<ProductCategories> lstpcat = new List<ProductCategories>();
    //    lstpcat = objpccat.GetAllPCategories();
    //    PCGridView.DataSource = lstpcat;
    //    PCGridView.DataBind();
    //}
    protected void PCGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        List<Products> lstprcid = new List<Products>();
        try
        {
            if (e.CommandName == "GetProducts")
            {
                objproducts = new Products();
                long productcatid = long.Parse(e.CommandArgument.ToString());
                lstprcid = objproducts.GetAllProductRecords(productcatid.ToString(), "", true);
                if (lstprcid.Count > 0)
                {
                    foreach (Products item in lstprcid)
                    {
                        lblsectionhead.Text = item.ProductCategoryName;
                    }
                }
                datalistproducts.DataSource = lstprcid;
                datalistproducts.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void PCGridView_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in PCGridView.Rows)
    //    {
    //        if (row.RowIndex == PCGridView.SelectedIndex)
    //        {
    //            row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
    //        }
    //        else
    //        {
    //            row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
    //        }
    //    }
    //}




    protected void datalistproducts_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        HiddenField hdnProductId = (HiddenField)e.Item.FindControl("hdnProductId");
        LinkButton lblprice = (LinkButton)e.Item.FindControl("lblprice");
        Label lblNewPrice = (Label)e.Item.FindControl("lblNewPrice");
        Label lblOffer = (Label)e.Item.FindControl("lblOffer");
        if (hdnProductId != null)
        {
            string Percent = new Utilities().GetResultForQueryfromDB("select top 1 discount from productDiscounts where productid=" + hdnProductId.Value + " order by validfrom desc");

            double Price = double.Parse(lblprice.Text);
            if (Percent != "")
            {
                lblOffer.Text = Percent + "% Off";
                lblNewPrice.Text = (Price * ((100 - double.Parse(Percent)) / 100)).ToString("0.00");
                lblprice.Style.Add("text-decoration", "line-through");
            }
        }
    }
}