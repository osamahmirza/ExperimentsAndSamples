using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;
using GoProGo.Data;
using Telerik.Web.UI;
using System.Configuration;

public partial class Controls_ucPubProf_Reviews : UserControlBase
{
    string _Description = string.Empty;
    string _Keywords = string.Empty;

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
            RadRating1.ReadOnly = true;
            RadRating1.Value = ObjProfile.ReviewScore == null ? 0 : (int)ObjProfile.ReviewScore;
            lblAvgScore.Text = string.Format("{0:0.00}", ObjProfile.ReviewScore);
            lblTotalReviews.Text = ObjProfile.ReviewCount == null ? "0" : ((int)ObjProfile.ReviewCount).ToString();
            hlWriteReview.NavigateUrl = string.Format(hlWriteReview.NavigateUrl, _ObjProfile.ID);

            _Keywords = ObjProfile.FirstName + " " + ObjProfile.LastName + " Reviews";
            _Description = ObjProfile.FirstName + " " + ObjProfile.LastName + " Reviews";
            
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Can not load profile.", Severity = 3 });
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

            List<vwReview> source = GoProGoDC.ProfileDC.GetReviewByProfileID(ObjProfile.ID, rowNum, pageSize, ref totalRowCount).ToList();
            RadGrid1.VirtualItemCount = (int)totalRowCount;
            RadGrid1.DataSource = source;
            if (isBind) RadGrid1.DataBind();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Can not load reviews.", Severity = 1 });
        }
    }
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        string dateTimeFormat = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();

        if ((e.Item) is GridDataItem)
        {
            vwReview ent = (vwReview)e.Item.DataItem;
            GridDataItem item = (GridDataItem)e.Item;

            Label lblName = (Label)item["Header"].FindControl("lblReviewerName");
            RadRating RadRating2 = (RadRating)item["Header"].FindControl("RadRating2");
            Label lblScore = (Label)item["Header"].FindControl("lblScore");
            Label lblDate = (Label)item["Header"].FindControl("lblDate");
            Label lblReview = (Label)item["Header"].FindControl("lblReview");

            lblName.Text = ent.FirstName + " " + ent.LastName;
            lblScore.Text = string.Format("{0:0.00}", ent.Score);
            lblDate.Text = ent.CreatedDate.ToString(dateTimeFormat);
            lblReview.Text = ent.Review;

            if (ent.Score != null)
                RadRating2.Value = Double.Parse(ent.Score.ToString());
            else
                RadRating2.Value = 0;
            RadRating2.ReadOnly = true;

        }
    }
}
