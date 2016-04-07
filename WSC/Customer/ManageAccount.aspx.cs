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
                if (Session["SecurityLevel"] == "C" || Session["SecurityLevel"] == "M" || Session["SecurityLevel"] == "S")
                {

                    Customer objCus = new Customer();
                    objCus = objBAL.GetCustomerByFilter(Customer.SearchFilter.UserId, Convert.ToInt32(Session["UserID"]).ToString());

                    txtUserName.Text = Convert.ToString(Session["UserName"]);
                    txtFirstName.Text = objCus.FirstName;
                    txtLastName.Text = objCus.LastName;
                    txtAddress.Text = objCus.Address;
                    txtAddressTwo.Text = objCus.Address2;
                    txtCity.Text = objCus.City;
                    txtState.Text = objCus.State;
                    txtZipCode.Text = objCus.ZipCode;
                    txtPhone.Text = objCus.PhoneNo;
                    txtEmail.Text = Session["UserEmail"].ToString();


                    custid = objCus.CustomerId;
                }
                else
                {
                    Response.Redirect("~/NoAccess.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Submit button process, this will update the customer information in the database.

            Customer objCus = new Customer();

            UserAccount cUser = null;

            cUser = objBAL.GetUserAccount(Session["UserName"].ToString(), txtPassword.Text);

            cUser.Email = txtEmail.Text;

            objBAL.UpdateUser(cUser);

            //Update Customer Record 
            objCus = new Customer(Convert.ToInt32(Session["CustomerId"]), Convert.ToInt32(Session["UserId"]), txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddressTwo.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtPhone.Text);
            objCus = objBAL.UpdateCustomer(objCus);

            lblComplete.Visible = true;



        }

        protected void UpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                UserAccount objUA = null;

                //Check existing
                objUA = objBAL.GetUserAccount(Session["UserName"].ToString(), txtOldPassword.Text);

                if (objUA != null)
                {
                    objUA = objBAL.UpdateUser(new UserAccount(Convert.ToInt32(Session["UserId"]), Session["UserName"].ToString(), txtNewPassword.Text, UserAccount.UserRole.Customer, txtEmail.Text));
                }

                lblUpdateComplete.Visible = true;
                btnUpdatePassword.Visible = false;
            }
            catch (Exception)
            {
                lblWrongPassword.Visible = true;
            }

        }
    }
}
