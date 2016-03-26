﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BAL;

namespace WSC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        
        }

        private bool SiteSpecificationAuthenticationMethod(string UserName, string Password)
        {
            UserAccount objUA = null;
            BusinessLayer objBAL = new BusinessLayer();

            objUA = objBAL.GetUserAccount(UserName, Password);

            if (objUA != null) {

                Session["UserID"] = objUA.UserId;
                Session["UserName"] = objUA.UserName;
                Session["SecurityLevel"] = objUA.UserType;

                if (objUA.UserId > 0)
                    return true;
            }

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