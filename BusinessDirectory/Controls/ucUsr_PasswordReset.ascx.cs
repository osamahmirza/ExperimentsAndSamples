using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using System.Web.Security;
using System.Web.Mail;

public partial class ucUsr_PasswordReset : UserControlBase
{
    public event ControlError OnError;
    public event EventHandler OnPasswordChanged;
    public event EventHandler OnCancel;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {

                string email = tbEmail.Text.Trim();
                string newPwd = string.Empty;
                MembershipUserCollection users = Membership.FindUsersByEmail(email);
                if (users.Count > 0)
                {
                    foreach (MembershipUser user in users)
                    {
                        newPwd = user.ResetPassword();
                        //TODO: Send user's password through email
                        Response.Write("New Pwd: " + newPwd + " Send this via smtp to user");
                        if (OnPasswordChanged != null)
                            OnPasswordChanged(this, null);
                        break;
                    }
                }
                else
                {
                    throw new Exception("Email not found.");
                }
            }
            else
            {
                throw new Exception("Invalid email address.");
            }
        }
        catch (Exception ex)
        {
            if (OnError != null)
                OnError(this, new ControlErrorArgs() { InnerException = ex });
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (OnCancel != null)
            OnCancel(this, null);
    }
}
