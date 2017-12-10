using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


/// <summary>
/// Summary description for Productpicture
/// </summary>
public class Productpicture
{
    DBAccess db = new DBAccess();
    public long ProductPictureID { get; set; }
    public string PicturePath { get; set; }
    public long ProductID { get; set; }
    public string ProductName { get; set; }
    public string PictureThumbPath { get; set; }
    public string ProductPictures { get; set; }
    public long PictureThumbnailsID { get; set; }
    public long ProductCategoryID { get; set; }

    public float Price{ get; set; }

    public string VideoPath { get; set; }

    public void SaveProductPictures()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into ProductPictures values(@PicturePath,@ProductID)", db.conn);

            cmd.Parameters.AddWithValue("@PicturePath", PicturePath);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void UpdateProductPictures()
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update  ProductPictures set PicturePath=@PicturePath where ProductID=@ProductID", db.conn);
           
            cmd.Parameters.AddWithValue("@PicturePath", PicturePath);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public string DeleteProductPictures(long ppid, long pid)
    {
        string msg = "";
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("  delete  from ProductPictures where productpictureid=@ProductPictureID and ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductPictureID", ppid);
            cmd.Parameters.AddWithValue("@ProductID", pid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
            msg = "Picture removed successfully";
        }
        catch (Exception ex)
        {
            db.CloseConn();
            msg = "Picture cannot be removed";
        }
        return msg;
    }
    public void DeleteProductImages_PPid(long ppid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete  from PicturesThumbnails where  ProductPictureID=@ProductPictureID", db.conn);
           
            cmd.Parameters.AddWithValue("@ProductPictureID", ppid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void DeleteProductImages(long ppid, long ptid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete  from PicturesThumbnails where PictureThumbnailsID=@PictureThumbnailsID and ProductPictureID=@ProductPictureID", db.conn);
            cmd.Parameters.AddWithValue("@PictureThumbnailsID", ptid);
            cmd.Parameters.AddWithValue("@ProductPictureID", ppid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<Productpicture> GetProductPicture(long id)
    {
        List<Productpicture> listproductpictures = new List<Productpicture>();
        Productpicture objproductpictures = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select PicturePath,ProductID from ProductPictures where ProductID=" + id, db.conn);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objproductpictures = new Productpicture();
                //objproductpictures.ProductPictureID = int.Parse(dr["ProductPictureID"].ToString());
                objproductpictures.PicturePath = dr["PicturePath"].ToString();
                // objproductpictures.ProductID
                objproductpictures.ProductID = int.Parse(dr["ProductID"].ToString());
                listproductpictures.Add(objproductpictures);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listproductpictures;
    }
    public List<Productpicture> GetPictures(long id)
    {

        List<Productpicture> listpictures = new List<Productpicture>();
        Productpicture objpictures = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand(@"select PT.PictureThumbnailsID,PT.PictureThumbPath,PT.ProductPictureID,P.ProductID
  from ProductPictures P,PicturesThumbnails PT where P.ProductPictureID= PT.ProductPictureID and ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objpictures = new Productpicture();
                objpictures.PictureThumbPath = dr["PictureThumbPath"].ToString();
                objpictures.ProductPictureID = long.Parse(dr["ProductPictureID"].ToString());
                objpictures.ProductID = long.Parse(dr["ProductID"].ToString());
                objpictures.PictureThumbnailsID = long.Parse(dr["PictureThumbnailsID"].ToString());
                listpictures.Add(objpictures);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listpictures;
    }
    public List<Productpicture> PictureAvailability(long pid )
    {
        List<Productpicture>  lstpic=new List<Productpicture>();
        Productpicture pp;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select P.ProductName,PP.PicturePath,PP.ProductPictureID from Products P, ProductPictures PP where P.ProductID=PP.ProductID AND PP.ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pp = new Productpicture();
                pp.PicturePath = dr["PicturePath"].ToString();
                pp.ProductName = dr["ProductName"].ToString();
                pp.ProductPictureID =long.Parse(dr["ProductPictureID"].ToString());
                lstpic.Add(pp);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return lstpic;

    }
    public List<Productpicture> GetPicture(long id)
    {

        List<Productpicture> listpictures = new List<Productpicture>();
        Productpicture objpictures = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from ProductPictures where  ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objpictures = new Productpicture();

                objpictures.PicturePath = dr["PicturePath"].ToString();
                objpictures.ProductPictureID = long.Parse(dr["ProductPictureID"].ToString());
                objpictures.ProductID = long.Parse(dr["ProductID"].ToString());
                listpictures.Add(objpictures);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listpictures;
    }
    public void DeleteProductPic(long prodid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete  from ProductPictures where ProductID=@ProductID", db.conn);
            
            cmd.Parameters.AddWithValue("@ProductID", prodid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public void DeleteProductpic(long pcid)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("delete from  productpictures  where ProductID=(select ProductID from products where   ProductCategoryID=@ProductCategoryID)", db.conn);
            cmd.Parameters.AddWithValue("@ProductCategoryID", pcid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public long SaveProductPicture()
    {
        long result=0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into ProductPictures(PicturePath,ProductID) values(@PicturePath,@ProductID)SELECT SCOPE_IDENTITY()", db.conn);

            cmd.Parameters.AddWithValue("@PicturePath", PicturePath);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            result = long.Parse(cmd.ExecuteScalar().ToString());

            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return result;
    }

   

    public void SaveProductPictureThumbnails(long ppid)
    {
        
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into PicturesThumbnails values(@PictureThumbPath,@ProductPictureID)", db.conn);

            cmd.Parameters.AddWithValue("@PictureThumbPath", PictureThumbPath);
            cmd.Parameters.AddWithValue("@ProductPictureID", ppid);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
     
    }

    public long GetPictureID(long pid)
    {
        long ppid = 0;
        //List<Productpicture> listpictures = new List<Productpicture>();
        //Productpicture objpictures = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from ProductPictures where  ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
          
                ppid =long.Parse( dr["ProductPictureID"].ToString());
               
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return ppid;
    }
    public void UpdateProductThumbnail(long ppid, string pthpath)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update  PicturesThumbnails set PictureThumbPath=@PictureThumbPath where ProductPictureID=@ProductPictureID", db.conn);

            cmd.Parameters.AddWithValue("@ProductPictureID", ppid);
            cmd.Parameters.AddWithValue("@PictureThumbPath", pthpath);
            
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<Productpicture> GetPictureThumbnails(long ppid)
    {

        List<Productpicture> listpictures = new List<Productpicture>();
        Productpicture objpictures = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from PicturesThumbnails where  ProductPictureID=@ProductPictureID", db.conn);
            cmd.Parameters.AddWithValue("@ProductPictureID", ppid);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objpictures = new Productpicture();

                objpictures.PictureThumbPath = dr["PictureThumbPath"].ToString();
                objpictures.ProductPictureID = long.Parse(dr["ProductPictureID"].ToString());
                //objpictures.ProductPictureID = long.Parse(dr["ProductPictureID"].ToString());
                listpictures.Add(objpictures);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listpictures;
    }
    Utilities objutilities = new Utilities();
    public List<Productpicture> GetPlantPictures(long id)
    {

        List<Productpicture> listpictures = new List<Productpicture>();
        Productpicture objpictures = null;
        try
        {
            db.OpenConn();
            float rate = 0;
            //string sqlquery = "select PicturePath from ProductPictures  where ProductID=@ProductID";

            string sqlquery = "select p.ProductName,p.Price,pp.PicturePath from ProductPictures pp inner join Products p on pp.ProductID=p.ProductID where pp.ProductID=@ProductID";

            SqlCommand cmd = new SqlCommand(sqlquery, db.conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            SqlDataReader dr = cmd.ExecuteReader();

            string countrycode = "";
            string value = "";
            string symbol = "";

            //if (HttpContext.Current.Session["Country"] != null)
            //{
            //    countrycode = HttpContext.Current.Session["Country"].ToString();
            //}

            //if (countrycode != "" && countrycode != "INR")
            //{
            //    value = objutilities.GetCurrencyRate("1", "INR", countrycode);
            //    symbol = objutilities.GetCurrencySymbol(countrycode);
            //}
            //else
            //{
            //    symbol = objutilities.GetCurrencySymbol("INR");
            //}


            while (dr.Read())
            {
                objpictures = new Productpicture();
                objpictures.PicturePath = dr["PicturePath"].ToString();
                objpictures.ProductName = dr["ProductName"].ToString();

                double price = 0;
                if (countrycode != "" && countrycode != "INR")
                {
                    price = double.Parse(value) * double.Parse(dr["Price"].ToString());
                }
                else
                {
                    price = double.Parse(dr["Price"].ToString());
                }

                //int myInt = (int)Math.Ceiling(double.Parse(price.ToString()));

                //objpictures.CountryPrice = symbol + " " + myInt.ToString("0.00"); 

                rate =  float.Parse(dr["Price"].ToString()) ;
                objpictures.Price = rate;
                string ppath=objpictures.PicturePath ;
                if(ppath == "")
                {
                    objpictures.PicturePath = "~/Images/noimage_icon.jpg";                    
                }               
                //objpictures.PictureThumbPath = dr["PictureThumbPath"].ToString();
                //string pthumbpath=objpictures.PictureThumbPath;
                //if (pthumbpath == "")
                //{
                //    objpictures.PictureThumbPath = "~/Images/noimage_icon.jpg";
                //}
                
                listpictures.Add(objpictures);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listpictures;
    }
    public List<Productpicture> GetPlantThumbPictures( long id)
    {

        List<Productpicture> listpictures = new List<Productpicture>();
        Productpicture objpictures = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select top 4 PT.PictureThumbPath from PicturesThumbnails PT inner join ProductPictures PP on PT.ProductPictureID=PP.ProductPictureID where ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objpictures = new Productpicture();

               // objpictures.PicturePath = dr["PicturePath"].ToString();
                //string ppath = objpictures.PicturePath;
                //if (ppath == "")
                //{
                //    objpictures.PicturePath = "~/Images/noimage_icon.jpg";
                //}
               objpictures.PictureThumbPath = dr["PictureThumbPath"].ToString();
                //string pthumbpath=objpictures.PictureThumbPath;
                //if (pthumbpath == "")
                //{
                //    objpictures.PictureThumbPath = "~/Images/noimage_icon.jpg";
                //}

                listpictures.Add(objpictures);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listpictures;
    }
    public long GetPPictures(long id)
    {
        long ppid = 0;
        List<Productpicture> listpictures = new List<Productpicture>();
        Productpicture objpictures = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from ProductPictures where  ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objpictures = new Productpicture();

               // objpictures.PicturePath = dr["PicturePath"].ToString();
                objpictures.ProductPictureID = long.Parse(dr["ProductPictureID"].ToString());
                ppid = long.Parse(dr["ProductPictureID"].ToString());
               // objpictures.ProductID = long.Parse(dr["ProductID"].ToString());
                listpictures.Add(objpictures);

            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return ppid;
    }
    public void SaveProductVideoPath(long prodid ,string videopath)
    {
        long result = 0;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("insert into ProductPictures(PicturePath,ProductID) values(@PicturePath,@ProductID)", db.conn);
            cmd.Parameters.AddWithValue("@VideoPath", videopath);
            cmd.Parameters.AddWithValue("@ProductID", prodid);
           // result = long.Parse(cmd.ExecuteScalar().ToString());
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    
    }
    public void UpdateProductVideoPath(long pid, string videopath)
    {
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("update  ProductPictures set VideoPath=@VideoPath where ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", pid);
            cmd.Parameters.AddWithValue("@VideoPath", videopath);
            cmd.ExecuteNonQuery();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
    }
    public List<Productpicture> GetProductVideoPath(string id)
    {

        List<Productpicture> listpictures = new List<Productpicture>();
        Productpicture objpictures = null;
        try
        {
            db.OpenConn();
            SqlCommand cmd = new SqlCommand("select * from ProductPictures where  ProductID=@ProductID", db.conn);
            cmd.Parameters.AddWithValue("@ProductID", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                objpictures = new Productpicture();

                objpictures.PicturePath = dr["PicturePath"].ToString();
                objpictures.ProductPictureID = long.Parse(dr["ProductPictureID"].ToString());
                objpictures.ProductID = long.Parse(dr["ProductID"].ToString());
                objpictures.VideoPath = dr["VideoPath"].ToString();
                listpictures.Add(objpictures);
            }
            dr.Close();
            db.CloseConn();
        }
        catch (Exception ex)
        {
            db.CloseConn();
            throw ex;
        }
        return listpictures;
    }

    public string CountryPrice { get; set; }
}