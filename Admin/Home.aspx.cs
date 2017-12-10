using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
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
            txtDateRange.InnerHtml = DateTime.Now.AddMonths(-1).ToString("dd MMMM, yyyy") + " - " + DateTime.Now.ToString("dd MMMM, yyyy");
            hdnFromDate.Value = DateTime.Now.AddMonths(-1).ToString("dd MMMM, yyyy");
            hdnToDate.Value = DateTime.Now.ToString("dd MMMM, yyyy");

            if (Session["emailid"] != null && Session["UserAccountID"] != null)
            {
                string email = Session["emailid"].ToString();

                //lstuseraccounts = objuser.GetUserAccountsRecord(Session["emailid"].ToString());
                //foreach (UserAccounts ua in lstuseraccounts)
                //{
                //    uid = ua.UserAccountID;
                //    Session["useraccountids"] = uid;
                //}
                //long cid = uid;
                //lstorders = objorders.GetTotallistofOrders();
                //MyOrderStatusGridview.DataSource = lstorders;
                //MyOrderStatusGridview.DataBind();
                BindGrid();
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/frmLogin.aspx");
            }
        }
    }
    List<Orders> lstorders = new List<Orders>();
    public void BindGrid()
    {
        string sortOrder = " order by OrderDateTime desc";
        if (ddlSort.SelectedValue != "-1")
        {
            if (imgSort.ImageUrl.Contains("ascending"))
                sortOrder = " order by " + ddlSort.SelectedValue + " asc";
            else
                sortOrder = " order by " + ddlSort.SelectedValue + " desc";
        }

        string userid = Session["UserAccountID"].ToString();
        lstorders = objorders.GetOrders("", "", txtOrderNo.Text, hdnFromDate.Value, hdnToDate.Value, ddlStatus.SelectedValue, txtMobileNo.Text, sortOrder);
        MyOrderStatusGridview.DataSource = lstorders;
        MyOrderStatusGridview.DataBind();

    }
    protected void MyOrderStatusGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        HiddenField hdnGOrderID = (HiddenField)e.Row.FindControl("hdnGOrderID");
        GridView grdItemDetails = (GridView)e.Row.FindControl("grdItemDetails");
        if (hdnGOrderID != null)
        {
            List<OrderDetails> lstD = new List<OrderDetails>();
            lstD = lstorders.Where(x => x.OrderID.ToString() == hdnGOrderID.Value).Single().lstDetails;
            grdItemDetails.DataSource = lstD;
            grdItemDetails.DataBind();
            //lstD = (from itemslist in lstorders where (itemslist.OrderID == long.Parse(hdnGOrderID.Value.ToString())) select itemslist).ToList();
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void imgSort_Click(object sender, ImageClickEventArgs e)
    {
        if (imgSort.ImageUrl.Contains("ascending"))
            imgSort.ImageUrl = "~/images/descending.png";
        else
            imgSort.ImageUrl = "~/images/ascending.png";

        BindGrid();
    }
}