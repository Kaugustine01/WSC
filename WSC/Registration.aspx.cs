using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class Registration : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Customer objCustomer = null;

            try
            {

                UserAccount objUA = new UserAccount(0, txtUserName.Text, txtPassword.Text, UserAccount.UserRole.Customer);
                objUA = objBAL.InsertUser(objUA);

                //Insert New Customer, will check if already exists
                //If already exists will throw exception
                objCustomer = new Customer(0, objUA.UserId, txtFirstName.Text, txtLastName.Text, txtAddress.Text, "", txtCity.Text, txtState.Text, txtZipCode.Text, txtPhone.Text);
                objCustomer = objBAL.InsertCustomer(objCustomer);

                Response.Redirect("RegistrationComplete.asxp");

            }
            catch (Exception)
            {
                Response.Redirect("RegistrationFailed.asxp");
            }

        }
    }
}