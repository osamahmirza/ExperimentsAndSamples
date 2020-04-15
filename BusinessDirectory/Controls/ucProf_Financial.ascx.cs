using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class ucProf_Financial : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetObj();
    }

    private void SetObj()
    {
        //tblProfile prof = GoProGo.Data.GoProGoDC.ProfileDC.tblProfiles.First(pro => pro.UserID.ToString() == MembershipUser.ProviderUserKey.ToString());
        ////This will trigger Initialize if !IsPostback
        //ObjProfile = prof;
        ObjProfile = SessionBag.Profile;
    }

    private void Initialize()
    {
        rcmbCurrency.Items.Add(new RadComboBoxItem("[Select Currency]", "-1"));
        rcmbCurrency.AppendDataBoundItems = true;
        rcmbCurrency.DataSource = GoProGo.Business.Lookup.Geo.GetEnabledCountries();
        rcmbCurrency.DataTextField = "Currency";
        rcmbCurrency.DataValueField = "ID";
        rcmbCurrency.DataBind();

        rcmbServiceCategory.DataSource = GoProGo.Business.Lookup.Profile.GetAllCategories();
        rcmbServiceCategory.DataTextField = "Name";
        rcmbServiceCategory.DataValueField = "ID";
        rcmbServiceCategory.DataBind();

        rcmbJobUnit.DataSource = GoProGo.Business.Lookup.Profile.GetAllJobUnits();
        rcmbJobUnit.DataTextField = "JobUnit";
        rcmbJobUnit.DataValueField = "ID";
        rcmbJobUnit.DataBind();

        PopulateControl();
    }
    private tblProfile _ObjProfile;
    public tblProfile ObjProfile
    {
        get
        {
            return _ObjProfile;
        }
        set
        {
            _ObjProfile = value;
            if (!IsPostBack)
                Initialize();
        }
    }
    private void PopulateControl()
    {
        MinimumRate = _ObjProfile.MinimumRate == null ? 0 : (decimal)_ObjProfile.MinimumRate;
        Currency_CountryID = _ObjProfile.Currency_CountryID == null ? -1 : (int)_ObjProfile.Currency_CountryID;
        JobUnitID = _ObjProfile.JobUnitID == null ? -1 : (int)_ObjProfile.JobUnitID;
    }
    public void SaveProfile()
    {
        try
        {

            _ObjProfile.MinimumRate = MinimumRate;
            _ObjProfile.Currency_CountryID = Currency_CountryID;
            _ObjProfile.JobUnitID = JobUnitID;

            GoProGo.Data.GoProGoDC.ProfileDC.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });  
        }
    }
    public Decimal MinimumRate 
    {
        get
        {
            return string.IsNullOrEmpty(rmtbMinimumRate.Text.Trim()) ? 0 : decimal.Parse(rmtbMinimumRate.Text.Trim());
        }
        set
        {
            rmtbMinimumRate.Text = value.ToString();
        }
    }
    public int Currency_CountryID 
    {
        get
        {
            return int.Parse(rcmbCurrency.SelectedItem.Value);
        }
        set
        {
            rcmbCurrency.SelectedValue = value.ToString();
        }
    }
    public int JobUnitID 
    {
        get
        {
            return int.Parse(rcmbJobUnit.SelectedItem.Value);
        }
        set
        {
            rcmbJobUnit.SelectedValue = value.ToString();
        }
    }
    public int CategoryID 
    {
        get
        {
            return int.Parse(rcmbServiceCategory.SelectedItem.Value);
        }
        set
        {
            rcmbServiceCategory.SelectedValue = value.ToString();
        }
    }
}
