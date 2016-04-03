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

    protected void btnHome_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void btnCatalog_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Catalog.aspx");
    }

    protected void btnViewCart_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Catalog.aspx");
    }

    protected void btnManageAccount_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/ManageAccount.aspx");
    }

    protected void btnViewOrders_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/CustViewOrders.aspx");
    }

    protected void btnAdmViewOrders_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ViewOrders.aspx");
    }

    protected void btnAddEmployees_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddEmployees.aspx");
    }

    protected void btnManageEmployees_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ManageEmployees.aspx");
    }
}
