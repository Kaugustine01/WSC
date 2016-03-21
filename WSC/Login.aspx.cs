using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool SiteSpecificationAuthenticationMethod(string UserName, string Password)
        {
            return false;
        }

        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            Authenticated = SiteSpecificationAuthenticationMethod(Login1.UserName, Login1.Password);

            e.Authenticated = Authenticated;
        }
    }
}