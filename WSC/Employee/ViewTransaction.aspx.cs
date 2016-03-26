using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC.Employee
{
    public partial class ViewTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SecurityLevel"] == "M" || Session["SecurityLevel"] == "S")
            {

            }
            else
            {
                Response.Redirect("NoAccess.aspx");
            }
        }
    }
}