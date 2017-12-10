using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    Products objProducts = new Products();
        ProductCategories objpc = new ProductCategories();
    SpecificationValue objspec = new SpecificationValue();
    Productpicture objprodpic = new Productpicture();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        if (!IsPostBack)
        {
            BindData();
            Bindddlproductcategory();
        }
        Session["up1"] = "";
        Session["up2"] = "";
        Session["up3"] = "";
        Session["up4"] = "";
        Session["up5"] = "";
    }

    public void BindData()
    {
        GridView1.DataSource = objProducts.GetRequiredData();
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Addimage")
            {

                long Pono = long.Parse(e.CommandArgument.ToString());
                Session["id"] = Pono;
                Response.Redirect("ProductPictures.aspx");
            }

            else if (e.CommandName == "Addspec")
            {
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                string sValue = ((HiddenField)GridView1.Rows[RemoveAt].Cells[5].FindControl("hidenpcid")).Value;
                string pname = ((Label)GridView1.Rows[RemoveAt].Cells[2].FindControl("lblpn")).Text;
                Session["PplantName"] = pname;
                long Poid = long.Parse(e.CommandArgument.ToString());
                string pcid = sValue;
                Session["id"] = Poid;
                Session["pcid"] = pcid;
                Response.Redirect("SpecificationValues.aspx");
            }
            else if (e.CommandName == "EditProduct")
            {

                long productid = long.Parse(e.CommandArgument.ToString());
                Session["productid"] = productid;
                List<Products> lstpr = objProducts.GetProductData(productid);

                foreach (Products pitem in lstpr)
                {
                   
                    string PCName = pitem.ProductCategoryName;
                    ddlProductCategoryu.SelectedItem.Text = PCName;
                    ddlProductCategoryu.SelectedValue = pitem.ProductCategoryID.ToString();
                    TextProductName.Text = pitem.ProductName;                    
                    TextDescription.Text = pitem.Description;
                    txtproductprice.Text = pitem.Price.ToString();
                    textGemSize.Text = pitem.GemSize.ToString();                   
                    txtdeliverycharges.Text = pitem.DeliveryCharges;                                     
                }
                mpebtnEdit.Show();
            }
            else if (e.CommandName == "DeleteProduct")
            {
                long productid = long.Parse(e.CommandArgument.ToString());
                
                objspec.DeleteProductSpec(productid);
                objprodpic.DeleteProductPic(productid);
                objProducts.DeleteRecord(productid);
                BindData();
                DivMsg.Style.Add("display", "inline-table");
                lblMsg.Text = "Deleted Successfully !";
            }
        }
        catch (Exception ex)
        {
          // Response.Write("<script  type=text/javascript''>alert('You don't have Permission to perform this operation...Please try again..!')</script>");
            //throw ex;
            DivMsg.Style.Add("display", "inline-table");
            lblMsg.Text = "Cannot delete product !";
        }
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtproductname.Text != "")
            {
                objProducts.ProductCategoryName = ddlproductcategory.SelectedItem.Text.ToString();
                objProducts.ProductCategoryID = long.Parse(ddlproductcategory.SelectedValue);
                objProducts.ProductName = txtproductname.Text;
                objProducts.Description = txtdescription.Text;
                objProducts.Price = float.Parse(textproductprice.Text);
                objProducts.DeliveryCharges = textdeliverycharges.Text;
                objProducts.GemSize = float.Parse(txtgemsize.Text);
                objProducts.ItemCode = "0";
                objProducts.SaveRecord();

                BindData();
                txtproductname.Text = "";
                txtdescription.Text = "";
                textproductprice.Text = "";
                textdeliverycharges.Text = "";
                mpelinkaddproduct.Hide();
                DivMsg.Style.Add("display", "inline-table");
                lblMsg.Text = "Saved Successfully !";
              //  textitemcode.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Bindddlproductcategory()
    {
        List<ProductCategories> lstpcate = new List<ProductCategories>();
        lstpcate = objpc.GetProductCategory(true);

        ddlproductcategory.DataSource = lstpcate;
        ddlproductcategory.DataTextField = "ProductCategoryName";
        ddlproductcategory.DataValueField = "ProductCategoryID";
        ddlproductcategory.DataBind();
        ddlProductCategoryu.DataSource = lstpcate;
        ddlProductCategoryu.DataTextField = "ProductCategoryName";
        ddlProductCategoryu.DataValueField = "ProductCategoryID";
        ddlProductCategoryu.DataBind();

    }


    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextProductName.Text != null)
            {

                objProducts.ProductID = long.Parse(Session["productid"].ToString());
                objProducts.ProductCategoryID =long.Parse( ddlProductCategoryu.SelectedValue);
                objProducts.ProductName = TextProductName.Text;            
                objProducts.Description = TextDescription.Text;
                objProducts.Price = float.Parse(txtproductprice.Text);
                objProducts.DeliveryCharges = txtdeliverycharges.Text;
                objProducts.GemSize = float.Parse(textGemSize.Text);
                objProducts.ItemCode = "0";           
                objProducts.UpdateProduct();
               
                TextProductName.Text = "";
                TextDescription.Text = "";
                txtproductprice.Text = "";
                txtdeliverycharges.Text = "";

                DivMsg.Style.Add("display", "inline-table");
                lblMsg.Text = "Details Updated Successfully !";
                BindData();
              
                Bindddlproductcategory();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  
    protected void BtnGo_Click(object sender, EventArgs e)
    {
        if (ddlpcategorylist.SelectedValue != "0" && ddlpcategorylist.SelectedValue != "-1" && ddlpcategorylist.SelectedValue != "")
        {

            long pcid = long.Parse(ddlpcategorylist.SelectedValue);
            string pid = ddlproductlist.SelectedValue;

            if (pcid != 0 && pid != null && pid != "")
            {
                long prid = long.Parse(pid);
                List<Products> lstpro = objProducts.GetRequiredDataProductWise(pcid, prid);
                GridView1.DataSource = lstpro;
                GridView1.DataBind();
            }
            else if (pcid != 0 && pid == null || pid == "")
            {
                List<Products> lstpro = objProducts.GetRequiredDataCategoryWise(pcid);
                GridView1.DataSource = lstpro;
                GridView1.DataBind();
            }
        }
        else
        {
            GridView1.DataSource = objProducts.GetRequiredData();
            GridView1.DataBind();
        }
    }
}