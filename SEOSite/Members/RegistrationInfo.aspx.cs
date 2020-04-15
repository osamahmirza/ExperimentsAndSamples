using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ANWO.Presentation;
using ANWO.Common;

public partial class Members_RegistrationInfo : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void Load_Events()
    {
        SetLoggedInUser();
        RegisterEvents();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserInfo1.SaveUser();
    }

    private void RegisterEvents()
    {
        PersonInfo1.OnSuccess += new EventHandler(PersonInfo1_OnSuccess);
        PersonInfo1.OnError += new ControlError(PersonInfo1_OnError);
        UserInfo1.OnSuccess += new EventHandler(UserInfo1_OnSuccess);
        UserInfo1.OnError += new ControlError(UserInfo1_OnError);
    }

    void UserInfo1_OnError(object sender, ControlErrorArgs args)
    {
        ((IMessage)Master).ClearMessage();
        ((IMessage)Master).ShowMessage(args.Message);
    }

    void UserInfo1_OnSuccess(object sender, EventArgs e)
    {
        ((IMessage)Master).ShowMessage("User Information saved.");
        PersonInfo1.SaveProfile(sender as System.Web.Security.MembershipUser);
    }

    void PersonInfo1_OnError(object sender, ControlErrorArgs args)
    {
        ((IMessage)Master).ClearMessage();
        ((IMessage)Master).ShowMessage(args.Message);
    }

    void PersonInfo1_OnSuccess(object sender, EventArgs e)
    {
        ((IMessage)Master).ShowMessage("Personal Information saved.");
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

            PersonInfo1.NWOProfile = SessionBag.Profile;
            UserInfo1.User = SessionBag.MembershipUser;
        }
    }
}