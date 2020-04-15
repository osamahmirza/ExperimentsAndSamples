using ANewWebOrder;
using ANWO.Common;
using ANWO.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucConnectPublic : UserControlBase
{
    const string _LinkMainBody = "<div id='connectpublic'>#replace#</div>";
    string _Link = "<div><a href='#link#'><img src='#image#'/></a></div>";
    StringBuilder sb = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    private void Initialize()
    {
        if (!IsPostBack)
        {
            if (CampaignID != 0)
            {
                CampaignConnect = DataContext.NWODC.vwCampaignConnects.Where(a => a.CampaignID == CampaignID).ToList();
                LoadLinks();
            }
            else
                ThrowError(this, new ControlErrorArgs() { Message = "Invalid Hawk Id", Severity = 6 });
        }
    }

    private void LoadLinks()
    {
        if (CampaignConnect != null && CampaignConnect.Count > 0)
        {
            foreach (var item in CampaignConnect)
            {
                string tempImage = item.Image.Replace("~", "..");
                sb.Append(_Link.Replace("#link#", item.Link.Replace("~", "..")).Replace("#image#", tempImage ));
            }
            Literal1.Text = _LinkMainBody.Replace("#replace#", sb.ToString());
        }
    }

    private int _CampaignID;
    public int CampaignID
    {
        get
        {
            return _CampaignID;
        }
        set
        {
            _CampaignID = value;
            Initialize();
        }
    }

    private List<vwCampaignConnect> _CampaignConnect;
    public List<vwCampaignConnect> CampaignConnect
    {
        get
        {
            return _CampaignConnect;
        }
        private set
        {
            _CampaignConnect = value;
        }
    }
}