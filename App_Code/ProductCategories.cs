using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ProductCategories
/// </summary>
public class ProductCategories
{
    DBAccess db = new DBAccess();

    public long ProductCategoryID { get; set; }
    public string ProductCategoryName { get; set; }
    public string Description { get; set; }
    public string IsRawPartrequired { get; set; }
    public long GroupMasterID { get; set; }
    public string GroupName { get; set; }

    public int Count { get; set; }

    public void SaveProductCategory()
    {
        try
        {
            db.OpenConn();
            string query = "insert into ProductCategory(ProductCategoryName,Description) values(@productcategoryname,@desc)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
 
            cmd.Parameters.AddWithValue("@productcategoryname", ProductCategoryName);
            cmd.Parameters.AddWithValue("@desc", Description);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }

    public void SaveProductCategorywithGId()
    {
        try
        {
            db.OpenConn();
            string query = "insert into ProductCategory(ProductCategoryName,Description) values(@productcategoryname,@desc)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            //cmd.Parameters.AddWithValue("@productcategoryid", ProductCategoryID);
            cmd.Parameters.AddWithValue("@productcategoryname", ProductCategoryName);
            cmd.Parameters.AddWithValue("@desc", Description);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }


  public List<ProductCategories> GetProductCategory(bool istitlerequired)
    {
        List<ProductCategories> lstprodcatgry = new List<ProductCategories>();
        ProductCategories objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from ProductCategory";

            if (istitlerequired)
            {
                objprodctgry = new ProductCategories();
                objprodctgry.ProductCategoryID =0;
                objprodctgry.ProductCategoryName = "-Select Product Category-";
                objprodctgry.Description = "";
                lstprodcatgry.Add(objprodctgry);
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new ProductCategories();
                objprodctgry.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                objprodctgry.ProductCategoryName = dr["ProductCategoryName"].ToString();
                objprodctgry.Description = dr["Description"].ToString();
                lstprodcatgry.Add(objprodctgry);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstprodcatgry;
    }
  public void UpdateProductCategory()
  {
      try
      {
          db.OpenConn();
          SqlCommand cmd = new SqlCommand("update  ProductCategory set ProductCategoryName=@ProductCategoryName where ProductCategoryID=@ProductCategoryID", db.conn);
          cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
          cmd.Parameters.AddWithValue("@ProductCategoryName", ProductCategoryName);

          cmd.ExecuteNonQuery();
          db.CloseConn();
      }
      catch (Exception ex)
      {
          db.CloseConn();
          throw ex;
      }
  }
    public void DeleteProductCategory()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from ProductCategory  where ProductCategoryID=@ProductCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
         
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }

    public void DeleteProductCategory(long pcid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from ProductCategory  where ProductCategoryID=@ProductCategoryID", db.conn);
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
    public List<ProductCategories> GetProductCategories(bool istitlerequired)
    {
        List<ProductCategories> lstprodcatgry = new List<ProductCategories>();
        ProductCategories objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from ProductCategory";

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new ProductCategories();
                objprodctgry.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                objprodctgry.ProductCategoryName = dr["ProductCategoryName"].ToString();
                objprodctgry.Description = dr["Description"].ToString();
                lstprodcatgry.Add(objprodctgry);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstprodcatgry;
    }

    public List<ProductCategories> GetProductCategoryDetails(long pcid)
    {
        List<ProductCategories> lstpcobj = new List<ProductCategories>();
        ProductCategories pcobj;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select P.ProductCategoryID, P.productcategoryname,P.description from productcategory P  where ProductCategoryID=@ProductCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pcobj = new ProductCategories();
                pcobj.ProductCategoryName = dr["ProductCategoryName"].ToString();
                pcobj.Description = dr["Description"].ToString();
                
                pcobj.ProductCategoryID =long.Parse( dr["ProductCategoryID"].ToString());
                
                lstpcobj.Add(pcobj);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpcobj;
    }

    public void UpdateProductCategories(long pcid,string pcname,string desc)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update  ProductCategory set ProductCategoryName=@ProductCategoryName,Description=@Description where ProductCategoryID=@ProductCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            cmd.Parameters.AddWithValue("@ProductCategoryName", pcname);
            cmd.Parameters.AddWithValue("@Description", desc);
            

            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }

    
    public List<ProductCategories> GetPcNameId()
    {
        List<ProductCategories> lstprodcat = new List<ProductCategories>();
        ProductCategories objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from ProductCategory";

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new ProductCategories();
                objprodctgry.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                objprodctgry.ProductCategoryName = dr["ProductCategoryName"].ToString();
                objprodctgry.Description = dr["Description"].ToString();
                //objprodctgry.Description = dr["Description"].ToString();
                lstprodcat.Add(objprodctgry);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstprodcat;
    }
    public List<ProductCategories> GetProductCategory(bool istitlerequired, string status)
    {
        List<ProductCategories> lstprodcatgry = new List<ProductCategories>();
        ProductCategories objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from ProductCategory";

            if (istitlerequired)
            {
                objprodctgry = new ProductCategories();
                objprodctgry.ProductCategoryID = 0;
                objprodctgry.ProductCategoryName = "-Select Product Category-";
                objprodctgry.Description = "";
                lstprodcatgry.Add(objprodctgry);
            }
            if (status != "")
            {
                if (query.Contains("where"))
                {
                    query += " and IsRawPartrequired = '" + status + "'";
                }
                else
                {
                    query += "  where IsRawPartrequired = '" + status + "'";
                }
            }


            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new ProductCategories();
                objprodctgry.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                objprodctgry.ProductCategoryName = dr["ProductCategoryName"].ToString();
                objprodctgry.Description = dr["Description"].ToString();
                lstprodcatgry.Add(objprodctgry);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstprodcatgry;
    }

    public List<ProductCategories> GetAllProductCategory()
    {
        List<ProductCategories> lstprodcatgry = new List<ProductCategories>();
        ProductCategories objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from ProductCategory";

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new ProductCategories();
                objprodctgry.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                objprodctgry.ProductCategoryName = dr["ProductCategoryName"].ToString();
                objprodctgry.Description = dr["Description"].ToString();
                lstprodcatgry.Add(objprodctgry);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstprodcatgry;
    }
    public List<ProductCategories> GetPCDetails(long prdcid)
    {
        List<ProductCategories> lstprodcatgry = new List<ProductCategories>();
        ProductCategories objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from ProductCategory where ProductCategoryID=@ProductCategoryID";


            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", prdcid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new ProductCategories();
                objprodctgry.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                objprodctgry.ProductCategoryName = dr["ProductCategoryName"].ToString();
                objprodctgry.Description = dr["Description"].ToString();
                lstprodcatgry.Add(objprodctgry);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstprodcatgry;
    }
    public List<ProductCategories> GetPCategories()
    {

        List<ProductCategories> listOfCategories = new List<ProductCategories>();
        ProductCategories pctgry = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from ProductCategory", db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pctgry = new ProductCategories();
                pctgry.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                pctgry.ProductCategoryName = dr["ProductCategoryName"].ToString();
                listOfCategories.Add(pctgry);
            }
            db.CloseConn();
        }
        catch (Exception ee)
        {
            db.CloseConn();
            throw ee;
        }
        return listOfCategories;
    }

    public List<ProductCategories> GetAllPCategories()
    {
        string prdcatname = "";  
        List<ProductCategories> listOfCategories = new List<ProductCategories>();
        ProductCategories pctgry = null;
        try
        {
            db.OpenConn();
            string query = "select distinct pc.ProductCategoryID,pc.ProductCategoryName,(select count(productid) from products p where productcategoryid=pc.productcategoryid and p.ProductID not in (select od.productid from Orders o inner join OrderDetails od on o.OrderID=od.OrderID where Status='Success' or dateadd(MI,10,OrderDateTime)>GETDATE()))as Count from productcategory pc inner join products p on p.productcategoryid=pc.productcategoryid order by productcategoryid asc";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pctgry = new ProductCategories();
                pctgry.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                //pctgry.ProductCategoryName = dr["ProductCategoryName"].ToString();
                prdcatname = dr["ProductCategoryName"].ToString() + "(" + dr["Count"].ToString() + ")";
                pctgry.ProductCategoryName = prdcatname;
                pctgry.Count=int.Parse(dr["Count"].ToString());
                listOfCategories.Add(pctgry);
            }
            db.CloseConn();
        }
        catch (Exception ee)
        {
            db.CloseConn();
            throw ee;
        }
        return listOfCategories;
    }
}