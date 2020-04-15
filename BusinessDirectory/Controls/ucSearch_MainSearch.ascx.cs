using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Utility;
using Telerik.Web.UI;
using GoProGo.Data.Entity.Geo;
using GoProGo.Data;
using GoProGo.Business.GoogleGeoCoder;

public partial class Controls_ucSearch_MainSearch : UserControlBase
{
    string _Country = string.Empty;
    string _City = string.Empty;
    string _Province = string.Empty;
    const string _STR_MAINSEARCHOPT = "MainSearchOption";
    const string _STR_SELECTEDMENUOPT = "SelectedMenuOption";

    private UserLocalInfo _UserBrowsingInfo;
    public UserLocalInfo UserBrowsingInfo
    {
        get
        {
            return _UserBrowsingInfo;
        }
        set
        {
            _UserBrowsingInfo = value;
            if (!IsPostBack)
                Initialize();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //To let Binding Expression work
        pnlScript.DataBind();
        RegisterEvents();
        SetObj();

        this.Page.Form.DefaultButton = btnSearch.UniqueID;
    }

    protected void Main_SearchOptions(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie(_STR_MAINSEARCHOPT);
        //Set the cookies value
        if (rbServiceProviders.Checked == true)
            cookie.Value = "0";
        else
            cookie.Value = "1";
        //Set the cookie to expire in 1 year
        DateTime dtNow = DateTime.Now;
        TimeSpan tsDays = new TimeSpan(365, 0, 0, 0);
        cookie.Expires = dtNow + tsDays;
        //Add the cookie
        Response.Cookies.Add(cookie);

        //Routine to set which menu to show
        ShowSelectedMenu();

    }

    private void ShowSelectedMenu()
    {
        if (rbServiceProviders.Checked)
        {
            tbMainSearch.EmptyMessage = "e.g. Plumer, Tutor, Dentist, Accountant, Lawyer, Web Developer, Painter...";
            tbCategorySearch.EmptyMessage = "e.g. Plumer, Tutor, Dentist, Accountant...";
            tbDemandTypeSearch.EmptyMessage = "e.g. Plumer, Tutor, Dentist, Accountant...";
            pnlSupplyMenu.Visible = true;
            pnlDemandMenu.Visible = false;
            rmSupplyOptions.Items[0].Selected = true;
            SetSupplyCriteriaControls("Main Search");
        }
        else
        {
            tbMainSearch.EmptyMessage = "e.g. Tutoring, Swimming Lessons, Body Work, Driving Lessons, Paint Job...";
            tbCategorySearch.EmptyMessage = "e.g. Tutoring, Driving Lessons...";
            tbDemandTypeSearch.EmptyMessage = "e.g. Tutoring, Driving Lessons...";
            pnlDemandMenu.Visible = true;
            pnlSupplyMenu.Visible = false;
            rmDemandOptions.Items[0].Selected = true;
            SetDemandCriteriaControls("Main Search");
        }
    }

    private void RegisterEvents()
    {
        cmbCountry.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(cmbCountry_SelectedIndexChanged);
        cmbRegion.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(cmbRegion_SelectedIndexChanged);
    }

    void cmbRegion_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            cmbCity.Items.Clear();
            cmbCity.Items.Add(new RadComboBoxItem("[Select City]", "-1"));
            cmbCity.AppendDataBoundItems = true;
            cmbCity.DataSource = GoProGo.Business.Lookup.Geo.GetCitiesByRegionID(int.Parse(cmbRegion.SelectedItem.Value));
            cmbCity.DataTextField = "City";
            cmbCity.DataValueField = "ID";
            cmbCity.DataBind();

            if (!IsPostBack)
            {
                tblCity city = GoProGoDC.GeoDC.GetCityByRegionAndCity(int.Parse(cmbRegion.SelectedItem.Value), UserBrowsingInfo.City).SingleOrDefault<tblCity>();
                if (city != null)
                    cmbCity.SelectedValue = city.ID.ToString();
                else
                    cmbCategory.SelectedIndex = 0;
                //TODO: Log this situation
                //throw new Exception("City can not be null.");
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 1 });
        }
    }

    void cmbCountry_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            cmbRegion.Items.Clear();
            cmbRegion.Items.Add(new RadComboBoxItem("[Select Region]", "-1"));
            cmbRegion.AppendDataBoundItems = true;
            cmbRegion.DataSource = GoProGo.Business.Lookup.Geo.GetRegionsByCountryID(int.Parse(cmbCountry.SelectedItem.Value));
            cmbRegion.DataTextField = "Region";
            cmbRegion.DataValueField = "ID";
            cmbRegion.DataBind();

            cmbCity.Items.Clear();
            if (!IsPostBack)
            {
                tblRegion region = GoProGoDC.GeoDC.GetRegionByCountryAndRegion(int.Parse(cmbCountry.SelectedItem.Value), UserBrowsingInfo.RegionName.ToLower()).SingleOrDefault<tblRegion>(); //GoProGo.Business.Lookup.Geo.GetRegionsByCountryID(int.Parse(cmbCountry.SelectedItem.Value)).Where(a => a.Region.ToLower().Equals(UserBrowsingInfo.RegionName.ToLower())).SingleOrDefault<tblRegion>();
                if (region != null)
                    cmbRegion.SelectedValue = region.ID.ToString();
                else
                    cmbRegion.SelectedIndex = 0;
                //TODO: Log this situation
                //throw new Exception("Region can not be null.");
            }

            cmbRegion_SelectedIndexChanged(null, null);
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });
        }
    }

    private void SetObj()
    {
        UserBrowsingInfo = SessionBag.UserBrowsingInfo;
    }
    private void Initialize()
    {
        ReadUserPrefFromCookie();

        cmbCountry.Items.Clear();
        cmbCountry.Items.Add(new RadComboBoxItem("[Select Country]", "-1"));
        cmbCountry.AppendDataBoundItems = true;
        cmbCountry.DataSource = GoProGo.Business.Lookup.Geo.GetEnabledCountries();
        cmbCountry.DataTextField = "Country";
        cmbCountry.DataValueField = "ID";
        cmbCountry.DataBind();

        cmbRegion.Items.Clear();

        tblCountry country = GoProGo.Business.Lookup.Geo.GetEnabledCountries().Where(a => a.Country.ToLower().Equals(UserBrowsingInfo.Country.ToLower())).SingleOrDefault<tblCountry>();
        if (country != null)
            cmbCountry.SelectedValue = country.ID.ToString();
        else
            cmbCountry.SelectedIndex = 0;

        cmbCountry_SelectedIndexChanged(null, null);

    }

    private void ReadUserPrefFromCookie()
    {
        //Grab the cookie
        HttpCookie cookie = Request.Cookies[_STR_MAINSEARCHOPT];

        //Check to make sure the cookie exists
        if (cookie != null)
        {
            //Write the cookie value
            String strCookieValue = cookie.Value.ToString();
            if (strCookieValue.Equals("0"))
                rbServiceProviders.Checked = true;
            else
                rbServiceTakers.Checked = true;
        }
        else
        {
            rbServiceProviders.Checked = true;
        }
        //Decide which menu to show based on RadioButton checked
        ShowSelectedMenu();
    }
    protected void rmSupplyOptions_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
    {
        SetSupplyCriteriaControls(e.Item.Text);
    }

    private void SetSupplyCriteriaControls(string optionClicked)
    {
        switch (optionClicked)
        {
            case "Main Search":
                pnlDemandType.Visible = false;
                pnlCategorySearch.Visible = false;
                pnlDistanceSearch.Visible = false;
                pnlNameSearch.Visible = false;
                pnlMainSearch.Visible = true;
                break;
            case "Name Search":
                pnlDemandType.Visible = false;
                pnlCategorySearch.Visible = false;
                pnlDistanceSearch.Visible = false;
                pnlNameSearch.Visible = true;
                pnlMainSearch.Visible = false;
                break;
            case "Category Search":
                pnlDemandType.Visible = false;
                pnlCategorySearch.Visible = true;
                pnlDistanceSearch.Visible = false;
                pnlNameSearch.Visible = false;
                pnlMainSearch.Visible = false;
                PopulateCategory();
                break;
            case "Distance Search":
                pnlDemandType.Visible = false;
                pnlCategorySearch.Visible = false;
                pnlDistanceSearch.Visible = true;
                pnlNameSearch.Visible = false;
                pnlMainSearch.Visible = false;
                break;
            default:
                break;
        }
    }

    protected void rmDemandOptions_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
    {
        SetDemandCriteriaControls(e.Item.Text);
    }
    private void SetDemandCriteriaControls(string optionClicked)
    {
        switch (optionClicked)
        {
            case "Main Search":
                pnlCategorySearch.Visible = false;
                pnlDistanceSearch.Visible = false;
                pnlNameSearch.Visible = false;
                pnlDemandType.Visible = false;
                pnlMainSearch.Visible = true;
                break;
            case "Category Search":
                pnlCategorySearch.Visible = true;
                pnlDistanceSearch.Visible = false;
                pnlNameSearch.Visible = false;
                pnlDemandType.Visible = false;
                pnlMainSearch.Visible = false;
                PopulateCategory();
                break;
            case "Demand Type Search":
                pnlDemandType.Visible = true;
                pnlCategorySearch.Visible = false;
                pnlDistanceSearch.Visible = false;
                pnlNameSearch.Visible = false;
                pnlMainSearch.Visible = false;
                PopulateDemandType();
                break;
            default:
                break;
        }
    }

    private void PopulateDemandType()
    {
        cmbDemandType.Items.Clear();
        cmbDemandType.Items.Add(new RadComboBoxItem("[Select]", "-1"));
        cmbDemandType.AppendDataBoundItems = true;
        cmbDemandType.DataSource = GoProGo.Business.Lookup.Profile.GetAllDemandTypes();
        cmbDemandType.DataTextField = "Name";
        cmbDemandType.DataValueField = "ID";
        cmbDemandType.DataBind();
    }

    private void PopulateCategory()
    {
        cmbCategory.Items.Clear();
        cmbCategory.Items.Add(new RadComboBoxItem("[Select]", "-1"));
        cmbCategory.AppendDataBoundItems = true;
        cmbCategory.DataSource = GoProGo.Business.Lookup.Profile.GetAllCategories();
        cmbCategory.DataTextField = "Name";
        cmbCategory.DataValueField = "ID";
        cmbCategory.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (rbServiceProviders.Checked)
        {
            if (rmSupplyOptions.SelectedItem.Text.Equals("Main Search"))
            {
                if (tbMainSearch.Text.Trim().Length > 1 && cmbCity.SelectedItem != null)
                {
                    Response.Redirect(string.Format("~/ServiceBrowsing/CategoryCityList.aspx?CityID={0}&Str={1}&Type=MainSearch", cmbCity.SelectedItem.Value, tbMainSearch.Text.Trim()));
                }
                else
                {
                    ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Search is too general.", Severity = 6 });
                }
            }
            else if (rmSupplyOptions.SelectedItem.Text.Equals("Name Search"))
            {
                if (tbFirstName.Text.Trim().Length > 0 && tbLastName.Text.Trim().Length > 0 && cmbCity.SelectedItem != null)
                {
                    Response.Redirect(string.Format("~/ServiceBrowsing/CategoryCityList.aspx?CityID={0}&FirstName={1}&LastName={2}&Type=NameSearch", cmbCity.SelectedItem.Value, tbFirstName.Text.Trim(), tbLastName.Text.Trim()));
                }
                else
                {
                    ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Please provide full name.", Severity = 6 });
                }
            }
            else if (rmSupplyOptions.SelectedItem.Text.Equals("Category Search"))
            {
                if (cmbCategory.SelectedItem != null && tbCategorySearch.Text.Trim().Length > 1 && cmbCity.SelectedItem != null)
                {
                    Response.Redirect(string.Format("~/ServiceBrowsing/CategoryCityList.aspx?CityID={0}&Str={1}&CategoryID={2}&Type=CategorySearch", cmbCity.SelectedItem.Value, tbCategorySearch.Text.Trim(), cmbCategory.SelectedItem.Value));
                }
                else
                {
                    ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Search is too general.", Severity = 6 });
                }
            }
            else if (rmSupplyOptions.SelectedItem.Text.Equals("Distance Search"))
            {
                if (tbDistanceSearch.Text.Trim().Length > 1 && tbZip.Text.Trim().Length > 2 && cmbCity.SelectedItem != null && cmbCountry.SelectedValue != null)
                {
                    //Check if the country is allowed for zip code search, if country is not allowed then simply throw
                    //user error that zip code search is not available in your area.
                    //try to get coordinates for zip code including country, region and city
                    tblCountry cou = GoProGo.Business.Entities.Geo.GetCountryByID(int.Parse(cmbCountry.SelectedValue));
                    Coordinate cord = Geocode.GetCoordinates(string.Format("{0},{1},{2}", tbZip.Text.Trim(), cmbCity.SelectedItem.Text, cmbCountry.SelectedItem.Text));

                    if (cou != null && cou.IsZipSearchAllowed == true)
                    {
                        Response.Redirect(string.Format("~/ServiceBrowsing/CategoryCityList.aspx?CityID={0}&Str={1}&IsKM={2}&Lat={3}&Long={4}&Type=DistanceSearch",
                                                            cmbCity.SelectedItem.Value,
                                                            tbDistanceSearch.Text.Trim(),
                                                            GoProGo.Business.Entities.Geo.IsCountryKM(cou).ToString(),
                                                            cord.Latitude.ToString(),
                                                            cord.Longitude.ToString()
                                                        ));
                    }
                    else
                    {
                        ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Country is not allowed for Zip/Postal Code search." });
                    }
                }
                else
                {
                    ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Search is too general.", Severity = 6 });
                }
            }
            else
            {
                ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Please select a City.", Severity = 6 });
            }
        }
        else
        {
            if (rmSupplyOptions.SelectedItem.Text.Equals("Main Search"))
            {
                if (tbMainSearch.Text.Trim().Length > 1 && cmbCity.SelectedItem != null)
                {
                    Response.Redirect(string.Format("~/DemandBrowsing/CategoryCityList.aspx?CityID={0}&Str={1}&Type=MainSearch", cmbCity.SelectedItem.Value, tbMainSearch.Text.Trim()));
                }
                else
                {
                    ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Search is too general.", Severity = 6 });
                }
            }
            else if (rmSupplyOptions.SelectedItem.Text.Equals("Category Search"))
            {
                if (cmbCategory.SelectedItem != null && tbCategorySearch.Text.Trim().Length > 1 && cmbCity.SelectedItem != null)
                {
                    Response.Redirect(string.Format("~/DemandBrowsing/CategoryCityList.aspx?CityID={0}&Str={1}&CategoryID={2}&Type=CategorySearch", cmbCity.SelectedItem.Value, tbCategorySearch.Text.Trim(), cmbCategory.SelectedItem.Value));
                }
                else
                {
                    ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Search is too general.", Severity = 6 });
                }
            }
            else if (rmSupplyOptions.SelectedItem.Text.Equals("Demand Type Search"))
            {
                if (cmbDemandType.SelectedItem != null && tbDemandTypeSearch.Text.Trim().Length > 1 && cmbCity.SelectedItem != null)
                {
                    Response.Redirect(string.Format("~/DemandBrowsing/CategoryCityList.aspx?CityID={0}&Str={1}&DemandTypeID={2}&Type=CategorySearch", cmbCity.SelectedItem.Value, tbCategorySearch.Text.Trim(), cmbDemandType.SelectedItem.Value));
                }
                else
                {
                    ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Search is too general.", Severity = 6 });
                }
            }

        }
    }
}
