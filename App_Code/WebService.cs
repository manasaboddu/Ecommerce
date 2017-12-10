using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using AjaxControlToolkit;
using System.Collections.Specialized;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]

public class WebService : System.Web.Services.WebService
{


    public WebService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool DoesEmailExist(string email)
    {
        UserAccounts objua = new UserAccounts();
        bool boolobj = true;
        boolobj = objua.IsEmailAvailable(email);
        return boolobj;

    }
    [WebMethod]
    public string GetProductList(string allproductid, string productid)
    {
        string products = "";
        bool isexist = false;
        string[] id = allproductid.Split(',');
        if (id.Contains(productid))
        {
            foreach (string s in id)
            {
                if (s != productid && s != "")
                {
                    if (products == "" || products == null)
                        products = s;
                    else
                    products += ","+s  ;
                }
            }
        }
  
        else
        {
            foreach (string s in id)
            {
                if (s == productid)
                {
                    isexist = true;
                    allproductid.Replace(productid, "");
                }
            }
            if (!isexist)
            {
                allproductid +=","+ productid  ;
            }
            products = allproductid;

            //allproductid = allproductid.Trim(new char[] { ',' });

        }
        return products;
    }
    

    [WebMethod]
    public List<Products> GetCartProducts(long pid, int qty)
    {
        List<Products> lstprdts = new List<Products>();
        Products objp = new Products();
        lstprdts = objp.GetCartProductDetails(pid.ToString(), qty);
        return lstprdts;

    }

    [WebMethod]
    public AjaxControlToolkit.CascadingDropDownNameValue[] GetPCategories(string knownCategoryValues, string category)
    {
        //System.Diagnostics.Debug.Print(knownCategoryValues + " --- " + category);


        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);


        List<AjaxControlToolkit.CascadingDropDownNameValue> values = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

        List<ProductCategories> lstcategory = (new ProductCategories()).GetPCategories();

        foreach (ProductCategories objcategory in lstcategory)
        {
            CascadingDropDownNameValue item = new CascadingDropDownNameValue(objcategory.ProductCategoryName, objcategory.ProductCategoryID.ToString());

            values.Add(item);

        }


        if (kv.Count == 1 && kv.ContainsKey("ProductCategoryID"))
        //if (kv.Count == 1 && category=="StatesId")
        {

            string s = kv["ProductCategoryID"];

            values.Clear();

            List<Products> lstprdts = (new Products()).GetProducts(long.Parse(s));


            foreach (Products objprdts in lstprdts)
            {
                CascadingDropDownNameValue item = new CascadingDropDownNameValue(objprdts.ProductName, objprdts.ProductID.ToString());

                values.Add(item);
            }

        }
        //else if (kv.Count == 2 && category == "StatesId")
        else if (kv.Count == 2 && kv.ContainsKey("ProductID"))
        //else if (kv.Count == 2)
        {
            string s = kv["ProductID"];
            values.Clear();
            List<SpecificationCategory> banks = (new SpecificationCategory()).GetSCategories(long.Parse(s));

            foreach (SpecificationCategory objspctgy in banks)
            {
                CascadingDropDownNameValue item = new CascadingDropDownNameValue(objspctgy.SpecificationCategoryName, objspctgy.SpecificationCategoryID.ToString());

                values.Add(item);

            }
        }

