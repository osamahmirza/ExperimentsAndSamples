using ANewWebOrder;
using ANWO.Presentation;
using ANWO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucRecentlyAdded : UserControlBase
{
    private const string _CAMPAIGNPAGENAME = "~/CyberHawks/ANewWebOrder-Hawks.aspx?ID={0}";

    protected void Page_Load(object sender, EventArgs e)
    {
        BindDataToRepeater();
    }

    private void BindDataToRepeater()
    {
        if (!IsPostBack)
        {
            rptRecentlyAdded.DataSource = GetRecentlyAdded();
            rptRecentlyAdded.DataBind();
        }
    }

    private List<vwCampaign> GetRecentlyAdded()
    {
        return ListGenerateFactory.GetRecentlyAddedCampaign(AppSettings.RecentlyAddedNumber);
    }
    protected void rptRecentlyAdded_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Panel pnl1 = e.Item.FindControl("pnlContent1") as Panel;

                vwCampaign row = e.Item.DataItem as vwCampaign;

                if (row != null)
                {

                    pnl1.Controls.Add(new HyperLink() { Text = row.Title, NavigateUrl = string.Format(_CAMPAIGNPAGENAME, row.ID) });

                }
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ANWO.Common.ControlErrorArgs() { Message = ex.Message, Severity = 1 });
        }
    }
}