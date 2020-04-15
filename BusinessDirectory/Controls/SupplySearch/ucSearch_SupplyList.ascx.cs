using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data;
using System.ComponentModel;
using System.Data;
using GoProGo.Data.Entity.Profile;
using Telerik.Web.UI;
using System.IO;
using GoProGo.Data.Entity.Geo;
using GoProGo.Utility;

public partial class ucSearch_FreeSupplyList : UserControlBase
{
    bool _IsDatasourceProbable = true;

    string _CityID = string.Empty;
    string _CategoryID = string.Empty;
    string _Type = string.Empty;
    string _Latitude = string.Empty;
    string _Longitude = string.Empty;
    string _IsKilometer = string.Empty;

    string _ProfileAddress = string.Empty;

    SearchControlType _SearchControlType = SearchControlType.Undefined;
    int _CtyID = 0;
    int _CatID = 0;
    decimal _Lat = 0;
    decimal _Lon = 0;
    bool _IsKM = true;

    private const string PICTURE_HANDLER = @"~\PublicFile.ashx?ProfPicture=";

    //For CategoryBrowsing and CategorySearch
    public int CategoryID { get; set; }
    public int CityID { get; set; }
    //For MainSearch, CategorySearch, DistanceSearch
    public string SearchString { get; set; }
    //For DistanceSearch
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsKilometer { get; set; }
    //For NameSearch
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        SearchString = Request.QueryString["Str"];
        _Type = Request.QueryString["Type"];

        _CityID = Request.QueryString["CityID"];
        _CategoryID = Request.QueryString["CategoryID"];
        _Latitude = Request.QueryString["Lat"];
        _Longitude = Request.QueryString["Long"];
        _IsKilometer = Request.QueryString["IsKM"];

        FirstName = Request.QueryString["FirstName"];
        LastName = Request.QueryString["LastName"];

