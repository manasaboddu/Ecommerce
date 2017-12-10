using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

//using System.Drawing;

public partial class ProductPictures : System.Web.UI.Page
{
    Productpicture objpp = new Productpicture();
    string uploadpath ="";
    string uploadpath2 = "";
    string uploadpath3 = "";
    string uploadpath4 = "";
    string uploadpath5 = "";
    string uploadpath6 = "";
    public string filepath;
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterPostBackControl(this.btnsave);
        if (!IsPostBack)
        {
            //if (Session["Role"] != null)
            //{
            //    if (Session["Role"].ToString() == "Adminstrator")
            //    {
            //        Response.Redirect("ProductPictures.aspx");
            //    }

            //}
            //else
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}
            BindData();

            if (Session["id"] != null)
            {
                long pid = long.Parse(Session["id"].ToString());
                CheckPictureAvailability(pid);
            }
        }

    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        Productpicture objpp = new Productpicture();
        string newpath = "";
        if (Session["id"] != null && Session["id"].ToString() != "")
        {
            long ID = long.Parse(Session["id"].ToString());
            //String imgpath = File1.FileName;
            //string FullImage = File1.FileName;

          


            lblmsg.Text = "";
            if (Session["up1"] != null && Session["up1"].ToString() != "")
            {

                if (Session["up1"] != null && Session["up1"].ToString() != "")
                {
                    uploadpath = Session["up1"].ToString();
                    if (btnsave.Text == "Save")
                    {

                        //string filename = Path.GetFileName(AjaxFileUpload1.PostedFile.FileName);
                        //AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        long poid = objpp.ProductID;                        
                        objpp.PicturePath = uploadpath;
                        objpp.PictureThumbPath = uploadpath;
                        List<Productpicture> lstppictur = objpp.GetPicture(poid);
                        long ppictureid = 0;
                        if (lstppictur.Count >= 1)
                        {
                            ppictureid = objpp.GetPPictures(poid);
                        }
                        else
                        {
                            ppictureid = objpp.SaveProductPicture();
                        }
                        objpp.SaveProductPictureThumbnails(ppictureid);
                     

                    }
                    else
                    {
                        // AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        objpp.PicturePath = uploadpath;
                        objpp.PictureThumbPath = uploadpath;
                        string path = uploadpath;
                        objpp.UpdateProductPictures();
                        long ppid = objpp.GetPictureID(objpp.ProductID);
                        List<Productpicture> lstpic = objpp.GetPictureThumbnails(ppid);
                        if (lstpic.Count > 0)
                        {
                            objpp.UpdateProductThumbnail(ppid, path);
                        }
                        else
                        {
                            objpp.SaveProductPictureThumbnails(ppid);
                        }
                   
                    }
                }
                if (Session["up2"] != null && Session["up2"].ToString() != "")
                {
                    uploadpath2 = Session["up2"].ToString();
                    if (btnsave.Text == "Save")
                    {

                        //string filename = Path.GetFileName(AjaxFileUpload1.PostedFile.FileName);
                        //AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        long poid = objpp.ProductID;

                        objpp.PicturePath = uploadpath2;
                        objpp.PictureThumbPath = uploadpath2;
                        List<Productpicture> lstppictur = objpp.GetPicture(poid);
                        long ppictureid = 0;
                        if (lstppictur.Count >= 1)
                        {
                            ppictureid = objpp.GetPPictures(poid);
                        }
                        else
                        {
                            ppictureid = objpp.SaveProductPicture();
                        }
                        objpp.SaveProductPictureThumbnails(ppictureid);
                       

                    }
                    else
                    {
                        // AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        objpp.PicturePath = uploadpath2;
                        objpp.PictureThumbPath = uploadpath2;
                        string path = uploadpath2;
                        objpp.UpdateProductPictures();
                        long ppid = objpp.GetPictureID(objpp.ProductID);
                        List<Productpicture> lstpic = objpp.GetPictureThumbnails(ppid);
                        if (lstpic.Count > 0)
                        {
                            objpp.UpdateProductThumbnail(ppid, path);
                        }
                        else
                        {
                            objpp.SaveProductPictureThumbnails(ppid);
                        }
                   
                    }
                }
                if (Session["up3"] != null && Session["up3"].ToString() != "")
                {
                    uploadpath3 = Session["up3"].ToString();
                    if (btnsave.Text == "Save")
                    {

                        //string filename = Path.GetFileName(AjaxFileUpload1.PostedFile.FileName);
                        //AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        long poid = objpp.ProductID;
                        objpp.PicturePath = uploadpath3;
                        objpp.PictureThumbPath = uploadpath3;
                        List<Productpicture> lstppictur = objpp.GetPicture(poid);
                        long ppictureid = 0;
                        if (lstppictur.Count >= 1)
                        {
                            ppictureid = objpp.GetPPictures(poid);
                        }
                        else
                        {
                            ppictureid = objpp.SaveProductPicture();
                        }
                        objpp.SaveProductPictureThumbnails(ppictureid);
                      
                    }
                    else
                    {
                        // AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        objpp.PicturePath = uploadpath3;
                        objpp.PictureThumbPath = uploadpath3;
                        string path = uploadpath3;
                        objpp.UpdateProductPictures();
                        long ppid = objpp.GetPictureID(objpp.ProductID);
                        List<Productpicture> lstpic = objpp.GetPictureThumbnails(ppid);
                        if (lstpic.Count > 0)
                        {
                            objpp.UpdateProductThumbnail(ppid, path);
                        }
                        else
                        {
                            objpp.SaveProductPictureThumbnails(ppid);
                        }
                    
                    }
                }
                if (Session["up4"] != null && Session["up4"].ToString() != "")
                {
                    uploadpath4 = Session["up4"].ToString();
                    if (btnsave.Text == "Save")
                    {

                        //string filename = Path.GetFileName(AjaxFileUpload1.PostedFile.FileName);
                        //AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        long poid = objpp.ProductID;
                        objpp.PicturePath = uploadpath4;
                        objpp.PictureThumbPath = uploadpath4;
                        List<Productpicture> lstppictur = objpp.GetPicture(poid);
                        long ppictureid = 0;
                        if (lstppictur.Count >= 1)
                        {
                            ppictureid = objpp.GetPPictures(poid);
                        }
                        else
                        {
                            ppictureid = objpp.SaveProductPicture();
                        }
                        objpp.SaveProductPictureThumbnails(ppictureid);
                       
                    }
                    else
                    {
                        // AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        objpp.PicturePath = uploadpath4;
                        objpp.PictureThumbPath = uploadpath4;
                        string path = uploadpath4;
                        objpp.UpdateProductPictures();
                        long ppid = objpp.GetPictureID(objpp.ProductID);
                        List<Productpicture> lstpic = objpp.GetPictureThumbnails(ppid);
                        if (lstpic.Count > 0)
                        {
                            objpp.UpdateProductThumbnail(ppid, path);
                        }
                        else
                        {
                            objpp.SaveProductPictureThumbnails(ppid);
                        }
                  
                    }
                }
                if (Session["up5"] != null && Session["up5"].ToString() != "")
                {
                    uploadpath5 = Session["up5"].ToString();
                    if (btnsave.Text == "Save")
                    {

                        //string filename = Path.GetFileName(AjaxFileUpload1.PostedFile.FileName);
                        //AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        long poid = objpp.ProductID;
                        objpp.PicturePath = uploadpath5;
                        objpp.PictureThumbPath = uploadpath5;
                        List<Productpicture> lstppictur = objpp.GetPicture(poid);
                        long ppictureid = 0;
                        if (lstppictur.Count >= 1)
                        {
                            ppictureid = objpp.GetPPictures(poid);
                        }
                        else
                        {
                            ppictureid = objpp.SaveProductPicture();
                        }
                        objpp.SaveProductPictureThumbnails(ppictureid);                      

                    }
                    else
                    {
                        // AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        objpp.PicturePath = uploadpath5;
                        objpp.PictureThumbPath = uploadpath5;
                        string path = uploadpath5;
                        objpp.UpdateProductPictures();
                        long ppid = objpp.GetPictureID(objpp.ProductID);
                        List<Productpicture> lstpic = objpp.GetPictureThumbnails(ppid);
                        if (lstpic.Count > 0)
                        {
                            objpp.UpdateProductThumbnail(ppid, path);
                        }
                        else
                        {
                            objpp.SaveProductPictureThumbnails(ppid);
                        }
                    
                    }
                }
                if (Session["up6"] != null && Session["up6"].ToString() != "")
                {
                    uploadpath6 = Session["up6"].ToString();
                    if (btnsave.Text == "Save")
                    {

                        //string filename = Path.GetFileName(AjaxFileUpload1.PostedFile.FileName);
                        //AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        long poid = objpp.ProductID;
                        objpp.PicturePath = uploadpath6;
                        objpp.PictureThumbPath = uploadpath6;
                        List<Productpicture> lstppictur = objpp.GetPicture(poid);
                        long ppictureid = 0;
                        if (lstppictur.Count >= 1)
                        {
                            ppictureid = objpp.GetPPictures(poid);
                        }
                        else
                        {
                            ppictureid = objpp.SaveProductPicture();
                        }
                        objpp.SaveProductPictureThumbnails(ppictureid);

                    }
                    else
                    {
                        // AjaxFileUpload1.SaveAs(Server.MapPath(Session["path"].ToString()));
                        objpp.ProductID = long.Parse(Session["id"].ToString());
                        objpp.PicturePath = uploadpath6;
                        objpp.PictureThumbPath = uploadpath6;
                        string path = uploadpath6;
                        objpp.UpdateProductPictures();
                        long ppid = objpp.GetPictureID(objpp.ProductID);
                        List<Productpicture> lstpic = objpp.GetPictureThumbnails(ppid);
                        if (lstpic.Count > 0)
                        {
                            objpp.UpdateProductThumbnail(ppid, path);
                        }
                        else
                        {
                            objpp.SaveProductPictureThumbnails(ppid);
                        }

                    }
                }
                uploadpath = "";
                uploadpath2 = "";
                uploadpath3 = "";
                uploadpath4 = "";                
                uploadpath5 = "";
                uploadpath6 = "";
                Session["up1"] = null;
                Session["up2"] = null;
                Session["up3"] = null;
                Session["up4"] = null;
                Session["up5"] = null;
                Session["up6"] = null;
                BindData();
                Response.Redirect("Product.aspx");
            }
            else
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Please select image before you save";
            }
        }
        else
        {
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Text = "Please select image before you savedasdsa";
        }
    }

    public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxImageHeight)
    {
        var ratio = (double)maxImageHeight / image.Height;
        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);
        var newImage = new Bitmap(newWidth, newHeight);
        using (var g = Graphics.FromImage(newImage))
        {
            g.DrawImage(image, 0, 0, newWidth, newHeight);
        }
        return newImage;
    }

    public void CheckPictureAvailability(long pid)
    {
        btnsave.Text = "Save";
        //objpp.ProductID = pid;
        //List<Productpicture> lstdata = objpp.PictureAvailability(pid);
        //if (lstdata.Count > 0)
        //{
        //    btnsave.Text = "Update";
        //}
        //else
        //{
        //    btnsave.Text = "Save";
        //}
    }
    public void BindData()
    {
        if (Session["id"] != null)
        {
            long id = long.Parse(Session["id"].ToString());
            DatalistPimage.DataSource = objpp.GetPicture(id);
            DatalistPimage.DataBind();
            DatalistThumb.DataSource = objpp.GetPictures(id);
            DatalistThumb.DataBind();
        }
    }
  
    protected void AjaxFileUpload1_UploadComplete(object sender, AjaxFileUploadEventArgs e)
    {
        if (Session["id"] != null && Session["id"].ToString() != "")
        {

            long ID = long.Parse(Session["id"].ToString());
            Productpicture objpp = new Productpicture();
            string filename = Session["id"].ToString() + "_" + System.IO.Path.GetFileName(e.FileName);
            //System.Drawing.Image image = System.Drawing.Image.FromStream(filename, true, true);
            // yourImage = resizeImage(yourImage, new Size(50, 50));
            string strUploadPath = "~/Images/";
            string filepath = strUploadPath + filename;
            AjaxFileUpload1.SaveAs(Server.MapPath(strUploadPath + filename));
            objpp.PicturePath = filepath;
            objpp.ProductID = ID;


            if (Session["up1"] == null )
            {
                Session["up1"] = filepath;
            }
            else if (Session["up1"] == "")
            {
                Session["up1"] = filepath;
            }
            else if (Session["up2"] == null )
            {
                Session["up2"] = filepath;
            }
            else if (Session["up2"] == "")
            {
                Session["up2"] = filepath;
            }
            else if (Session["up3"] == null )
            {
                Session["up3"] = filepath;
            }
            else if (Session["up3"] == "")
            {
                Session["up3"] = filepath;
            }
            else if (Session["up4"] == null )
            {
                Session["up4"] = filepath;
            }
            else if (Session["up4"] == "")
            {
                Session["up4"] = filepath;
            }
            else if (Session["up5"] == null )
            {
                Session["up5"] = filepath;
            }
            else if (Session["up5"] == "")
            {
                Session["up5"] = filepath;
            }
            else if (Session["up6"] == null)
            {
                Session["up6"] = filepath;
            }
            else if (Session["up6"] == "")
            {
                Session["up6"] = filepath;
            }
        }
      
    }
    public static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
    {
        return (System.Drawing.Image)(new Bitmap(imgToResize, size));
    }
    protected void DatalistPimage_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Removes")
        {
            Productpicture objpp = new Productpicture();
            long ppid = long.Parse(e.CommandArgument.ToString());
            HiddenField obj = (HiddenField)e.Item.FindControl("hdnproductid");
            long prodtid = long.Parse(obj.Value);
            objpp.DeleteProductImages_PPid(prodtid);
            objpp.DeleteProductPictures(ppid, prodtid);
            objpp.DeleteProductImages_PPid(prodtid);
            BindData();

        }
    }
    protected void DatalistThumb_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            Productpicture objpp = new Productpicture();
            long ptid = long.Parse(e.CommandArgument.ToString());
            HiddenField obj = (HiddenField)e.Item.FindControl("hdnproductid");
            long ppid = long.Parse(obj.Value);

            objpp.DeleteProductImages(ppid, ptid);
            BindData();

        }

    }
    protected void btnSaveVideopath_Click(object sender, EventArgs e)
    {
        objpp.ProductID = long.Parse(Session["id"].ToString());
        long poid = long.Parse(Session["id"].ToString());
        string videopath = txtvideolinkpath.Text;
        List<Productpicture> lstppictur = objpp.GetPicture(poid);
        long ppictureid = 0;
        if (lstppictur.Count >= 1)
        {

            objpp.UpdateProductVideoPath(poid, videopath);
            lblmsge.Text = " Video Link Path Updated Successfully";
        }
        else
        {
            objpp.SaveProductVideoPath(poid, videopath);
            lblmsge.Text = " Video Link Path Saved Successfully";
        }
    }
  
}