        return values.ToArray();

    }



    [WebMethod]
    public AjaxControlToolkit.CascadingDropDownNameValue[] GetCategories(string knownCategoryValues, string category)
    {
        //System.Diagnostics.Debug.Print(knownCategoryValues + " --- " + category);


        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);


        List<AjaxControlToolkit.CascadingDropDownNameValue> values = new List<AjaxControlToolkit.CascadingDropDownNameValue>();

        List<ProductCategories> lstcategory = (new ProductCategories()).GetPCategories();

        foreach (ProductCategories objcategory in lstcategory)
        {
            CascadingDropDownNameValue item = new CascadingDropDownNameValue(objcategory.ProductCategoryName, objcategory.ProductCategoryID.ToString());

            values.Add(item);

        }


        if (kv.Count == 1 && kv.ContainsKey("ProductCategoryID"))
        //if (kv.Count == 1 && category=="StatesId")
        {

            string s = kv["ProductCategoryID"];

            values.Clear();

            List<Products> lstprdts = (new Products()).GetProducts(long.Parse(s));


            foreach (Products objprdts in lstprdts)
            {
                CascadingDropDownNameValue item = new CascadingDropDownNameValue(objprdts.ProductName, objprdts.ProductID.ToString());

                values.Add(item);
            }

        }
        ////else if (kv.Count == 2 && category == "StatesId")
        //else if (kv.Count == 2 && kv.ContainsKey("ProductID"))
        ////else if (kv.Count == 2)
        //{
        //    string s = kv["ProductID"];
        //    values.Clear();
        //    List<SpecificationCategory> banks = (new SpecificationCategory()).GetSCategories(long.Parse(s));

        //    foreach (SpecificationCategory objspctgy in banks)
        //    {
        //        CascadingDropDownNameValue item = new CascadingDropDownNameValue(objspctgy.SpecificationCategoryName, objspctgy.SpecificationCategoryID.ToString());

        //        values.Add(item);

        //    }
        //}

        return values.ToArray();

    }
    [WebMethod]
    public static string gethtml(string contextkey)
    {
        System.Threading.Thread.Sleep(200);
        string value = (contextkey == "U") ?
            DateTime.UtcNow.ToString() : string.Format("{0:" + contextkey + "}", DateTime.Now);
        return string.Format("<span style='font-weight:bold;'>{0}</span>", value);
    }

    [WebMethod]
    public string SaveUserDetails(string fname,string lname,long mobileno,string email)
    {
        string issaved="";
        try
        {
            
            UserAccounts objuseraccounts = new UserAccounts();
            objuseraccounts.Firstname = fname;
            objuseraccounts.LastName = lname;
            objuseraccounts.EmailID = email;
            objuseraccounts.MobileNo = mobileno;
            objuseraccounts.Password = "admin123";
            objuseraccounts.Role = "user";
            long uid = objuseraccounts.IsMobileNoExist(mobileno);
            if (uid != 0)
            {
                objuseraccounts.UpdateUserDetail(uid);
                issaved = "Updated Succesfully";
            }
            else
            {
                objuseraccounts.SaveRecord();
                issaved = "Saved Successfully";
            }
        }
        catch(Exception ex)
        {

            issaved ="Failed@"+ ex.Message;
        }
        return issaved;

    }
    [WebMethod]
    public List<SpecificationCategory> GetSpecificationCategories()
    {
        List<SpecificationCategory> lstprdts = new List<SpecificationCategory>();
        SpecificationCategory objp = new SpecificationCategory();
        lstprdts = objp.GetSpecificationCategory();
        return lstprdts;

    }

    //[WebMethod]
    //public List<Products> GetDataForMappedItems(long pid)
    //{
    //    List<Products> lstprdts = new List<Products>();
    //    Products objprd = new Products();
    //    lstprdts=objprd.GetPCateRecords(pcid, pid);
    //    return lstprdts;
    //}


    [WebMethod]
    public string GetResultfromQry(string Qry)
    {

        return new Utilities().GetResultForQueryfromDB(Qry);

    }

    [WebMethod]
    public string SaveNewUser(string firstname, string lastname, string emailid, string pswrd, string mobileno)
    {
        string result = "";
        try
        {
            if (!new UserAccounts().IsEmailAvailable(emailid))
            {
                UserAccounts uaobj = new UserAccounts();
                uaobj.Firstname = firstname;
                uaobj.LastName = lastname;
                uaobj.EmailID = emailid;
                uaobj.Password = "12345";
                uaobj.Role = "User";
                uaobj.MobileNo = long.Parse(mobileno);
                long i = uaobj.SaveRecord();

                if (i != 0)
                {
                    ReedemPoints objR = new ReedemPoints();
                    objR.UserID = i;
                    objR.OrderType = "Registration";
                    objR.Type = "Credit";
                    objR.Points = 50;
                    objR.SaveRecord();
                }

                result = "Success";
            }
            else
                result = "Already user has been registerd";
        }
        catch (Exception ex)
        {
            result = "";
        }
        return result;
    }
}
