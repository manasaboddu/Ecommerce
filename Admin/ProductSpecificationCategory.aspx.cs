using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductSpecificationCategory : System.Web.UI.Page
{
    //SpecificationMaster smobj = new SpecificationMaster();
    ProductCategories pcobj = new ProductCategories();
    SpecificationCategory spobj = new SpecificationCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {        
            binddata();
            BindPcategory();
           // BindddlSpecCategoryData();
           // Bindddlproductcategory();
        }
    }
    public void binddata()
    {
        List<SpecificationCategory> lstspecnemast = new List<SpecificationCategory>();
        lstspecnemast = spobj.GetSpecificationCategory();
        Session["lstspeccategorydata"] = lstspecnemast;
        GridView1.DataSource = (List<SpecificationCategory>)Session["lstspeccategorydata"];        
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
       // binddata();
        BindSpecData();

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
       // binddata();
        BindSpecData();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        //string s = GridView1.Rows[e.RowIndex].Cells[0].Text;
        Label lblno = (Label)row.FindControl("lblsmno");
        long smid = long.Parse(lblno.Text);

        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        long pid = long.Parse(id);

        pcobj.ProductCategoryID = pid;
        spobj.ProductCategoryID = pid;
        spobj.SpecificationCategoryID = smid;
        pcobj.DeleteProductCategory(pid);
        spobj.DeleteSpecificationCategory();
       // binddata();
        BindSpecData();
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        if (txtsmastername.Text != "")
        {
            spobj.ProductName = ddlproducts.SelectedItem.Text.ToString();

            //objpc = (ProductCategories)ddlproductcategory.SelectedItem;

            spobj.ProductID = long.Parse(ddlproducts.SelectedValue);
            spobj.SpecificationCategoryName = txtsmastername.Text;
            //spobj.Description = txtdescription.Text;
            spobj.SaveRecord();

            //binddata();
            BindSpecData();
            txtsmastername.Text = "";
            //txtdescription.Text = "";
            ModalPopupExtender1.Hide();
            DivMsg.Style.Add("display", "inline-table");
            lblMsg.Text = "Saved Successfully !";
        }
    }

    //public void Bindddlproductcategory()
    //{
    //    ddlproductcategory.DataSource = pcobj.GetProductCategory(true);
    //    ddlproductcategory.DataTextField = "ProductCategoryName";
    //    ddlproductcategory.DataValueField = "ProductCategoryID";
    //    ddlproductcategory.DataBind();
    //}
    public void BindPcategory()
    {
        SpecificationCategory objspec = new SpecificationCategory();
        ddlPCname.DataSource = pcobj.GetProductCategory(true);
        ddlPCname.DataTextField = "ProductCategoryName";
        ddlPCname.DataValueField = "ProductCategoryID";
        ddlPCname.DataBind();
    }


    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //TextBox t1, t2, t3;
        GridViewRow row = GridView1.Rows[e.RowIndex];
        Label lblno = (Label)row.FindControl("lblsmno");
        long smid = long.Parse(lblno.Text);
        //long smid = long.Parse(((Label)row.Cells[0].Controls[0]).Text);
        //long pcid = long.Parse(((TextBox)row.Cells[1].Controls[0]).Text);
        //long pcid = long.Parse(GridView1.DataKeys[row_index]["ProductId"].ToString());
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        long pcid = long.Parse(id);
        string pcname = ((TextBox)row.FindControl("txtpcname")).Text;
        string smname = ((TextBox)row.FindControl("txsmname")).Text;
        spobj.ProductCategoryID = pcid;
        pcobj.ProductCategoryID = pcid;
        spobj.SpecificationCategoryID = smid;
        pcobj.ProductCategoryName = pcname;
        spobj.SpecificationCategoryName = smname;
        spobj.UpdateSpecificationCategory();
        pcobj.UpdateProductCategory();
        GridView1.EditIndex = -1;
        //binddata();
        BindSpecData();

    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["SmId"] != null && Session["SmId"].ToString() != "")
        {
            string SpecName = TextSpecMname.Text;
            long SpecId = long.Parse(Session["SmId"].ToString());
            spobj.UpdateSpecCategory(SpecId, SpecName);
           // binddata();
            if (ddlPCname.SelectedValue != "0" && ddlPCname.SelectedValue != "-1")
            {
                long pcid = long.Parse(ddlPCname.SelectedValue);
                List<SpecificationCategory> lstspec = spobj.GetSpecBasedOnPC(pcid);
                Session["lstspeccategorydata"] = lstspec;
                GridView1.DataSource = (List<SpecificationCategory>)Session["lstspeccategorydata"];
                GridView1.DataBind();
                BindSpecData();
                mpeUpdate.Hide();
                DivMsg.Style.Add("display", "inline-table");
                lblMsg.Text = "Updated Successfully !";
            }
            else
            {
                binddata();
            }
        }



    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ButtonEdit")
        {
            long SmId = long.Parse(e.CommandArgument.ToString());
            Session["SmId"] = SmId;
            List<SpecificationCategory> lstspec = spobj.GetSpecCategory(SmId);
            foreach (SpecificationCategory listitem in lstspec)
            {
                //ddlSpecCategoryData.SelectedItem.Text= listitem.SpecificationCategoryName;
                //ddlSpecCategoryData.SelectedValue = listitem.SpecificationCategoryID.ToString();
                Textpcname.Text = listitem.ProductName;
                TextSpecMname.Text = listitem.SpecificationCategoryName;
            }
            mpeUpdate.Show();
        }
        else if (e.CommandName == "ButtonDelete")
        {
            long Smid = long.Parse(e.CommandArgument.ToString());
            spobj.DeleteSpecCategory(Smid);
          //  binddata();
            BindSpecData();
            DivMsg.Style.Add("display", "inline-table");
            lblMsg.Text = "Deleted Successfully !";
        }
    }

    protected void BtnGo_Click(object sender, EventArgs e)
    {
        long pcid = long.Parse(ddlPCname.SelectedValue);
        List<SpecificationCategory> lstspec = spobj.GetSpecBasedOnPC(pcid);
        Session["lstspeccategorydata"] = lstspec;
        GridView1.DataSource = (List<SpecificationCategory>)Session["lstspeccategorydata"];
        GridView1.DataBind();
    }
    protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = (List<SpecificationCategory>)Session["lstspeccategorydata"];
        GridView1.DataBind();
    }
    public void BindSpecData()
    {
        long pcid = long.Parse(ddlPCname.SelectedValue);
        List<SpecificationCategory> lstspec = spobj.GetSpecBasedOnPC(pcid);
        Session["lstspeccategorydata"] = lstspec;
        GridView1.DataSource = (List<SpecificationCategory>)Session["lstspeccategorydata"];
        GridView1.DataBind();
    }
}