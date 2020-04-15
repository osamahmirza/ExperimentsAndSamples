using ANWO;
using ANWO.Common;
using ANWO.Biz.Entities;
using ANWO.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANewWebOrder;
using ANWO.Utility;

public partial class UserControls_ucCampaignPublic : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterEvents();
        Initialize();
    }

    private void Initialize()
    {
        //if (!IsPostBack)
        //{
        try
        {
            CampaignID = GetIDFromQS();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Invalid Cyber Hawk", Severity = 6 });
        }
        //}
    }

    private void RegisterEvents()
    {
        ucMainInfo.OnError += ucMainInfo_OnError;

        ucTags.OnError += ucTags_OnError;
        ucTags1.OnError += ucTags1_OnError;
        ucTags2.OnError += ucTags2_OnError;
        ucTags3.OnError += ucTags3_OnError;

        ucCampaignContactUs.OnError += ucCampaignContactUs_OnError;
        ucCampaignContactUs1.OnError += ucCampaignContactUs1_OnError;
        ucCampaignContactUs2.OnError += ucCampaignContactUs2_OnError;
        ucCampaignContactUs3.OnError += ucCampaignContactUs3_OnError;

        ucConnectPublic.OnError += ucConnectPublic_OnError;
        ucConnectPublic1.OnError += ucConnectPublic1_OnError;
        ucConnectPublic2.OnError += ucConnectPublic2_OnError;
        ucConnectPublic3.OnError += ucConnectPublic3_OnError;
    }

    void ucConnectPublic3_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucConnectPublic2_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucConnectPublic1_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucCampaignContactUs3_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    private void ucCampaignContactUs2_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucCampaignContactUs1_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucTags3_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucTags2_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucTags1_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucConnectPublic_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucCampaignContactUs_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucTags_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ucMainInfo_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    private void FetchCampaignAndFill()
    {
        try
        {
            if (CampaignID != 0)
            {
                ucMainInfo.Header = Campaign.Header;
                ucMainInfo.Website = Campaign.Website;
                ucMainInfo.LongDescription = Campaign.LongDescription;
                ucMainInfo.CompanyName = Campaign.CompanyName;
                ucMainInfo.Title = Campaign.Title;

                #region Tags
                ucTags.SearchTags = Campaign.Keywords;
                ucTags.BizTags = Campaign.TargetAudiance;
                ucTags.GeoTags = Campaign.GeographicScopeID == 1 ? Campaign.tlkpGeographicScope.Name : Campaign.GeographicScope;

                ucTags1.SearchTags = Campaign.Keywords;
                ucTags1.BizTags = Campaign.TargetAudiance;
                ucTags1.GeoTags = Campaign.GeographicScopeID == 1 ? Campaign.tlkpGeographicScope.Name : Campaign.GeographicScope;

                ucTags2.SearchTags = Campaign.Keywords;
                ucTags2.BizTags = Campaign.TargetAudiance;
                ucTags2.GeoTags = Campaign.GeographicScopeID == 1 ? Campaign.tlkpGeographicScope.Name : Campaign.GeographicScope;

                ucTags3.SearchTags = Campaign.Keywords;
                ucTags3.BizTags = Campaign.TargetAudiance;
                ucTags3.GeoTags = Campaign.GeographicScopeID == 1 ? Campaign.tlkpGeographicScope.Name : Campaign.GeographicScope;
                #endregion

                #region Connect Public
                ucConnectPublic.CampaignID = CampaignID;
                ucConnectPublic1.CampaignID = CampaignID;
                ucConnectPublic2.CampaignID = CampaignID;
                ucConnectPublic3.CampaignID = CampaignID;
                #endregion

                #region Phones
                ucPhoneAndFax.Phone = Campaign.CompaignPhone;
                ucPhoneAndFax.Fax = Campaign.CompaignFax;

                ucPhoneAndFax1.Phone = Campaign.CompaignPhone;
                ucPhoneAndFax1.Fax = Campaign.CompaignFax;

                ucPhoneAndFax2.Phone = Campaign.CompaignPhone;
                ucPhoneAndFax2.Fax = Campaign.CompaignFax;

                ucPhoneAndFax3.Phone = Campaign.CompaignPhone;
                ucPhoneAndFax3.Fax = Campaign.CompaignFax;
                #endregion

            }
            else
                throw new Exception("Invalid Cyber Hawk");
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Cyber Hawk not found.", Severity = 3 });
        }
    }

    private int _CampaignID;
    public int CampaignID
    {
        get
        {
            return _CampaignID;
        }
        set
        {
            _CampaignID = value;
            SetVolatileProperties();
            if (!IsPostBack)
                FetchCampaignAndFill();
        }
    }

    private void SetVolatileProperties()
    {
        Campaign = DataContext.NWODC.tblCampaigns.Where(a => a.ID == _CampaignID).Single();
        ucCampaignContactUs.ToEmail = Campaign.CompaignEmail;
    }

    private tblCampaign Campaign
    {
        get
        {
            return SessionBag.CurrentCampaign;
        }
        set
        {
            SessionBag.CurrentCampaign = value;
        }
    }
}