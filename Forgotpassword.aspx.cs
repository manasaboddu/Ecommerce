using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forgotpassword : System.Web.UI.Page
{
    UserAccounts uaobj = new UserAccounts();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string emailid = txtemail.Text;
        List<UserAccounts> lstua = uaobj.GetUserAccountsRecord(emailid);
        if (lstua.Count > 0)
        {
            string emaild = "";
            string password = "";
            string username = "";
            string name = "";
            foreach (UserAccounts item in lstua)
            {
                string fname = item.Firstname;
                string lname = item.LastName;
                string fullname = fname + lname;
                Session["fullname"] = fullname;
                string uname = item.EmailID;
                
                Session["username"] = uname;
                string pwd = item.Password;
                
                Session["password"] = pwd;
                
                name = item.Firstname;
                emaild = item.EmailID;
                username = item.EmailID;
                password = item.Password;
            }
            
        }
        else
        {
            lblresult.ForeColor = System.Drawing.Color.Red;
            lblresult.Text = "Invalid Emailid";
        }

    }
}