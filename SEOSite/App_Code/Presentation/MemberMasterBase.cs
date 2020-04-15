using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using ANWO.Utility;
using ANewWebOrder;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MasterBase
/// </summary>
namespace ANWO.Presentation
{
    public abstract class MemberBaseMasterPage : CommonBaseMaster, ISessionBag, IMemberOperation
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PopulateNotifications();
        }

        public abstract void PopulateNotifications();

        public abstract void GenerateControlBasedMetaData(string header);

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
                if (SessionBag.MembershipUser == null || SessionBag.Profile == null)
                {
                    MembershipUserCollection users = Membership.FindUsersByName(Page.User.Identity.Name);
                    foreach (MembershipUser user in users)
                    {
                        //Set session first
                        SessionBag.MembershipUser = user;
                        SessionBag.Profile = DataContext.NWODC.tblProfiles.FirstOrDefault(pro => pro.UserID.ToString() == MembershipUser.ProviderUserKey.ToString());
                        break;
                    }
                }
                return SessionBag.MembershipUser;
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
            SessionBag.MembershipUser = null;
        }

        #endregion

        public override void CommonBaseMaster_Load(string param)
        {
            GenerateControlBasedMetaData(param);
        }
    }
}