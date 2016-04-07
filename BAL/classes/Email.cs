using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace BAL
{
    public class Email
    {
        SmtpClient objClient = new SmtpClient("smtp.gmail.com", 587);
        MailAddress objFrom = new MailAddress("wscecom@gmail.com", "WSC <No Reply>");

        public string Subject { get; set; }

        public string Body { get; set; }

        public string To { get; set; }

        public Email() { }

        public void SendIt()
        {
            //Enable SSL
            objClient.EnableSsl = true;            

            //Address TO
            MailAddress objTo = new MailAddress(To);

            //New Mail Msg
            MailMessage objMessage = new MailMessage(objFrom, objTo);

            //Body of Email
            objMessage.Body = Body;

            //Subject of Email
            objMessage.Subject = Subject;

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
