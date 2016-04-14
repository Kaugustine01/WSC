using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

/*
    Programmer: Kenneth Augustine
    Date:       04/7/2016
    Purpose:    Email
    Details:    This program is used for sending emails.
 */

namespace BAL
{
    public static class Email
    {
        static Email() { }

        public static void SendIt(string sTo, string sSubject, string sBody)
        {
            SmtpClient objClient = new SmtpClient("smtp.gmail.com", 587);
            MailAddress objFrom = new MailAddress(ConfigurationManager.AppSettings["GmailUsername"].ToString(), "WSC <No Reply>");

            //Enable SSL
            objClient.EnableSsl = true;            

            //Address TO
            MailAddress objTo = new MailAddress(sTo);

            //New Mail Msg
            MailMessage objMessage = new MailMessage(objFrom, objTo);

            //Set Body to HTML
            objMessage.IsBodyHtml = true;

            //Body of Email
            objMessage.Body = sBody;

            //Subject of Email
            objMessage.Subject = sSubject;

            //Gmail UserName
            string sUsername = ConfigurationManager.AppSettings["GmailUsername"].ToString();
            
            //Gmail Password
            string sPassword = ConfigurationManager.AppSettings["GmailPassword"].ToString();

            //Email Acct Credentials
            NetworkCredential objNetworkCredential = new NetworkCredential(sUsername, sPassword);

            //Set SMTP Credentials
            objClient.Credentials = objNetworkCredential;

            try
            {
                //Send Email
                objClient.Send(objMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
