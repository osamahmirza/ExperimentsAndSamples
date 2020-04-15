using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class Controls_ucPubProf_Supply : UserControlBase
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
            lblSlogan.Text = ObjProfile.Slogan;
            lblService.Text = ObjProfile.Profile;

            _Description = ObjProfile.ProfileDescription;
            _Keywords = ObjProfile.SearchTags;
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
    protected void Page_Init(object sender , EventArgs e)
    {
        Page.LoadComplete += new EventHandler(Page_LoadComplete);
    }
}
