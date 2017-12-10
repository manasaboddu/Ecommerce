using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Drawing;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class ProductInnerPage : System.Web.UI.Page
{
    string gradetype = "";
    Productpicture objproductpic = new Productpicture();
    List<Productpicture> lstproductpic = new List<Productpicture>();
    AjaxControlToolkit.TabContainer tbcDynamic;
    string URL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
           
        }
        
    }

    public void BindData()
    {
        string pridn = Request.QueryString["prid"];

        if (pridn != "")
        {
            long prid = long.Parse(pridn);
            objproductpic.ProductID = long.Parse(pridn);
            lstproductpic = objproductpic.GetPlantPictures(prid);
            datalistfzimages.DataSource = lstproductpic;
            datalistfzimages.DataBind();          
        }
    }
    protected void datalistfzimages_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        string pridn = Request.QueryString["prid"];
        long prdid = long.Parse(pridn); 
    }     
  
    protected void Page_Init(object sender, EventArgs e)
    {
        Createtab();
        ImageZooming();

    }
    protected void ImageZooming()
    {
        string pridn = Request.QueryString["prid"];
        long prid = long.Parse(pridn); 
        List<Productpicture> lstppic = new List<Productpicture>();
        lstppic = objproductpic.GetPlantThumbPictures(prid);
        StringBuilder html = new StringBuilder();
        if (lstppic.Count > 0)
        {
            html.Append("<div style='padding:5px; width:100%;'>");
            html.Append("<ul id='etalage'>");
            for (int i = 0; i < lstppic.Count; i++)
            {

                string imgpath = lstppic[i].PictureThumbPath.ToString();
                string newimgpath = imgpath.Replace("~", ".");
                html.Append("<li><img class='etalage_thumb_image' src='" + newimgpath + "' /><img class='etalage_source_image' src='" + newimgpath + "' class='img-responsive' /></li>");

            }
            html.Append("</ul>");
            html.Append("</div>");
            PlhThumbimg.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
    protected void Createtab()
    {
        string pridn = Request.QueryString["prid"];

        SpecificationValue objspecval = new SpecificationValue();
        List<SpecificationCategory> lstspec = new List<SpecificationCategory>();
        SpecificationCategory objspec = new SpecificationCategory();
        long pcid = long.Parse(pridn);
        lstspec = objspec.GetSCategories(pcid);
        tbcDynamic = new AjaxControlToolkit.TabContainer();
        StringBuilder html = new StringBuilder();
        for (int i = 0; i < lstspec.Count; i++)
        {

            html.Append("<table class='table table-striped table-hover table-bordered'>");
            html.Append("<tbody>");

            Table tbl = new Table();
            TabPanel objtabpanel = new TabPanel();
            objtabpanel.HeaderText = lstspec[i].SpecificationCategoryName;
            objtabpanel.ID = lstspec[i].SpecificationCategoryID.ToString();
            tbcDynamic.Tabs.Add(objtabpanel);
            List<SpecificationValue> lstspecnam = objspecval.GetProductSpecs(long.Parse(objtabpanel.ID));
            foreach (SpecificationValue items in lstspecnam)
            {
                if (items.SpecificationMasterName == "* Grade")
                {
                    gradetype = items.SpecificationValueName;
                    Session["gradetype"] = gradetype;
                }
                else
                {
                    html.Append("<tr>");
                    html.Append("<td>");
                    html.Append(items.SpecificationMasterName);
                    html.Append("</td >");
                    html.Append("<td>");
                    html.Append(items.SpecificationValueName);
                    html.Append("</td>");
                    html.Append("</tr>");
                }
            }
            html.Append("</tbody>");
            html.Append("</table>");
        }
        PLH.Controls.Add(new Literal { Text = html.ToString() }); 

    }
    
   
    
    
}