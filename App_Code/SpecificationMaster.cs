using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SpecificationMaster
/// </summary>
public class SpecificationMaster
{
    DBAccess db = new DBAccess();
    public long SpecificationMasterID { get; set; }
    public string SpecificationMasterName { get; set; }
    public string Description { get; set; }
    public long ProductID { get; set; }
    public string ProductName { get; set; }
    public long ProductCategoryID { get; set; }
    public string ProductCategoryName { get; set; }
    public long SpecificationCategoryID { get; set; }
    public string SpecificationCategoryName { get; set; }
   
    public void UpdateSpecificationMaster()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update  SpecificationMaster set SpecificationMasterName=@SpecificationMasterName where ProductID=@ProductID and SpecificationMasterID=@SpecificationMasterID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@SpecificationMasterName", SpecificationMasterName);
            cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecificationMasterID);
           
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void DeleteSpecificationMaster()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from SpecificationMaster where ProductID=@ProductID and SpecificationCategoryID=@SpecificationCategoryID and @SpecificationMasterID=SpecificationMasterID ", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@SpecificationCategoryID", SpecificationCategoryID);
            cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecificationMasterID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<SpecificationMaster> GetSpecificationMaster()
    {
        List<SpecificationMaster> listspecificationmaster = new List<SpecificationMaster>();
        SpecificationMaster objspecificationmaster = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select S.SpecificationMasterID, P.ProductID,P.ProductName,SC.SpecificationCategoryName,S.SpecificationMasterName from Products P inner join SpecificationMaster S on P.ProductID=S.ProductID inner join SpecificationCategory SC on S.SpecificationCategoryID=SC.SpecificationCategoryID", db.conn);
           
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objspecificationmaster = new SpecificationMaster();
                objspecificationmaster.ProductID = long.Parse(dr["ProductID"].ToString());
                objspecificationmaster.ProductName = dr["ProductName"].ToString();
                objspecificationmaster.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                objspecificationmaster.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                objspecificationmaster.SpecificationMasterID=long.Parse(dr["SpecificationMasterID"].ToString());
              
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
    public int SaveRecord()
    {
        int value=0;
        try
        {
            db.OpenConn();
            string query = "insert into SpecificationMaster(SpecificationMasterName,Description,ProductID,SpecificationCategoryID) values(@SpecificationMasterName,@Description,@ProductID,@SpecificationCategoryID) SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            //cmd.Parameters.AddWithValue("@productid", ProductID);
            cmd.Parameters.AddWithValue("@SpecificationMasterName", SpecificationMasterName);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@SpecificationCategoryID", SpecificationCategoryID);
            value = int.Parse(cmd.ExecuteScalar().ToString());
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
        }
        return value;
    }
    public List<SpecificationMaster> GetSpecMaster(long SpecId)
    {
        List<SpecificationMaster> listspecmaster = new List<SpecificationMaster>();
        SpecificationMaster objspecmaster = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select P.ProductName,S.SpecificationMasterName,SC.SpecificationCategoryName,SC.SpecificationCategoryID from Products P inner join SpecificationMaster S on P.ProductID=S.ProductID inner join SpecificationCategory SC on S.SpecificationCategoryID=SC.SpecificationCategoryID where SpecificationMasterID=@SpecificationMasterID", db.conn);
            cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecId);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objspecmaster = new SpecificationMaster();
                objspecmaster.ProductName = dr["ProductName"].ToString();
                objspecmaster.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                objspecmaster.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
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
    public void UpdateSpecMaster(long scid,long SmID,string SmName)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update  SpecificationMaster set SpecificationCategoryID=@SpecificationCategoryID, SpecificationMasterName=@SpecificationMasterName where  SpecificationMasterID=@SpecificationMasterID", db.conn);
            cmd.Parameters.AddWithValue("@SpecificationCategoryID", scid);
                cmd.Parameters.AddWithValue("@SpecificationMasterID", SmID);
            cmd.Parameters.AddWithValue("@SpecificationMasterName", SmName);
            

            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void DeleteSpecMaster(long SpecMid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from SpecificationMaster where SpecificationMasterID=@SpecificationMasterID ", db.conn);

            cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecMid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<SpecificationMaster> GetSpecBasedOnPC(long PcId)
    {
        List<SpecificationMaster> listspemaster = new List<SpecificationMaster>();
        SpecificationMaster objspmaster;
        string Sqlquery = "";
        if (PcId != 0)
        {
            Sqlquery = "select S.SpecificationMasterID, P.ProductID,P.ProductName,SC.SpecificationCategoryName,S.SpecificationMasterName from Products P inner join SpecificationMaster S on P.ProductID=S.ProductID inner join SpecificationCategory SC on S.SpecificationCategoryID=SC.SpecificationCategoryID where P.ProductCategoryID=" + PcId + "";
        }
        else
        {
            Sqlquery = "select S.SpecificationMasterID, P.ProductID,P.ProductName,SC.SpecificationCategoryName,S.SpecificationMasterName from Products P inner join SpecificationMaster S on P.ProductID=S.ProductID inner join SpecificationCategory SC on S.SpecificationCategoryID=SC.SpecificationCategoryID";
        }
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(Sqlquery, db.conn);
           // cmd.Parameters.AddWithValue("@ProductCategoryID", PcId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objspmaster = new SpecificationMaster();
                objspmaster.ProductID =long.Parse(dr["ProductID"].ToString());
                objspmaster.ProductName = dr["ProductName"].ToString();
                objspmaster.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                objspmaster.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                objspmaster.SpecificationMasterID = long.Parse(dr["SpecificationMasterID"].ToString());
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
}
  
            

        

