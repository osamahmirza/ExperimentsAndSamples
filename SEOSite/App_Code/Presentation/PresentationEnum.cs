using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANWO.Presentation
{
    public enum MyAccountType
    {
        Profile,
        Favourite,
        Messages,
        Traffic,
        CommentsAndScore,
        ChangePassword,
        SMSAlerts,
        Advertisments,
        Billing,
        MembershipStatus,
        None
    }
    public enum PageType
    {
        Public,
        Member,
        Admin,
        Sales
    }
}
