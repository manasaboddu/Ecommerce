using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DBAccess
/// </summary>
public class DBAccess
{
    public SqlConnection conn = null;
    string path = "";
    string dbstring = "";
    public DBAccess()
    {
        //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
      
        try
        {

            dbstring = "Initial Catalog=GEMS_DB;Data Source=MANASA;User ID=sa;Password=Dell@123";
            conn = new SqlConnection(dbstring);
        }
        catch
        {
          
        }

    }
    public void OpenConn()
    {
        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        catch
        {
          
        }

    }
    public void CloseConn()
    {
        try
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
        }
        catch
        {
          
        }
    }
}