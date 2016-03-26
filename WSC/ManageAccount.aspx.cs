using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC
{
    public partial class ManageAccount : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityLevel"] == "C")
            {
                Customer objCus = new Customer();
                objCus = objBAL.GetCustomerByUserId(Convert.ToInt32(Session["UserID"]));

                txtUserName.Text = Convert.ToString(Session["UserName"]);
                txtFirstName.Text = objCus.FirstName;
                txtLastName.Text = objCus.LastName;
                txtAddress.Text = objCus.Address;
                txtCity.Text = objCus.City;
                txtState.Text = objCus.State;
                txtZipCode.Text = objCus.ZipCode;
                txtPhone.Text = objCus.PhoneNo;
            }
            else
            {
                Response.Redirect("NoAccess.aspx");
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}