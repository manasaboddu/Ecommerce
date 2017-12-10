using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;
using System.Linq;

/// <summary>
/// Summary description for Utilities
/// </summary>
public class Utilities
{
    public Utilities()
    {
    }

    //DBUtility db = new DBUtility();
    DBAccess db = new DBAccess();
    public string Encode(string text)
    {
        byte[] mybyte = System.Text.Encoding.UTF8.GetBytes(text);
        string returntext = System.Convert.ToBase64String(mybyte);
        return returntext;
    }
    public string Decode(string text)
    {
        byte[] mybyte = System.Convert.FromBase64String(text);
        string returntext = System.Text.Encoding.UTF8.GetString(mybyte);
        return returntext;
    }

    public string GetAddressforQuery(long dlid)
    {
        
        UserAccounts objenquiryDetails = new UserAccounts();
        string DeleAddress = "";
        try
        {

            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select * from DeliveryLocations where DeliveryLocationsID=@DeliveryLocationsID ", db.conn);

            cmd.Parameters.AddWithValue("@DeliveryLocationsID", dlid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DeleAddress = dr["FName"].ToString() + "-" + dr["LName"].ToString() + "," + dr["PhoneNo"].ToString() + "," + dr["Street1"].ToString() + "," + dr["Street2"].ToString() + "," + dr["City"].ToString() + "," + dr["PostalCode"].ToString();

            }

            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        // string i = catname.Trim(new char[] { ',' });
        return DeleAddress.Trim(new char[] { ',' });

    }

    //Currency Conversion Method
    public string GetCurrencyRate(string Amt, string FromCode, string ToCode)
    {

        //System.Net.WebClient client = new System.Net.WebClient();
        //double rate = double.Parse(client.DownloadString("https://www.igolder.com/exchangerate.ashx?from=" + FromCode + "&to=" + ToCode));
        //return rate;


        string URL = "http://www.google.com/finance/converter?a=" + Amt + "&from=" + FromCode + "&to=" + ToCode;
        byte[] databuffer = Encoding.ASCII.GetBytes("test=postvar&test2=another");
        HttpWebRequest _webreqquest = (HttpWebRequest)WebRequest.Create(URL);
        _webreqquest.Method = "POST";
        _webreqquest.ContentType = "application/x-www-form-urlencoded";
        _webreqquest.ContentLength = databuffer.Length;
        Stream PostData = _webreqquest.GetRequestStream();
        PostData.Write(databuffer, 0, databuffer.Length);
        PostData.Close();
        HttpWebResponse WebResp = (HttpWebResponse)_webreqquest.GetResponse();
        Stream finalanswer = WebResp.GetResponseStream();
        StreamReader _answer = new StreamReader(finalanswer);
        string[] value = Regex.Split(_answer.ReadToEnd(), "&nbsp;");


        int first = value[1].IndexOf("<div id=currency_converter_result>");
        int last = value[1].LastIndexOf("</span>");

        string str2 = value[1].Substring(first, last - first);

        str2 = str2.Replace("<span class=bld>", " ");
        str2 = str2.Replace("<div id=currency_converter_result>", "");
        string[] str = str2.Split(' ');
        str2 =str[4].ToString();
        return str2;
    }

    //public string GetCurrencyRate(string fromtype)
    //{ 
    
    //}


    public string GetCurrencySymbol(string code)
    {
        System.Globalization.RegionInfo regionInfo = (from culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures)
                                                      where culture.Name.Length > 0 && !culture.IsNeutralCulture
                                                      let region = new System.Globalization.RegionInfo(culture.LCID)
                                                      where String.Equals(region.ISOCurrencySymbol, code, StringComparison.InvariantCultureIgnoreCase)
                                                      select region).First();

        return regionInfo.CurrencySymbol;
    }

    public List<Utilities> GetCountries()
    {
        List<Utilities> lstCountries = new List<Utilities>();
        Utilities objCountry = new Utilities();
        objCountry.CountryCode = "INR";
        objCountry.CountryName = "India Rupees Rs";
        lstCountries.Add(objCountry);
        objCountry = new Utilities();
        objCountry.CountryCode = "USD";
        objCountry.CountryName = "United States Dollars $";
        lstCountries.Add(objCountry);

        return lstCountries;

    }

    public string CountryCode { get; set; }

    public string CountryName { get; set; }
    public string GetURLPath()
    {
        return "http://49.207.32.42:105/shrines_sales";
    }

    public string GetResultForQueryfromDB(string query)
    {
        string val = "";
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.CommandTimeout = 0;
            SqlDataReader dreader = cmd.ExecuteReader();
            if (dreader.Read())
            {
                val = dreader[0].ToString();
            }
            db.CloseConn();
        }
        catch (Exception ee) { throw ee; }

        return val;

    }
}
