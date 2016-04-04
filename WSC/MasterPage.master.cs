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
        // Navigation View - Security Levels
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
        else if(Session["SecurityLevel"] == "")
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
