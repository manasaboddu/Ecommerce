using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class MyOrderStatus : System.Web.UI.Page
{
    CultureInfo ukCulture = new CultureInfo("en-GB");
    List<UserAccounts> lstuseraccounts = new List<UserAccounts>();
    UserAccounts objuser = new UserAccounts();
    List<OrderDetails> lstcd = new List<OrderDetails>();

    OrderDetails objcustdet = new OrderDetails();
    Orders objorders = new Orders();
    protected void Page_Load(object sender, EventArgs e)
    {
        long uid = 0;
        if (!IsPostBack)
        {

            if (Session["emailid"] != null && Session["emailid"] != "")
            {
                BindGrid();
            }
            else
            {
                Response.Redirect("frmLogin.aspx");
            }
        }
    }
    List<Orders> lstorders = new List<Orders>();
    public void BindGrid()
    {
        string userid = Session["UserAccountID"].ToString();
        lstorders = objorders.GetOrders("", userid, "", "", "", "", "", " order by OrderDateTime desc");
        MyOrderStatusGridview.DataSource = lstorders;
        MyOrderStatusGridview.DataBind();

    }
    protected void MyOrderStatusGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "OrderRefNo")
        {
            long orderrefno = long.Parse(e.CommandArgument.ToString());
            Session["ordersrefno"] = orderrefno;
            Response.Redirect("MyOrders.aspx");
        }

    }
    protected void btnCancelOrder_Click(object sender, EventArgs e)
    {
        if (hdnOrderid.Value != "")
        {
            Orders obj = new Orders();
            obj.OrderID = long.Parse(hdnOrderid.Value);
            obj.Status = "Cancelled";
            obj.CancelOrder();
            lblMsg.Text = "Your Order No: " + hdnOrderNo.Value + " has been cancelled";
            BindGrid();
        }
    }
    protected void MyOrderStatusGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblStatus = (Label)e.Row.FindControl("lblstatus");
        Label lblOrderDate = (Label)e.Row.FindControl("lblOrderDate");
        LinkButton lnkCancel = (LinkButton)e.Row.FindControl("lnkCancel");
        
        if (lblStatus != null)
        {
            DateTime dt = DateTime.Parse(lblOrderDate.Text, ukCulture.DateTimeFormat);

            if (dt.AddDays(5).Date <= DateTime.Now.Date)
            {
                lnkCancel.Visible = false;
            }
            else
            {
                if (lblStatus.Text == "Success")
                {

                }
                else
                {
                    lnkCancel.Visible = false;
                }
            }
        }

        HiddenField hdnGOrderID = (HiddenField)e.Row.FindControl("hdnGOrderID");
        GridView grdItemDetails = (GridView)e.Row.FindControl("grdItemDetails");
        if (hdnGOrderID != null)
        {
            List<Orders> lstO = new List<Orders>();
            List<OrderDetails> lstD = new List<OrderDetails>();
            lstO = lstorders.Where(x => x.OrderID.ToString() == hdnGOrderID.Value).ToList();
            lstD = lstO[0].lstDetails;

            lstD = lstorders.Where(x => x.OrderID.ToString() == hdnGOrderID.Value).Single().lstDetails;
            grdItemDetails.DataSource = lstD;
            grdItemDetails.DataBind();
            //lstD = (from itemslist in lstorders where (itemslist.OrderID == long.Parse(hdnGOrderID.Value.ToString())) select itemslist).ToList();
        }
    }
}