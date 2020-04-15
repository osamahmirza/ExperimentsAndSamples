using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoProGo.Presentation
{
    public enum MessageType
    {
        Information,
        Warning,
        Error,
        None
    }
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
