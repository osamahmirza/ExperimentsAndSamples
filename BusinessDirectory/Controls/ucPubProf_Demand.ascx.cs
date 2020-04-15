using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;
using Telerik.Web.UI;
using GoProGo.Data;

public partial class Controls_ucPubProf_Demand : UserControlBase
{
    private string _Keywords;
    private string _Description;
    private int _DemandID;
    //Based on the populating this property
    //we will decide which panel to show and which to not.
    //NOTE: DemandID should be set prior to setting ObjProfile.
    public int DemandID
    {
        get
        {
            return _DemandID;
        }
        set
        {
            _DemandID = value;
        }
    }

    private void SwapPanels(bool isDemand)
    {
        pnlDemand.Visible = isDemand;
        pnlDemandList.Visible = (isDemand ^ true);
    }

    private tblProfile _ObjProfile;
    //NOTE: DemandID must be set prior to ObjProfile
    public tblProfile ObjProfile
    {
        get
        {
            return _ObjProfile;
        }
        set
        {
            _ObjProfile = value;
            StartWF();
        }
    }

    private void StartWF()
    {
        if (!IsPostBack)
            PopulateControls();
    }

    private void PopulateControls()
    {
        try
        {
            lnkBackToList.NavigateUrl = "~/PersonDemand.aspx?ProfileID=" + ObjProfile.ID;
            if (DemandID <= 0)
            {
                SwapPanels(false);
                GiveSourceToGrid(true);
            }
            else
            {
                SwapPanels(true);
                vwDemand demand = GoProGoDC.ProfileDC.GetDemandByID(DemandID).SingleOrDefault();
                tblDemand demandDesc = GoProGoDC.ProfileDC.GetDemandDescriptionByID(DemandID).SingleOrDefault();
                if (demand != null)
                {
                    lblTitle.Text = demand.Title;
                    //TODO: Format date according to browser settings
                    lblPostDate.Text = demand.PostedDate.ToShortDateString();
                    lblEndDate.Text = demand.PostingEndDate.ToShortDateString();
                    lblDemandType.Text = demand.DemandTypeName;
                    lblBudget.Text = string.Format("{0} - {1} per {2}", demand.MinimumBudget.ToString(), demand.MaxBudget.ToString(), demand.JobUnitName);
                    lblLocation.Text = string.Format("{0}, {1}", demand.LocationCity, demand.LocationCountry);
                    lblDemandDescription.Text = demandDesc.Description;
                    _Description = demandDesc.Description.Substring(0, demandDesc.Description.Length > 200 ? 200 : demandDesc.Description.Length);
                    _Keywords = demandDesc.SearchTags;
                }
                else
                {
                    throw new Exception(string.Format("Invalid DemandID {0}.", DemandID));
                }
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Can not load demand(s).", Severity = 3 });
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        AddKeywordsAndDescription(this, new KeywordAndDescriptionArgs() { Description = _Description, Keyword = _Keywords });
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {
        Page.LoadComplete += new EventHandler(Page_LoadComplete);
    }
    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GiveSourceToGrid(false);
    }
    private void GiveSourceToGrid(bool isBind)
    {
        try
        {
            int rowNum = RadGrid1.CurrentPageIndex + 1;
            int pageSize = RadGrid1.MasterTableView.PageSize;
            int? totalRowCount = 0;

            List<vwDemand> source = GoProGoDC.ProfileDC.GetDemandByProfileID(ObjProfile.ID, rowNum, pageSize, ref totalRowCount).ToList();
            RadGrid1.VirtualItemCount = (int)totalRowCount;
            RadGrid1.DataSource = source;
            if (isBind) RadGrid1.DataBind();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Can not load review(s).", Severity = 1 });
        }
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if ((e.Item) is GridDataItem)
        {
            vwDemand ent = (vwDemand)e.Item.DataItem;
            GridDataItem item = (GridDataItem)e.Item;

            Label lblTitle = (Label)item["Header"].FindControl("lblTitle");
            Label lblPostDate = (Label)item["Header"].FindControl("lblPostDate");
            Label lblEndDate = (Label)item["Header"].FindControl("lblEndDate");
            Label lblDemandType = (Label)item["Header"].FindControl("lblDemandType");
            Label lblBudget = (Label)item["Header"].FindControl("lblBudget");
            Label lblLocation = (Label)item["Header"].FindControl("lblLocation");
            HyperLink hlDetail = (HyperLink)item["Header"].FindControl("hlDetail");

            lblTitle.Text = ent.Title;
            //TODO: fix format of dates according to browser settings
            lblPostDate.Text = ent.PostedDate.ToShortDateString();
            lblEndDate.Text = ent.PostingEndDate.ToShortDateString();
            lblDemandType.Text = ent.DemandTypeName;
            lblBudget.Text = string.Format("{0} - {1} per {2}", ent.MinimumBudget.ToString(), ent.MaxBudget.ToString(), ent.JobUnitName);
            lblLocation.Text = string.Format("{0}, {1}", ent.LocationCity, ent.LocationCountry);
            hlDetail.NavigateUrl = string.Format(hlDetail.NavigateUrl, ent.ProfileID, ent.ID);

            _Keywords += ent.Title + " ";
            if (!string.IsNullOrEmpty(_Description))
                _Description = ent.DemandTypeName;
        }
    }
}
