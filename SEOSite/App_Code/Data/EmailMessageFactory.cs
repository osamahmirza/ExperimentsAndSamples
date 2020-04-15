using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANWO.Biz.Entities;
using ANewWebOrder;

/// <summary>
/// Summary description for EmailMessageFactory
/// </summary>
namespace ANWO.Biz
{
    public class EmailMessageFactory
    {
        
        public EmailMessageFactory()
        {
        }

        public static EmailMessage GetAccountActivation(string templateKey, string requestID, string toEmail)
        {
            EmailMessage msg = new EmailMessage();
            Data data = new Data();
            var emailTemplate = data.NWODC.tblEmailTemplates.Where(a => a.TemplateKey == templateKey).SingleOrDefault();

            if (emailTemplate != null)
            {
                msg.FromEmail = emailTemplate.FromEmail;
                msg.Title = emailTemplate.Title;
                msg.ToEmail = toEmail;
                msg.Message = emailTemplate.Template.Replace("<#ACTIVATIONID#>", requestID);
            }
            else
            {
                throw new Exception("Email template is not for key:" + templateKey);
            }

            return msg;
        }

        public static EmailMessage GetRefundInvoice(string templateKey, string invoiceID)
        {
            EmailMessage msg = new EmailMessage();

            Data data = new Data();
            var emailTemplate = data.NWODC.tblEmailTemplates.Where(a => a.TemplateKey == templateKey).SingleOrDefault();
            var invoice = data.NWODC.tblInvoices.Where(a => a.ID == invoiceID).SingleOrDefault();

            var prof = invoice.tblProfile;
            var user = data.NWODC.aspnet_Users.Where(a => a.UserId == prof.UserID).SingleOrDefault();
            var membership = data.NWODC.aspnet_Memberships.Where(a => a.UserId == prof.UserID).SingleOrDefault();

            var SLA = data.NWODC.tblSettings.Where(a => a.SettingKey == "SLAAddress").SingleOrDefault();
            var HowTo = data.NWODC.tblSettings.Where(a => a.SettingKey == "HowTo").SingleOrDefault();
            var Help = data.NWODC.tblSettings.Where(a => a.SettingKey == "Help").SingleOrDefault();

            if (emailTemplate != null && invoice != null)
            {
                string message;

                msg.FromEmail = emailTemplate.FromEmail;
                msg.ToEmail = membership.Email;
                msg.Title = emailTemplate.Title;

                message = emailTemplate.Template.Replace("<#DATETIMELONG#>", DateTime.Now.ToString("f"));
                message = message.Replace("<#DATETIMESHORT#>", DateTime.Now.ToString("D"));
                message = message.Replace("<#CUSTOMERNAME#>", prof.FirstName + " " + prof.LastName);
                message = message.Replace("<#LOGINNAME#>", user.UserName);
                message = message.Replace("<#RECEIPTNUMBER#>", invoice.Invoice);
                message = message.Replace("<#ORDERTOTAL#>", invoice.MCGross + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#SALESEMAIL#>", ContactEmails.SALES);
                message = message.Replace("<#QTY#>", invoice.Quantity);
                message = message.Replace("<#PLAN#>", invoice.ItemName);
                message = message.Replace("<#PRICE#>", invoice.MCGross + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#SUBTOTAL#>", invoice.MCGross + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#SHIPPING#>", invoice.Shipping + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#TAX#>", invoice.Tax + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#TOTAL#>", invoice.MCGross + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#CYBERHAWKSLA#>", SLA.Setting);
                message = message.Replace("<#HOWTO#>", HowTo.Setting);
                message = message.Replace("<#HELP#>", Help.Setting);
                msg.Message = message;
            }
            else
            {
                throw new Exception("No Email template found against key:" + templateKey);
            }
            return msg;
        }

        public static EmailMessage GetPaymentInvoice(string templateKey, string invoiceID)
        {
            EmailMessage msg = new EmailMessage();

           Data data = new Data();
            var emailTemplate = data.NWODC.tblEmailTemplates.Where(a => a.TemplateKey == templateKey).SingleOrDefault();
            var invoice = data.NWODC.tblInvoices.Where(a => a.ID == invoiceID).SingleOrDefault();
            
            var prof = invoice.tblProfile;
            var user = data.NWODC.aspnet_Users.Where(a => a.UserId == prof.UserID).SingleOrDefault();
            var membership = data.NWODC.aspnet_Memberships.Where(a => a.UserId == prof.UserID).SingleOrDefault();
            
            var SLA = data.NWODC.tblSettings.Where(a => a.SettingKey == "SLAAddress").SingleOrDefault();
            var HowTo = data.NWODC.tblSettings.Where(a => a.SettingKey == "HowTo").SingleOrDefault();
            var Help = data.NWODC.tblSettings.Where(a => a.SettingKey == "Help").SingleOrDefault();

            if(emailTemplate != null && invoice != null)
            {
                string message;

                msg.FromEmail = emailTemplate.FromEmail;
                msg.ToEmail = membership.Email;
                msg.Title = emailTemplate.Title;

                message = emailTemplate.Template.Replace("<#DATETIME#>", DateTime.Now.ToString("f"));
                message = message.Replace("<#DATETIMESMALL#>", DateTime.Now.ToString("D"));
                message = message.Replace("<#CUSTOMERNAME#>", prof.FirstName + " " + prof.LastName);
                message = message.Replace("<#LOGINNAME#>", user.UserName);
                message = message.Replace("<#RECEIPTNUMBER#>",invoice.Invoice);
                message = message.Replace("<#ORDERTOTAL#>",invoice.MCGross + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#SALESEMAIL#>", ContactEmails.SALES);
                message = message.Replace("<#QTY#>", invoice.Quantity);
                message = message.Replace("<#PLAN#>", invoice.ItemName);
                message = message.Replace("<#PRICE#>", invoice.MCGross + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#SUBTOTAL#>", invoice.MCGross + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#SHIPPING#>", invoice.Shipping + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#TAX#>", invoice.Tax + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#TOTAL#>", invoice.MCGross + " (" + invoice.MCCurrency + ")");
                message = message.Replace("<#CYBERHAWKSLA#>", SLA.Setting);
                message = message.Replace("<#HOWTO#>", HowTo.Setting);
                message = message.Replace("<#HELP#>", Help.Setting);
                msg.Message = message;
            }
            else
            {
                throw new Exception("No Email template found against key:" + templateKey);
            }
            return msg;
        }

        public static EmailMessage GetAlertNotification(string templateKey, string toEmail, string notification)
        {
            EmailMessage msg = new EmailMessage();

            Data data = new Data();
            var emailTemplate = data.NWODC.tblEmailTemplates.Where(a => a.TemplateKey == templateKey).SingleOrDefault();
            if(emailTemplate != null)
            {
                msg.FromEmail = emailTemplate.FromEmail;
                msg.Title = emailTemplate.Title;
                msg.ToEmail = toEmail;
                msg.Message = emailTemplate.Template.Replace("<#NOTIFICATION#>", notification);
            }
            else
            {
                throw new Exception("Email template is not for against key:" + templateKey);
            }

            return msg;
        }
    }
}