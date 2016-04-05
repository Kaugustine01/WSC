using System;

/*
    Programmer: Daniel Bays
    Date:       04/05/2016
    Purpose:    Master Page Process
    Details:    This program is used to Populate and the Customers Detailed view of an order.
 */

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Navigation View - Security Level for Customer
        if (Session["SecurityLevel"] == "C")
        {
            btnCustViewOrders.Visible = true;
            btnManageAccount.Visible = true;
            btnViewCart.Visible = true;
            hplWelcome.Text = "Welcome " + Session["UserName"].ToString();
            hplWelcome.Visible = true;
            hplRegister.Visible = false;
            hplLogin.Visible = false;
            hplLogout.Visible = true;
        }

        // Navigation View - Security Level for Admin
        else if (Session["SecurityLevel"] == "M")
        {
            btnCustViewOrders.Visible = false;
            btnManageAccount.Visible = false;
            btnViewCart.Visible = false;
            lblAdmin.Visible = true;
            btnAddEmployees.Visible = true;
            btnAdmViewOrders.Visible = true;
            btnManageEmployees.Visible = true;
            hplWelcome.Text = "Welcome " + Session["UserName"].ToString();
            hplWelcome.Visible = true;
            hplRegister.Visible = false;
            hplLogin.Visible = false;
            hplLogout.Visible = true;
        }

        // Navigation View - Security Level for Sales
        else if (Session["SecurityLevel"] == "S")
        {
            btnCustViewOrders.Visible = false;
            btnManageAccount.Visible = false;
            btnViewCart.Visible = false;
            lblAdmin.Visible = true;
            btnAdmViewOrders.Visible = true;
            hplWelcome.Text = "Welcome " + Session["UserName"].ToString();
            hplWelcome.Visible = true;
            hplRegister.Visible = false;
            hplLogin.Visible = false;
            hplLogout.Visible = true;
        }

        // Navigation View - Security Level for Non Users
        else
        {
            btnCustViewOrders.Visible = false;
            btnManageAccount.Visible = false;
            btnViewCart.Visible = false;
            lblAdmin.Visible = false;
            btnAddEmployees.Visible = false;
            btnAdmViewOrders.Visible = false;
            btnManageEmployees.Visible = false;
            hplWelcome.Visible = false;
            hplRegister.Visible = true;
            hplLogin.Visible = true;
            hplLogout.Visible = false;
        }
    }

    // Home page Redirect
    protected void Home_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    // Catalog page Redirect
    protected void Catalog_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Catalog.aspx");
    }

    // ViewCart page Redirect
    protected void ViewCart_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Customer/ViewCart.aspx");
    }

    // Manage Account page Redirect
    protected void ManageAccount_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Customer/ManageAccount.aspx");
    }

    // View Orders page Redirect
    protected void ViewOrders_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Customer/ViewOrders.aspx");
    }

    // Admin View Orders page Redirect
    protected void AdmViewOrders_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ViewOrders.aspx");
    }

    // Add Employees page Redirect
    protected void AddEmployees_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AddEmployees.aspx");
    }

    // Manage Employees page Redirect
    protected void ManageEmployees_Click(Object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ManageEmployees.aspx");
    }

    protected void Logout_Click(Object sender, EventArgs e)
    {
        //Destroy all session vars
        Session.Abandon();

        //redirect to default
        Response.Redirect("~/default.aspx");
    }
}
