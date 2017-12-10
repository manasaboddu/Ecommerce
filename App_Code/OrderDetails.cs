using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for OrderDetails
/// </summary>
public class OrderDetails
{
    DBAccess db = new DBAccess();
    public long OrderDetailsID { get; set; }
    public long OrderID { get; set; }
    public long ProductID { get; set; }
    public float Quantity { get; set; }
    public string Options { get; set; }
    public DateTime OrderDateTime { get; set; }
    public float Amount { get; set; }
    public string ProductName { get; set; }
    public string PicturePath { get; set; }
    public string OrderNo { get; set; }
    public long UserAccountID { get; set; }
    public float Price { get; set; }
    public void SaveOrderDetails()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into OrderDetails values(@OrderID,@ProductID,@Quantity,'',@SaleRate)", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@SaleRate", SaleRate);
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
            SqlCommand cmd = new SqlCommand("update OrderDetails set OrderID=@OrderID,ProductID=@ProductID,Quantity=@Quantity,Options=@Options where OrderDetailsID=@OrderDetailsID", db.conn);
            cmd.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Options", Options);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void DeleteOrderDetails()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from OrderDetails where OrderDetailsID=@OrderDetailsID ", db.conn);
            cmd.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<OrderDetails> GetOrderDetails()
    {
        List<OrderDetails> lstorderdetails=new List<OrderDetails>();
        OrderDetails objod;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from OrderDetails where OrderDetailsID=@OrderDetailsID", db.conn);
            cmd.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                objod = new OrderDetails();
                objod.OrderDetailsID = long.Parse(dr["OrderDetailsID"].ToString());
                objod.ProductID = long.Parse(dr["ProductID"].ToString());
                objod.OrderID = long.Parse(dr["OrderID"].ToString());
                objod.Quantity = int.Parse(dr["Quantity"].ToString());
                objod.Options = dr["Options"].ToString();
                lstorderdetails.Add(objod);
            }
            dr.Close();
            db.CloseConn();
        
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstorderdetails;
    }
    public List<OrderDetails> GetOrderProductId(long orderid)
    {
        List<OrderDetails> lstorderdetails = new List<OrderDetails>();
        OrderDetails objod;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select productid from OrderDetails where OrderID=@OrderID", db.conn);
            cmd.Parameters.AddWithValue("@OrderID", orderid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objod = new OrderDetails();

                objod.ProductID = long.Parse(dr["ProductID"].ToString());
                lstorderdetails.Add(objod);
            }
            dr.Close();
            db.CloseConn();

        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstorderdetails;
    }
    Utilities objutilities = new Utilities();
    public List<OrderDetails> GetlistofOrders(long orid)
    {
        Orders objorders = new Orders();
        List<Orders> lstorders = new List<Orders>();
        List<OrderDetails> lstOrderDetails = new List<OrderDetails>();
        OrderDetails objOrderDetails = new OrderDetails();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select distinct * from OrderDetails od left outer join ProductPictures pp on pp.ProductID=od.ProductID inner join Products p on p.ProductID=od.ProductID inner join 
po on od.OrderID=po.OrderID where od.OrderID=@OrderID", db.conn);

           
            cmd.Parameters.AddWithValue("@OrderID", orid);
            SqlDataReader dr = cmd.ExecuteReader();
           // string symbol = "";
            //symbol = objutilities.GetCurrencySymbol("INR");
            while (dr.Read())
            {
                objOrderDetails = new OrderDetails();
                objOrderDetails.Quantity = int.Parse(dr["Quantity"].ToString());
                objOrderDetails.Price =float.Parse((double.Parse(dr["ConversionValue"].ToString()) / objOrderDetails.Quantity).ToString());

                string symbol = objutilities.GetCurrencySymbol(dr["CurrencyType"].ToString());
               // double totamunt= objOrderDetails.Quantity*objOrderDetails.Price;

                double totamunt =double.Parse(dr["ConversionValue"].ToString());


                int myInt = (int)Math.Ceiling(double.Parse(totamunt.ToString("0.00")));
                objOrderDetails.TotalAmount = symbol + " " + myInt.ToString("0.00");
                objOrderDetails.PriceSymbl = symbol + " " + objOrderDetails.Price.ToString("0.00");
                objOrderDetails.Amount = myInt;
                              

                objOrderDetails.ProductName = dr["ProductName"].ToString();
                objOrderDetails.PicturePath = dr["PicturePath"].ToString();

                


                string path = objOrderDetails.PicturePath;
                if (path == "" || path == null)
                {
                    objOrderDetails.PicturePath = "~/Images/noimage_icon.jpg";
                }
                // objOrderDetails.OrderNo = dr["OrderNo"].ToString();
                objOrderDetails.OrderID = long.Parse(dr["OrderID"].ToString());
                lstorders = objorders.GetOrders(dr["OrderID"].ToString(),"","","","","","","");
                if (lstorders.Count > 0)
                {
                    foreach (Orders item in lstorders)
                    {
                        objOrderDetails.OrderDateTime = item.OrderDateTime;
                        objOrderDetails.OrderNo = item.OrderNo;
                    }
                }
                else
                {
                    objOrderDetails.OrderDateTime = DateTime.Parse("-");
                }
                objOrderDetails.ProductID = long.Parse(dr["ProductID"].ToString());
                lstOrderDetails.Add(objOrderDetails);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstOrderDetails;

    }

    public string TotalAmount { get; set; }

    public string PriceSymbl { get; set; }
    public float DeliveryCharges { get; set; }
    public float SaleRate { get; set; }

    public List<OrderDetails> GetOrderDetailsByOrderID(string paramOrderID)
    {
        Orders objorders = new Orders();
        List<Orders> lstorders = new List<Orders>();
        List<OrderDetails> lstOrderDetails = new List<OrderDetails>();
        OrderDetails objOrderDetails = new OrderDetails();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select * from OrderDetails od inner join Products p on p.ProductID=od.ProductID where od.orderid=" + paramOrderID + "", db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objOrderDetails = new OrderDetails();
                objOrderDetails.OrderDetailsID = long.Parse(dr["OrderDetailsID"].ToString());
                objOrderDetails.OrderID = long.Parse(dr["OrderID"].ToString());
                objOrderDetails.ProductID = long.Parse(dr["ProductID"].ToString());
                
                objOrderDetails.Quantity = int.Parse(dr["Quantity"].ToString());
                objOrderDetails.Price = float.Parse(dr["SaleRate"].ToString());
                objOrderDetails.DeliveryCharges = 0; // float.Parse(dr["DeliveryCharges"].ToString());
                objOrderDetails.Amount = objOrderDetails.Quantity * objOrderDetails.Price; 
                objOrderDetails.ProductName = dr["ProductName"].ToString();
                List<Productpicture> lstPP = new List<Productpicture>();
                lstPP = new Productpicture().GetProductPicture(objOrderDetails.ProductID);
                string path = "/Images/noimage_icon.jpg";
                foreach (Productpicture item in lstPP)
                {
                    if (item.PicturePath != "")
                    {
                        path =  item.PicturePath.Replace("~", "");
                    }
                }
                objOrderDetails.PicturePath = path;                
                lstOrderDetails.Add(objOrderDetails);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstOrderDetails;

    }
}