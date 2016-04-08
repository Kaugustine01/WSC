using System;
using BAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{    public partial class PasswordRecovery : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try {
                int nUserId = 0;

                nUserId = objBAL.GetUserIdByUserName(txtUserName.Text);

                if (nUserId > 0)
                {

                    //Send Email.
                    SendEmail(nUserId);              

                    //Hide Panel and show message
                }
                else
                {
                    //Show Error
                    lblError.Visible = true;
                    throw new Exception("User is not found");
                }
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

        }

        private bool SendEmail(int nUserId)
        {
            UserAccount objUA = null;
            string sHtml = string.Empty, stoken = string.Empty, sLink = string.Empty;

            //Create token, encrypt UserID | and Unix timecodestamp
            stoken = HttpContext.Current.Server.UrlEncode(Crypto.Encrypt(nUserId + "|" + objBAL.ConvertToUnixTimestamp(DateTime.Now)));

            var WebAddress = new UriBuilder(Request.Url.Scheme, Request.Url.Host, Request.Url.Port, "passwordrecovery.aspx?token=" + stoken);            

            var scheme = Request.Url.Scheme; // will get http, https, etc.
            var host = Request.Url.Host; // will get www.mywebsite.com
            var port = Request.Url.Port; // will get the port
            var path = Request.Url.AbsolutePath;

            //Get UserAccount
            objUA = objBAL.GetUserAccount(new UserAccount(0, "", "", UserAccount.UserRole.OperationManager,""), nUserId);

            //html for email
            sHtml = string.Format(@"Hi,<br /><br />Please click on the link below to reset your password.
            <br /><br />You have 45 mins to click the link.  Thank You.<br /><br /><br /><br />{0}", WebAddress.ToString());

            //Send password recovery email
            Email.SendIt(objUA.Email, "WSC Password Recovery", sHtml);
            
            return true;
        }




    }
}