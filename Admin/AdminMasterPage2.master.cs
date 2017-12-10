using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;

public partial class Admin_AdminMasterPage2 : System.Web.UI.MasterPage
{
    Products objproduct = new Products();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Role"] != null)
            {
                //lblUserName.Text = Session["emailid"].ToString();
                // lblheading.Text = "Welcome";
                // lnkbtnlogout.Visible = true;


                if (Session["UserName"] != null)
                {
                    string s = Session["UserName"].ToString();

                    if (Session["UserName"].ToString() != "Admin")
                    {
                        string Name = Session["UserName"].ToString();
                        //lblUserName.Text = Name.ToUpper();
                    }
                }
                //else if (Session["UserName"] == null)
                //{
                //    Session["UserRequireURL"] = Request.UrlReferrer;
                //    Response.Redirect("~/frmLogin.aspx");
                //}
                if (Session["FirstName"] != null && Session["FirstName"].ToString() != "")
                {
                    lblUserName.Text = "Welcome : " + Session["FirstName"].ToString();
                }

                // divHeader.Style.Add("height", "20");
                if (Session["customername"] != null && Session["customername"].ToString() != "")
                {
                   // lblCustomerName.Text = Session["customername"].ToString();
                }

            }
            else
            {
                Response.Redirect("~/frmLogin.aspx");
            }
        }
    }
    protected void lnkbtnlogout_Click(object sender, EventArgs e)
    {
      //  lblUserName.Text = "";
       // lblheading.Text = "";
      //  lnkbtnlogout.Visible = false;

            Session["emailid"] = null;
            Session["Role"] = null;
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");

        
    }

    
 
}
