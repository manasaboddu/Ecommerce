using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Changeuserlogin : System.Web.UI.Page
{
    UserAccounts uaobj = new UserAccounts();
    //byte value;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblresult.Text = "";
            lblmsg.Text = "";
        }
        if (Session["emailid"] != null)
        {
            string mail = Session["emailid"].ToString();
            List<UserAccounts> lst = uaobj.GetUserAccountsRecord(mail);
            if (lst.Count > 0)
            {
                foreach (UserAccounts item in lst)
                {
                    txtfirstname.Text = item.Firstname;
                    txtlastname.Text = item.LastName;
                    txtemailid.Text = Session["emailid"].ToString();
                }
            }

        }
    }

    //protected void chkchngepswrd_CheckedChanged(object sender, EventArgs e)
    //{
    //    lblresult.Text = "";
    //    lblmsg.Text = "";
    //    if (chkchngepswrd.Checked)
    //    {
    //        chngediv.Visible = true;
    //    }
    //    else
    //    {
    //        chngediv.Visible = false;
    //    }
    //}
    protected void btnsavechanges_Click(object sender, EventArgs e)
    {
        lblresult.Text = "";
        lblmsg.Text = "";
        if (txtcurrentpswrd.Text == "")
        {
            string fname = txtfirstname.Text;
            string lname = txtlastname.Text;
            string emailid = txtemailid.Text;
            string mailid = Session["emailid"].ToString();
            int i = uaobj.UpdateDetails(fname, lname, emailid, mailid);
            if (i == 1)
            {
                lblresult.ForeColor = System.Drawing.Color.Green;
                lblresult.Text = "Settings changed Successfully";
            }
            else
            {
                lblresult.ForeColor = System.Drawing.Color.Red;
                lblresult.Text = "Settings changed Failed";
            }
        }
        else
        {
            string cpswrd = txtcurrentpswrd.Text;
            bool chckpswrdvalid = uaobj.GetUserAccountsDetails(cpswrd);
            if (chckpswrdvalid)
            {
                uaobj.Password = txtchngepswrd.Text;
                uaobj.Firstname = txtfirstname.Text;
                uaobj.LastName = txtlastname.Text;
                uaobj.EmailID = txtemailid.Text;
                string mailid = Session["emailid"].ToString();
                int i = uaobj.UpdateUserDetails(mailid);
                if (i == 1)
                {
                    lblresult.ForeColor = System.Drawing.Color.Green;
                    lblresult.Text = "Settings changed Successfully";
                }
                else
                {
                    lblresult.ForeColor = System.Drawing.Color.Red;
                    lblresult.Text = "Changing Settings Failed";
                }
            }
            else
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Invalid Password";
            }
        }
    }
}