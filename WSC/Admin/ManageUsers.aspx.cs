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
                
            }
            else
            {
                Response.Redirect("NoAccess.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Customer objCus = null;

            objCus = objBAL.GetCustomerByFilter(Customer.SearchFilter.LastName, txtSearchLastName.Text);

            ManageUsersGridView.DataSource = objCus;
            ManageUsersGridView.DataBind();
            
        }
    }
}