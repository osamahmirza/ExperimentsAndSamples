using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using System.Web.Security;
using GoProGo.Utility;
using GoProGo.Data.Entity.Profile;

public partial class ucUsr_UpdateEmail : UserControlBase
{
    public event EventHandler OnEmailChanged;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Initialize();
    }
    
    private void Initialize()
    {
        try
        {
            rtbChangeEmail.Text = MembershipUser.Email;
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity=3});
        }
    }
    public void Save()
    {
        try
        {
            if (this.IsAuthenticated && Page.IsValid)
            {
                string newEmail = rtbChangeEmail.Text.Trim();
                MembershipUser user = this.MembershipUser;
                user.Email = newEmail;
                Membership.UpdateUser(user);
                if (OnEmailChanged != null)
                    OnEmailChanged(this, null);
            }
            else
            {
                throw new Exception("User is not authenticated or invalid input");
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });
        }
    }
}
