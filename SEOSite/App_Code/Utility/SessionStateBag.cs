using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ANewWebOrder;
using System.Configuration;

namespace ANWO.Utility
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

        public tblProfile RegistrationInfo
        {
            get
            {
                if (Session["RegestrationInfo"] == null)
                    Session["RegestrationInfo"] = new tblProfile();
                return Session["RegestrationInfo"] as tblProfile;
            }
            set
            {
                Session["RegestrationInfo"] = value;
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

        public List<tblLink> CampaignWebLinks
        {
            get
            {
                if (Session["CampaignWebLinks"] == null)
                    Session["CampaignWebLinks"] = new List<tblLink>();
                return Session["CampaignWebLinks"] as List<tblLink>;
            }
            set
            {
                Session["CampaignWebLinks"] = value;
            }
        }

        public List<tblProductOrService> CampaignProductServices
        {
            get
            {
                if (Session["CampaignProductServices"] == null)
                    Session["CampaignProductServices"] = new List<tblProductOrService>();
                return Session["CampaignProductServices"] as List<tblProductOrService>;
            }
            set
            {
                Session["CampaignProductServices"] = value;
            }
        }

        public List<vwCampaignConnect> CampaignConnect
        {
            get
            {
                if (Session["CampaignConnect"] == null)
                    Session["CampaignConnect"] = new List<vwCampaignConnect>();
                return Session["CampaignConnect"] as List<vwCampaignConnect>;
            }
            set
            {
                Session["CampaignConnect"] = value;
            }
        }

        public tblCampaign CurrentCampaign
        {
            get
            {
                if (Session["CurrentCampaign"] == null)
                    Session["CurrentCampaign"] = new tblCampaign();
                return Session["CurrentCampaign"] as tblCampaign;
            }
            set
            {
                Session["CurrentCampaign"] = value;
            }
        }

        public string PayPalMode 
        {
            get
            {
                if (Session["PayPalMode"] == null)
                    Session["PayPalMode"] = Utility.AppSettings.PayPalMode;
                return Session["PayPalMode"].ToString();
            }
        }

    }
}