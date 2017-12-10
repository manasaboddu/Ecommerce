using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Products
/// </summary>
public class Products
{
    DBAccess db = new DBAccess();

    public Products()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long ProductID { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public long ProductCategoryID { get; set; }
    public string ProductCategoryName { get; set; }
    public string PicturePath { get; set; }
    public float Price { get; set; }
    public string DeliveryCharges { get; set; }
    public string SpecificationMasterName { get; set; }
    public string SpecificationValueName { get; set; }
    public string isfinalproduct { get; set; }

    public long MappedproductID { get; set; }
    public long CheckedPid { get; set; }
    public int Type { get; set; }
    public int Change { get; set; }
    public string ItemCode { get; set; }
    public string GroupName { get; set; }
    public string UnitRate { get; set; }
    public string PAmount { get; set; }
    public int InbuiltQty { get; set; }
    public string IEQuantity { get; set; }

    public float GemSize { get; set; }
    public void SaveRecord()
    {
        try
        {
            db.OpenConn();
            string query = "insert into Products(ProductName,Description,ProductCategoryID,Price,DeliveryCharges,ItemCode,GemSize) values(@ProductName,@Description,@ProductCategoryID,@Price,@DeliveryCharges,@ItemCode,@GemSize)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            //cmd.Parameters.AddWithValue("@productid", ProductID);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@DeliveryCharges", DeliveryCharges);
            
            cmd.Parameters.AddWithValue("@ItemCode", ItemCode);
            
            cmd.Parameters.AddWithValue("@GemSize", GemSize);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }

    public void DeleteRecord(long pid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from products where productid=@productid", db.conn);
            cmd.Parameters.AddWithValue("@productid", pid);
            cmd.ExecuteNonQuery();
            db.CloseConn();

        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }

    public void UpdateProducts()
    {
        try
        {
            db.OpenConn();
            string query = "update Products set ProductName=@productname,Description=@desc,ProductCategoryID=@productcategoryid where ProductID=@productid ";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@productid", ProductID);
            cmd.Parameters.AddWithValue("@productname", ProductName);
            cmd.Parameters.AddWithValue("@desc", Description);
            cmd.Parameters.AddWithValue("@productcategoryid", ProductCategoryID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }


    public List<SpecificationData> GetRequiredData()
    {
        List<SpecificationData> lstsd = new List<SpecificationData>();
        SpecificationData sd;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select P.ProductID, P.ProductName, PC.ProductCategoryName, PC.ProductCategoryID from Products P,ProductCategory PC where PC.ProductCategoryID=P.ProductCategoryID", db.conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sd = new SpecificationData();
                sd.ProductID = long.Parse(dr["ProductID"].ToString());
                sd.ProductName = dr["ProductName"].ToString();
                sd.ProductCategoryName = dr["ProductCategoryName"].ToString();
                sd.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                //sd.SpecificationValueName = dr["SpecificationValueName"].ToString();
                //sd.PicturePath = dr["PicturePath"].ToString();
                lstsd.Add(sd);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstsd;
    }
    public List<Products> GetPCRecord()
    {
        List<Products> lstp = new List<Products>();
        Products pobj = new Products();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("SELECT P.ProductID, P.productname,PP.picturepath,P.Price FROM Products P,ProductPictures PP WHERE P.ProductID=PP.ProductID and ProductCategoryID=@ProductCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pobj = new Products();
                pobj.ProductID = long.Parse(dr["ProductID"].ToString());
                pobj.ProductName = dr["ProductName"].ToString();
                pobj.PicturePath = dr["PicturePath"].ToString();
                pobj.Price = float.Parse(dr["Price"].ToString());
                lstp.Add(pobj);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstp;
    }

    public List<Products> GetPCRecord(long procatid)
    {
        List<Products> lstp = new List<Products>();
        Products pobj = new Products();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"SELECT P.ProductID, P.productname,PP.picturepath,P.Price FROM Products P left outer join
ProductPictures PP on P.ProductID=PP.ProductID where ProductCategoryID=@ProductCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", procatid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pobj = new Products();
                pobj.ProductID = long.Parse(dr["ProductID"].ToString());
                pobj.ProductName = dr["ProductName"].ToString();
                pobj.PicturePath = dr["PicturePath"].ToString();
                pobj.Price =float.Parse( dr["Price"].ToString());
                lstp.Add(pobj);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstp;
    }
    public List<Products> GetProductRecord(long pid)
    {
        List<Products> lstprd = new List<Products>();
        Products objp;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select PC.ProductCategoryName,P.ProductName,P.Description from ProductCategory PC,Products P where PC.ProductCategoryID=P.ProductCategoryID and ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objp = new Products();
                objp.ProductName = dr["ProductName"].ToString();
                objp.ProductCategoryName = dr["ProductCategoryName"].ToString();
                objp.Description = dr["Description"].ToString();
                lstprd.Add(objp);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstprd;
    }
    public void UpdateProduct()
    {
        try
        {
            db.OpenConn();
            string query = "update Products set ProductCategoryID=@ProductCategoryID,ProductName=@ProductName,Description=@Description,Price=@Price,DeliveryCharges=@DeliveryCharges,ItemCode=@ItemCode,GemSize=@GemSize  where ProductID=@ProductID ";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@DeliveryCharges", DeliveryCharges);
            cmd.Parameters.AddWithValue("@ItemCode", ItemCode);
            cmd.Parameters.AddWithValue("@GemSize", GemSize);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void UpdateProductCategoryName(long pcid)
    {
        try
        {
            db.OpenConn();
            string query = "update ProductCategory set ProductCategoryName=@ProductCategoryName where ProductCategoryID=@ProductCategoryID ";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryName", ProductCategoryName);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<Products> GetAllProductData(long pid)
    {
        List<Products> lstpd = new List<Products>();
        Products sdobj;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"SELECT P.ProductID, P.productname,PP.picturepath,P.Price,P.Description FROM Products P left outer join
ProductPictures PP on P.ProductID=PP.ProductID where ProductCategoryID=@ProductCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sdobj = new Products();
                sdobj.ProductID = long.Parse(dr["ProductID"].ToString());
                sdobj.ProductName = dr["ProductName"].ToString();
                sdobj.Price = float.Parse(dr["Price"].ToString());
                sdobj.PicturePath = dr["PicturePath"].ToString();
                sdobj.Description = dr["Description"].ToString();
                lstpd.Add(sdobj);

            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpd;
    }
    public List<Products> GetCartProductDetails(long pid)
    {
        List<Products> lstcartpd = new List<Products>();
        Products objproducts;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select PP.PicturePath,P.ProductName,P.ProductID,P.Price,P.DeliveryCharges,P.Price from Products P,ProductPictures PP where P.ProductID=PP.ProductID AND P.ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objproducts = new Products();
                objproducts.PicturePath = dr["PicturePath"].ToString();
                objproducts.ProductName = dr["ProductName"].ToString();
                objproducts.Price = float.Parse(dr["Price"].ToString());
                objproducts.DeliveryCharges = dr["DeliveryCharges"].ToString();
                objproducts.ProductID = long.Parse(dr["ProductID"].ToString());
                lstcartpd.Add(objproducts);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstcartpd;
    }

    public int Qty { get; set; }
    public float Rate { get; set; }

    public List<Products> GetCartProductDetails(string pid, int qnty)
    {
        float price = 0;
        List<Products> lstcartpd = new List<Products>();
        List<Products> lstpspecmaper = new List<Products>();
        Products objproducts;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from Products P where P.ProductID in (" + pid + ")", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pid);

            SqlDataReader dr = cmd.ExecuteReader();


            string countrycode = "";
            string value = "1";
            string symbol = "";
            

            while (dr.Read())
            {
                objproducts = new Products();                
                objproducts.ProductName = dr["ProductName"].ToString();
                string cost = dr["Price"].ToString();
                if (cost != null && cost != "")
                {
                     price = float.Parse(dr["Price"].ToString());
                }


                double cstprice = 0;
                if (countrycode != "" && countrycode != "INR")
                {
                    cstprice = double.Parse(value) * double.Parse(dr["Price"].ToString());
                }
                else
                {
                    cstprice = double.Parse(dr["Price"].ToString());
                }

                int myInt = (int)Math.Ceiling(double.Parse(cstprice.ToString()));

                objproducts.CountryPrice =  myInt.ToString("0.00");


                objproducts.Symbol = symbol;
                price = float.Parse(myInt.ToString("0.00"));

                objproducts.Price = myInt;

                objproducts.Qty = qnty;
                objproducts.InbuiltQty = qnty;
                string rate = (qnty * myInt).ToString("0.00");
                objproducts.Rates = rate;
                objproducts.Rate = float.Parse(objproducts.Rates);

                objproducts.DeliveryCharges = dr["DeliveryCharges"].ToString();
                objproducts.ProductID = long.Parse(dr["ProductID"].ToString());
                lstpspecmaper = objproducts.GetProductPicture(objproducts.ProductID);
                if (lstpspecmaper.Count > 0)
                {
                    foreach (Products item in lstpspecmaper)
                    {
                        objproducts.PicturePath = item.PicturePath;
                    }
                }
                lstcartpd.Add(objproducts);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstcartpd;
    }

    public List<Products> GetPcRecs(long pcid)
    {
        List<Products> lstp = new List<Products>();
        Products pobj = new Products();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from products p where p.ProductCategoryID=@ProductCategoryID and p.productid not in (select pp.productid from productpictures pp)", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pobj = new Products();
                pobj.ProductID = long.Parse(dr["ProductID"].ToString());
                pobj.ProductName = dr["ProductName"].ToString();

                pobj.Price = float.Parse(dr["Price"].ToString());
                lstp.Add(pobj);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstp;
    }

    public long DeleteProduct(long pcid)
    {
        long i = 0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from products where ProductCategoryID=@ProductCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
            i = 1;

        }
        catch (Exception ex)
        {
            db.CloseConn();
            i = 0;
           // throw ex;
        }
        return i;
    }
    
    public List<Products> GetAllRecords(long pcid, string type, string price, string gemsize, bool isAvailableConitionRequired)
    {

        List<Products> lstpd = new List<Products>();
        List<Products> lstpspecmaper = new List<Products>();
        string sqlquery = "";
        string rate = "";
        string size = "";
        if (gemsize != "")
        {
            if (gemsize == "1")
            {
                size = " and P.GemSize <=1 ";
            }
            else if (gemsize == "35")
            {
                size = " and P.GemSize >=3 and P.GemSize <=5 ";
            }
            else if (gemsize == "58")
            {
                size = " and P.GemSize >=5 and P.GemSize <=8 ";
            }
            else if (gemsize == "810")
            {
                size = " and P.GemSize >=8 and P.GemSize <=10 ";
            }
            else if (gemsize == "1015")
            {
                size = " and P.GemSize >=10 and P.GemSize <=15 ";
            }
            else if (gemsize == "1520")
            {
                size = " and P.GemSize >=15 and P.GemSize <=20 ";
            }
            else if (gemsize == "20")
            {
                size = " and P.GemSize >=20  ";
            }
        }
        if (price != "")
        {
            if (price == "0-199")
            {
                rate = " and price >=0 and price <=9999 ";
            }
            else if (price == "200-399")
            {
                rate = "  and price >= 10000 and price <=19999 ";
            }
            else if (price == "2000-29999")
            {
                rate = " and price >= 20000 and price <=29999 ";
            }
            else if (price == "30000-39999")
            {
                rate = " and price >= 30000 and price <=39999 ";
            }
            else if (price == "40000-49999")
            {
                rate = " and price >= 40000 and price <=49999 ";
            }
            else if (price == "50000")
            {
                rate = " and price >= 50000  ";
            }
           
        }
        if (type == "ascen")
        {
            sqlquery = "SELECT * FROM Products p where ProductCategoryID=@ProductCategoryID  " + rate + " " + size + " order by Price asc ";
        }
        else if (type == "descen")
        {
            sqlquery = "SELECT * FROM Products p where ProductCategoryID=@ProductCategoryID  " + rate + " " + size + " order by Price desc";
        }
        else
        {
            sqlquery = "SELECT * FROM Products p where ProductCategoryID=@ProductCategoryID " + rate + " " + size + " ";
        }
        //if (isAvailableConitionRequired)
        //{
        //    if (sqlquery.Contains("where"))
        //    {
        //        sqlquery += " and p.ProductID not in (select od.productid from Orders o inner join OrderDetails od on o.OrderID=od.OrderID where Status='Success' or dateadd(MI,10,OrderDateTime)>GETDATE())";
        //    }
        //    else
        //    {
        //        sqlquery += " where p.ProductID not in (select od.productid from Orders o inner join OrderDetails od on o.OrderID=od.OrderID where Status='Success' or dateadd(MI,10,OrderDateTime)>GETDATE())";
        //    }
        //}
        Products sdobj;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(sqlquery, db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            SqlDataReader dr = cmd.ExecuteReader();

            string countrycode = "USD";
            string value = "1";
            string symbol = "";
            
            while (dr.Read())
            {
                sdobj = new Products();
                sdobj.ProductID = long.Parse(dr["ProductID"].ToString());
                lstpspecmaper = sdobj.GetProductPicture(sdobj.ProductID);
                if (lstpspecmaper.Count > 0)
                {
                    foreach (Products item in lstpspecmaper)
                    {
                        sdobj.PicturePath = item.PicturePath;

                    }
                }
                            
                sdobj.ProductName = dr["ProductName"].ToString();
                //sdobj.PicturePath = dr["PicturePath"].ToString();

                double cntryprice = 0;
                if (countrycode != "" && countrycode != "INR")
                {
                    cntryprice = double.Parse(value) * double.Parse(dr["Price"].ToString());
                }
                else
                {
                    cntryprice = double.Parse(dr["Price"].ToString());
                }

                int myInt = (int)Math.Ceiling(double.Parse(cntryprice.ToString()));

                sdobj.CountryPrice = symbol + " " + myInt.ToString("0.00"); 



                sdobj.Price = float.Parse(dr["Price"].ToString());
                sdobj.Description = dr["Description"].ToString();
                lstpd.Add(sdobj);

            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpd;
    }
    Utilities objutilities = new Utilities();
    public List<Products> GetAllProductRecords(string paramProductCatID, string paramSearchtext,bool isAvailableConitionRequired)
    {

        List<Products> lstpd = new List<Products>();
        List<Products> lstpspecmaper = new List<Products>();

        Products sdobj;
        try
        {
            db.OpenConn();
            string query = "SELECT * FROM Products P";
            if (paramProductCatID != "" && paramProductCatID != "-1")
            {
                query += " where ProductCategoryId in (" + paramProductCatID + ")";
            }
            if (paramSearchtext != "" && paramSearchtext != "-1")
            {
                if (query.Contains("where"))
                {
                    query += " and ProductName like '%" + paramSearchtext + "%'";
                }
                else
                {
                    query += " where ProductName like '%" + paramSearchtext + "%'";
                }
            }
            
            SqlCommand cmd = new SqlCommand(query, db.conn);
  
            SqlDataReader dr = cmd.ExecuteReader();

            string countrycode = "USD";
            string value = "1";
            string symbol = "";
   
                symbol = objutilities.GetCurrencySymbol("USD");
           
            while (dr.Read())
            {
                sdobj = new Products();
                sdobj.ProductID = long.Parse(dr["ProductID"].ToString());
                lstpspecmaper = sdobj.GetProductPicture(sdobj.ProductID);
                if (lstpspecmaper.Count > 0)
                {
                    foreach (Products item in lstpspecmaper)
                    {
                        sdobj.PicturePath = item.PicturePath;

                    }
                }

                double price = 0;
                if (countrycode != "" && countrycode != "INR")
                {
                    price = double.Parse(value) * double.Parse(dr["Price"].ToString());
                }
                else
                {
                    price = double.Parse(dr["Price"].ToString());
                }
               
                int myInt = (int)Math.Ceiling(double.Parse(price.ToString()));

                sdobj.CountryPrice = myInt.ToString("0.00"); ;


                sdobj.ProductName = dr["ProductName"].ToString();
                //sdobj.PicturePath = dr["PicturePath"].ToString();
                sdobj.Price = float.Parse(dr["Price"].ToString());
                sdobj.Description = dr["Description"].ToString();
                lstpd.Add(sdobj);

            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpd;
    }
    
    
    public long GetProductsNames(long productid)
    {
        Products pobj = new Products();
        string query = "";
        long catgoryid = 0;
        try
        {
            db.OpenConn();
            query = "select * from products";

            if (productid != -1)
            {
                if (query.Contains("where"))
                {
                    query += " and ProductID = " + productid;
                }
                else
                {
                    query += "  where ProductID = " + productid;
                }
            }
            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                catgoryid = long.Parse(dr["ProductCategoryID"].ToString());
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return catgoryid;
    }

    public List<Products> GetProductsNames(bool istrue, string productcategoryid)
    {

        List<Products> lstp = new List<Products>();
        Products pobj = new Products();
        string query = "";
        try
        {
            db.OpenConn();
            query = "select * from products";
            if (istrue)
            {
                pobj = new Products();
                pobj.ProductID = -1;
                pobj.ProductName = "--Select Product--";
                lstp.Add(pobj);
            }
            if (productcategoryid != "")
            {
                if (query.Contains("where"))
                {
                    query += " and isfinalproduct = '" + productcategoryid + "'";
                }
                else
                {
                    query += "  where isfinalproduct = '" + productcategoryid + "'";
                }
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pobj = new Products();
                pobj.ProductID = long.Parse(dr["ProductID"].ToString());
                pobj.ProductName = dr["ProductName"].ToString();
                pobj.Price = float.Parse(dr["Price"].ToString()); 
                lstp.Add(pobj);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstp;
    }
    public List<Products> GetPCRecords()
    {
        List<Products> lstp = new List<Products>();
        Products pobj = new Products();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("SELECT P.ProductID, P.productname,P.Price,PP.PicturePath  FROM Products p left outer join ProductPictures PP on P.ProductID=PP.ProductID where P.ProductCategoryID=@ProductCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pobj = new Products();
                pobj.ProductID = long.Parse(dr["ProductID"].ToString());    
                pobj.ProductName = dr["ProductName"].ToString();
                pobj.Price = float.Parse(dr["Price"].ToString());
                pobj.PicturePath = dr["PicturePath"].ToString();
                string path = pobj.PicturePath;
                if (path =="")
                {
                    pobj.PicturePath = "~/Images/noimage_icon.jpg";
                }
                lstp.Add(pobj);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstp;
    }


    public List<Products> GetProductData(long pid)
    {
        List<Products> lstpd = new List<Products>();
        Products sdobj;


        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select PP.PicturePath, P.ProductID,P.ItemCode,  P.ProductName ,P.Description,P.Price,P.DeliveryCharges,PC.ProductCategoryName,PC.ProductCategoryID,P.GemSize from Products P left outer join ProductPictures PP on P.ProductID=PP.ProductID inner join ProductCategory PC on P.ProductCategoryID=PC.ProductCategoryID  where P.ProductID=@ProductID ", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sdobj = new Products();
                sdobj.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                sdobj.ProductID = long.Parse(dr["ProductID"].ToString());
                sdobj.ProductName = dr["ProductName"].ToString();
                
                sdobj.Price = float.Parse(dr["Price"].ToString());
                sdobj.PicturePath = dr["PicturePath"].ToString();
                sdobj.Description = dr["Description"].ToString();
                sdobj.DeliveryCharges = dr["DeliveryCharges"].ToString();
                sdobj.ProductCategoryName = dr["ProductCategoryName"].ToString();
                sdobj.ItemCode = dr["ItemCode"].ToString();
                sdobj.GemSize = float.Parse(dr["GemSize"].ToString());
                lstpd.Add(sdobj);

            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpd;
    }

    
    public List<Products> GetProducts(long pcid)
    {

        List<Products> listOfProducts = new List<Products>();
        Products prdts = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from Products where productcategoryid=@productcategoryid", db.conn);
            cmd.Parameters.AddWithValue("@productcategoryid", pcid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                prdts = new Products();
                prdts.ProductID = long.Parse(dr["ProductID"].ToString());
                prdts.ProductName = dr["ProductName"].ToString();
                listOfProducts.Add(prdts);
            }
            db.CloseConn();
        }
        catch (Exception ee)
        {
            db.CloseConn();
            throw ee;
        }
        return listOfProducts;
    }
    
    public List<Products> GetProductPicture(long pid)
    {
        List<Products> lstsd = new List<Products>();
        Products sd;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@" select P.Productid,PP.PicturePath from Products P   left outer join ProductPictures PP on P.ProductID=PP.ProductID where P.ProductID=@productid ", db.conn);
            cmd.Parameters.AddWithValue("@productid", pid);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sd = new Products();
                // sd.ProductName = dr["ProductName"].ToString();
                sd.PicturePath = dr["PicturePath"].ToString();
                string path = sd.PicturePath;
                if (path == "" )
                {
                    sd.PicturePath = "~/Images/noimage_icon.jpg";
                }

                //sd.Type = int.Parse(dr["Type"].ToString());
                //sd.ProductID = long.Parse(dr["ProductID"].ToString());

                lstsd.Add(sd);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstsd;
    }
   
     public int GetBuildProductType(long pmid)
    {
        List<Products> lstsd = new List<Products>();
        Products objprd = new Products();
    
        int mpqty = 0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select  * from ProductSpectMapper
where  ProductMapperID=@ProductMapperID", db.conn);
            cmd.Parameters.AddWithValue("@ProductMapperID", pmid);
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                if (dr["InbuiltQty"].ToString() != null && dr["InbuiltQty"].ToString() != "")
                {
                   mpqty = int.Parse(dr["InbuiltQty"].ToString());
                }
                else
                {
                    mpqty = 1;
                }
                
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return mpqty;
    }

    public List<Products> GetRequiredDataProductWise(long pcid, long pid)
    {
        List<Products> lstsd = new List<Products>();
        Products sd;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select P.ProductID, P.ProductName, PC.ProductCategoryName, PC.ProductCategoryID from Products P inner join ProductCategory PC on PC.ProductCategoryID=P.ProductCategoryID where P.ProductCategoryID=@ProductCategoryID and ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
                cmd.Parameters.AddWithValue("@ProductID",pid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sd = new Products();
                sd.ProductID = long.Parse(dr["ProductID"].ToString());
                sd.ProductName = dr["ProductName"].ToString();
                sd.ProductCategoryName = dr["ProductCategoryName"].ToString();
                sd.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                //sd.SpecificationValueName = dr["SpecificationValueName"].ToString();
                //sd.PicturePath = dr["PicturePath"].ToString();
                lstsd.Add(sd);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstsd;
    }

    public List<Products> GetRequiredDataCategoryWise(long pcid)
    {
        List<Products> lstsd = new List<Products>();
        Products sd;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select P.ProductID, P.ProductName, PC.ProductCategoryName, PC.ProductCategoryID from Products P inner join ProductCategory PC on PC.ProductCategoryID=P.ProductCategoryID where P.ProductCategoryID=@ProductCategoryID ", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sd = new Products();
                sd.ProductID = long.Parse(dr["ProductID"].ToString());
                sd.ProductName = dr["ProductName"].ToString();
                sd.ProductCategoryName = dr["ProductCategoryName"].ToString();
                sd.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                //sd.SpecificationValueName = dr["SpecificationValueName"].ToString();
                //sd.PicturePath = dr["PicturePath"].ToString();
                lstsd.Add(sd);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstsd;
    }

    
    public string TotalAmount { get; set; }

    public string CountryPrice { get; set; }

    public string Symbol { get; set; }

    public string Rates { get; set; }
}