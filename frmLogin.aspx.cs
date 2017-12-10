using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;
using System.IO;

public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Form.DefaultButton = btnLogin.UniqueID;
        }
    }

    public void ValidateCredentials()
    {
        string role = "";
        UserAccounts uaobj = new UserAccounts();
        uaobj.EmailID = hdnlgnemailid.Value;
        uaobj.Password = hdnlgnpswrd.Value;
        List<UserAccounts> lstobj = uaobj.GetUserRecord();
        foreach (UserAccounts item in lstobj)
        {
            Session["UserAccountID"] = item.UserAccountID.ToString();
            Session["Role"] = item.Role;
            Session["emailid"] = item.EmailID;
            Session["phoneno"] = item.MobileNo;
            role = Session["Role"].ToString();
            Session["uFname"] = item.Firstname;
            Session["uLname"] = item.LastName;
        }
        if (Session["Role"] != null)
        {
            if (role == "Administrator")
            {
                if (lstobj.Count > 0)
                {
                    FormsAuthentication.RedirectFromLoginPage(hdnlgnemailid.Value, false);
                    Response.Redirect("~/Admin/Product.aspx",false);
                }
                else
                {
                    Response.Redirect("<script type='text/javascript'>alert('Invalid Credentails...Please try again..!')</script>");
                    // lblmsg.Text = "invalid Email/Password";
                }
            }
            else
            {
                if (Session["emailid"] != null)
                {
                    if (lstobj.Count > 0)
                    {
                        FormsAuthentication.RedirectFromLoginPage(hdnlgnemailid.Value, false);
                        foreach (UserAccounts objua in lstobj)
                        {
                            string fname = objua.Firstname;
                            string lname = objua.LastName;
                            string fullname = fname + lname;
                            Session["userfullname"] = fullname;
                            long mobileno = objua.MobileNo;
                            Session["phoneno"] = mobileno;
                            long useraccountid = objua.UserAccountID;
                            Session["useraccid"] = useraccountid;
                            Session["UserAccountID"] = objua.UserAccountID;
                        }
                        if (Session["count"] != null)
                        {
                            Response.Redirect("DeliveryAddressPage.aspx");
                        }
                        else
                        {
                            Response.Redirect("Default.aspx");
                        }

                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }

            }
        }
        else if (role == "user")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Write("<script>alert('Invalid Credentails...Please try again..!')</script>");
        }
    }
    protected void btnsignin_Click(object sender, EventArgs e)
    {

        if (hdnlgnemailid.Value != "" && hdnlgnpswrd.Value != "")
        {
            ValidateCredentials();
        }
    }












}
