using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order_Offers
/// </summary>
public class Order_Offers
{
    public Order_Offers()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    DBAccess db = new DBAccess();
    public long Order_OffersID { get; set; }
    public long UserID { get; set; }
    public long CaseNo { get; set; }
    public string CaseType { get; set; }
    public string OfferCode { get; set; }
    public float OfferAmount { get; set; }
    public DateTime AppliedOn { get; set; }

    public long SaveOrder_Offers()
    {
        long dlid = 0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into Order_Offers values(@UserID,@CaseNo,@CaseType,@OfferCode,@OfferAmount,@AppliedOn); select cast(SCOPE_IDENTITY() as bigint)", db.conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@CaseNo", CaseNo);
            cmd.Parameters.AddWithValue("@CaseType", CaseType);
            cmd.Parameters.AddWithValue("@OfferCode", OfferCode);
            cmd.Parameters.AddWithValue("@OfferAmount", OfferAmount);
            cmd.Parameters.AddWithValue("@AppliedOn", AppliedOn);
           
            dlid = (long)cmd.ExecuteScalar();

            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return dlid;
    }
}