        ParseProperties();
        if (!IsPostBack)
            PopulateControl();
    }

    private void PopulateControl()
    {
        rtbSearch.Text = SearchString;
    }

    private void ParseProperties()
    {
        try
        {
            _SearchControlType = (SearchControlType)Enum.Parse(typeof(SearchControlType), _Type);

            switch (_SearchControlType)
            {
                case SearchControlType.CategoryBrowsing:
                    if (int.TryParse(_CityID, out _CtyID) && int.TryParse(_CategoryID, out _CatID))
                    {
                        CityID = _CtyID;
                        CategoryID = _CatID;
                        pnlSearch.Visible = false;
                    }
                    break;
                case SearchControlType.CategorySearch:
                    if (int.TryParse(_CityID, out _CtyID) && int.TryParse(_CategoryID, out _CatID))
                    {
                        CityID = _CtyID;
                        CategoryID = _CatID;
                    }
                    break;
                case SearchControlType.DistanceSearch:
                    if (int.TryParse(_CityID, out _CtyID) && decimal.TryParse(_Latitude, out _Lat) && decimal.TryParse(_Longitude, out _Lon) && bool.TryParse(_IsKilometer, out _IsKM))
                    {
                        CityID = _CtyID;
                        CategoryID = _CatID;
                        Latitude = (double)_Lat;
                        Longitude = (double)_Lon;
                        IsKilometer = _IsKM;
                    }
                    break;
                case SearchControlType.MainSearch:
                    if (int.TryParse(_CityID, out _CtyID))
                        CityID = _CtyID;
                    break;
                case SearchControlType.NameSearch:
                    if (int.TryParse(_CityID, out _CtyID))
                    {
                        CityID = _CtyID;
                        pnlSearch.Visible = false;
                    }
                    break;
                case SearchControlType.Undefined:
                    break;
                default:
                    break;
            }
            _IsDatasourceProbable = true;
        }
        catch (Exception ex)
        {
            _IsDatasourceProbable = false;
            pnlSearch.Visible = false;
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Please provide valid parameters.", Severity = 5 });
        }
    }

    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GiveSourceToGrid(false);
    }

    private void GiveSourceToGrid(bool isBind)
    {
        try
        {
            if (_IsDatasourceProbable)
            {
                int rowNum = RadGrid1.CurrentPageIndex + 1;
                int pageSize = RadGrid1.MasterTableView.PageSize;
                int? totalRowCount = 0;

                switch (_SearchControlType)
                {
                    case SearchControlType.Undefined:
                        ThrowError(this, new ControlErrorArgs() { Message = "Search type Invalid.", Severity = 6 });
                        break;
                    case SearchControlType.CategoryBrowsing:
                        {
                            List<vwSearchEnt> source = GoProGoDC.SearchDC.ProfileByCategoryAndCityID
                                (
                                    CategoryID,
                                    CityID,
                                    rowNum,
                                    pageSize,
                                    ref totalRowCount
                                 ).ToList();

                            RadGrid1.VirtualItemCount = (int)totalRowCount;
                            RadGrid1.DataSource = source;
                            if (isBind) RadGrid1.DataBind();
                        }
                        break;
                    case SearchControlType.MainSearch:
                        {
                            List<vwSearchEnt> source = GoProGoDC.SearchDC.ProfileSearchMain
                                (
                                    Common.MakeSearchCriteria(SearchString),
                                    CityID,
                                    rowNum,
                                    pageSize,
                                    ref totalRowCount
                                    ).ToList();
                            RadGrid1.VirtualItemCount = (int)totalRowCount;
                            RadGrid1.DataSource = source;
                            if (isBind) RadGrid1.DataBind();
                        }
                        break;
                    case SearchControlType.NameSearch:
                        {
                            List<vwSearchEnt> source = GoProGoDC.SearchDC.ProfileSearchName
                                   (
                                       FirstName,
                                       LastName,
                                       CityID,
                                       rowNum,
                                       pageSize,
                                       ref totalRowCount
                                   ).ToList();
                            RadGrid1.VirtualItemCount = (int)totalRowCount;
                            RadGrid1.DataSource = source;
                            if (isBind) RadGrid1.DataBind();
                        }
                        break;
                    case SearchControlType.CategorySearch:
                        {
                            List<vwSearchEnt> source = GoProGoDC.SearchDC.ProfileSearchCategory
                                   (
                                       Common.MakeSearchCriteria(SearchString),
                                       CategoryID,
                                       CityID,
                                       rowNum,
                                       pageSize,
                                       ref totalRowCount
                                   ).ToList();
                            RadGrid1.VirtualItemCount = (int)totalRowCount;
                            RadGrid1.DataSource = source;
                            if (isBind) RadGrid1.DataBind();
                        }
                        break;
                    case SearchControlType.DistanceSearch:
                        {
                            List<vwSearchEnt> source = GoProGoDC.SearchDC.ProfileSearchDistance
                                   (
                                       SearchString,
                                       Latitude,
                                       Longitude,
                                       IsKilometer,
                                       CityID,
                                       rowNum,
                                       pageSize,
                                       ref totalRowCount
                                   ).ToList();
                            RadGrid1.VirtualItemCount = (int)totalRowCount;
                            RadGrid1.DataSource = source;
                            if (isBind) RadGrid1.DataBind();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Search robot is having problem. Please re-try.", Severity = 1 });
        }
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if ((e.Item) is GridDataItem)
        {
            vwSearchEnt ent = (vwSearchEnt)e.Item.DataItem;
            GridDataItem item = (GridDataItem)e.Item;

            Image image = (Image)item["Header"].FindControl("Image1");
            HyperLink hlNameCategory = (HyperLink)item["Header"].FindControl("hlNameCategory");
            Label lblCategory = (Label)item["Header"].FindControl("lblCategory");
            Label lblMinRate = (Label)item["Header"].FindControl("lblMinRate");
            Label lblSlogan = (Label)item["Header"].FindControl("lblSlogan");
            Label lblDescription = (Label)item["Header"].FindControl("lblDescription");
            Label lblLocation = (Label)item["Header"].FindControl("lblLocation");
            Label lblDistance = (Label)item["Header"].FindControl("lblDistance");
            HyperLink hlMapit = (HyperLink)item["Header"].FindControl("hlMapit");
            RadRating RadRating1 = (RadRating)item["Header"].FindControl("RadRating1");
            Label lblReviewCount = (Label)item["Header"].FindControl("lblReviewCount");

            if (image != null)
                image.ImageUrl = GetPicturePath(ent.SmallProfilePicture);

            if (hlNameCategory != null)
            {
                hlNameCategory.Text = string.Format("<strong>{0} {1}</strong> ({2})", ent.FirstName, ent.LastName, ent.CategoryName);
                hlNameCategory.NavigateUrl = string.Format("~/PersonSupply.aspx?ProfileID={0}", ent.ID);
            }

            if (lblMinRate != null)
                lblMinRate.Text = string.Format("{0} ({1})/{2} ", ent.MinimumRate, ent.CurrencyCode, ent.JobUnitName);

            if (lblSlogan != null)
                lblSlogan.Text = ent.Slogan;

            if (lblDescription != null)
                lblDescription.Text = ent.ProfileDescription;

            if (lblLocation != null)
                lblLocation.Text = string.Format("{0}, {1}", ent.City, ent.Region);

            if (lblDistance != null)
            {
                if (ent.Distance > 0)
                    lblDistance.Text = string.Format("{0} {1} ({2})", "Approx. ", ent.Distance, (IsKilometer ? "KM" : "Mile"));
                else
                    lblDistance.Visible = false;
            }

            if (RadRating1 != null)
            {
                if (ent.ReviewScore != null && ent.ReviewCount != null)
                {
                    RadRating1.Value = Double.Parse(ent.ReviewScore.ToString());
                    RadRating1.ToolTip = string.Format("Avg. Score: {0}", ent.ReviewScore.ToString());
                    lblReviewCount.Text = string.Format("({0} reviews)", ent.ReviewCount.ToString());
                }
                else
                {
                    RadRating1.Value = 0;
                    RadRating1.ToolTip = string.Format("Avg. Score: 0");
                    lblReviewCount.Text = string.Format("(0 reviews)");
                }
            }

            if (hlMapit != null)
            {
                _ProfileAddress = string.Format("{0} {1},{2},{3},{4}", ent.AddressLine1, ent.AddressLine2, ent.City, ent.Region, ent.Country);
                _ProfileAddress = "http://mapof.it/" + _ProfileAddress;
                hlMapit.NavigateUrl = _ProfileAddress;
                hlMapit.Target = "_blank";
            }
        }
    }

    private string GetPicturePath(string normalFullName)
    {
        //if picture is not found then load simple picture from website
        return PICTURE_HANDLER + Path.GetFileName(normalFullName);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchString = rtbSearch.Text.Trim();
        GiveSourceToGrid(true);
    }
}

public enum SearchControlType
{
    Undefined = 0,
    CategoryBrowsing = 1,
    MainSearch = 2,
    NameSearch = 3,
    CategorySearch = 4,
    DistanceSearch = 5
}
