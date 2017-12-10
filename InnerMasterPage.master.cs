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
using System.Web.Security;

public partial class InnerMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string role = "";
        if (!IsPostBack)
        {
            
            if (Session["count"] != null)
            {
                lblcount.Text = Session["count"].ToString();
            }
            if (Session["emailid"] != null)
            {
                if (Session["Role"] != null)
                {
                    role = Session["Role"].ToString();
                    if (role == "Administrator")
                    {
                        Response.Redirect("~/Admin/Product.aspx");
                    }
                    else
                    {
                        linklogout.Visible = true;
                       linkreg.Visible = false;
                       // lblicemail.Text = "Welcome :" + Session["emailid"].ToString();
                        divmymenu.Visible = true;
                        if (lblMPoints.Text == "")
                        {
                            string userid = Session["UserAccountID"].ToString();
                            string Points = new Utilities().GetResultForQueryfromDB("select ISNULL(SUM(Points), 0) - (select  ISNULL(sum(Points), 0) from ReedemPoints where Type = 'Debit' and UserID = " + userid + ") from ReedemPoints where Type = 'credit' and UserID = " + userid);
                            lblMPoints.Text = "Reedem Points : " + Points;
                        }
                    }
                }
                else
                {
                    linklogout.Visible = true;
                    linkreg.Visible = false;
                
                    divmymenu.Visible = true;
                }

            }
            else
            {
              //  lblheading.Visible = false;
              //  lblUserName.Visible = false;
                linklogout.Visible = false;
                linkreg.Visible = true;
                divmymenu.Visible = false;
            }

        }
        if (Session["count"] == null)
        {
            string initialcount = "0";
            lblcount.Text = initialcount;
            lblcount.Enabled = false;
        }
        else if ((Session["count"] != null))
        {
            lblcount.Text = Session["count"].ToString();
            lblcount.Enabled = true;
        }


    }
    protected void linklogout_Click(object sender, EventArgs e)
    {
      //  lblheading.Text = "";
      //  lblUserName.Text = "";
        linklogout.Visible = false;
        Session["emailid"] = null;
        Session["count"] = null;
        Session["pid"] = null;
        Session["orderno"] = null;
        Session["UserAccountID"] = null;
        Response.Redirect("Default.aspx");
    }

    protected void lblcount_Click(object sender, EventArgs e)
    {
        Response.Redirect("CartProductDetailspage.aspx");
    }
    
    
    
    
}
