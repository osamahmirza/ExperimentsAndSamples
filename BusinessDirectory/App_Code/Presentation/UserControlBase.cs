using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using GoProGo.Utility;
using System.Web.Security;

/// <summary>
/// Summary description for UserControlBase
/// </summary>
namespace GoProGo.Presentation
{
    public class UserControlBase : UserControl, ISessionBag, IMemberOperation
    {
        public delegate void AddKeywordAndDescription(object sender, KeywordAndDescriptionArgs args);
        public delegate void ControlError(object sender, ControlErrorArgs args);
        public event ControlError OnError;
        public event AddKeywordAndDescription OnAddKeywordsAndDescription;

        public UserControlBase()
        {
        }

        #region ISessionBag Members
        private SessionStateBag _SessionBag;
        public SessionStateBag SessionBag
        {
            get
            {
                if (_SessionBag == null)
                {
                    _SessionBag = new SessionStateBag();
                }
                return _SessionBag;
            }
        }
        #endregion

        #region IMemberOperation Members

        public MembershipUser MembershipUser
        {
            get
            {
                if (SessionBag.MembershipUser == null)
                {
                    MembershipUserCollection users = Membership.FindUsersByName(Page.User.Identity.Name);
                    foreach (MembershipUser user in users)
                    {
                        //Set session first
                        SessionBag.MembershipUser = user;
                        break;
                    }
                }

                return SessionBag.MembershipUser;
            }
            set
            {
                SessionBag.MembershipUser = value;
            }
        }

        public bool IsAuthenticated
        {
            get 
            {
                return Request.IsAuthenticated;
            }
        }

        public string Email
        {
            get 
            {
                return MembershipUser.Email;
            }
        }

        public string UserName
        {
            get 
            {
                return MembershipUser.UserName;
            }
        }

        public void UpdateMembershipUser()
        {
            MembershipUser = null;
        }

        #endregion

        protected void ThrowError(object sender, ControlErrorArgs args)
        {
            //Do Logging here
            if (OnError != null)
                OnError(sender, args);
        }
        protected void AddKeywordsAndDescription(object sender, KeywordAndDescriptionArgs args)
        {
            if (OnAddKeywordsAndDescription != null)
                OnAddKeywordsAndDescription(sender, args);
        }
    }


    public class ControlErrorArgs : EventArgs
    {
        public Exception InnerException { get; set; }
        public int Severity { get; set; }
        public string Message { get; set; }
    }

    public class KeywordAndDescriptionArgs : EventArgs
    {
        public string Keyword { get; set; }
        public string Description { get; set; }
    }
}
