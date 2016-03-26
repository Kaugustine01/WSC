using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

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
            if (ddlEmpType.Text == "Sales")
            {
                try
                {
                    //Insert User, will check if already exists.
                    //If already exists will throw exception
                    UserAccount objUA = new UserAccount(0, txtUserName.Text, txtPassword.Text, UserAccount.UserRole.Sales);
                    objUA = objBAL.InsertUser(objUA);

                    lblSubmission.Visible = true;
                }
                catch (Exception)
                {
                    lblError.Visible = true;
                }
            }
            else if (ddlEmpType.Text == "Operations Manager")
            {
                try
                {
                    //Insert User, will check if already exists.
                    //If already exists will throw exception
                    UserAccount objUA = new UserAccount(0, txtUserName.Text, txtPassword.Text, UserAccount.UserRole.OperationManager);
                    objUA = objBAL.InsertUser(objUA);

                    lblSubmission.Visible = true;
                }
                catch (Exception)
                {
                    lblError.Visible = true;
                }
            }
            
        }
    }
}