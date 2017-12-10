using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyBooking : System.Web.UI.Page
{
    public long pid;
    Orders objorder = new Orders();
    List<Orders> lstorders = new List<Orders>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["stringn"] != null)
            {
                string value = Request.QueryString["stringn"].ToString();
                string decryptvalue = new Utilities().Decode(value);
                string[] splitvalue = decryptvalue.Split('_');
                string orderno = splitvalue[0];
                string transno = splitvalue[1];
                string status = splitvalue[2];


                Orders o = new Orders();
                o.OrderNo = orderno;
                o.Status = status;
                o.UpdateOrderStatus();
                if (status == "Success" || status == "success")
                {
                    string name = Session["uFname"].ToString();
                    string emaild = Session["emailid"].ToString();
                    string mobile = Session["phoneno"].ToString();
                    string refno = orderno;
                    string message = "Your Order Reference No is: #" + refno;
                    string message2 = "Your Order Reference No is: #" + refno;
                    try
                    {
                      //  List<Orders> lstorders = new List<Orders>();
                      //  lstorders = new Orders().GetOrders("", "", orderno,"","","","","");
                        
                    }
                    catch { }


                    lblorderrefvalue.Text = "<img src='images/success.png' /><br/><br/>" + message2;
                }
                else
                {
                    string name = Session["uFname"].ToString();
                    string emaild = Session["emailid"].ToString();
                    string mobile = Session["phoneno"].ToString();
                    string refno = orderno;
                    string message = "<img src='images/fail.png' /><br/><span style='color:#D13D61;font-size:30px;'>oops..!!</span><br/><br/>Your Order Reference No : #" + refno + " is cancelled / payment gate way authentication failure..<br/> Please try again.. ";
                    lblorderrefvalue.Text = message;
                    Label2.Text = "";
                }
            }
            Session["count"] = 0;            
            Session["pid"] = null;
            Session["count"] = null;
            Session["name"] = null;
            Session["doorno"] = null;
            Session["street1"] = null;
            Session["street2"] = null;
            Session["city"] = null;
            Session["apartmentname"] = null;
            Session["postalcode"] = null;
            //  Session["phoneno"] = null;
            Session["orderno"] = null;
            Session["listfinalcartdetails"] = null;

            string url = "MyOrderStatus.aspx";
            Response.AddHeader("REFRESH", "5;URL=" + url);
        }

    }
}