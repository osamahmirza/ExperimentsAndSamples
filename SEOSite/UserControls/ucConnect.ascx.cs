using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANewWebOrder;
using ANWO.Utility;
using System.Text.RegularExpressions;
using ANWO.Common;

public partial class ucConnect : UserControlBase
{
    //NOTE: IF Image is not found, javascript will try load page one more time
    bool _IsCalled = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string linkID = e.CommandArgument.ToString();
        if (e.CommandName == "Delete")
        {
            CampaignConnect = CampaignConnect.Where(a => a.ModifiedID.ToString() != linkID).ToList();
            BindDropDownAndRepeater();
        }
    }

    private void Initialize()
    {
        if (!IsPostBack && !_IsCalled)
            FetchConnections();
        _IsCalled = true;
    }

    private void FetchConnections()
    {
        if (CampaignID != 0)
            CampaignConnect = DataContext.NWODC.vwCampaignConnects.Where(a => a.CampaignID == CampaignID).ToList();
        else
            CampaignConnect = new List<vwCampaignConnect>();
        BindDropDownAndRepeater();
    }

    private void BindDropDownAndRepeater()
    {
        BindDropDownList();
        BindRepeater();
    }

    private void BindDropDownList()
    {
        List<tlkpConnect> connect = new List<tlkpConnect>();
        foreach (var item in DataContext.NWODC.tlkpConnects)
        {
            var conOpt = CampaignConnect.Where(a => a.ConnectID == item.ID).SingleOrDefault();
            if (conOpt == null)
            {
                connect.Add(item);
            }
        }
        if (connect.Count != 0)
        {
            ddlConnectionOption.DataSource = connect;
            ddlConnectionOption.DataTextField = "Name";
            ddlConnectionOption.DataValueField = "ID";
            ddlConnectionOption.DataBind();
            pnlAddConnection.Visible = true;
        }
        else
        {
            pnlAddConnection.Visible = false;
        }
    }

    private void BindRepeater()
    {
        Repeater1.DataSource = CampaignConnect;
        Repeater1.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            List<vwCampaignConnect> campaignConnects = CampaignConnect;
            var vwItem = DataContext.NWODC.tlkpConnects.Where(a => a.ID == Convert.ToInt32(ddlConnectionOption.SelectedValue)).Single();
            if (vwItem == null)
                throw new Exception("View item cannot be null.");

            campaignConnects.Add(new vwCampaignConnect()
            {
                CampaignID = this.CampaignID,
                ConnectID = Convert.ToInt32(ddlConnectionOption.SelectedValue),
                Link = tbLink.Text.Trim(),
                ModifiedID = DateTime.Now.Ticks.ToString(),
                Image = vwItem.Image,
                Name = vwItem.Name
            });

            CampaignConnect = campaignConnects;
            tbLink.Text = string.Empty;
            //Remove the selected one from DropDownList
            BindDropDownAndRepeater();
        }
    }

    public bool Validate()
    {
        if (CampaignConnect.Count >= DataContext.NWODC.tlkpConnects.Count())
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Can't add more links in Other Connection Options..", Severity = 5 });
            return false;
        }

        Regex re = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        if (!re.IsMatch(tbLink.Text.Trim()))
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Invalid Link in Other Connection Options.", Severity = 6 });
            return false;
        }

        return true;
    }

    #region Properties
    public List<vwCampaignConnect> CampaignConnect
    {
        get
        {
            return SessionBag.CampaignConnect;
        }
        private set
        {
            SessionBag.CampaignConnect = value;
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

    #endregion

}