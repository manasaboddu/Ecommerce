using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Specificationvalues : System.Web.UI.Page
{
    SpecificationValue objspec = new SpecificationValue();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["PplantName"] != null && Session["PplantName"].ToString() != "")
        {
            lblplantname.Text = Session["PplantName"].ToString();
        }
        if (!IsPostBack)
        {
            //if (Session["Role"] != null)
            //{
            //    if (Session["Role"].ToString() == "Adminstrator")
            //    {
            //        Response.Redirect("Specificationvalues.aspx");
            //    }

            //}
            //else
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}
            Bindspec();
            BindSpecificationategory();
            //CheckAvailability();
        }
    }

    public void Bindspec()
    {
        if (Session["id"] != null && Session["pcid"] != null && Session["pcid"].ToString() != "" && Session["id"].ToString() != "")
        {
            objspec.ProductID = long.Parse(Session["id"].ToString());
            objspec.ProductCategoryID = long.Parse(Session["pcid"].ToString());
            List<SpecificationValue> lstspec = objspec.GetSpec();

            if (lstspec.Count > 0)
            {
                //lblspecvalues.Text = "Update Specifications";
                gridview1.DataSource = lstspec;
                gridview1.DataBind();
                btnsaveGriddata.Text = "Update";
            }
            else
            {
                //lblspecvalues.Text = "Add Specifications";
                List<SpecificationValue> lstspe = objspec.GetProductSpec();
                gridview1.DataSource = lstspe;
                gridview1.DataBind();
                btnsaveGriddata.Text = "Save";

            }
        }
        else
        {
            Response.Redirect("Product.aspx");
        }
    }

    protected void btnsaveGriddata_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null && Session["id"].ToString() != "")
        {
            if (btnsaveGriddata.Text == "Update")
            {

                foreach (GridViewRow gr in gridview1.Rows)
                {
                    HiddenField lsmid = (HiddenField)gr.FindControl("hdnspecmasterid");
                    //Label lsmid = (Label)gr.FindControl("lblspecmasterid");
                    Label lsmn = (Label)gr.FindControl("lblspecmastername");
                    TextBox txtspecvalue = (TextBox)gr.FindControl("txtspec");
                    long smid = long.Parse(lsmid.Value);
                    long pid = long.Parse(Session["id"].ToString());
                    string smn = lsmn.Text;
                    string svn = txtspecvalue.Text;
                    objspec.ProductID = pid;
                    objspec.SpecificationMasterID = smid;
                    objspec.SpecificationValueName = svn;
                    objspec.UpdateSpecRecord();
                    //Bindspec();
                }

                Response.Write("Record Updated Successfully");
                Response.Redirect("Product.aspx");
            }
            else if (btnsaveGriddata.Text == "Save")
            {


                foreach (GridViewRow gr in gridview1.Rows)
                {
                    HiddenField lsmid = (HiddenField)gr.FindControl("hdnspecmasterid");
                    //Label lsmid = (Label)gr.FindControl("lblspecmasterid");
                    Label lsmn = (Label)gr.FindControl("lblspecmastername");
                    TextBox txtspecvalue = (TextBox)gr.FindControl("txtspec");
                    long smid = long.Parse(lsmid.Value);
                    long pid = long.Parse(Session["id"].ToString());
                    string smn = lsmn.Text;
                    string svn = txtspecvalue.Text;
                    objspec.ProductID = pid;
                    objspec.SpecificationMasterID = smid;
                    objspec.SpecificationValueName = svn;
                    objspec.SaveRecord();

                }
                Response.Write("Record Saved Successfully");
                Response.Redirect("Product.aspx");
            }
        }
        else
        {
            Response.Redirect("Product.aspx");
        }


    }

    public void BindSpecificationategory()
    {
        if (Session["id"] != null && Session["id"].ToString() != "")
        {
            SpecificationCategory objspec = new SpecificationCategory();
            objspec.ProductID = long.Parse(Session["id"].ToString());
            ddlspecificationCategoryname.DataSource = objspec.GetSpecCategValues(true);
            ddlspecificationCategoryname.DataTextField = "SpecificationCategoryName";
            ddlspecificationCategoryname.DataValueField = "SpecificationCategoryID";
            ddlspecificationCategoryname.DataBind();
        }
        else
        {
            Response.Redirect("Product.aspx");
        }
    }
    protected void BtnGo_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["id"] != null && Session["id"].ToString() != "")
        {
            SpecificationValue objspecvalue = new SpecificationValue();
            long prid = long.Parse(Session["id"].ToString());
            long scid = long.Parse(ddlspecificationCategoryname.SelectedValue);
            List<SpecificationValue> lstspec = objspecvalue.GetSpecBasedOnCateg(scid, prid);
            gridview1.DataSource = lstspec;
            gridview1.DataBind();
        }
        else
        {
            Response.Redirect("Product.aspx");
        }
    }
}