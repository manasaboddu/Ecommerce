using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DatalistTestPage : System.Web.UI.Page
{
    ProductCategories objpccat = new ProductCategories();
    Products objproducts = new Products();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            //DataList1.DataSource = objproducts.GetAllRecords(); 
            //DataList1.DataBind();
        }
    }

    protected void Save(object sender, EventArgs e)
    {
        string name = string.Empty;
        string email = string.Empty;
        // This will Update and insert one by one in Sql. You can Insert or Update as per your requirement
        foreach (DataListItem item in this.DataList1.Items)
        {
            name = (item.FindControl("txtName") as TextBox).Text;
            email = (item.FindControl("txtEmail") as TextBox).Text;
           
        }
    }
}