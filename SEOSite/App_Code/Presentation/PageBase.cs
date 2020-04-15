using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using ANWO.Utility;

/// <summary>
/// Summary description for PageBase
/// </summary>
namespace ANWO.Presentation
{
    public class PageBase : Page, ISessionBag, IMemberOperation
    {
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



        protected void AddMetaTag(string httpEquiv, string content)
        {
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = httpEquiv;
            meta.Content = content;
            this.Header.Controls.Add(meta);
        }

        protected void AddKeywordsAndDescription(string keywords, string description)
        {
            AddMetaTag("keywords", keywords);
            AddMetaTag("description", description);
        }
    }
}
