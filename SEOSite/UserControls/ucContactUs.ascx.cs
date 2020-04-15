using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using System.Net.Mail;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using ANWO.Common;
using ANWO.Utility;
using ANWO.Biz.Entities;

public partial class ucUserControls_ContactUs : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string fromEmail = txtEmail.Text.Trim();
            string toEmail = GetEmailAddress();
            string subject = ddlRecipients.SelectedItem.Text + ": " + txtSubject.Text.Trim();
            string body = txtMessage.Text;

            if (UtilityFunctions.EmailAddressExists(fromEmail, toEmail))
            {
                EmailSender.SendEmail(fromEmail, toEmail, subject, body, MailPriority.Normal, MailSendContext.Contact);
                Response.Redirect("default.aspx", false);
            }
            else
            {
                ThrowError(this, new ControlErrorArgs() { LogOnly = true, Message = "Invalid Email Address.", Severity = 6 });    
            }

        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, LogOnly = true, Message = "Mail could not be sent.", Severity=1});
        }
    }

    private string GetEmailAddress()
    {
        string value = ddlRecipients.SelectedItem.Value;
        switch (value)
        {
            case "1":
                return ContactEmails.INFO;
            case "2":
                return ContactEmails.SALES;
            case "3":
                return ContactEmails.CS;
            case "4":
                return ContactEmails.WEBMASTER;
            case "5":
                return ContactEmails.BILLING;
            default:
                return ContactEmails.INFO;
        }
    }

}