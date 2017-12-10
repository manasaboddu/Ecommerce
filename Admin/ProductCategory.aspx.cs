using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductCategory : System.Web.UI.Page
{
    public long pcid;
    ProductCategories objprocat = new ProductCategories();
    Products objproduct = new Products();
    Productpicture objpp = new Productpicture();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            Bindddlproductcategory();
          
        }
    }
    public void BindGrid()
    {
        GridProdCategery.DataSource = objprocat.GetProductCategories(true);
        GridProdCategery.DataBind();
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (txtprodcatname.Text != "")
        {
            objprocat.ProductCategoryName = txtprodcatname.Text;
            objprocat.Description = txtprodcatdescri.Text;
           
                objprocat.SaveProductCategory();
            
            // objprocat.SaveProductCategory();
            txtprodcatname.Text = "";
            txtprodcatdescri.Text = "";
            BindGrid();
            DivMsg.Style.Add("display", "inline-table");
            lblMsg.Text = "Saved Successfully !";
            ModalPopupExtender1.Hide();
        }
        
    }
    protected void GridProdCategery_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditPcategory")
        {
            pcid = long.Parse(e.CommandArgument.ToString());
            List<ProductCategories> lstcat = objprocat.GetProductCategoryDetails(pcid);
            Session["Pcid"] = pcid;
            foreach (ProductCategories item in lstcat)
            {
                TextPcname.Text = item.ProductCategoryName;
                TextDesc.Text = item.Description;
            }
            mpeUpdate.Show();
           
        }
        else if (e.CommandName == "DeletePcategory")
        {
            pcid = long.Parse(e.CommandArgument.ToString());
         long res =   objproduct.DeleteProduct(pcid);
            if (res > 0)
            {
                objpp.DeleteProductpic(pcid);
                objprocat.DeleteProductCategory(pcid);
                BindGrid();
                DivMsg.Style.Add("display", "inline-table");
                lblMsg.Text = "Deleted Successfully !";
            }
            else
            {
                DivMsg.Style.Add("display", "inline-table");
                lblMsg.Text = "Cannot Delete Product Catgory !!";
            }
        }
    }

    protected void BtnUpdate_Click1(object sender, EventArgs e)
    {
        if (Session["Pcid"] != null && Session["Pcid"].ToString() != "")
        {
            //string pcname = TextPcname.Text;
            string pcname = TextPcname.Text;
            string desc = TextDesc.Text;
            long PcId = long.Parse(Session["Pcid"].ToString());
           
            
                objprocat.UpdateProductCategories(PcId, pcname, desc);
            
            txtprodcatdescri.Text = "";
            txtprodcatname.Text = "";
            BindGrid();
            Bindddlproductcategory();
            DivMsg.Style.Add("display", "inline-table");
            lblMsg.Text = "Updated Successfully !";
        }
    }
    public void Bindddlproductcategory()
    {
        ddlPCategorytypes.DataSource = objprocat.GetProductCategory(true);
        ddlPCategorytypes.DataTextField = "ProductCategoryName";
        ddlPCategorytypes.DataValueField = "ProductCategoryID";
        ddlPCategorytypes.DataBind();
    }
    
    
    protected void BtnGo_Click(object sender, EventArgs e)
    {
        string pcid= ddlPCategorytypes.SelectedValue;
        if (pcid != null && pcid != "" && pcid != "0" && pcid!="-1")
        {
            long pcaid = long.Parse(pcid);
            List<ProductCategories> lstcate = objprocat.GetProductCategoryDetails(pcaid);
            GridProdCategery.DataSource = lstcate;
            GridProdCategery.DataBind();
        }
        else
        {
            GridProdCategery.DataSource = objprocat.GetProductCategories(true);
            GridProdCategery.DataBind();
        }

    }
}