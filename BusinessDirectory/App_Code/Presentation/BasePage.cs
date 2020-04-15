using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoProGo.Presentation;
using System.Web.Security;

/// <summary>
/// Summary description for BasePage
/// </summary>
public abstract class BasePage : PageBase
{
	public BasePage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        SetLoggedinUser();
        Load_Events();
        Load_Header();

    }
    public abstract void Load_Events();
    public abstract void Load_Header();

    private void SetLoggedinUser()
    {
        if (!string.IsNullOrEmpty(User.Identity.Name))
        {
            MembershipUserCollection users = Membership.FindUsersByName(User.Identity.Name);

            foreach (MembershipUser user in users)
            {
                if (SessionBag.MembershipUser == null || SessionBag.Profile == null)
                {
                    SessionBag.MembershipUser = user;
                    SessionBag.Profile = GoProGo.Data.GoProGoDC.ProfileDC.tblProfiles.FirstOrDefault(pro => pro.UserID.ToString() == MembershipUser.ProviderUserKey.ToString());
                }

                break;
            }
        }
    }
}
