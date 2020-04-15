using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using System.Web.Security;

public partial class ucUsr_ChangePassword : UserControlBase
{
    public event EventHandler OnPasswordChange;
    public event ControlError OnError;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        string pwd = tbPassword.Text.Trim();
        string pwdNew = tbNewPassword.Text.Trim();
        string pwdConf = tbConfirmPassword.Text.Trim();

        try
        {
            if (pwdNew != pwdConf && Page.IsValid)
            {
                if (!this.MembershipUser.ChangePassword(pwd, pwdNew))
                    throw new Exception("Password can not be changed.");
            }
        }
        catch (Exception ex)
        {
            if (OnError != null)
                OnError(this, new ControlErrorArgs() {InnerException = ex });
        }
    }
}
