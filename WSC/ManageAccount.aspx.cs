using System;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       4/05/2016
    Purpose:    Customer Manage Account Process
    Details:    This program is used to Populate Customer Manage Account Form and Updated Customer personal information in the Database.
 */

namespace WSC
{
    public partial class ManageAccount : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();
        int custid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // If user is logged in as a customer will fill in the manage account form with customer information
                if (Session["SecurityLevel"] == "C")
                {

                    Customer objCus = new Customer();
                    objCus = objBAL.GetCustomerByFilter(Customer.SearchFilter.UserId, Convert.ToInt32(Session["UserID"]).ToString());

                    txtCustomerId.Text = Convert.ToString(objCus.CustomerId);
                    txtUserName.Text = Convert.ToString(Session["UserName"]);
                    txtFirstName.Text = objCus.FirstName;
                    txtLastName.Text = objCus.LastName;
                    txtAddress.Text = objCus.Address;
                    txtAddressTwo.Text = objCus.Address2;
                    txtCity.Text = objCus.City;
                    txtState.Text = objCus.State;
                    txtZipCode.Text = objCus.ZipCode;
                    txtPhone.Text = objCus.PhoneNo;

                    custid = objCus.CustomerId;
                }
                else
                {
                    Response.Redirect("NoAccess.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Submit button process, this will update the customer information in the database.
            try
            {
                Customer objCus = new Customer();

                //Update Customer Record 
                objCus = new Customer(Convert.ToInt32(txtCustomerId.Text), Convert.ToInt32(Session["UserId"]), txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddressTwo.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtPhone.Text);
                objCus = objBAL.UpdateCustomer(objCus);

                lblComplete.Visible = true;
            }
            catch (Exception)
            {

                lblError.Visible = true;
            }
            
        }
    }
}
