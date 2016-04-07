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

            lblPassword.Visible = true;
            txtPassword.Visible = true;
        }

        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            UserAccount cAdmin = new UserAccount();
            UserAccount uUsers = new UserAccount();

            // uUsers.
            // cAdmin = objBAL.GetUserAccount(Session["UserName"].ToString(), txtPassword.Text);


            // objBAL.UpdateUser()
        }

        protected void OnSelectedIndexChange(object sender, EventArgs e)
        {
            // create user id variable
            int userId = Convert.ToInt32(ManageUsersGridView.SelectedRow.Cells[1].Text);

            UserAccount uAdmin = objBAL.GetUserAccount(Session["UserName"].ToString(), txtPassword.Text);

            UserAccount cUser = objBAL.GetUserAccount(uAdmin, userId);

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
        }
    }
}