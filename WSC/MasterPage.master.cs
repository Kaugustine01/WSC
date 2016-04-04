using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Home_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void Catalog_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Catalog.aspx");
    }

    protected void ViewCart_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/ViewCart.aspx");
    }

    protected void ManageAccount_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/ManageAccount.aspx");
    }

    protected void ViewOrders_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/CustViewOrders.aspx");
    }

    protected void AdmViewOrders_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ViewOrders.aspx");
    }

    protected void AddEmployees_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddEmployees.aspx");
    }

    protected void ManageEmployees_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ManageEmployees.aspx");
    }
}
