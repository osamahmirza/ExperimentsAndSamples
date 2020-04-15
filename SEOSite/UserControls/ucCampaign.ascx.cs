using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANWO.Utility;
using ANewWebOrder;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ANWO.Biz.Entities;
using ANWO;
using ANWO.Common;

public partial class ucCampaign : UserControlBase
{
    private static string _NEWCYBERHAWK = "You are creating a new CyberHawk";

    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterEvents();
        Initialize();
    }

    private void Initialize()
    {
        if (!IsPostBack)
        {
            try
            {
                CampaignID = GetIDFromQS();
            }
            catch (Exception ex)
            {
                ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Invalid Cyber Hawk", Severity = 6 });
            }
        }
    }

    private void RegisterEvents()
    {
        ucLinks1.OnError += new ControlError(Links1_OnError);
        ucProductAndService1.OnError += new ControlError(ProductAndService1_OnError);
        ucConnect1.OnError += new ControlError(ucConnect1_OnError);
    }

    void ucConnect1_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void ProductAndService1_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
    }

    void Links1_OnError(object sender, ControlErrorArgs args)
    {
        ThrowError(this, args);
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
            InitializeControls();
            if (!IsPostBack)
                FetchCampaignAndFill();
        }
    }

    private void InitializeControls()
    {
        ucProductAndService1.CampaignID = _CampaignID;
        ucLinks1.CampaignID = _CampaignID;
        ucConnect1.CampaignID = _CampaignID;
        tbTermsAndConditions.Text = DataContext.NWODC.tblAgreements.Where(a => a.tlkpAgreementType.Name == "Campaign").SingleOrDefault().Agreement;

        lblCaption.Text = "You are editing ";

        if (CampaignID == 0)
        {
            lblCaption.Text = _NEWCYBERHAWK;
        }

    }

    private void FetchCampaignAndFill()
    {
        try
        {
            if (CampaignID != 0)
            {
                Campaign = DataContext.NWODC.tblCampaigns.Where(a => a.ID == _CampaignID && a.ProfileID == SessionBag.Profile.ID).Single();
                //Security Check
                if (Campaign == null || Campaign.ID == 0)
                    throw new Exception(string.Format("User with ID {0} tried to access an invalid Campaign", SessionBag.Profile.ID.ToString()));
                
                PopulateDropdownList();

                lblCaption.Text = lblCaption.Text + Campaign.Name;

                ucBusinessInfo.Name = Campaign.Name;
                ucBusinessInfo.CompanyName = Campaign.CompanyName;
                ucBusinessInfo.Email = Campaign.CompaignEmail;
                ucBusinessInfo.Fax = Campaign.CompaignFax;
                ucBusinessInfo.Phone = Campaign.CompaignPhone;
                tbBusinessDefinition.Text = Campaign.LongDescription;
                tbMissionStatement.Text = Campaign.MissionStatement;
                tbTarget.Text = Campaign.TargetAudiance;
                tbGeographicLocation.Text = Campaign.GeographicScope;
                
                ucWebsiteInfo.WebsiteName = Campaign.Header;
                ucWebsiteInfo.Website = Campaign.Website;
                ucWebsiteInfo.WebsiteDescription = Campaign.Title;

                //tbLinkCategoryName.Text = Campaign.LinkCategoryName;
                //tbProductCategoryName.Text = Campaign.ProductCategoryName;

                //Select parent category based on selected category (sub-category)
                int? parentCatID = DataContext.NWODC.tlkpCategories.Where(a => a.ID == Campaign.CategoryID).Single().ParentID;
                ddlCategory.SelectedValue = parentCatID.ToString();
                ddlCategory_SelectedIndexChanged(null, null);
                ddlSubCategory.SelectedValue = Campaign.CategoryID > 0 ? Campaign.CategoryID.ToString() : "-1";


                ddlGeographicScope.SelectedValue = Campaign.GeographicScopeID > 0 ? Campaign.GeographicScopeID.ToString() : "-1";
                tbSearchPhrase.Text = Campaign.Keywords;
            }
            else
                Campaign = new tblCampaign();

            PeekabooGeographicScope();

            InitializeIsLiveSection(Campaign);

        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "CyberHawk not found.", Severity = 3 });
        }
    }

    private void InitializeIsLiveSection(tblCampaign camp)
    {
        if (camp.IsLive == true)
            rbIsLiveYes.Checked = true;
        else
            rbIsLiveNo.Checked = true;

        if (camp.ID == 0)
        {
            //lnkPayment.Text = "Please save CyberHawk before you can pay for it.";
            //lnkPayment.Enabled = true;
            rbIsLiveNo.Enabled = false;
            rbIsLiveYes.Enabled = false;
        }
        //else
        //{
        //    if (camp.ExpiryDate == null || camp.ExpiryDate <= DateTime.Now)
        //    {
        //        pnlPaymentRequired.Visible = true;
        //        if (camp.ExpiryDate == null)
        //        {
        //            lnkPayment.Text = "Please make a payment to make your CyberHawk fly!";
        //            rbIsLiveNo.Enabled = false;
        //            rbIsLiveYes.Enabled = false;
        //            lnkPayment.Enabled = true;
        //            lblExpirationDate.Visible = false;
        //        }
        //        else
        //        {
        //            if (camp.ExpiryDate <= DateTime.Now)
        //            {
        //                lnkPayment.Text = "Your CyberHawk has expired";
        //                lnkPayment.Enabled = true;

        //                rbIsLiveNo.Enabled = false;
        //                rbIsLiveYes.Enabled = false;

        //                rbIsLiveNo.Checked = true;
        //            }
        //            DateTime expDate = (DateTime)camp.ExpiryDate;
        //            lblExpirationDate.Text = "CyberHawk Expiration Date: " + expDate.ToString("D");
        //            lblExpirationDate.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        lnkPayment.Text = "Make Payment (get more flight-time for your CyberHawk)";
        //        lnkPayment.Visible = true;
        //    }
        //}
    }

    private void PopulateDropdownList()
    {
        ddlCategory.Items.Add(new ListItem() { Text = "[Select]", Value = "-1" });
        ddlCategory.AppendDataBoundItems = true;
        ddlCategory.DataSource = DataContext.NWODC.tlkpCategories.Where(a => a.ParentID == null);
        ddlCategory.DataValueField = "ID";
        ddlCategory.DataTextField = "Name";
        ddlCategory.DataBind();

        ddlGeographicScope.Items.Add(new ListItem() { Text = "[Select]", Value = "-1" });
        ddlGeographicScope.AppendDataBoundItems = true;
        ddlGeographicScope.DataSource = DataContext.NWODC.tlkpGeographicScopes;
        ddlGeographicScope.DataValueField = "ID";
        ddlGeographicScope.DataTextField = "Name";
        ddlGeographicScope.DataBind();
    }
    public bool Validate()
    {
        if (ucBusinessInfo.Name.Trim().Length > 64 || ucBusinessInfo.Name.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "CyberHawk Name is required.", Severity = 6 });
            return false;
        }

        if (ucBusinessInfo.Name.Trim().Length > 0)
        {
            List<tblCampaign> camps = DataContext.NWODC.tblCampaigns.Where(a => a.ProfileID == SessionBag.Profile.ID && a.Name == ucBusinessInfo.Name.Trim()).ToList();

            if (Campaign.ID == 0 && camps != null && camps.Count > 0)
            {
                ThrowError(this, new ControlErrorArgs() { Message = "CyberHawk Name is duplicate.", Severity = 6 });
                return false;
            }

            if (Campaign.ID != 0 && camps != null && camps.Count > 0)
            {
                List<tblCampaign> duplicate = camps.Where(a => a.ID != Campaign.ID).ToList();

                if (duplicate != null && duplicate.Count > 0)
                {
                    ThrowError(this, new ControlErrorArgs() { Message = "CyberHawk Name is duplicate.", Severity = 6 });
                    return false;
                }
            }
        }

        //Website Address
        Regex re = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        if (ucWebsiteInfo.Website.Trim().Length > 255 && ucWebsiteInfo.Website.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Website Address is required.", Severity = 6 });
            return false;
        }
        if (!re.IsMatch(ucWebsiteInfo.Website.Trim()))
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Website Address is invalid", Severity = 6 });
            return false;
        }
        //Website Name
        if (ucWebsiteInfo.WebsiteName.Trim().Length > 255 && ucWebsiteInfo.WebsiteName.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Website Name is required", Severity = 6 });
            return false;
        }
        //Website's Email
        re = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        if (ucBusinessInfo.Email.Trim().Length > 255 && ucBusinessInfo.Email.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Website's Email is required.", Severity = 6 });
            return false;
        }
        if (!re.IsMatch(ucBusinessInfo.Email.Trim()))
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Website's Email is invalid.", Severity = 6 });
            return false;
        }
        //Mission Statement
        if (tbMissionStatement.Text.Trim().Length > 256 && tbMissionStatement.Text.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Mission Statement is required.", Severity = 6 });
            return false;
        }
        //Website Description
        if (ucWebsiteInfo.WebsiteDescription.Trim().Length > 69 && ucWebsiteInfo.WebsiteDescription.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Website Description is required.", Severity = 6 });
            return false;
        }
        //Search Phrase
        if (tbSearchPhrase.Text.Trim().Length > 256 && tbSearchPhrase.Text.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Search Phrase is required.", Severity = 6 });
            return false;
        }
        //Business Category
        if (ddlCategory.SelectedValue == null || ddlCategory.SelectedValue == "-1")
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Business Category is required.", Severity = 6 });
            return false;
        }
        //Geographic Scope
        if (ddlGeographicScope.SelectedValue == null || ddlGeographicScope.SelectedValue == "-1")
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Geographic Scope is required.", Severity = 6 });
            return false;
        }
        //Geographic Location
        if (tbGeographicLocation.Text.Trim().Length > 2048 && tbGeographicLocation.Text.Trim().Length < 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Geographic Location is required.", Severity = 6 });
            return false;
        }
        //Describe your business
        if (tbBusinessDefinition.Text.Trim().Length > 1024 && tbBusinessDefinition.Text.Trim().Length < 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Describe Your Business is required.", Severity = 6 });
            return false;
        }
        //What is your target
        if (tbTarget.Text.Trim().Length > 1024 && tbTarget.Text.Trim().Length < 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Target is required.", Severity = 6 });
            return false;
        }
        //Link Category Name
        if (tbLinkCategoryName.Text.Trim().Length > 128 && tbLinkCategoryName.Text.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Link Category Name is required.", Severity = 6 });
            return false;
        }
        //Link Category Name
        if (tbProductCategoryName.Text.Trim().Length > 128 && tbProductCategoryName.Text.Trim().Length <= 0)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Category Name for Product/Service/Cause is required.", Severity = 6 });
            return false;
        }
        //I Agree to above mentioned end user license agreement
        if (!cbAgree.Checked)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Agreement to terms and conditions is required.", Severity = 6 });
            return false;
        }
        //Links
        if (SessionBag.CampaignWebLinks.Count < 1)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "At least one link is required.", Severity = 6 });
            return false;
        }
        //Products or Services
        if (SessionBag.CampaignProductServices.Count < 1)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "At least one Product or Service is required.", Severity = 6 });
            return false;
        }
        return true;
    }
    public void TemporarySave()
    {
        Campaign.LongDescription = tbBusinessDefinition.Text.Trim(); //This is blogpost
        Campaign.Website = ucWebsiteInfo.Website.Trim();
        Campaign.CompaignEmail = ucBusinessInfo.Email.Trim();
        Campaign.CompanyName = ucBusinessInfo.CompanyName.Trim();
        Campaign.CompaignPhone = ucBusinessInfo.Phone.Trim();
        Campaign.Title = ucWebsiteInfo.WebsiteDescription.Trim(); //(this goes in title field)
        Campaign.Header = ucWebsiteInfo.WebsiteName.Trim(); //(this will go in header field)
        Campaign.Keywords = tbSearchPhrase.Text.Trim();
        Campaign.CompaignFax = ucBusinessInfo.Fax.Trim();
        Campaign.MissionStatement = tbMissionStatement.Text.Trim();
        Campaign.TargetAudiance = tbTarget.Text.Trim();
        Campaign.GeographicScopeID = Convert.ToInt32(ddlGeographicScope.SelectedValue);
        Campaign.CategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);
        Campaign.GeographicScope = tbGeographicLocation.Text.Trim();
        Campaign.ProfileID = SessionBag.Profile.ID;
        Campaign.IsLive = rbIsLiveYes.Checked;
        Campaign.Name = ucBusinessInfo.Name.Trim();
        //Campaign.LinkCategoryName = tbLinkCategoryName.Text.Trim();
        //Campaign.ProductCategoryName = tbProductCategoryName.Text.Trim();
        Campaign.AgreementID = DataContext.NWODC.tblAgreements.Where(a => a.tlkpAgreementType.Name == "Campaign").SingleOrDefault().ID;
        //Saving in session after updating lists
        Campaign = FillLists(Campaign);
    }

    public void Save()
    {
        TemporarySave();
        try
        {
            if (Validate())
            {
                Campaign camp = tblCampaign.TranslateToLocalCampaign(Campaign);
                string xml = UtilityFunctions.SerializeToXML<Campaign>(camp);
                xml = xml.Replace(" encoding=\"utf-8\"", "");
                DataContext.NWODC.UpdateCampaign(xml);
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "CyberHawk cannot be saved.", Severity = 1 });
        }
    }

    private tblCampaign FillLists(tblCampaign tempCamp)
    {
        tempCamp.tblCampaignConnects.Clear();
        foreach (var item in SessionBag.CampaignConnect)
        {
            tempCamp.tblCampaignConnects.Add(new tblCampaignConnect()
            {
                CampaignID = Campaign.ID,
                Link = item.Link,
                ConnectID = item.ConnectID
            });
        }

        tempCamp.tblLinks.Clear();
        foreach (var item in SessionBag.CampaignWebLinks)
        {
            tempCamp.tblLinks.Add(new tblLink()
            {
                CampaignID = Campaign.ID,
                Description = item.Description,
                Link = item.Link
            });
        }

        tempCamp.tblProductOrServices.Clear();
        foreach (var item in SessionBag.CampaignProductServices)
        {
            tempCamp.tblProductOrServices.Add(new tblProductOrService()
            {
                CampaignID = Campaign.ID,
                ProductOrService = item.ProductOrService,
                SearchPhraseForProductOrService = item.SearchPhraseForProductOrService
            });
        }
        return tempCamp;
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
    protected void ddlGeographicScope_SelectedIndexChanged(object sender, EventArgs e)
    {
        PeekabooGeographicScope();
    }

    private void PeekabooGeographicScope()
    {
        if (Convert.ToInt32(ddlGeographicScope.SelectedValue) > 1)
        {
            tbGeographicLocation.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
        }
        else
        {
            tbGeographicLocation.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
            tbGeographicLocation.Text = string.Empty;
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubCategory.Items.Clear();
        ddlSubCategory.Items.Add(new ListItem() { Text = "[Select]", Value = "-1" });
        ddlSubCategory.AppendDataBoundItems = true;
        ddlSubCategory.DataSource = DataContext.NWODC.tlkpCategories.Where(a => a.ParentID != null && a.ParentID == Convert.ToInt32(ddlCategory.SelectedValue)).ToList();
        ddlSubCategory.DataValueField = "ID";
        ddlSubCategory.DataTextField = "Name";
        ddlSubCategory.DataBind();
    }
}