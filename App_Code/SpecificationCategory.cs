using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for specificationCategory
/// </summary>
public class SpecificationCategory
{
    DBAccess db = new DBAccess();
    public long SpecificationCategoryID { get; set; }
    public string SpecificationCategoryName { get; set; }
    //public string Description { get; set; }
    public long ProductID { get; set; }
    public string ProductName { get; set; }
    public long ProductCategoryID { get; set; }
    public string ProductCategoryName { get; set; }




    public void SaveRecord()
    {
        try
        {
            db.OpenConn();
            string query = "insert into SpecificationCategory(SpecificationCategoryName,ProductID) values(@SpecificationCategoryName,@ProductID)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            //cmd.Parameters.AddWithValue("@productid", ProductID);
            cmd.Parameters.AddWithValue("@SpecificationCategoryName", SpecificationCategoryName);            
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }



    public void UpdateSpecificationCategory()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update  SpecificationCategory set SpecificationCategoryName=@SpecificationCategoryName where ProductID=@ProductID and SpecificationMasterID=@SpecificationMasterID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@SpecificationCategoryName", SpecificationCategoryName);
            cmd.Parameters.AddWithValue("@SpecificationCategoryID", SpecificationCategoryID);

            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void DeleteSpecificationCategory()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from SpecificationCategory where ProductID=@ProductID and @SpecificationCategoryID=SpecificationCategoryID ", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@SpecificationCategoryID", SpecificationCategoryID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<SpecificationCategory> GetSpecificationCategory()
    {
        List<SpecificationCategory> listspecificationmaster = new List<SpecificationCategory>();
        SpecificationCategory objspecificationmaster = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select S.SpecificationCategoryID, P.ProductID,P.ProductName,S.SpecificationCategoryName from Products P,SpecificationCategory S where P.ProductID=S.ProductID", db.conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objspecificationmaster = new SpecificationCategory();
                objspecificationmaster.ProductID = long.Parse(dr["ProductID"].ToString());
                objspecificationmaster.ProductName = dr["ProductName"].ToString();
                objspecificationmaster.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                objspecificationmaster.SpecificationCategoryID = long.Parse(dr["SpecificationCategoryID"].ToString());

                listspecificationmaster.Add(objspecificationmaster);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listspecificationmaster;
    }
    public void UpdateSpecCategory (long SmID, string SmName)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update  SpecificationCategory set SpecificationCategoryName=@SpecificationCategoryName where  SpecificationCategoryID=@SpecificationCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@SpecificationCategoryName", SmName);
            cmd.Parameters.AddWithValue("@SpecificationCategoryID", SmID);

            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<SpecificationCategory> GetSpecCategory(long SpecId)
    {
        List<SpecificationCategory> listspecmaster = new List<SpecificationCategory>();
        SpecificationCategory objspecmaster = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select P.ProductName,S.SpecificationCategoryName,S.SpecificationCategoryID from Products P,SpecificationCategory S where P.ProductID=S.ProductID and SpecificationCategoryID=@SpecificationCategoryID", db.conn);
            cmd.Parameters.AddWithValue("@SpecificationCategoryID", SpecId);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objspecmaster = new SpecificationCategory();
                objspecmaster.ProductName = dr["ProductName"].ToString();
                objspecmaster.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                objspecmaster.SpecificationCategoryID = long.Parse(dr["SpecificationCategoryID"].ToString());
                listspecmaster.Add(objspecmaster);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listspecmaster;
    }
    public void DeleteSpecCategory(long SpecMid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from SpecificationCategory where SpecificationCategoryID=@SpecificationCategoryID ", db.conn);

            cmd.Parameters.AddWithValue("@SpecificationCategoryID", SpecMid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<SpecificationCategory> GetSpecBasedOnPC(long PcId)
    {
        List<SpecificationCategory> listspemaster = new List<SpecificationCategory>();
        SpecificationCategory objspmaster;
        string Sqlquery = "";
        if (PcId != 0)
        {
            Sqlquery = "select P.ProductID,P.ProductName,S.SpecificationCategoryID,S.SpecificationCategoryName  from Products P inner join SpecificationCategory S on P.ProductID=S.ProductID where P.ProductCategoryID= " + PcId + " ";
        }
        else
        {
            Sqlquery = "select P.ProductID,P.ProductName,S.SpecificationCategoryID,S.SpecificationCategoryName  from Products P inner join SpecificationCategory S on P.ProductID=S.ProductID ";
        }
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(Sqlquery, db.conn);
            //cmd.Parameters.AddWithValue("@ProductCategoryID", PcId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objspmaster = new SpecificationCategory();
                objspmaster.ProductName = dr["ProductName"].ToString();
                objspmaster.ProductID = long.Parse(dr["ProductID"].ToString());
                objspmaster.SpecificationCategoryID = long.Parse(dr["SpecificationCategoryID"].ToString());
                objspmaster.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                listspemaster.Add(objspmaster);

            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listspemaster;
    }
    public List<SpecificationCategory> GetSpecCategory(bool istitlerequired)
    {
        List<SpecificationCategory> lstprodcatgry = new List<SpecificationCategory>();
        SpecificationCategory objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from SpecificationCategory";

            if (istitlerequired)
            {
                objprodctgry = new SpecificationCategory();
                objprodctgry.SpecificationCategoryID = 0;
                objprodctgry.SpecificationCategoryName = "-Select Product Category-";
                
                lstprodcatgry.Add(objprodctgry);
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new SpecificationCategory();
                objprodctgry.SpecificationCategoryID = long.Parse(dr["SpecificationCategoryID"].ToString());
                objprodctgry.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                
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
    public List<SpecificationCategory> GetSCategories( long pcid)
    {

        List<SpecificationCategory> listOfCategories = new List<SpecificationCategory>();
        SpecificationCategory sctgry = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from SpecificationCategory where productid=@productid", db.conn);
            cmd.Parameters.AddWithValue("@productid", pcid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sctgry = new SpecificationCategory();
                sctgry.SpecificationCategoryID = long.Parse(dr["SpecificationCategoryID"].ToString());
                sctgry.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                listOfCategories.Add(sctgry);
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

    public List<SpecificationCategory> GetSCategoryCount(long pid)
    {
        //int result;
        List<SpecificationCategory> listOfCategories = new List<SpecificationCategory>();
        SpecificationCategory objspeccate = new SpecificationCategory();
        try
        {
            db.OpenConn();

            
            string query = "select SpecificationCategoryID from specificationcategory where productid=@productid ";
            
            SqlCommand CmdRows = new SqlCommand(query, db.conn);
            CmdRows.Parameters.AddWithValue("@productid", pid);
            SqlDataReader dr = CmdRows.ExecuteReader();
            while (dr.Read())
            {
                objspeccate = new SpecificationCategory();
                objspeccate.SpecificationCategoryID =long.Parse( dr["SpecificationCategoryID"].ToString());
                listOfCategories.Add(objspeccate);
            }

            dr.Close();

            db.CloseConn();

        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listOfCategories;
    }

    public int GetSCCount(long pid)
    {
        int result;
        List<SpecificationCategory> listOfCategories = new List<SpecificationCategory>();
        SpecificationCategory objspeccate = new SpecificationCategory();
        try
        {
            db.OpenConn();


            string query = "select count(*) from specificationcategory where productid=@productid ";

            SqlCommand CmdRows = new SqlCommand(query, db.conn);
            CmdRows.Parameters.AddWithValue("@productid", pid);
            result = (int)CmdRows.ExecuteScalar();
         


            db.CloseConn();

        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return result;
    }
    public List<SpecificationCategory> GetSpecCategValues(bool istitlerequired)
    {
        List<SpecificationCategory> lstspeccatgry = new List<SpecificationCategory>();
        SpecificationCategory objspecgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from SpecificationCategory where ProductID=@ProductID ";

            if (istitlerequired)
            {
                objspecgry = new SpecificationCategory();
                objspecgry.SpecificationCategoryID = 0;
                objspecgry.SpecificationCategoryName = "-Select SpecificationCategory-";

                lstspeccatgry.Add(objspecgry);
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objspecgry = new SpecificationCategory();
                objspecgry.SpecificationCategoryID = long.Parse(dr["SpecificationCategoryID"].ToString());
                objspecgry.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();

                lstspeccatgry.Add(objspecgry);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstspeccatgry;
    }
}