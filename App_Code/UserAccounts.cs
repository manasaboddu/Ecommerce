using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for userlogin
/// </summary>
public class UserAccounts
{
    DBAccess db = new DBAccess();
    public long UserAccountID { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public  long MobileNo { get; set; }
    public string EmailID { get; set; }
    public string Password { get; set; }
    public string TokenID { get; set; }

    public List<UserAccounts> GetUserRecord()
    {
        List<UserAccounts> lstul = new List<UserAccounts>();
        UserAccounts ul;
        try
        {
            db.OpenConn();
            SqlCommand cmd;
            if (Password != "")
            {
                cmd = new SqlCommand("select * from UserAccounts where EmailID=@EmailID and Password=@Password", db.conn);
            }
            else
            {
                cmd = new SqlCommand("select * from UserAccounts where EmailID=@EmailID", db.conn);
            }
            cmd.Parameters.AddWithValue("@EmailID", EmailID);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ul = new UserAccounts();
                ul.EmailID = dr["EmailID"].ToString();
                ul.Password = dr["Password"].ToString();
                ul.Role = dr["Role"].ToString();
                ul.Firstname = dr["Firstname"].ToString();
                ul.LastName = dr["LastName"].ToString();
                ul.MobileNo = long.Parse(dr["MobileNo"].ToString());
                ul.UserAccountID = long.Parse(dr["UserAccountID"].ToString());
                lstul.Add(ul);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstul;
    }
    public long SaveRecord()
    {
        long i = 0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into UserAccounts values(@Password,@Firstname,@LastName,@Role,@MobileNo,@EmailID,'');select cast(SCOPE_IDENTITY() as bigint)", db.conn);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Firstname", Firstname);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@EmailID", EmailID);

            i = (long)cmd.ExecuteScalar();

            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return i;
    }
    public bool IsEmailAvailable(string email)
    {
       
        bool isavailable = false;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select EmailID from UserAccounts where EmailID=@EmailID", db.conn);
            cmd.Parameters.AddWithValue("@EmailID", email);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isavailable = true;
                
            }
            dr.Close();
            db.CloseConn();
          
        }
        catch (Exception ex)
        {
            db.CloseConn();

            return false;
        }
        return isavailable;
    }
    public List<UserAccounts> GetUserAccountsRecord(string eid)
    {
        List<UserAccounts> lstul = new List<UserAccounts>();
        UserAccounts ul;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from UserAccounts where EmailID=@EmailID", db.conn);
            cmd.Parameters.AddWithValue("@EmailID", eid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ul = new UserAccounts();
                ul.EmailID = dr["EmailID"].ToString();
                ul.Password = dr["Password"].ToString();
                ul.Firstname = dr["Firstname"].ToString();
                ul.LastName = dr["LastName"].ToString();
                ul.UserAccountID = long.Parse(dr["UserAccountID"].ToString());
                lstul.Add(ul);    
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstul;
    }
    public int UpdateDetails(string fname,string lname,string emailid,string mail)
    {
        int i = 0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update useraccounts set firstname=@fname,lastname=@lname,emailid=@emailid where emailid=@email", db.conn);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@emailid", emailid);
            cmd.Parameters.AddWithValue("@email", mail);
           i= cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return i;
    }
    public int UpdateUserDetails(string mail)
    {
        int i = 0;
        try
        {

            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update useraccounts set firstname=@fname,lastname=@lname,emailid=@emailid,password=@pswrd where emailid=@email", db.conn);
            cmd.Parameters.AddWithValue("@fname", Firstname);
            cmd.Parameters.AddWithValue("@lname", LastName);
            cmd.Parameters.AddWithValue("@emailid", EmailID);
            cmd.Parameters.AddWithValue("@email", mail);
            cmd.Parameters.AddWithValue("@pswrd", Password);
            i = cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return i;
    }
    public void UpdatePassword(string emailid, string pwd)
    {
        try
        {

            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update UserAccounts set Password=@Password where EmailID=@EmailID",db.conn);
            cmd.Parameters.AddWithValue("@EmailID", emailid);
            cmd.Parameters.AddWithValue("@Password", pwd);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public bool GetUserAccountsDetails(string pswrd)
    {
        bool val = false;
        UserAccounts ul;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from UserAccounts where Password=@pswrd", db.conn);
            cmd.Parameters.AddWithValue("@pswrd", pswrd);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            { 
                val=true;
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return val;
    }
    public long IsMobileNoExist(long mobileno)
    {

        long id = 0;
        UserAccounts objuser = new UserAccounts();
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select UserAccountID from UserAccounts where MobileNo=@MobileNo", db.conn);
            cmd.Parameters.AddWithValue("@MobileNo", mobileno);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                objuser = new UserAccounts();
                id =long .Parse( dr["UserAccountID"].ToString());
            }
        
            dr.Close();
            db.CloseConn();

        }
        catch (Exception ex)
        {
            db.CloseConn();

            throw ex;
        }
        return id;
    }
    public int UpdateUserDetail(long uid)
    {
        int i = 0;
        try
        {

            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update useraccounts set firstname=@fname,lastname=@lname,emailid=@emailid where UserAccountID=@UserAccountID", db.conn);
            cmd.Parameters.AddWithValue("@fname", Firstname);
            cmd.Parameters.AddWithValue("@lname", LastName);
            cmd.Parameters.AddWithValue("@emailid", EmailID);
            //cmd.Parameters.AddWithValue("@email", EmailID);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@UserAccountID", uid);
               
            //cmd.Parameters.AddWithValue("@pswrd", Password);
            i = cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return i;
    }

}