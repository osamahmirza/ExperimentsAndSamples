using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Net;
using System.Web.UI;
using GoProGo.Data.Entity.Profile;

namespace GoProGo.Utility
{
    public class SessionStateBag
    {
        private System.Web.SessionState.HttpSessionState Session = System.Web.HttpContext.Current.Session;

        public MembershipUser MembershipUser
        {
            get
            {
                return Session["MembershipUser"] as MembershipUser;
            }
            set
            {
                Session["MembershipUser"] = value;
            }
        }

        public UserLocalInfo UserBrowsingInfo 
        {
            get
            {
                return Session["UserBrowsingInfo"] as UserLocalInfo;
            }
            set
            {
                Session["UserBrowsingInfo"] = value;
            }
        }

        public tblProfile Profile 
        {
            get
            {
                return Session["Profile"] as tblProfile;
            }
            set
            {
                Session["Profile"] = value;
            }
        }
    }
}
