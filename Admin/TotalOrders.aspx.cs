using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TotalOrders : System.Web.UI.Page
{
    List<UserAccounts> lstuseraccounts = new List<UserAccounts>();
    UserAccounts objuser = new UserAccounts();
    List<OrderDetails> lstcd = new List<OrderDetails>();
    List<Orders> lstorders = new List<Orders>();
    OrderDetails objcustdet = new OrderDetails();
    Orders objorders = new Orders();
    protected void Page_Load(object sender, EventArgs e)
    {
        long uid = 0;
        if (!IsPostBack)
        {

            if (Session["emailid"] != null && Session["emailid"] != "")
            {
                string email = Session["emailid"].ToString();
                lstuseraccounts = objuser.GetUserAccountsRecord(Session["emailid"].ToString());
                foreach (UserAccounts ua in lstuseraccounts)
                {
                    uid = ua.UserAccountID;
                    Session["useraccountids"] = uid;
                }
                long cid = uid;
               // lstorders = objorders.GetlistofOrders(cid);
                lstorders = objorders.GetTotallistofOrders();
                //foreach (CustomerDetails cd in lstcd)
                //{
                //    objcustdet = new CustomerDetails();
                //    objcustdet.EnqReferenceNo = cd.EnqReferenceNo;

                //    objcustdet.EnqDateTime = cd.EnqDateTime;
                //    objcustdet.CategoryName = cd.CategoryName;
                //    objcustdet.EnqStatus = cd.EnqStatus;
                //    lstcd.Add(objcustdet);
                //}
                MyOrderStatusGridview.DataSource = lstorders;
                MyOrderStatusGridview.DataBind();
            }
        }
    }
    protected void MyOrderStatusGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "OrderRefNo")
        {
            long orderrefno = long.Parse(e.CommandArgument.ToString());
            Session["ordersrefno"] = orderrefno;
            Response.Redirect("OrderProducts.aspx");
        }
    }
}