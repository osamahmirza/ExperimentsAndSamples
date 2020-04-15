using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using System.Web.Security;

public partial class Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Login1.LoggedIn += new EventHandler(Login1_LoggedIn);
    }

    void Login1_LoggedIn(object sender, EventArgs e)
    {
        MembershipUserCollection users = Membership.FindUsersByName(Login1.UserName);
        if (users != null)
            foreach (MembershipUser user in users)
            {
                if (SessionBag.MembershipUser == null || SessionBag.Profile == null)
                {
                    SessionBag.MembershipUser = user;
                    SessionBag.Profile = DataContext.NWODC.tblProfiles.FirstOrDefault(pro => pro.UserID.ToString() == MembershipUser.ProviderUserKey.ToString());
                }
                break;
            }
    }

    public override void Load_Events()
    {
    }
}