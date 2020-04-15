using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using ANWO.Utility;
using ANWO.Common;

/// <summary>
/// Summary description for UserControlBase
/// </summary>
namespace ANWO.Presentation
{
    public class UserControlBase : UserControl, ISessionBag, IMemberOperation
    {
        public new event ControlError OnError;
        public event EventHandler OnSuccess;

        public UserControlBase()
        {
        }

        #region Fetch Param From QS
        protected int GetIDFromQS()
        {
            int campID = 0;
            string campaignID = Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(campaignID) && !string.IsNullOrEmpty(campaignID.Trim()) && UtilityFunctions.IsInt(campaignID))
                campID = Convert.ToInt32(campaignID);
            else
                campID = 0;

            return campID;
        } 
        #endregion

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
                if (SessionBag.MembershipUser == null && !string.IsNullOrEmpty(Page.User.Identity.Name))
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

        #region DataContext
        private Data _DataContext;
        public Data DataContext
        {
            get
            {
                if (_DataContext == null)
                    _DataContext = new Data();
                return _DataContext;
            }
        } 
        #endregion

        #region Events Firing
        protected void ThrowError(object sender, ControlErrorArgs args)
        {
            ANWOLogger.WriteExceptionLog(args.Message, args.InnerException, LogCategory.General);
            if (OnError != null)
            {
                if (!args.LogOnly)
                    OnError(sender, args);
            }
        }

        protected void ThrowSuccess(object sender, EventArgs args)
        {
            if (OnSuccess != null)
                OnSuccess(sender, args);
        } 
        #endregion
    }
}
