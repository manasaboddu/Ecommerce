using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OfferMaster
/// </summary>
public class OfferMaster
{
    public OfferMaster()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public long OfferID { set; get; }
    public string OfferType { set; get; }
    public string OfferAmount { set; get; }
    public DateTime ValidUpto { set; get; }
    public string OfferCode { set; get; }

    DBAccess db = new DBAccess();

    public List<OfferMaster> GetAllOffers()
    {
        List<OfferMaster> lstorderdetails = new List<OfferMaster>();
        OfferMaster objod;
        try
        {
            db.OpenConn();

            string Date = DateTime.Now.ToString("dd-MMM-yyyy");

            SqlCommand cmd = new SqlCommand("select  * from OfferMaster where validupto <='"+ Date + "'", db.conn);
          //  cmd.Parameters.AddWithValue("@OrderDetailsID", OrderDetailsID);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objod = new OfferMaster();
                objod.OfferID = long.Parse(dr["OfferID"].ToString());
                objod.OfferType = dr["OfferType"].ToString();
                objod.OfferAmount = dr["OfferAmount"].ToString();
                objod.ValidUpto = DateTime.Parse(dr["ValidUpto"].ToString());
                objod.OfferCode = dr["OfferCode"].ToString();
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
}