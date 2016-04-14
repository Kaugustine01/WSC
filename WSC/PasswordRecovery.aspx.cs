using System;
using BAL;
using System.Web;

/*
    Programmer: Kenneth Augustine
    Date:       04/05/2016
    Purpose:    Forgot Password
    Details:    This program is used for password Recovery.
 */

namespace WSC
{    public partial class PasswordRecovery : System.Web.UI.Page
    {
        BusinessLayer objBAL = new BusinessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sToken = string.Empty;
            lblError.Visible = false;
            UserAccount objUA = null;

            try {
                //Check for query string
                if (!IsPostBack)
                {
                    if (Request["token"] != null)
                    {
                        //Hide Username Panel
                        PanelGetUserName.Visible = false;

                        //Process token
                        objUA = ProcessToken(Request["token"].ToString());

                        if (objUA != null)
                        {
                            if (objUA.UserId > 0)
                            {
                                //Unhide Panel, Session UserClass                         
                                PanelEmailHasBeenSent.Visible = false;
                                PanelNewPassword.Visible = true;

                                //Load UserAcct into Session
                                Session["UserAccount"] = objUA;
                            }
                            else
                                throw new Exception("Problem with token, cannot resolve password recovery.");
                        }
                        else
                            throw new Exception("Problem with token, cannot resolve password recovery.");
                    }
                    else
                    {
                        //Get Username panel enabled, not an email postback
                        PanelGetUserName.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Hide Panels
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try {
                int nUserId = 0;

                nUserId = objBAL.GetUserIdByUserName(txtUserName.Text);

                if (nUserId > 0)
                {
                    //Disable submit button
                    btnSubmit.Enabled = false;

                    //Send Email.
                    SendEmail(nUserId);

                    //Hide Panel and show message
                    PanelGetUserName.Visible = false;
                    PanelNewPassword.Visible = false;
                    PanelEmailHasBeenSent.Visible = true;
                }
                else
                {
                    //Show Error
                    lblError.Visible = true;
                    //Disable submit button
                    btnSubmit.Enabled = true;
                    //Throw exception
                    throw new Exception("User is not found");
                }
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }

        }

        protected void UpdatePassword_Click(object sender, EventArgs e)
        {
            UserAccount objUA = null;

            try
            {
                //Hide error msg if visable
                lblWrongPassword.Visible = false;

                //Cast UserSession into object
                var ua = Session["UserAccount"] as UserAccount;   

                if (ua != null)
                {
                    if (ua.UserId > 0)
                    {
                        objUA = objBAL.UpdateUser(new UserAccount(ua.UserId, ua.UserName, txtNewPassword.Text, ua.UserType, ua.Email));

                        lblUpdateComplete.Visible = true;
                        btnUpdatePassword.Visible = false;
                    }
                    else
                        throw new Exception("Users old password is invalid");
                }
                else
                    throw new Exception("Users old password is invalid");
            }
            catch (Exception)
            {
                lblWrongPassword.Visible = true;
            }
        }

        private bool SendEmail(int nUserId)
        {
            UserAccount objUA = null;
            string sHtml = string.Empty, stoken = string.Empty, sLink = string.Empty;

            //Create token, encrypt UserID | and Unix timecodestamp
            stoken = HttpContext.Current.Server.UrlEncode(Crypto.Encrypt(nUserId + "|" + objBAL.ConvertToUnixTimestamp(DateTime.Now)));

            var WebAddress = new UriBuilder(Request.Url.Scheme, Request.Url.Host, Request.Url.Port);            
            
            //Get UserAccount
            objUA = objBAL.GetUserAccount(new UserAccount(), nUserId);

            //html for email
            sHtml = string.Format(@"Hi,<br /><br />Please click on the link below to reset your password.
            <br /><br />You have 45 mins to click the link.  Thank You.<br /><br /><br /><br />{0}", WebAddress.ToString()) + "passwordrecovery.aspx?token=" + stoken;

            //Send password recovery email
            Email.SendIt(objUA.Email, "WSC Password Recovery", sHtml);
            
            return true;
        }

        private UserAccount ProcessToken(string sToken)
        {
            UserAccount objUA = null;

            try
            {
                //Get token from querystring, Decode, and decrypt
                sToken = Crypto.Decrypt(HttpContext.Current.Server.UrlDecode(Request["token"].ToString()));

                //Split UserID and Unix Timecode stamp from the token.
                string[] arrToken = sToken.Split('|');

                if (arrToken.Length == 2)
                {
                    //Calculate now - converted unix timecode stamp to dateTime of when link was generated
                    TimeSpan span = DateTime.Now.Subtract(objBAL.ConvertFromUnixTimestamp(double.Parse(arrToken[1])));

                    //Check Unix timecode stamp to see if its older than 35 mins.
                    if (span.Minutes < 45)
                    {
                        //Get UserAccount
                        objUA = objBAL.GetUserAccount(new UserAccount(), int.Parse(arrToken[0]));

                        if (objUA != null)
                            if (objUA.UserId > 0)
                                return objUA;
                    }
                    else
                        throw new Exception("Password recovery link is only valid for 45mins.");

                }
                else
                    throw new Exception("Problem with token, cannot resolve password recovery.");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objUA;
        }
    }
}