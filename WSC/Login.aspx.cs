using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
    {
        // Insert Code that implements a site specific custom
        // Authentication method here.
        //
        // This exaple implementation always returns false
        return false;
    }

    protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
    {
        bool Authenticated = false;
        Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password);

        e.Authenticated = Authenticated;
    }
}