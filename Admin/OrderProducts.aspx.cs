using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OrderProducts : System.Web.UI.Page
{
 public int total;
    List<OrderDetails> lstcd = new List<OrderDetails>();
    OrderDetails objcustdet = new OrderDetails();
    Orders objorders = new Orders();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Session["ordersrefno"]!=null && Session["ordersrefno"]!="")
            {
                string orderno=objorders.GetOrderNo(long.Parse(Session["ordersrefno"].ToString()));
            lablefororders.Text = "Your Currently Viewing OrderRefNo:";
            lblrefno.Text = "#" + orderno;
            }
        }
        if (Session["ordersrefno"] != null && Session["ordersrefno"] != "")
        {
            long orno = long.Parse(Session["ordersrefno"].ToString());
           // long cstid = long.Parse(Session["useraccountids"].ToString());
            lstcd = objcustdet.GetlistofOrders(orno);
            //foreach(CustomerDetails cd in lstcd )
            //{
            //    objcustdet = new CustomerDetails();
            //    objcustdet.EnqReferenceNo = cd.EnqReferenceNo;

            //    objcustdet.EnqDateTime = cd.EnqDateTime;
            //    objcustdet.CategoryName = cd.CategoryName;
            //    objcustdet.EnqStatus = cd.EnqStatus;
            //    lstcd.Add(objcustdet);
            //}
            MyOrdersGridview.DataSource = lstcd;
            MyOrdersGridview.DataBind();
        }

    }

    protected void MyOrdersGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Refnoproducts")
        //{
        //    long refno = long.Parse(e.CommandArgument.ToString());
        //    Session["refno"] = refno;
        //    Response.Redirect("OrdersPage.aspx");
        //}
    }
    double totala = 0;
    string symbol = "";
    protected void MyOrdersGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            string amount = DataBinder.Eval(e.Row.DataItem, "Amount").ToString();
            string stramount = DataBinder.Eval(e.Row.DataItem, "TotalAmount").ToString();
            string[] symbl = stramount.Split(' ');

            symbol = symbl[0];

            if (amount != "-" && amount != "" && amount != null)
            {
                totala += double.Parse(amount);
            }             
         
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblamount = (Label)e.Row.FindControl("lblTotal");
            if (totala != null )
            {
                lblamount.Text = symbol + " " + totala.ToString("0.00");
            }
            else
            {
                lblamount.Text = "-";
            }
           
        }
    }

    protected void lnkbtnBacktomyOrders_Click(object sender, EventArgs e)
    {
       
    }
}