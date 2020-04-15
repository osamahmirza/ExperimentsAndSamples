using GoProGo.Business.GoogleGeoCoder;
using GoProGo.Data;
using GoProGo.Data.Entity.Profile;
using GoProGo.Presentation;
using System;
using System.Text;
using Telerik.Web.UI;

public partial class ucProf_Address : UserControlBase
{
    string _Country = string.Empty;
    string _City = string.Empty;
    string _Province = string.Empty;

     
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

    protected void Page_Load(object sender, EventArgs e)
    {
        SetObj();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        cmbCountry.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(cmbCountry_SelectedIndexChanged);
        cmbRegion.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(cmbRegion_SelectedIndexChanged);
    }

    private void SetObj()
    {
        //tblProfile prof = GoProGo.Data.GoProGoDC.ProfileDC.tblProfiles.First(pro => pro.UserID.ToString() == MembershipUser.ProviderUserKey.ToString());
        //This will trigger Initialize function
        //ObjProfile = prof;
        ObjProfile = SessionBag.Profile;
    }

    #region Helper Functions
    private void Initialize()
    {
        try
        {
            cmbCountry.Items.Add(new RadComboBoxItem("[Select Country]", "-1"));
            cmbCountry.AppendDataBoundItems = true;
            cmbCountry.DataSource = GoProGo.Business.Lookup.Geo.GetEnabledCountries();
            cmbCountry.DataTextField = "Country";
            cmbCountry.DataValueField = "ID";
            cmbCountry.DataBind();

            PopulateControl();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });  
        }
    }

    private void PopulateControl()
    {
        AddressLine1 = _ObjProfile.AddressLine1;
        AddressLine2 = _ObjProfile.AddressLine2;
        PostalCode = _ObjProfile.Zip;
        CountryID = _ObjProfile.CountryID == null ? -1 : (int)_ObjProfile.CountryID;
        cmbCountry_SelectedIndexChanged(null, null);
        RegionID = _ObjProfile.RegionID == null ? -1 : (int)_ObjProfile.RegionID;
        cmbRegion_SelectedIndexChanged(null, null);
        CityID = _ObjProfile.CityID == null ? -1 : (int)_ObjProfile.CityID;
        
    }

    public void SaveProfile()
    {
        try
        {
            _ObjProfile.AddressLine1 = AddressLine1;
            _ObjProfile.AddressLine2 = AddressLine2;
            _ObjProfile.Zip = PostalCode;
            _ObjProfile.CountryID = CountryID;
            _ObjProfile.RegionID = RegionID;
            _ObjProfile.CityID = CityID;

            StringBuilder address = new StringBuilder();
            _Country = cmbCountry.SelectedItem.Text;
            _City = cmbCity.SelectedItem.Text;
            _Province = cmbRegion.SelectedItem.Text;

            if (!string.IsNullOrEmpty(AddressLine1))
                address.Append(AddressLine1);
            if (!string.IsNullOrEmpty(AddressLine2))
                address.Append(", " + AddressLine2);
            if (!string.IsNullOrEmpty(_City))
                address.Append(", " + _City);
            if (!string.IsNullOrEmpty(_Province))
                address.Append(", " + _Province);
            if(string.IsNullOrEmpty(", " + _Country))
                address.Append(", " + _Country);

            Coordinate cord = Geocode.GetCoordinates(address.ToString());
            _ObjProfile.Latitude = (float)cord.Latitude;
            _ObjProfile.Longitude = (float)cord.Longitude;

            GoProGoDC.ProfileDC.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });  
        }
    } 
    #endregion

    #region Event Handlers
    void cmbCountry_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            cmbRegion.Items.Clear();
            cmbRegion.Items.Add(new RadComboBoxItem("[Select]", "-1"));
            cmbRegion.AppendDataBoundItems = true;
            cmbRegion.DataSource = GoProGo.Business.Lookup.Geo.GetRegionsByCountryID(int.Parse(cmbCountry.SelectedItem.Value));
            cmbRegion.DataTextField = "Region";
            cmbRegion.DataValueField = "ID";
            cmbRegion.DataBind();

            cmbCity.Items.Clear();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });  
        }
    }

    void cmbRegion_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            cmbCity.Items.Clear();
            cmbCity.Items.Add(new RadComboBoxItem("[Select]", "-1"));
            cmbCity.AppendDataBoundItems = true;
            cmbCity.DataSource = GoProGo.Business.Lookup.Geo.GetCitiesByRegionID(int.Parse(cmbRegion.SelectedItem.Value));
            cmbCity.DataTextField = "City";
            cmbCity.DataValueField = "ID";
            cmbCity.DataBind();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });  
        }
    } 
    #endregion

    #region Properties
    public string AddressLine1
    {
        get
        {
            return tbAddressLine1.Text.Trim();
        }
        set
        {
            tbAddressLine1.Text = value;
        }
    }
    public string AddressLine2
    {
        get
        {
            return tbAddressLine2.Text.Trim();
        }
        set
        {
            tbAddressLine2.Text = value;
        }
    }
    public string PostalCode
    {
        get
        {
            return rtbPostal.Text.Trim();
        }
        set
        {
            rtbPostal.Text = value;
        }
    }
    public int CountryID
    {
        get
        {
            return int.Parse(cmbCountry.SelectedItem.Value);
        }
        set
        {
            cmbCountry.SelectedValue = value.ToString();
        }
    }
    public int RegionID
    {
        get
        {
            return int.Parse(cmbRegion.SelectedItem.Value);
        }
        set
        {
            cmbRegion.SelectedValue = value.ToString();
        }
    }
    public int CityID
    {
        get
        {
            return int.Parse(cmbCity.SelectedItem.Value);
        }
        set
        {
            cmbCity.SelectedValue = value.ToString();
        }
    } 
    #endregion

}
