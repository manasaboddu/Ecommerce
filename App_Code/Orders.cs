using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
/// <summary>
/// Summary description for Orders
/// </summary>
public class Orders
{
    CultureInfo ukCulture = new CultureInfo("en-GB");
    DBAccess db = new DBAccess();
    public long OrderID { get; set; }
    public long DeliveryBoyMasterID { get; set; }
    public long UserAccountID { get; set; }
    public string OrderNo { get; set; }
    public string Status { get; set; }
    public string Remarks { get; set; }
    public long DeliveryLocationsID { get; set; }
    public long DeliveryMobileNo { get; set; }
    public string EnteredBy { get; set; }
    public float OrderAmount { get; set; }
    public string DeliverToPersonName { get; set; }
    public float DeliveryCharges { get; set; }
    public long ProductID { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDateTime { get; set; }
    public DateTime DeliveryDateTime { get; set; }
    public string GrandTotal { get; set; }
    public string TotalAmount { get; set; }
    public string Address { get; set; }

    public long SaveOrders()
    {
        long id = -1;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into Orders values(1,@UserAccountID,'',getdate(),getdate(),getdate(),getdate(),@Status,'',@DeliveryLocationsID,@DeliveryMobileNo,'',@OrderAmount,@DeliverToPersonName,@DeliveryCharges);select cast(SCOPE_IDENTITY() as bigint)", db.conn);

            cmd.Parameters.AddWithValue("@UserAccountID", UserAccountID);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@DeliveryMobileNo", DeliveryMobileNo);
            cmd.Parameters.AddWithValue("@OrderAmount", OrderAmount);
            cmd.Parameters.AddWithValue("@DeliverToPersonName", DeliverToPersonName);
            cmd.Parameters.AddWithValue("@DeliveryCharges", DeliveryCharges);
            cmd.Parameters.AddWithValue("@DeliveryLocationsID", DeliveryLocationsID);
            id = (long)cmd.ExecuteScalar();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return id;
    }
    public void UpdateOrders()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update Orders set DeliveryBoyMasterID=@DeliveryBoyMasterID,UserAccountID=@UserAccountID,OrderNo=@OrderNo,Status=@Status,Remarks=@Remarks,DeliveryLocationsID=@DeliveryLocationsID,DeliveryMobileNo=@DeliveryMobileNo,EnteredBy=@EnteredBy,OrderAmount=@OrderAmount,DeliverToPersonName=@DeliverToPersonName,DeliveryCharges=@DeliveryCharges where OrderID=@OrderID ", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@DeliveryBoyMasterID", DeliveryBoyMasterID);
            cmd.Parameters.AddWithValue("@UserAccountID", UserAccountID);
            cmd.Parameters.AddWithValue("@OrderNo", OrderNo);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@DeliveryLocationsID", DeliveryLocationsID);
            cmd.Parameters.AddWithValue("@DeliveryMobileNo", DeliveryMobileNo);
            cmd.Parameters.AddWithValue("@EnteredBy", EnteredBy);
            cmd.Parameters.AddWithValue("@OrderAmount", OrderAmount);
            cmd.Parameters.AddWithValue("@DeliverToPersonName", DeliverToPersonName);
            cmd.Parameters.AddWithValue("@DeliveryCharges", DeliveryCharges);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void DeleteOrders()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from Orders where OrderID=@OrderID", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public string UserMobileNo { get; set; }
    public string UserName { get; set; }
    public List<OrderDetails> lstDetails { get; set; }
    public List<Orders> GetOrders(string paramOrderID,string paramUserID,string paramOrderNo,string paramFromDate,string paramToDate,string paramStatus,string paramMobile,string sortorder)
    {
        List<Orders> lstorders = new List<Orders>();
        Orders objorders = new Orders();
        try
        {
            db.OpenConn();
            string query = "select o.*,ua.Firstname,ua.MobileNo from Orders o inner join UserAccounts ua on o.UserAccountID=ua.UserAccountID";
            if (paramOrderID != "" && paramOrderID != "-1")
            {
                query += " where OrderID=" + paramOrderID;
            }
            if (paramUserID != "" && paramUserID != "-1")
            {
                if (query.Contains("where"))
                {
                    query += " and ua.UserAccountID=" + paramUserID;
                }
                else
                {
                    query += " where ua.UserAccountID=" + paramUserID;
                }
            }
            if (paramOrderNo != "" && paramOrderNo != "-1")
            {
                if (query.Contains("where"))
                {
                    query += " and OrderNo='" + paramOrderNo+"'";
                }
                else
                {
                    query += " where OrderNo='" + paramOrderNo + "'";
                }
            }
            if (paramFromDate != "" && paramToDate != "")
            {
                if (query.Contains("where"))
                {
                    query += " and dateadd(dd,0,datediff(dd,0,convert(datetime, OrderDateTime))) between '" + DateTime.Parse(paramFromDate, ukCulture.DateTimeFormat) + "' and '" + DateTime.Parse(paramToDate, ukCulture.DateTimeFormat) + "'";
                }
                else
                {
                    query += " where dateadd(dd,0,datediff(dd,0,convert(datetime, OrderDateTime))) between '" + DateTime.Parse(paramFromDate, ukCulture.DateTimeFormat) + "' and '" + DateTime.Parse(paramToDate, ukCulture.DateTimeFormat) + "'";
                }                
            }
            if (paramStatus != "" && paramStatus != "-1")
            {
                if (paramStatus == "Pending")
                {
                    if (query.Contains("where"))
                    {
                        query += " and status!='Success'";
                    }
                    else
                    {
                        query += " where status!='Success'";
                    }
                }
                else
                {
                    if (query.Contains("where"))
                    {
                        query += " and Status='" + paramStatus + "'";
                    }
                    else
                    {
                        query += " where Status='" + paramStatus + "'";
                    }
                }
            }
            if (paramMobile != "" && paramMobile != "-1")
            {
                if (query.Contains("where"))
                {
                    query += " and ua.MobileNo='" + paramMobile + "'";
                }
                else
                {
                    query += " where ua.MobileNo='" + paramMobile + "'";
                }
            }
            query += sortorder;
            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objorders = new Orders();
                objorders.OrderID = long.Parse(dr["OrderID"].ToString());
                objorders.DeliveryBoyMasterID = long.Parse(dr["DeliveryBoyMasterID"].ToString());
                objorders.UserAccountID = long.Parse(dr["UserAccountID"].ToString());
                objorders.OrderNo = dr["OrderNo"].ToString();
                objorders.Status = dr["Status"].ToString();
                objorders.Remarks = dr["Remarks"].ToString();
                objorders.DeliveryLocationsID = long.Parse(dr["DeliveryLocationsID"].ToString());
                objorders.DeliveryMobileNo = long.Parse(dr["DeliveryMobileNo"].ToString());
                objorders.EnteredBy = dr["EnteredBy"].ToString();
                objorders.OrderAmount = float.Parse(dr["OrderAmount"].ToString());
                objorders.DeliverToPersonName = dr["DeliverToPersonName"].ToString();
                objorders.DeliveryCharges = float.Parse(dr["DeliveryCharges"].ToString());
                objorders.OrderDateTime = DateTime.Parse(dr["OrderDateTime"].ToString());
                objorders.UserName = dr["Firstname"].ToString();
                objorders.UserMobileNo = dr["MobileNo"].ToString();
                //DeliveryLocations objDL = new DeliveryLocations();
                //objDL = new DeliveryLocations().GetDeliveryDetails_DLID(objorders.DeliveryLocationsID.ToString());
                //if (objDL != null)
                //{ 
                    
                //}
                objorders.Address = new Utilities().GetAddressforQuery(objorders.DeliveryLocationsID);
                objorders.lstDetails=new OrderDetails().GetOrderDetailsByOrderID(objorders.OrderID.ToString());
                lstorders.Add(objorders);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstorders;
    }

    public List<Orders> GetMyBookingOrders(string orderno)
    {
        List<Orders> lstOrders = new List<Orders>();
        Orders objOrders;


        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select OrderNo ,OrderDateTime,DeliveryDateTime,Status from Orders  where OrderNo=@OrderNo", db.conn);
            //cmd.Parameters.AddWithValue("@ProductID", pid);
            cmd.Parameters.AddWithValue("@OrderNo", orderno);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objOrders = new Orders();
                objOrders.OrderNo = dr["OrderNo"].ToString();
                //objOrders.ProductID = long.Parse(dr["ProductID"].ToString());
                objOrders.GrandTotal = HttpContext.Current.Session["oedertotalamount"].ToString();

                //objOrders.Quantity = int.Parse(dr["Quantity"].ToString());
                objOrders.OrderDateTime = DateTime.Parse(dr["OrderDateTime"].ToString());
                objOrders.DeliveryDateTime = DateTime.Parse(dr["OrderDateTime"].ToString()).AddDays(2);
                objOrders.Status = dr["Status"].ToString();
                lstOrders.Add(objOrders);

            }
            dr.Close();
            db.CloseConn();

        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstOrders;
    }

