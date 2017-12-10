using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReedemPoints
/// </summary>
public class ReedemPoints
{
    public ReedemPoints()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DBAccess db = new DBAccess();
    public long PointsID { get; set; }
    public long UserID { get; set; }
    public string OrderType { get; set; }
    public string Type { get; set; }
    public long Points { get; set; }


    public void SaveRecord()
    {
        try
        {
            db.OpenConn();
            string query = "insert into ReedemPoints(UserID,OrderType,Type,Points) values(@UserID,@OrderType,@Type,@Points)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@OrderType", OrderType);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Points", Points);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }

}