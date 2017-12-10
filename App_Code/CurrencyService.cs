using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CurrencyService
/// </summary>
public class CurrencyService
{
    public CurrencyService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long ServiceID { set; get; }


    DBAccess db = new DBAccess();
    public float FromValue { get; set; }
    public float ToValue { get; set; }
    public string ConversionTypeFrom { get; set; }
    public string ConversionTypeTo { get; set; }
    public DateTime EventDate { get; set; }

    public long CurrencyID { get; set; }
    public string CountryCode { get; set; }
    public string CurrencyName { get; set; }

    public List<CurrencyService> GetAllConverstions(bool istitlerequired)
    {
        List<CurrencyService> lstprodcatgry = new List<CurrencyService>();
        CurrencyService objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from CurrencyService order by ConversionTypeTo desc";

            if (istitlerequired)
            {
                objprodctgry = new CurrencyService();
                objprodctgry.ToValue = -1;
                objprodctgry.ConversionTypeTo = "--Select Country-";
                
                lstprodcatgry.Add(objprodctgry);
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new CurrencyService();
                objprodctgry.ToValue = float.Parse(dr["ToValue"].ToString());
                objprodctgry.ConversionTypeTo = dr["ConversionTypeTo"].ToString();
                
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

    public List<CurrencyService> GetAllCurrency(bool istitlerequired)
    {
        List<CurrencyService> lstprodcatgry = new List<CurrencyService>();
        CurrencyService objprodctgry = null;
        try
        {
            db.OpenConn();
            string query = "select * from Currency ";

            if (istitlerequired)
            {
                objprodctgry = new CurrencyService();
                objprodctgry.CountryCode = "-1";
                objprodctgry.CurrencyName = "--Select Country-";

                lstprodcatgry.Add(objprodctgry);
            }

            SqlCommand cmd = new SqlCommand(query, db.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objprodctgry = new CurrencyService();
                objprodctgry.CountryCode = dr["CountryCode"].ToString();
                objprodctgry.CurrencyName = dr["CurrencyName"].ToString();

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
}