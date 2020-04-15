using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANewWebOrder;
using ANWO.Presentation;
using ANWO;
using System.Web.Security;
using ANWO.Common;

public partial class RegistrationStep1 : UserControlBase
{
    bool _IsLoaded = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterEvents();
        if (!IsPostBack)
            Initialize();
    }

    private void RegisterEvents()
    {
    }

    private void Initialize()
    {
        try
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem("[Select Country]", "-1"));
            ddlCountry.AppendDataBoundItems = true;
            ddlCountry.DataSource = DataContext.NWODC.tblPaypalCountries.ToList();
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "ID";
            ddlCountry.DataBind();
            if (!_IsLoaded)
                PopulateControl();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 1 });
        }
    }

    private void PopulateControl()
    {
        if (NWOProfile != null)
        {
            if (!IsPostBack && !_IsLoaded)
            {
                _IsLoaded = true;
                Initialize();
            }

            if (NWOProfile.CountryID > 0)
                CountryID = NWOProfile.CountryID;

            tbRegion.Text = NWOProfile.Region;
            tbCity.Text = NWOProfile.City;
            tbPhone.Text = NWOProfile.Phone1;
            tbPhone2.Text = NWOProfile.Phone2;
            tbZip.Text = NWOProfile.PostalCode;
            tbStreetAddress.Text = NWOProfile.StreetAddress;
            tbAppartment.Text = NWOProfile.Apartment;
            tbFax.Text = NWOProfile.Fax;
            tbFirstName.Text = NWOProfile.FirstName;
            tbMiddleInitial.Text = NWOProfile.MiddleInitials;
            tbLastName.Text = NWOProfile.LastName;
        }
    }

    public tblProfile SaveProfile(MembershipUser membershipUser)
    {
        try
        {
            if (!Validate())
                ThrowError(this, new ControlErrorArgs() 
                                                    { 
                                                        InnerException = new Exception("Validation Failed: One or more fields have invalid value."), 
                                                        Message = "One or more fields have invalid value.", 
                                                        Severity = 3 
                                                    });
            else
            {
                if (!IsEdit)
                {
                    PopulateProfile(membershipUser);
                    DataContext.NWODC.tblProfiles.InsertOnSubmit(NWOProfile);
                }
                else
                {
                    NWOProfile = DataContext.NWODC.tblProfiles.Where(a => a.ID == NWOProfile.ID).SingleOrDefault();
                    PopulateProfile(membershipUser);
                }
                DataContext.NWODC.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
                ThrowSuccess(this, new EventArgs());
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 1 });
        }

        return NWOProfile;
    }

    public void Rollback()
    {
        try
        {
            DataContext.NWODC.tblProfiles.DeleteOnSubmit(NWOProfile);
            DataContext.NWODC.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
        }
        catch (Exception ex)
        {
            //TODO:Log error somehow
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 1, LogOnly = true });
        }
    }

    public tblProfile GetProfile()
    {
        try
        {
            PopulateProfile();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 1 });
        }

        return NWOProfile;
    }

    private void PopulateProfile(System.Web.Security.MembershipUser user = null)
    {
        NWOProfile.StreetAddress = StreetAddress;
        NWOProfile.Apartment = Appartment;
        NWOProfile.City = City;
        NWOProfile.CountryID = CountryID;
        NWOProfile.Fax = Fax;
        NWOProfile.FirstName = FirstName;
        NWOProfile.MiddleInitials = MI;
        NWOProfile.LastName = LastName;
        NWOProfile.PostalCode = Zip;
        NWOProfile.Phone1 = Phone;
        NWOProfile.Region = Region;
        NWOProfile.Phone2 = Phone2;

        if (NWOProfile.ID == 0)
        {
            NWOProfile.CreatedDate = DateTime.Now;
        }

        if (user != null)
            NWOProfile.UserID = new Guid(user.ProviderUserKey.ToString());
    }

    public bool Validate()
    {
        if (string.IsNullOrEmpty(City)  || string.IsNullOrEmpty(Region)  || CountryID < 1 || string.IsNullOrEmpty(StreetAddress) || string.IsNullOrEmpty(Phone) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || !Page.IsValid)
            return false;
        else
            return true;
    }

    private tblProfile _NWOProfile;
    public tblProfile NWOProfile
    {
        get
        {
            if (_NWOProfile == null)
                _NWOProfile = new tblProfile();
            return _NWOProfile;
        }
        set
        {
            _NWOProfile = value;
            if (!IsPostBack)
                PopulateControl();
        }
    }

    private void LoadDataFromProfile()
    {
        tblProfile prof = SessionBag.Profile;
        if (prof != null)
        {
            Phone = prof.Phone1;
            Phone2 = prof.Phone2;
            Fax = prof.Fax;
            StreetAddress = prof.StreetAddress;
            Appartment = prof.Apartment;
            CountryID = prof.CountryID;
            Region = prof.Region;
            City = prof.City;
            Zip = prof.PostalCode;
            FirstName = prof.FirstName;
            MI = prof.MiddleInitials;
            LastName = prof.LastName;
        }
    }

    #region Properties

    public string Phone
    {
        get
        {
            return tbPhone.Text.Trim();
        }
        set
        {
            tbPhone.Text = value;
        }
    }
    public string Phone2
    {
        get
        {
            return tbPhone2.Text.Trim();
        }
        set
        {
            tbPhone2.Text.Trim();
        }
    }

    public string Zip
    {
        get
        {
            return tbZip.Text.Trim();
        }
        set
        {
            tbZip.Text = value;
        }
    }
    public string StreetAddress
    {
        get
        {
            return tbStreetAddress.Text.Trim();
        }
        set
        {
            tbStreetAddress.Text = value;
        }
    }
    public string Appartment
    {
        get
        {
            return tbAppartment.Text.Trim();
        }
        set
        {
            tbAppartment.Text = value;
        }
    }
    public string Fax
    {
        get
        {
            return tbFax.Text.Trim();
        }
        set
        {
            tbFax.Text = value;
        }
    }
    public string FirstName
    {
        get
        {
            return tbFirstName.Text.Trim();
        }
        set
        {
            tbFirstName.Text = value;
        }
    }

    public string MI
    {
        get
        {
            return tbMiddleInitial.Text.Trim();
        }
        set
        {
            tbMiddleInitial.Text = value;
        }
    }

    public string LastName
    {
        get
        {
            return tbLastName.Text.Trim();
        }
        set
        {
            tbLastName.Text = value;
        }
    }

    public string City
    {
        get
        {
            return tbCity.Text.Trim();
        }
        set
        {
            tbCity.Text = value;

        }
    }
    public string Region
    {
        get
        {
            return tbRegion.Text.Trim();
        }
        set
        {
            tbRegion.Text = value;
        }
    }
    public int CountryID
    {
        get
        {
            if (string.IsNullOrEmpty(ddlCountry.SelectedValue))
                return 0;
            return Convert.ToInt32(ddlCountry.SelectedValue);
        }
        set
        {
            ddlCountry.SelectedValue = value.ToString();
        }
    }

    private bool _IsEdit;
    public bool IsEdit
    {
        get
        {
            return _IsEdit;
        }
        set
        {
            _IsEdit = value;
        }
    }
    #endregion

}