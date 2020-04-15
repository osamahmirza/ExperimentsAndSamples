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

public partial class Login : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        MembershipUserCollection users = Membership.FindUsersByName(Login1.UserName);
        
        foreach (MembershipUser user in users)
        {
            SessionBag.MembershipUser = user;
            SessionBag.Profile = GoProGo.Data.GoProGoDC.ProfileDC.GetProfileByUserID((Guid)MembershipUser.ProviderUserKey).First<tblProfile>(); 
            break;
        }
    }
}
