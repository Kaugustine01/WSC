using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WSC.Admin
{
    public partial class ManageEmployees : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityLevel"] == "M")
            {
                Customer objCust = new Customer();

            }
            else
            {
                Response.Redirect("NoAccess.aspx");
            }
        }
    }
}