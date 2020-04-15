using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Data.Entity.Profile;
using GoProGo.Presentation;
using Telerik.Web.UI;
using System.Data;
using System.Configuration;
using GoProGo.Data;
using System.Text;

public partial class Controls_ucProf_Inquiries : UserControlBase
{
    string _DateTimeFormat = string.Empty;
    const string _TEXTBOX = "TextBold";
    public event EventHandler OnForwardInquiriesCompleted;

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

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if ((e.Item) is GridDataItem)
        {
            if (string.IsNullOrEmpty(_DateTimeFormat))
                _DateTimeFormat = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();
            tblInquiry ent = (tblInquiry)e.Item.DataItem;
            GridDataItem item = (GridDataItem)e.Item;

            HyperLink link = (HyperLink)item["Subject"].FindControl("lnkSubject");
            Label time = (Label)item["Time"].FindControl("lblTime");
            Label email = (Label)item["Email"].FindControl("lblEmail");
            Label phone = (Label)item["Phone"].FindControl("lblPhone");

            if (link != null && !string.IsNullOrEmpty(ent.ID.ToString()))
                link.NavigateUrl = link.NavigateUrl + ent.ID.ToString();
            if (time != null && !string.IsNullOrEmpty(ent.TimeStamp.ToString()))
                time.Text = ent.TimeStamp.ToString(_DateTimeFormat);

            if (!ent.IsRead)
            {
                time.CssClass = _TEXTBOX;
                email.CssClass = _TEXTBOX;
                phone.CssClass = _TEXTBOX;
            }
        }
    }
    protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            String id = dataItem.GetDataKeyValue("ID").ToString();

            tblInquiry fav = GoProGoDC.ProfileDC.tblInquiries.Where(a => a.ID == int.Parse(id)).SingleOrDefault<tblInquiry>();

            GoProGoDC.ProfileDC.tblInquiries.DeleteOnSubmit(fav);
            GoProGoDC.ProfileDC.SubmitChanges();
            PopulateControl(true);
        }
    }

    public void Refresh()
    {
        PopulateControl(true);
    }
    public void DeleteSelected()
    {
        bool isNeedSubmit = false;
        List<tblInquiry> inquiries = new List<tblInquiry>();

        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            if (item.Selected)
            {
                string strID = ((Telerik.Web.UI.GridEditableItem)(item)).KeyValues.Split(new char[] { '"' })[1];
                if (!string.IsNullOrEmpty(strID))
                {
                    tblInquiry inq = GoProGoDC.ProfileDC.tblInquiries.Where(a => a.ID == int.Parse(strID)).SingleOrDefault<tblInquiry>();
                    if (inq != null)
                        inquiries.Add(inq);
                    isNeedSubmit = true;
                }
            }
        }

        if (isNeedSubmit)
        {
            GoProGoDC.ProfileDC.tblInquiries.DeleteAllOnSubmit(inquiries);
            GoProGoDC.ProfileDC.SubmitChanges();
            PopulateControl(true);
        }
    }
    public void ForwardToEmail()
    {
        bool isNeedSubmit = false;
        List<tblInquiry> inquiries = new List<tblInquiry>();

        StringBuilder IDs = new StringBuilder();

        for (int i = 0; i < RadGrid1.MasterTableView.Items.Count; i++)
        {
            if (RadGrid1.MasterTableView.Items[i].Selected)
            {
                if (i < RadGrid1.MasterTableView.Items.Count - 1)
                    IDs.Append((RadGrid1.MasterTableView.Items[i]["Selector"].FindControl("lblID") as Label).Text + ",");
                else
                    IDs.Append((RadGrid1.MasterTableView.Items[i]["Selector"].FindControl("lblID") as Label).Text);
                
                isNeedSubmit = true;
            }
        }

        if (isNeedSubmit)
        {
            GoProGoDC.ProfileDC.ForwardInquiriesToEmail(ObjProfile.ID, IDs.ToString());
            if (OnForwardInquiriesCompleted != null)
                OnForwardInquiriesCompleted(this, null);
        }
    }

    private void Initialize()
    {
        
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
    private void PopulateControl(bool isBind)
    {
        RadGrid1.DataSource = _ObjProfile.tblInquiries;
        if (isBind)
            RadGrid1.DataBind();
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
