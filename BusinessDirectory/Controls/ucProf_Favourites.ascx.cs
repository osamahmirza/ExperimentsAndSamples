using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Data.Entity.Profile;
using System.Web.Security;
using GoProGo.Presentation;
using GoProGo.Data;
using Telerik.Web.UI;
using System.Configuration;
using System.IO;
using System.Text;

public partial class ucProf_Favourites : UserControlBase
{
    string _DateTimeFormat = string.Empty;
    const string _TEXTBOLD = "TextBold";
    private const string PICTURE_HANDLER = @"~\PublicFile.ashx?ProfPicture=";
    public event EventHandler OnBatchDeleteCompleted;

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
    }

    private void SetObj()
    {
        ObjProfile = SessionBag.Profile;
    }

    private void Initialize()
    {
    }

    private void PopulateControl(bool isBind)
    {
        RadGrid1.DataSource = GoProGo.Business.Entities.Profile.GetFavouritesByProfileID(ObjProfile.ID);
        if (isBind)
            RadGrid1.DataBind();
    }

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if ((e.Item) is GridDataItem)
        {
            if (string.IsNullOrEmpty(_DateTimeFormat))
                _DateTimeFormat = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();
            vwFavourite ent = (vwFavourite)e.Item.DataItem;
            GridDataItem item = (GridDataItem)e.Item;

            HyperLink link = (HyperLink)item["Name"].FindControl("lnkName");
            Label category = (Label)item["ServiceCategory"].FindControl("lblCategory");
            Label rate = (Label)item["Rate"].FindControl("lblRate");
            Image image = (Image)item["Picture"].FindControl("Image1");

            if (link != null)
            {
                if (ent.IsLive)
                    link.NavigateUrl = link.NavigateUrl + ent.FavProfileID.ToString();
                link.Text = ent.FirstName + " " + ent.LastName;
            }

            if (rate != null)
                rate.Text = (ent.MinimumRate != null ? ent.MinimumRate.ToString() : "") + " (" + ent.CurrencyCode + ") / " + ent.JobUnit;

            if (image != null)
                image.ImageUrl = GetPicturePath(ent.SmallProfilePicture);

            if (category != null)
                category.Text = ent.Category;

            //if (ent.IsLive)
            //    category.CssClass = _TEXTBOLD;
        }
    }

    public void DeleteSelected()
    {
        bool isNeedSubmit = false;
        List<tblFavourite> favourites = new List<tblFavourite>();

        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            if (item.Selected)
            {
                string strID = ((Telerik.Web.UI.GridEditableItem)(item)).KeyValues.Split(new char[] {'"'})[1];
                if (!string.IsNullOrEmpty(strID))
                {
                    tblFavourite inq = GoProGoDC.ProfileDC.tblFavourites.Where(a => a.ID == int.Parse(strID)).SingleOrDefault<tblFavourite>();
                    if (inq != null)
                        favourites.Add(inq);
                    isNeedSubmit = true;
                }
            }
        }

        if (isNeedSubmit)
        {
            GoProGoDC.ProfileDC.tblFavourites.DeleteAllOnSubmit(favourites);
            GoProGoDC.ProfileDC.SubmitChanges();
            PopulateControl(true);
        }
    }

    public void Refresh()
    {
        PopulateControl(true);
    }
    private string GetPicturePath(string normalFullName)
    {
        return PICTURE_HANDLER + Path.GetFileName(normalFullName);
    }
    protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            String id = dataItem.GetDataKeyValue("ID").ToString();

            tblFavourite fav = GoProGoDC.ProfileDC.tblFavourites.Where(a => a.ID == int.Parse(id)).SingleOrDefault<tblFavourite>();

            GoProGoDC.ProfileDC.tblFavourites.DeleteOnSubmit(fav);
            GoProGoDC.ProfileDC.SubmitChanges();
            PopulateControl(true);
        }
    }
    protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        PopulateControl(false);
    }
    protected void RadGrid1_SortCommand(object source, GridSortCommandEventArgs e)
    {
        if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
        {
            GridSortExpression sortExpr = new GridSortExpression();
            sortExpr.FieldName = e.SortExpression;
            sortExpr.SortOrder = GridSortOrder.Ascending;

            e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
        }

    }
}
