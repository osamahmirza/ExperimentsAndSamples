using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;
using GoProGo.Data;

public partial class ucProf_Profile : UserControlBase
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
        RadEditor1.Content = _ObjProfile.Profile;
        rtbProfileDescription.Text = _ObjProfile.ProfileDescription;
    }
    
    public void SaveProfile()
    {
        try
        {
            _ObjProfile.Profile = RadEditor1.Content;
            _ObjProfile.ProfileDescription = rtbProfileDescription.Text;
            GoProGoDC.ProfileDC.SubmitChanges();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });  
        }
    }

    public string ProfileHTML
    {
        get
        {
            return RadEditor1.Content;
        }
        set
        {
            RadEditor1.Content = value;
        }

    }
    public string ProfileDescription 
    {
        get
        {
            return rtbProfileDescription.Text;
        }
        set
        {
            rtbProfileDescription.Text = value;
        }
    }
}
