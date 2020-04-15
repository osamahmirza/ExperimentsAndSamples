using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Data.Entity.Profile;
using System.Web.Security;
using GoProGo.Presentation;

public partial class Controls_ucProf_Hits : UserControlBase
{
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
        //tblProfile prof = GoProGo.Data.GoProGoDC.ProfileDC.tblProfiles.First(pro => pro.UserID.ToString() == MembershipUser.ProviderUserKey.ToString());
        ////This will trigger Initialize if !IsPostback
        //ObjProfile = prof;
        ObjProfile = SessionBag.Profile;
    }

    private void Initialize()
    {
        //Setting dictionary types and stuff
        lblHits.Text = _ObjProfile.Hits.ToString();
        
    }

    public void Refresh()
    {
        Initialize();
    }
}
