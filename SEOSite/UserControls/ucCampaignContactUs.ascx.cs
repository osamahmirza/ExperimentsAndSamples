using ANewWebOrder;
using ANWO.Common;
using ANWO.Presentation;
using ANWO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucCampaignContactUs : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string ToEmail { get; set; }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string fromEmail = tbFromAddress.Text;
        string subject = tbSubject.Text;
        string body = tbBody.Text;
        Validate();

        EmailSender.SendEmail(fromEmail, ToEmail, subject, body, MailPriority.Normal, MailSendContext.Contact);


    }

    private bool Validate()
    {
        bool valid = false;
        //Email Address
        Regex re = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        if (tbFromAddress.Text.Trim().Length > 255 && tbFromAddress.Text.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Email Address is required.", Severity = 6 });
            valid = false;
        }
        if (!re.IsMatch(tbFromAddress.Text.Trim()))
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Email Address is invalid.", Severity = 6 });
            valid = false;
        }
        //Subject
        if (tbSubject.Text.Trim().Length < 1)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Subject is required.", Severity = 6 });
            valid = false;
        }
        //Body
        if (tbBody.Text.Trim().Length < 1)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Message is required.", Severity = 6 });
            valid = false;
        }
        return valid;
    }
}