using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class ucProf_Marketing : UserControlBase
{
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

    private void Initialize()
    {
        PopulateControl();
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
    private void PopulateControl()
    {
        Website = _ObjProfile.Website;
        Slogan = _ObjProfile.Slogan;
        SearchTags = _ObjProfile.SearchTags;
        IsPublic = _ObjProfile.IsPublic == null ? false : (bool)_ObjProfile.IsPublic;
    }
    public void SaveProfile()
    {
        try
        {
            _ObjProfile.Website = Website;
            _ObjProfile.Slogan = Slogan;
            _ObjProfile.SearchTags = SearchTags;
            _ObjProfile.IsPublic = IsPublic;
            
            GoProGo.Data.GoProGoDC.ProfileDC.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });  
        }
    }
    
    //TODO: http://support.microsoft.com/kb/306158
    public string Picture 
    { 
        get; 
        set; 
    }
    
    public string Website 
    {
        get
        {
            return rtbWebsite.Text.Trim();
        }
        set
        {
            rtbWebsite.Text = value;
        }
    }
    public string Slogan 
    {
        get
        {
            return rtbSlogan.Text.Trim();
        }
        set
        {
            rtbSlogan.Text = value;
        }
    }
    public string SearchTags 
    {
        get
        {
            return rtbSearchTags.Text.Trim();
        }
        set
        {
            rtbSearchTags.Text = value;
        }
    }
    public bool IsPublic 
    {
        get
        {
            return rbYes.Checked;
        }
        set
        {
            if (value)
                rbYes.Checked = value;
            else
                rbNo.Checked = true;
        }
    }
}
