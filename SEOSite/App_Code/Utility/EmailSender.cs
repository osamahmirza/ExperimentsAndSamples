using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using ANWO;
using ANWO.Utility;

/// <summary>
/// Summary description for Email
/// </summary>
namespace ANWO.Utility
{
    public class EmailSender
    {
        public static void SendEmail(string from, string to, string title, string message, MailPriority priority = MailPriority.Normal, MailSendContext mailSendContext = MailSendContext.General)
        {
            //Send emails
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                //Setting SMTP Client
                SmtpClient client = new SmtpClient(settings.Smtp.Network.Host);
                client.Port = settings.Smtp.Network.Port;
                client.EnableSsl = settings.Smtp.Network.EnableSsl;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);

                MailMessage mailObj = new MailMessage(from, to, title, message);
                mailObj.Priority = priority;
                SmtpClient SMTPServer = new SmtpClient();


                SMTPServer.Send(mailObj);
            }
            catch (Exception ex)
            {
                ANWOLogger.WriteExceptionLog("MailSendContext: " + mailSendContext.ToString(), ex, LogCategory.HighAlert, 1);
            }
        }

    }
}