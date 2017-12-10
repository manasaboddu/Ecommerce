using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DeliveryLocations
/// </summary>
public class DeliveryLocations
{
    DBAccess db=new DBAccess();
    public long DeliveryLocationsID{get;set;}
    public long UserAccountID { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNo { get; set; }


    public long SaveDeliveryDetails()
    {
        long dlid = 0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into DeliveryLocations values(@UserAccountID,@FName,@LName,@Street1,@Street2,@City,@PostalCode,@PhoneNo); select cast(SCOPE_IDENTITY() as bigint)", db.conn);
            cmd.Parameters.AddWithValue("@UserAccountID", UserAccountID);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@Street1", Street1);
            cmd.Parameters.AddWithValue("@Street2", Street2);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            dlid =(long)cmd.ExecuteScalar();
         
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return dlid;
    }
    public void UpdateDeliveryLocation()
    {
        long dlid = 0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update DeliveryLocations set UserAccountID=@UserAccountID,FName=@FName,LName=LName,Street1=@Street1,Street2=@Street2,City=@City,PostalCode=@PostalCode where DeliveryLocationsID=@DeliveryLocationsID", db.conn);
            cmd.Parameters.AddWithValue("@DeliveryLocationsID", DeliveryLocationsID);
            cmd.Parameters.AddWithValue("@UserAccountID", UserAccountID);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@Street1", Street1);
            cmd.Parameters.AddWithValue("@Street2", Street2);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void UpdateDeliveryDetails()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update DeliveryLocations set UserAccountID=@UserAccountID,FName=@FName,LName=@LName,Street1=@Street1,Street2=@Street2,City=@City,PostalCode=@PostalCode where DeliveryLocationsID=@DeliveryLocationsID", db.conn);
            cmd.Parameters.AddWithValue("@DeliveryLocationsID", DeliveryLocationsID);
            cmd.Parameters.AddWithValue("@UserAccountID", UserAccountID);
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@Street1", Street1);
            cmd.Parameters.AddWithValue("@Street2", Street2);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void DeleteDeliveryDetails()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd=new SqlCommand("delete from DeliveryLocations where DeliveryLocationsID=@DeliveryLocationsID",db.conn);
            cmd.Parameters.AddWithValue("@DeliveryLocationsID", DeliveryLocationsID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch(Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<DeliveryLocations> GetDeliveryDetails()
    {
        List<DeliveryLocations> lstdeliverylocation = new List<DeliveryLocations>();
        DeliveryLocations dl;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from DeliveryLocations where DeliveryLocationsID=@DeliveryLocationsID", db.conn);
            cmd.Parameters.AddWithValue("@DeliveryLocationsID", DeliveryLocationsID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dl = new DeliveryLocations();
                dl.UserAccountID = long.Parse(dr["UserAccountID"].ToString());
                dl.FName = dr["FName"].ToString();
                dl.LName = dr["LName"].ToString();
                dl.Street1 = dr["Street1"].ToString();
                dl.Street2 = dr["Street2"].ToString();
                dl.City = dr["City"].ToString();
                dl.PostalCode = dr["PostalCode"].ToString();
                dl.PhoneNo = dr["PhoneNo"].ToString();
                lstdeliverylocation.Add(dl);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstdeliverylocation;
    }

    public List<DeliveryLocations> GetDeliveryDetails(long uaid)
    {
        List<DeliveryLocations> lstdeliverylocation = new List<DeliveryLocations>();
        DeliveryLocations dl;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from DeliveryLocations where UserAccountID=@UserAccountID", db.conn);
            cmd.Parameters.AddWithValue("@UserAccountID", uaid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dl = new DeliveryLocations();
                dl.DeliveryLocationsID = long.Parse(dr["DeliveryLocationsID"].ToString());
                dl.UserAccountID = long.Parse(dr["UserAccountID"].ToString());
                dl.FName = dr["FName"].ToString();
                dl.LName = dr["LName"].ToString();
                dl.Street1 = dr["Street1"].ToString();
                dl.Street2 = dr["Street2"].ToString();
                dl.City = dr["City"].ToString();
                dl.PostalCode = dr["PostalCode"].ToString();
                dl.PhoneNo = dr["PhoneNo"].ToString();
                lstdeliverylocation.Add(dl);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstdeliverylocation;
    }
    public DeliveryLocations GetDeliveryDetails_DLID(string paramDeliveryLocationID)
    {
        DeliveryLocations dl = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from DeliveryLocations where DeliveryLocationsID=" + paramDeliveryLocationID + "", db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dl = new DeliveryLocations();
                dl.DeliveryLocationsID = long.Parse(dr["DeliveryLocationsID"].ToString());
                dl.UserAccountID = long.Parse(dr["UserAccountID"].ToString());
                dl.FName = dr["FName"].ToString();
                dl.LName = dr["LName"].ToString();
                dl.Street1 = dr["Street1"].ToString();
                dl.Street2 = dr["Street2"].ToString();
                dl.City = dr["City"].ToString();
                dl.PostalCode = dr["PostalCode"].ToString();
                dl.PhoneNo = dr["PhoneNo"].ToString();
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return dl;
    }
}