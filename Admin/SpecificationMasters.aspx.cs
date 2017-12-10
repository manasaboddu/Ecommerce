using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpecificationMasters : System.Web.UI.Page
{
    SpecificationCategory scobj = new SpecificationCategory();
    SpecificationMaster smobj = new SpecificationMaster();
    ProductCategories pcobj = new ProductCategories();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["Role"] != null)
            //{
            //    if (Session["Role"].ToString() == "Adminstrator")
            //    {
            //        Response.Redirect("SpecificationMasters.aspx");
            //    }

            //}
            //else
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}
            binddata();
            BindPcategory();
            BindddlSpecCategoryData();
            //Bindddlproductcategory();
            //Bindddlspeccategory();
        }
    }
    public void binddata()
    {
        List<SpecificationMaster> lstspecnemast = new List<SpecificationMaster>();
        lstspecnemast = smobj.GetSpecificationMaster();
        Session["lstspecmasterdata"] = lstspecnemast;
        GridView1.DataSource = (List<SpecificationMaster>)Session["lstspecmasterdata"];
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
      //  binddata();
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
        smobj.ProductCategoryID = pid;
        smobj.SpecificationCategoryID=
        smobj.SpecificationMasterID = smid;
       // pcobj.DeleteProductCategory(pid);
        smobj.DeleteSpecificationMaster();
      //  binddata();
        BindSpecData();

 
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        SpecificationValue svobj=new SpecificationValue();
        if (txtsmastername.Text != "")
        {
            smobj.ProductCategoryName = ddlproductcategory.SelectedItem.Text.ToString();

            //objpc = (ProductCategories)ddlproductcategory.SelectedItem;
            smobj.SpecificationCategoryName = ddlspeccategory.SelectedItem.Text.ToString();
            smobj.SpecificationCategoryID = long.Parse(ddlspeccategory.SelectedValue);
            smobj.ProductCategoryID = long.Parse(ddlproductcategory.SelectedValue);
            smobj.ProductID = long.Parse(ddlproduct.SelectedValue);
            smobj.SpecificationMasterName = txtsmastername.Text;
            smobj.Description = txtdescription.Text;
            long smid =smobj.SaveRecord();
            svobj.SpecificationMasterID = smid;
            svobj.SpecificationMasterName = txtsmastername.Text;
            svobj.SpecificationValueName = "";
            svobj.ProductID = long.Parse(ddlproduct.SelectedValue);
            svobj.SaveRecord();

           // binddata();
            BindSpecData();
            txtsmastername.Text = "";
            txtdescription.Text = "";
            binddata();
            BindPcategory();
            BindddlSpecCategoryData();
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
    //  public void Bindddlspeccategory()
    //{
    //    ddlspeccategory.DataSource = scobj.GetSpecCategory(true);
    //    ddlspeccategory.DataTextField = "SpecificationCategoryName";
    //    ddlspeccategory.DataValueField = "SpecificationCategoryID";
    //    ddlspeccategory.DataBind();
    //}

    public void BindPcategory()
    {
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
        smobj.ProductCategoryID = pcid;
        pcobj.ProductCategoryID = pcid;
        smobj.SpecificationMasterID = smid;
        pcobj.ProductCategoryName = pcname;
        smobj.SpecificationMasterName = smname;
        smobj.UpdateSpecificationMaster();
        pcobj.UpdateProductCategory();
        GridView1.EditIndex = -1;

       // binddata();
        BindSpecData();

    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["SmId"] != null && Session["SmId"].ToString() != "")
        {
            SpecificationValue svupd = new SpecificationValue();
            long SpecCategId = long.Parse(ddlSpecCategoryData.SelectedValue);
            string SpecName = TextSpecMname.Text;
            long SpecId = long.Parse(Session["SmId"].ToString());
            smobj.UpdateSpecMaster(SpecCategId, SpecId, SpecName);
            //svupd.UpdateSpecRecord(SpecId, SpecName);

           // binddata();
            if (ddlPCname.SelectedValue != "0" && ddlPCname.SelectedValue != "-1")
            {
                long pcaid = long.Parse(ddlPCname.SelectedValue);
                List<SpecificationMaster> lstspecnew = smobj.GetSpecBasedOnPC(pcaid);
                Session["lstspecmasterdata"] = lstspecnew;
                GridView1.DataSource = (List<SpecificationMaster>)Session["lstspecmasterdata"];
                GridView1.DataBind();
                mpeUpdate.Hide();
                DivMsg.Style.Add("display", "inline-table");
                lblMsg.Text = "Updated Successfully !";
            }
            else
            {
                binddata();
                mpeUpdate.Hide();
            }
           // BindSpecData();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ButtonEdit")
        {
            long SmId = long.Parse(e.CommandArgument.ToString());
            Session["SmId"] = SmId;
            List<SpecificationMaster> lstspec = smobj.GetSpecMaster(SmId);
            foreach (SpecificationMaster listitem in lstspec)
            {
                Textpcname.Text = listitem.ProductName;
                ddlSpecCategoryData.SelectedItem.Text = listitem.SpecificationCategoryName;
                ddlSpecCategoryData.SelectedValue = listitem.SpecificationCategoryID.ToString();
                //Textscname.Text = listitem.SpecificationCategoryName;
                TextSpecMname.Text = listitem.SpecificationMasterName;
            }
            mpeUpdate.Show();
        }
        else if (e.CommandName == "ButtonDelete")
        {
            SpecificationValue svdel = new SpecificationValue();
            long Smid = long.Parse(e.CommandArgument.ToString());
            smobj.DeleteSpecMaster(Smid);
            svdel.DeleteSpecMast(Smid);
          //  binddata();
            BindSpecData();
            binddata();
            DivMsg.Style.Add("display", "inline-table");
            lblMsg.Text = "Deleted Successfully !";
        }
    }

    protected void BtnGo_Click(object sender, EventArgs e)
    {
        long pcid = long.Parse(ddlPCname.SelectedValue);
        List<SpecificationMaster> lstspec = smobj.GetSpecBasedOnPC(pcid);
        Session["lstspecmasterdata"] = lstspec;
        GridView1.DataSource = (List<SpecificationMaster>)Session["lstspecmasterdata"];
        GridView1.DataBind();
    }
    public void BindddlSpecCategoryData()
    {
        ddlSpecCategoryData.DataSource = scobj.GetSpecificationCategory();
        ddlSpecCategoryData.DataTextField = "SpecificationCategoryName";
        ddlSpecCategoryData.DataValueField = "SpecificationCategoryID";
        ddlSpecCategoryData.DataBind();
    }
    protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = (List<SpecificationMaster>)Session["lstspecmasterdata"];
        GridView1.DataBind();
    }
    public void BindSpecData()
    {
        GridView1.DataSource = (List<SpecificationMaster>)Session["lstspecmasterdata"];
        GridView1.DataBind();
    }
}