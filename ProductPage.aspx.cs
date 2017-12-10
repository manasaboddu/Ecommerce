using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductPage : System.Web.UI.Page
{
    string productid;
    long i;
    ProductCategories objpccat = new ProductCategories();
    Products objproducts = new Products();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["gemsize"] = null;
            Session["price"] = null;
            Session["descen"] = null;
            Session["ascen"] = null;
            //List<Products> lstobjp = objproducts.GetProductsData();
            List<ProductCategories> lstpc = new List<ProductCategories>();
            ProductCategories objpcid = new ProductCategories();
            lstpc = objpcid.GetAllProductCategory();
            PcGridview.DataSource = lstpc;
            PcGridview.DataBind();
            //PCNameGridview.DataSource = lstobjp;
            //PCNameGridview.DataBind();
        }
        else
        {
                    Session["gemsize"] = null;
                    Session["price"] = null;
                    Session["descen"] = null;
                    Session["ascen"] = null;
                    //List<Products> lstobjp = objproducts.GetProductsData();
                    List<ProductCategories> lstpc = new List<ProductCategories>();
                    ProductCategories objpcid = new ProductCategories();
                    lstpc = objpcid.GetAllProductCategory();
                    PcGridview.DataSource = lstpc;
                    PcGridview.DataBind();
                
            
        }
    }
    
    protected void PcGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string type = "";
        string price = "";
        string gemsize = "";
        HiddenField HiddProductCategoryID = (HiddenField)e.Row.FindControl("HiddProductCategoryID");
        DataList datalistproducts = (DataList)e.Row.FindControl("Datalist1");

        if (Session["descen"] != null && Session["descen"].ToString() != "")
        {
            type = "descen";
        }
        else if (Session["ascen"] != null && Session["ascen"].ToString() != "")
        {
            type = "ascen";
        }
        if (Session["price"] != null && Session["price"].ToString() != "")
        {
            price = Session["price"].ToString();
        }
        if (Session["gemsize"] != null && Session["gemsize"].ToString() != "")
        {
            gemsize = Session["gemsize"].ToString();
        }
        if (HiddProductCategoryID != null)
        {
            objproducts.ProductCategoryID = long.Parse(HiddProductCategoryID.Value);
            datalistproducts.DataSource = objproducts.GetAllRecords(objproducts.ProductCategoryID, type, price, gemsize,true);
            datalistproducts.DataBind();
        }
        else
        {
        }
    }
    protected void Datalist1_ItemCommand(object source, DataListCommandEventArgs e)
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
            //long proid=long .Parse(Session["prid"].ToString());
            if (Session["prid"].ToString() != "")
            {
                Response.Redirect("ProductInnerpage.aspx?prid=" + proid + "");
            }

        }
        else if (e.CommandName == "productcostdetails")
        {
            long proid = long.Parse(e.CommandArgument.ToString());
            Session["prid"] = long.Parse(e.CommandArgument.ToString());
            //long proid=long .Parse(Session["prid"].ToString());
            if (Session["prid"].ToString() != "")
            {
                Response.Redirect("ProductInnerpage.aspx?prid=" + proid + "");
            }

        }
        else if (e.CommandName == "AddtoCart")
        {
            Session["pcid"] = 39;
            long pid = long.Parse(e.CommandArgument.ToString());
            Session["productid"] = pid;

            if (Session["productid"] != null && Session["pid"] == null)
            {

                productid = Session["productid"].ToString();
                Session["pid"] = productid;
                i = 1;
                Session["count"] = i;
                LinkButton lblcount = (LinkButton)Master.FindControl("lblcount");
                lblcount.Text = Session["count"].ToString();

            }
            else if (Session["productid"] != null && Session["pid"] != null)
            {
                //i = int.Parse(Session["count"].ToString());
                bool isExist = true;
                productid = Session["productid"].ToString();
                string prid = Session["pid"].ToString();
                string[] productsid = prid.Split(new char[] { ',' });

                foreach (string item in productsid)
                {
                    if (item != null && item != "")
                    {
                        if (productid == item)
                        {
                            isExist = false;
                            break;
                        }
                    }

                }
                if (isExist)
                {
                    i = long.Parse(Session["count"].ToString());
                    i++;
                    Session["pid"] += "," + productid;
                    Session["count"] = i;
                    LinkButton lblcount = (LinkButton)Master.FindControl("lblcount");
                    lblcount.Text = Session["count"].ToString();
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    
    public void BindAscenDecenData()
    {
        List<ProductCategories> lstpc = new List<ProductCategories>();
        ProductCategories objpcid = new ProductCategories();
        if (CheckBoxList3.SelectedValue != "")
        {
            lstpc = objpcid.GetPCDetails(long.Parse(CheckBoxList3.SelectedValue));
        }
        else
        {
            lstpc = objpcid.GetAllProductCategory();
        }
        PcGridview.DataSource = lstpc;
        PcGridview.DataBind();
    }
    protected void btncheck_Click(object sender, EventArgs e)
    {
        List<ProductCategories> lstpcat = new List<ProductCategories>();
        ProductCategories objpcid = new ProductCategories();

        Session["price"] = null;
        Session["gemsize"] = null;
        if (CheckBoxList3.SelectedValue != "")
        {
            if (CheckBoxList1.SelectedValue != "")
            {
                if (CheckBoxList1.SelectedValue == "1")
                {
                    Session["price"] = "0-9999";

                }
                else if (CheckBoxList1.SelectedValue == "2")
                {
                    Session["price"] = "10000-19999";
                }
                else if (CheckBoxList1.SelectedValue == "3")
                {
                    Session["price"] = "20000-29999";
                }
                else if (CheckBoxList1.SelectedValue == "4")
                {
                    Session["price"] = "30000-39999";
                }
                else if (CheckBoxList1.SelectedValue == "5")
                {
                    Session["price"] = "40000-49999";
                }
                else if (CheckBoxList1.SelectedValue == "6")
                {
                    Session["price"] = "50000";
                }
            }
            else if (CheckBoxList2.SelectedValue != "")
            {
                Session["gemsize"] = CheckBoxList2.SelectedValue;
            }
            lstpcat = objpcid.GetPCDetails(long.Parse(CheckBoxList3.SelectedValue));

        }

        else
        {
            if (CheckBoxList1.SelectedValue != "")
            {
                if (CheckBoxList1.SelectedValue == "1")
                {
                    Session["price"] = "0-9999";

                }
                else if (CheckBoxList1.SelectedValue == "2")
                {
                    Session["price"] = "10000-19999";
                }
                else if (CheckBoxList1.SelectedValue == "3")
                {
                    Session["price"] = "20000-29999";
                }
                else if (CheckBoxList1.SelectedValue == "4")
                {
                    Session["price"] = "30000-39999";
                }
                else if (CheckBoxList1.SelectedValue == "5")
                {
                    Session["price"] = "40000-49999";
                }
                else if (CheckBoxList1.SelectedValue == "6")
                {
                    Session["price"] = "50000";
                }
            }
            if (CheckBoxList2.SelectedValue != "")
            {
                Session["gemsize"] = CheckBoxList2.SelectedValue;
            }
            lstpcat = objpcid.GetAllProductCategory();
        }

        PcGridview.DataSource = lstpcat;
        PcGridview.DataBind();
    }
}