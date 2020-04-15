using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANWO.Utility;
using ANewWebOrder;
using ANWO.Common;

public partial class ProductAndService : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
    }

    private void Initialize()
    {
        if (!IsPostBack)
        {
            if (CampaignID != 0)
                ProductsOrServices = DataContext.NWODC.tblProductOrServices.Where(a => a.CampaignID == CampaignID).ToList();
            else
                ProductsOrServices = new List<tblProductOrService>();
            BindRepeater();
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "Delete")
        {
            ProductsOrServices = ProductsOrServices.Where(a => a.ModifiedID.ToString() != id).ToList();
            BindRepeater();
        }
    }

    private void BindRepeater()
    {
        Repeater1.DataSource = ProductsOrServices;
        Repeater1.DataBind();

        lblCount.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            int order = ProductsOrServices.Count + 1;
            ProductsOrServices.Add(new tblProductOrService()
            {
                CampaignID = this.CampaignID,
                ProductOrService = tbProductOrService.Text.Trim(),
                SearchPhraseForProductOrService = tbSearchPhrase.Text.Trim(),
                ModifiedID = DateTime.Now.Ticks.ToString()
            });
            tbSearchPhrase.Text = string.Empty;
            tbProductOrService.Text = string.Empty;

            BindRepeater();
        }
    }

    public bool Validate()
    {
        if (ProductsOrServices.Count >= 5)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Can't add more than 5 Web Links in What Do You Offer.", Severity = 5 });
            return false;
        }

        if (string.IsNullOrEmpty(tbSearchPhrase.Text.Trim()) || string.IsNullOrEmpty(tbProductOrService.Text.Trim()))
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = null, Message = "Description or Web Link is empty.", Severity = 5 });
            return false;
        }

        return true;
    }

    #region Properties
    public List<tblProductOrService> ProductsOrServices
    {
        get
        {
            return SessionBag.CampaignProductServices;
        }
        private set
        {
            SessionBag.CampaignProductServices = value;
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

    public string ProductCount
    {
        get
        {
            return ProductsOrServices.Count.ToString();
        }
    }
    #endregion
}