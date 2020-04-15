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

public partial class Links : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
            Initialize();
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string linkID = e.CommandArgument.ToString();
        if (e.CommandName == "Delete")
        {
            WebLinks = WebLinks.Where(a => a.ModifiedID.ToString() != linkID).ToList();
            BindRepeater();
        }
    }

    private void Initialize()
    {
        if (!IsPostBack)
        {
            if (CampaignID != 0)
                WebLinks = DataContext.NWODC.tblLinks.Where(a => a.CampaignID == CampaignID).ToList();
            else
                WebLinks = new List<tblLink>();
            BindRepeater();
        }
    }

    private void BindRepeater()
    {
        Repeater1.DataSource = WebLinks;
        Repeater1.DataBind();

        lblCount.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            int order = WebLinks.Count + 1;
            WebLinks.Add(new tblLink()
                        {
                            CampaignID = this.CampaignID,
                            Description = tbDescription.Text.Trim(),
                            Link = tbLink.Text.Trim(),
                            ModifiedID = DateTime.Now.Ticks.ToString()
                        });
            tbDescription.Text = string.Empty;
            tbLink.Text = string.Empty;

            BindRepeater();
        }
    }

    public bool Validate()
    {
        if (WebLinks.Count >= 5)
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Can't add more than 5 links in Links to Webpage(s).", Severity = 6 });
            return false;
        }

        if (string.IsNullOrEmpty(tbDescription.Text.Trim()) || string.IsNullOrEmpty(tbLink.Text.Trim()))
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Description or Web Link is empty in Links to Webpage(s).", Severity = 6 });
            return false;
        }

        Regex re = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        if (!re.IsMatch(tbLink.Text.Trim()))
        {
            ThrowError(this, new ControlErrorArgs() { Message = "Invalid Link in Links to Webpage(s).", Severity = 6 });
            return false;
        }

        return true;
    }

    #region Properties
    public List<tblLink> WebLinks
    {
        get
        {
            return SessionBag.CampaignWebLinks;
        }
        private set
        {
            SessionBag.CampaignWebLinks = value;
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

    public string LinkCount
    {
        get
        {
            return WebLinks.Count.ToString();
        }
    }
    #endregion
}