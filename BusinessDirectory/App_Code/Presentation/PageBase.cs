using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using GoProGo.Utility;
using System.Web.Security;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for PageBase
/// </summary>
namespace GoProGo.Presentation
{
    //TODO: as soon you seen person coming from other than us or canada, redirect them to a page service not
    //available in your country.

    //Make one abastract class which will hold some page related, context related information, common for page, masterpage and usercontrol
    
    public class PageBase : Page, ISessionBag, IMemberOperation
    {
        public PageBase()
        {
            // TODO: Add constructor logic here
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
