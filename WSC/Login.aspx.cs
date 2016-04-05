using System;
using System.Web.UI.WebControls;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       04/05/2016
    Purpose:    User Login Process
    Details:    This program authenticate a user on login.
 */

namespace WSC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        
        }

        private bool SiteSpecificationAuthenticationMethod(string UserName, string Password)
        {
            // creates user account and business layer ojects
            UserAccount objUA = null;
            BusinessLayer objBAL = new BusinessLayer();

            // verifies that the user exists
            objUA = objBAL.GetUserAccount(UserName, Password);

            // if user exists, fills in the needed session variables
            if (objUA != null) {

                Session["UserID"] = objUA.UserId;
                Session["UserName"] = objUA.UserName;

                Customer objCus = new Customer();
                objCus = objBAL.GetCustomerByFilter(Customer.SearchFilter.UserId, Convert.ToInt32(Session["UserID"]).ToString());

                Session["CustomerID"] = objCus.CustomerId;

                if (objUA.UserType == UserAccount.UserRole.Customer)
                {
                    Session["SecurityLevel"] = "C";
                }
                else if (objUA.UserType == UserAccount.UserRole.Sales)
                {
                    Session["SecurityLevel"] = "S";
                }
                else if (objUA.UserType == UserAccount.UserRole.OperationManager)
                {
                    Session["SecurityLevel"] = "M";
                }

                // returns true of userid is greater than 0
                if (objUA.UserId > 0)
                    return true;
            }

            // returns false if authentication failed
            return false;
        }

        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            // authenticates the user.
            bool Authenticated = false;
            Authenticated = SiteSpecificationAuthenticationMethod(Login1.UserName, Login1.Password);

            e.Authenticated = Authenticated;
        }
    }
}