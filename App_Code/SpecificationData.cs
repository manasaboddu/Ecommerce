using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SpecificationData
/// </summary>
public class SpecificationData
{
    DBAccess db = new DBAccess();
    public long SpecificationValueID { get; set; }
    public string SpecificationValueName { get; set; }
    public long SpecificationMasterID { get; set; }
    public string SpecificationMasterName { get; set; }
    public string Description { get; set; }
    public long ProductID { get; set; }
    public string ProductCategoryName { get; set; }
    public string ProductName { get; set; }
    public string PicturePath { get; set; }
    public long ProductCategoryID { get; set; }


    public List<SpecificationData> GetSpecificationdata(long ProductID)
    {
      List<SpecificationData> lstsd=new List<SpecificationData>();
          SpecificationData sd;
        try
        {
            db.OpenConn();
            SqlCommand cmd=new SqlCommand("select S.SpecificationMasterName,SS.SpecificationValueName from SpecificationMaster S inner join SpecificationValues SS on S.SpecificationMasterID=SS.SpecificationMasterID where S.ProductID=@ProductID",db.conn);
            cmd.Parameters.AddWithValue("@ProductID",ProductID);
            SqlDataReader dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                sd=new SpecificationData();
                sd.SpecificationMasterName=dr["SpecificationMasterName"].ToString();
                sd.SpecificationValueName=dr["SpecificationValueName"].ToString();
                lstsd.Add(sd);

            }
            dr.Close();
            db.CloseConn();
        }
        catch(Exception ex)
         {
              db.CloseConn();
              throw ex;
         }
          return lstsd;
      }

    //public List<SpecificationData> GetRequiredData()
    //{
    //    List<SpecificationData>lstsd= new List<SpecificationData>();
    //    SpecificationData sd;
    //    try
    //    {
    //        db.OpenConn();
    //        SqlCommand cmd = new SqlCommand("select P.ProductID, P.ProductName, PC.ProductCategoryName, PC.ProductCategoryID from Products P,ProductCategory PC where PC.ProductCategoryID=P.ProductCategoryID", db.conn);
      
    //SqlDataReader dr = cmd.ExecuteReader();
    //        while (dr.Read())
    //        {
    //            sd = new SpecificationData();
    //            sd.ProductID = long.Parse(dr["ProductID"].ToString());
    //            sd.ProductName = dr["ProductName"].ToString();
    //            sd.ProductCategoryName = dr["ProductCategoryName"].ToString();
    //            //sd.SpecificationValueName = dr["SpecificationValueName"].ToString();
    //            //sd.PicturePath = dr["PicturePath"].ToString();
    //            lstsd.Add(sd);
    //        }
    //        dr.Close();
    //        db.CloseConn();
    //    }
    //    catch (Exception ex)
    //    {
    //        db.CloseConn();
    //        throw ex;
    //    }
    //    return lstsd;
    //}
    public List<SpecificationData> GetSpecData()
    {
        List<SpecificationData> lstsd = new List<SpecificationData>();
        SpecificationData specdata;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(" select P.ProductCategoryID,P.ProductCategoryName,S.SpecificationMasterName from ProductCategory P,SpecificationMaster S where PC.ProductCategoryID=S.ProductCategoryID", db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                specdata = new SpecificationData();
                specdata.ProductCategoryID = long.Parse(dr["ProductCategoryID"].ToString());
                specdata.ProductCategoryName = dr["ProductCategoryName"].ToString();
                specdata.SpecificationMasterName = dr["SpecificationMasterName"].ToString();
                lstsd.Add(specdata);
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
   

}
          
