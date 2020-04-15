using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ANWO.Presentation;

public partial class Members_Notifications : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public override void Load_Events()
    {
        SetLoggedInUser();
    }

    private void SetLoggedInUser()
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            MembershipUserCollection users = Membership.FindUsersByName(Page.User.Identity.Name);
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
    }
}