    public void UpdateOrder()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update Orders set OrderNo=@OrderNo where OrderID=@OrderID ", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@OrderNo", OrderNo);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<Orders> GetMyBookingDeatail(long useraccid)
    {
        List<Orders> lstOrders = new List<Orders>();
        Orders objOrders;


        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select OrderID, OrderNo ,OrderDateTime,DeliveryDateTime,Status from Orders  where UserAccountID=@UserAccountID", db.conn);

            cmd.Parameters.AddWithValue("@UserAccountID", useraccid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objOrders = new Orders();
                objOrders.OrderNo = dr["OrderNo"].ToString();
                //objOrders.ProductID = long.Parse(dr["ProductID"].ToString());
                //objOrders.GrandTotal = HttpContext.Current.Session["orderamount"].ToString();
                objOrders.OrderID = long.Parse(dr["OrderID"].ToString());
                objOrders.OrderDateTime = DateTime.Parse(dr["OrderDateTime"].ToString());
                objOrders.DeliveryDateTime = DateTime.Parse(dr["DeliveryDateTime"].ToString());
                objOrders.Status = dr["Status"].ToString();
                lstOrders.Add(objOrders);

            }
            dr.Close();
            db.CloseConn();

        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstOrders;
    }
    public List<Orders> GetlistofOrders(long cid)
    {

        List<Orders> lstOrders = new List<Orders>();
        Orders objOrders = new Orders();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select  * from Orders o  where UserAccountID=@UserAccountID order by o.orderid desc", db.conn);
            cmd.Parameters.AddWithValue("@UserAccountID", cid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objOrders = new Orders();
                objOrders.OrderNo = dr["OrderNo"].ToString();
                objOrders.OrderID = long.Parse(dr["OrderID"].ToString());
                objOrders.OrderDateTime = DateTime.Parse(dr["OrderDateTime"].ToString());
                if (dr["Status"].ToString() == "UserAccepts & PlacedOrder")
                {
                    objOrders.Status = "Pending";
                }
                else
                {
                    objOrders.Status = dr["Status"].ToString();
                }
                
                objOrders.TotalAmount = dr["OrderAmount"].ToString();

                objOrders.DeliveryLocationsID = long.Parse(dr["DeliveryLocationsID"].ToString());
                objOrders.Address = new Utilities().GetAddressforQuery(long.Parse(dr["DeliveryLocationsID"].ToString()));
                lstOrders.Add(objOrders);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstOrders;

    }
    Utilities objutilities = new Utilities();
    public List<Orders> GetTotallistofOrders()
    {

        List<Orders> lstOrders = new List<Orders>();
        Orders objOrders = new Orders();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select  * from Orders o  order by o.orderid desc", db.conn);

            //cmd.Parameters.AddWithValue("@UserAccountID", cid);
            SqlDataReader dr = cmd.ExecuteReader();

            string symbol = "";
            symbol = objutilities.GetCurrencySymbol("INR");
            while (dr.Read())
            {
                objOrders = new Orders();
                objOrders.OrderNo = dr["OrderNo"].ToString();
                objOrders.OrderID = long.Parse(dr["OrderID"].ToString());
                objOrders.OrderDateTime = DateTime.Parse(dr["OrderDateTime"].ToString());
                if (dr["Status"].ToString() == "UserAccepts & PlacedOrder")
                {
                    objOrders.Status = "Pending";
                }
                else
                {
                    objOrders.Status = dr["Status"].ToString();
                }
                
                
                objOrders.DeliveryLocationsID = long.Parse(dr["DeliveryLocationsID"].ToString());
                objOrders.Address = new Utilities().GetAddressforQuery(long.Parse(dr["DeliveryLocationsID"].ToString()));
                lstOrders.Add(objOrders);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstOrders;

    }
    public string GetOrderNo(long cid)
    {
        List<Orders> lstorders = new List<Orders>();
        Orders objorders = new Orders();
        string ono = "";
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select OrderNo from Orders where OrderID=@OrderID ", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", cid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objorders = new Orders();

                objorders.OrderNo = dr["OrderNo"].ToString();

                ono = objorders.OrderNo;
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return ono;
    }

    public void CancelOrder()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update Orders set Status=@Status where OrderID=@OrderID ", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void UpdateOrderStatus()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update Orders set Status=@Status,OrderAmount=@OrderAmount where OrderID=@OrderID ", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@OrderAmount", OrderAmount);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }

    public void UpdateOrderDetails()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update Orders set UserAccountID=@UserAccountID,Remarks=@Remarks,DeliveryLocationsID=@DeliveryLocationsID,DeliveryMobileNo=@DeliveryMobileNo,DeliverToPersonName=@DeliverToPersonName where OrderID=@OrderID ", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@UserAccountID", UserAccountID);                 
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@DeliveryLocationsID", DeliveryLocationsID);
            cmd.Parameters.AddWithValue("@DeliveryMobileNo", DeliveryMobileNo);
            cmd.Parameters.AddWithValue("@DeliverToPersonName", DeliverToPersonName);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public string CountryPrice { get; set; }
}

    

