using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       04/05/2016
    Purpose:    Manage User Process
    Details:    This program is used to edit User Type.
 */


namespace WSC.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        // create business layer object to use methods
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityLevel"] == "M")
            {
                // binds the gridview
                if (!IsPostBack)
                {
                    ManageUsersGridView.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/NoAccess.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // creates customer list
            List<Customer> lstCust = null;

            // addes customer to the list
            lstCust = objBAL.GetCustomerListByFilter(Customer.SearchFilter.LastName, txtSearchLastName.Text);

            // binds the customer list to grid.
            ManageUsersGridView.DataSource = lstCust;
            ManageUsersGridView.DataBind();

            // set password field to true visibility
            lblPassword.Visible = true;
            txtPassword.Visible = true;

            // set everything to false visibility
            lblUserName.Visible = false;
            lblUserType.Visible = false;
            txtUserName.Visible = false;
            ddlUserType.Visible = false;
            btnUpdateUser.Visible = false;
            lblEmail.Visible = false;
            txtEmail.Visible = false;
            btnUpdateUser.Visible = false;
            txtPassword2.Visible = false;
            lblPassword2.Visible = false;
        }

        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            UserAccount cAdmin = new UserAccount();
            UserAccount uUsers = new UserAccount();

            uUsers.UserId = Convert.ToInt32(Session["SelectedUser"]);
            uUsers.UserName = txtUserName.Text;
            uUsers.Email = txtEmail.Text;

            if (ddlUserType.Text == "Customer" )
            {
                uUsers.UserType = UserAccount.UserRole.Customer;
            }
            else if (ddlUserType.Text == "Sales" )
            {
                uUsers.UserType = UserAccount.UserRole.Sales;
            }
            else if (ddlUserType.Text == "Operations Manager" )
            {
                uUsers.UserType = UserAccount.UserRole.OperationManager;
            }

            cAdmin = objBAL.GetUserAccount(Session["UserName"].ToString(), txtPassword2.Text);

            objBAL.UpdateUser(cAdmin, uUsers);
        }

        protected void OnSelectedIndexChange(object sender, EventArgs e)
        {
            // create user id variable
            Session["SelectedUser"] = ManageUsersGridView.SelectedRow.Cells[1].Text;

            UserAccount uAdmin = objBAL.GetUserAccount(Session["UserName"].ToString(), txtPassword.Text);

            UserAccount cUser = objBAL.GetUserAccount(uAdmin, Convert.ToInt32(Session["SelectedUser"]));

            
            txtUserName.Text = cUser.UserName;
            txtEmail.Text = cUser.Email;

            if (cUser.UserType == UserAccount.UserRole.Customer)
            {
                ddlUserType.Text = "Customer";
            }
            else if (cUser.UserType == UserAccount.UserRole.Sales)
            {
                ddlUserType.Text = "Sales";
            }
            else if (cUser.UserType == UserAccount.UserRole.OperationManager)
            {
                ddlUserType.Text = "Operations Manager";
            }

            // makes edit fields visable
            lblUserName.Visible = true;
            lblUserType.Visible = true;
            txtUserName.Visible = true;
            ddlUserType.Visible = true;
            btnUpdateUser.Visible = true;
            lblEmail.Visible = true;
            txtEmail.Visible = true;
            btnUpdateUser.Visible = true;
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            txtPassword.Text = "";
            txtPassword2.Visible = true;
            lblPassword2.Visible = true;
        }
    }
}