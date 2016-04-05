using System;
using BAL;

/*
    Programmer: Daniel Bays
    Date:       04/05/2016
    Purpose:    Add Employee Process
    Details:    This program is used for the Admin to add Employees or Operations Managers.
 */

namespace WSC.Admin
{
    public partial class AddEmployees : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityLevel"] == "M")
            {

            }
            else
            {
                Response.Redirect("NoAccess.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Addes Sales Employee
            if (ddlEmpType.Text == "Sales")
            {
                try
                {
                    //Insert User, will check if already exists.
                    //If already exists will throw exception
                    UserAccount objUA = new UserAccount(0, txtUserName.Text, txtPassword.Text, UserAccount.UserRole.Sales);
                    objUA = objBAL.InsertUser(objUA);

                    lblSubmission.Visible = true;
                    btnSubmit.Visible = false;
                }
                catch (Exception)
                {
                    lblError.Visible = true;
                }
            }

            // Addes Operations Manager Employee
            else if (ddlEmpType.Text == "Operations Manager")
            {
                try
                {
                    //Insert User, will check if already exists.
                    //If already exists will throw exception
                    UserAccount objUA = new UserAccount(0, txtUserName.Text, txtPassword.Text, UserAccount.UserRole.OperationManager);
                    objUA = objBAL.InsertUser(objUA);

                    lblSubmission.Visible = true;
                    btnSubmit.Visible = false;
                }
                catch (Exception)
                {
                    lblError.Visible = true;
                }
            }
            
        }
    }
}