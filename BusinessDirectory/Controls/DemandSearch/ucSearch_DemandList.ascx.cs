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
using System.Globalization;

public partial class ucSearch_FreeSupplyList : UserControlBase
{
    bool _IsDatasourceProbable = true;
    List<tlkpDemandType> _DemandTypes = GoProGo.Business.Lookup.Profile.GetAllDemandTypes();

    string _CityID = string.Empty;
    string _CategoryID = string.Empty;
    string _DemandTypeID = string.Empty;
    string _Type = string.Empty;

    string _ProfileAddress = string.Empty;

    SearchControlType _SearchControlType = SearchControlType.Undefined;
    int _CtyID = 0;
    int _CatID = 0;
    int _DmdTyp = 0;

    //For CategoryBrowsing and CategorySearch
    public int CategoryID { get; set; }
    public int CityID { get; set; }
    public int DemandTypeID { get; set; }
    //For MainSearch, CategorySearch, DistanceSearch
    public string SearchString { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        SearchString = Request.QueryString["Str"];
        _Type = Request.QueryString["Type"];

        _CityID = Request.QueryString["CityID"];
        _CategoryID = Request.QueryString["CategoryID"];
        _DemandTypeID = Request.QueryString["DemandTypeID"];

        _DemandTypes = GoProGo.Business.Lookup.Profile.GetAllDemandTypes();

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
                case SearchControlType.MainSearch:
                    if (int.TryParse(_CityID, out _CtyID))
                        CityID = _CtyID;
                    break;
                case SearchControlType.DemandType:
                    if (int.TryParse(_CityID, out _CtyID) && int.TryParse(_DemandTypeID, out _DmdTyp))
                    {
                        CityID = _CtyID;
                        DemandTypeID = _DmdTyp;
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
                            List<vwDemandSearchEnt> source = GoProGoDC.SearchDC.DemandByCityIDAndCategoryID
                                            (
                                                CityID,
                                                CategoryID,
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
                            List<vwDemandSearchEnt> source = GoProGoDC.SearchDC.DemandSearchMain
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
                    case SearchControlType.CategorySearch:
                        {
                            List<vwDemandSearchEnt> source = GoProGoDC.SearchDC.DemandSearchCategory
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
                    case SearchControlType.DemandType:
                        {
                            List<vwDemandSearchEnt> source = GoProGoDC.SearchDC.DemandSearchDemandType
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
            CultureInfo cultInfo = new CultureInfo(this.SessionBag.UserBrowsingInfo.CultureCode);
            vwDemandSearchEnt ent = (vwDemandSearchEnt)e.Item.DataItem;
            GridDataItem item = (GridDataItem)e.Item;

            Label lblJobType = (Label)item["Header"].FindControl("lblJobType");
            HyperLink hlTitle = (HyperLink)item["Header"].FindControl("hlTitle");
            Label lblDescription = (Label)item["Header"].FindControl("lblDescription");
            Label lblLocation = (Label)item["Header"].FindControl("lblLocation");
            Label lblCategory = (Label)item["Header"].FindControl("lblCategory");
            Label lblPostDate = (Label)item["Header"].FindControl("lblPostDate");
            Label lblPostExpiry = (Label)item["Header"].FindControl("lblPostExpiry");
            Label lblBudget = (Label)item["Header"].FindControl("lblBudget");

            //Put demand type infront of Title in brackets.
            if (hlTitle != null)
            {
                hlTitle.Text = ent.Title;
                hlTitle.NavigateUrl = string.Format("~/PersonDemand.aspx?ProfileID={0}&DemandID={1}", ent.ProfileID, ent.ID);
            }

            if (lblDescription != null)
                lblDescription.Text = ent.DescriptionPlainText;

            if (lblLocation != null)
                lblLocation.Text = string.Format("{0}, {1}", ent.CityName, ent.RegionName);

            if (lblCategory != null)
                lblCategory.Text = ent.CategoryName;

            if (lblJobType != null)
                lblJobType.Text = ent.DemandTypeName;

            if (lblPostDate != null)
                lblPostDate.Text = ent.CreatedDate.ToString("d", cultInfo);

            if (lblPostExpiry != null)
                lblPostExpiry.Text = ent.EndTime.ToString("d", cultInfo);

            if (lblBudget != null)
                lblBudget.Text = ent.MinBudget.ToString() + " - " + ent.MaxBudget + " " + ent.CurrencyCode + " /" + ent.JobUnit;

            //if(lblPostDate != null)
            //lblPostDate.Text = DateTime.Parse(ent.Tim


        }
    }

    private string GetPicturePath(int demandTypeID)
    {
        return _DemandTypes.First(a => a.ID == demandTypeID).Image;
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
    MainSearch = 1,
    CategoryBrowsing = 2,
    CategorySearch = 3,
    DemandType = 4,
}
