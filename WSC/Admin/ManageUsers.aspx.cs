using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

namespace WSC.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityLevel"] == "M")
            {
                if(!IsPostBack)
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

            List < Customer > lstCust= null;

            lstCust = objBAL.GetCustomerListByFilter(Customer.SearchFilter.LastName, txtSearchLastName.Text);

            ManageUsersGridView.DataSource = lstCust;
            ManageUsersGridView.DataBind();
            
        }

        protected void ManageUsersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Customer updateCust = new Customer();

            GridViewRow row = ManageUsersGridView.Rows[e.RowIndex];

            string txtID = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string txtUsID = ((TextBox)row.FindControl("UserID")).Text;
            string txtFirstName = ((TextBox)row.FindControl("FirstName")).Text;
            string txtLastName = ((TextBox)row.FindControl("LastName")).Text;
            string txtAddress = ((TextBox)row.FindControl("Address")).Text;
            string txtAddress2 = ((TextBox)row.FindControl("Address2")).Text;
            string txtCity = ((TextBox)row.FindControl("City")).Text;
            string txtState = ((TextBox)row.FindControl("State")).Text;
            string txtZipCode = ((TextBox)row.FindControl("ZipCode")).Text;
            string txtPhoneNo = ((TextBox)row.FindControl("PhoneNo")).Text;


            updateCust.CustomerId = int.Parse(txtID);
            updateCust.UserId = int.Parse(txtID);
            updateCust.FirstName = txtFirstName;
            updateCust.LastName = txtLastName;
            updateCust.Address = txtAddress;
            updateCust.Address2 = txtAddress2;
            updateCust.City = txtCity;
            updateCust.State = txtState;
            updateCust.ZipCode = txtZipCode;
            updateCust.PhoneNo = txtPhoneNo;

            objBAL.UpdateCustomer(updateCust);

            ManageUsersGridView.EditIndex = -1;

            ManageUsersGridView.DataSource = updateCust;
            ManageUsersGridView.DataBind();

        }

        protected void ManageUsersGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ManageUsersGridView.EditIndex = e.NewEditIndex;
            DataBind();
        }
    }
}