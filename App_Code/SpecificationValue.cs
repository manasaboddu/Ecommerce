using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SpecificationValues
/// </summary>
public class SpecificationValue
{
    DBAccess db = new DBAccess();
    public long SpecificationValueID { get; set; }
    public string SpecificationValueName { get; set; }
    public long SpecificationMasterID { get; set; }
    public long ProductID { get; set; }
    public string SpecificationMasterName { get; set; }
    public long ProductCategoryID { get; set; }
    public string SpecificationCategoryName { get; set; }
    public long SpecificationCategoryID { get; set; }


    public void UpdateSpecRecord()
    {

        try
        {
            db.OpenConn();
            string query="update SpecificationValues set SpecificationValueName=@SpecificationValueName where SpecificationMasterID=@SpecificationMasterID and ProductID=@ProductID ";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@SpecificationValueName", SpecificationValueName);
            cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecificationMasterID);
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
  
    public List<SpecificationValue> GetSpec()
    {
        List<SpecificationValue> lstsvalues = new List<SpecificationValue>();
        SpecificationValue obj;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select SC.SpecificationCategoryID,SC.SpecificationCategoryName, SM.SpecificationMasterID,SM.specificationmastername ,SV.SpecificationValueName,SM.ProductID FROM SpecificationCategory SC inner join  specificationmaster SM  on SC.SpecificationCategoryId=SM.SpecificationCategoryId left outer join SpecificationValues SV on  SM.specificationmasterid=SV.specificationmasterid where SM.Productid=@ProductID ", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            //cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
            //cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecificationMasterID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj = new SpecificationValue();
                obj.SpecificationCategoryID = long.Parse(dr["SpecificationCategoryID"].ToString());
                obj.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                obj.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                obj.SpecificationValueName = dr["SpecificationValueName"].ToString();
                obj.SpecificationMasterID = long.Parse(dr["SpecificationMasterID"].ToString());
                lstsvalues.Add(obj);
            }
            //dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstsvalues;
    }
    public void SaveRecord()
    {

        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into SpecificationValues values(@SpecificationValueName,@SpecificationMasterID,@ProductID)", db.conn);
            cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecificationMasterID);
            cmd.Parameters.AddWithValue("@SpecificationValueName", SpecificationValueName);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
        }
    }
    public List<SpecificationValue> GetProductSpecDetails(long pcid, long productid)
    {
        List<SpecificationValue> lstpspec = new List<SpecificationValue>();
        SpecificationValue specvalue;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select S.specificationmastername,SV.specificationvaluename from 
SpecificationMaster S,SpecificationValues SV where S.SpecificationMasterID=SV.SpecificationMasterID AND S.ProductID=@ProductID ", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", productid);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                specvalue = new SpecificationValue();
                specvalue.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                specvalue.SpecificationValueName = dr["SpecificationValueName"].ToString();
                lstpspec.Add(specvalue);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpspec;
    }
    public List<SpecificationValue> GetProductSpecificationDetails(long pcid,long pid)
    {
        List<SpecificationValue> lstpspec = new List<SpecificationValue>();
        SpecificationValue specvalue;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select S.specificationmastername,SV.specificationvaluename from 
SpecificationMaster S,SpecificationValues SV where S.SpecificationMasterID=SV.SpecificationMasterID and ProductCategoryID=@ProductCategoryID and productid=@pructid", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            cmd.Parameters.AddWithValue("@pructid", pid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                specvalue = new SpecificationValue();
                specvalue.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                specvalue.SpecificationValueName = dr["SpecificationValueName"].ToString();
                lstpspec.Add(specvalue);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpspec;
    }
    public List<SpecificationValue> SelectedProductDetails(long pno)
    {
        List<SpecificationValue> lstsspecv = new List<SpecificationValue>();
        SpecificationValue specvalue;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select S.SpecificationMasterName,SV.SpecificationValueName,SV.ProductID from SpecificationMaster S,SpecificationValues SV where S.SpecificationMasterID=SV.SpecificationMasterID and ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pno);
           
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                specvalue = new SpecificationValue();
                specvalue.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                specvalue.SpecificationValueName = dr["SpecificationValueName"].ToString();
                specvalue.ProductID = long.Parse(dr["ProductID"].ToString());
                lstsspecv.Add(specvalue);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstsspecv;
    }

    public long PictureThumbnailsID { get; set; }
    public string PictureThumbPath { get; set; }
    public long ProductPictureID { get; set; }

    public List<SpecificationValue> GetPictureThumbnails(long thumbpathid)
    {
        List<SpecificationValue> lstpicthumnls = new List<SpecificationValue>();
        SpecificationValue objpicthumnls = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from PicturesThumbnails where ProductPictureID=@pictureid", db.conn);
            cmd.Parameters.AddWithValue("@pictureid", thumbpathid);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objpicthumnls = new SpecificationValue();
                objpicthumnls.PictureThumbnailsID = long.Parse(dr["PictureThumbnailsID"].ToString());
                objpicthumnls.PictureThumbPath = dr["PictureThumbPath"].ToString();
                objpicthumnls.ProductPictureID = long.Parse(dr["ProductPictureID"].ToString());
                lstpicthumnls.Add(objpicthumnls);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception e)
        {
            db.CloseConn();
            throw e;
        }
        return lstpicthumnls;
    }

    public List<SpecificationValue> GetProductSpec()
    {
        List<SpecificationValue> lstsvalues = new List<SpecificationValue>();
        SpecificationValue obj;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select SM.SpecificationMasterID,SM.Specificationmastername,P.ProductID  FROM specificationmaster SM inner join Products P on SM.ProductID=P.ProductID WHERE SM.PRoductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
            //cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecificationMasterID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj = new SpecificationValue();
                obj.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                
                obj.SpecificationMasterID = long.Parse(dr["SpecificationMasterID"].ToString());
                lstsvalues.Add(obj);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstsvalues;
    }
    public void DeleteProductSpec(long productid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from SpecificationValues where ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", productid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<SpecificationValue> GetProductSpecificationFeatures(long pcid)
    {
        List<SpecificationValue> lstpspec = new List<SpecificationValue>();
        SpecificationValue specvalue;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select SM.SpecificationMasterName,SV.SpecificationValueName from SpecificationMaster SM inner join SpecificationValues SV on SM.SpecificationMasterID=SV.SpecificationMasterID   where 
SV.productid=@ProductID ", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pcid);
            //cmd.Parameters.AddWithValue("@pructid", pid);
            //cmd.Parameters.AddWithValue("@Specificationcategoryid", speccategoryid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                specvalue = new SpecificationValue();
                specvalue.SpecificationMasterName = "* "+dr["SpecificationMasterName"].ToString();
                
                specvalue.SpecificationValueName = ":  "+dr["SpecificationValueName"].ToString();
                lstpspec.Add(specvalue);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpspec;
    }
    public List<SpecificationValue> GetProductRawParameterValues(long pcid)
    {
        List<SpecificationValue> lstpspec = new List<SpecificationValue>();
        SpecificationValue specvalue;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select SM.SpecificationMasterName,SV.SpecificationValueName from SpecificationMaster SM inner join SpecificationValues SV on SM.SpecificationMasterID=SV.SpecificationMasterID   where 
SV.productid=@ProductID and SM.Specificationcategoryid=2 ", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pcid);
            //cmd.Parameters.AddWithValue("@pructid", pid);
            //cmd.Parameters.AddWithValue("@Specificationcategoryid", speccategoryid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                specvalue = new SpecificationValue();
                specvalue.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                specvalue.SpecificationValueName = ":"+ dr["SpecificationValueName"].ToString();
                lstpspec.Add(specvalue);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpspec;
    }
    public List<SpecificationValue> GetProductTechSpec(long pcid)
    {
        List<SpecificationValue> lstpspec = new List<SpecificationValue>();
        SpecificationValue specvalue;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select SM.SpecificationMasterName,SV.SpecificationValueName from SpecificationMaster SM inner join SpecificationValues SV on SM.SpecificationMasterID=SV.SpecificationMasterID   where 
 SM.Specificationcategoryid=@Specificationcategoryid ", db.conn);

            cmd.Parameters.AddWithValue("@Specificationcategoryid", pcid);
            //cmd.Parameters.AddWithValue("@pructid", pid);
            //cmd.Parameters.AddWithValue("@Specificationcategoryid", speccategoryid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                specvalue = new SpecificationValue();
                specvalue.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                specvalue.SpecificationValueName = ":"+ dr["SpecificationValueName"].ToString();
                lstpspec.Add(specvalue);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpspec;
    }
    public void DeleteSpecMast(long specmid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from SpecificationValues where SpecificationMasterID=@SpecificationMasterID", db.conn);
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
    //public void UpdateSpecMaster(long spmid,string spname)
    //{

    //    try
    //    {
    //        db.OpenConn();
    //        string query = "update SpecificationValues set SpecificationValueName=@SpecificationValueName where SpecificationMasterID=@SpecificationMasterID and ProductID=@ProductID ";
    //        SqlCommand cmd = new SqlCommand(query, db.conn);
    //        cmd.Parameters.AddWithValue("@SpecificationValueName", SpecificationValueName);
    //        cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecificationMasterID);
    //        cmd.Parameters.AddWithValue("@ProductID", ProductID);
    //        cmd.ExecuteNonQuery();
    //        db.CloseConn();

    //    }
    //    catch (Exception ex)
    //    {
    //        db.CloseConn();
    //        throw ex;
    //    }

    //}

    public List<SpecificationValue> GetProductSpecs(long pcid)
    {
        List<SpecificationValue> lstpspec = new List<SpecificationValue>();
        SpecificationValue specvalue;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@" select SM.SpecificationMasterID, SM.SpecificationMasterName,SV.SpecificationValueName from SpecificationMaster SM left outer join SpecificationValues SV on SM.SpecificationMasterID=SV.SpecificationMasterID   where 
 SM.Specificationcategoryid=@Specificationcategoryid ", db.conn);

            cmd.Parameters.AddWithValue("@Specificationcategoryid", pcid);
            //cmd.Parameters.AddWithValue("@pructid", pid);
            //cmd.Parameters.AddWithValue("@Specificationcategoryid", speccategoryid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                specvalue = new SpecificationValue();
                specvalue.SpecificationMasterID =long.Parse(dr["SpecificationMasterID"].ToString());
                specvalue.SpecificationMasterName ="* "+ dr["SpecificationMasterName"].ToString();
                specvalue.SpecificationValueName = ": " + dr["SpecificationValueName"].ToString();
                lstpspec.Add(specvalue);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpspec;
    }
    public List<SpecificationValue> GetSpecBasedOnCateg(long scid,long prid)
    {
        List<SpecificationValue> lstsvalues = new List<SpecificationValue>();
        SpecificationValue obj;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select SC.SpecificationCategoryID,SC.SpecificationCategoryName, SM.SpecificationMasterID,SM.specificationmastername ,SV.SpecificationValueName,SM.ProductID FROM SpecificationCategory SC inner join  specificationmaster SM  on SC.SpecificationCategoryId=SM.SpecificationCategoryId left outer join SpecificationValues SV on  SM.specificationmasterid=SV.specificationmasterid where SM.ProductID=@ProductID and   SM.SpecificationCategoryID=@SpecificationCategoryID ", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", prid);
            cmd.Parameters.AddWithValue("@SpecificationCategoryID", scid);
                
            //cmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
            //cmd.Parameters.AddWithValue("@SpecificationMasterID", SpecificationMasterID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj = new SpecificationValue();
                obj.SpecificationCategoryName = dr["SpecificationCategoryName"].ToString();
                obj.SpecificationCategoryID = long.Parse(dr["SpecificationCategoryID"].ToString());
                obj.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                obj.SpecificationValueName = dr["SpecificationValueName"].ToString();
                obj.SpecificationMasterID = long.Parse(dr["SpecificationMasterID"].ToString());
                lstsvalues.Add(obj);
            }
            //dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstsvalues;
    }
}
