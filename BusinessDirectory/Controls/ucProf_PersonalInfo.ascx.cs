using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Utility;
using GoProGo.Business;
using Telerik.Web.UI;
using GoProGo.Data.Entity.Profile;
using GoProGo.Data;

public partial class ucProf_PersonalInfo : UserControlBase
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
        try
        {
            cmbSex.Items.Add(new RadComboBoxItem("[Select Sex]", "-1"));
            cmbSex.AppendDataBoundItems = true;
            cmbSex.DataSource = GoProGo.Business.Lookup.Profile.GetAllSexes();
            cmbSex.DataTextField = "Name";
            cmbSex.DataValueField = "ID";
            cmbSex.DataBind();

            PopulateControl();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message=ex.Message, Severity=3});  
        }
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
        FirstName = _ObjProfile.FirstName;
        LastName = _ObjProfile.LastName;
        SexID = _ObjProfile.SexID == null ? -1 : (int)_ObjProfile.SexID;
        CellPhone = _ObjProfile.CellPhone;
        Phone = _ObjProfile.Phone;
        Fax = _ObjProfile.Fax;

    }

    public void SaveProfile()
    {
        try
        {

            _ObjProfile.FirstName = FirstName;
            _ObjProfile.LastName = LastName;
            _ObjProfile.SexID = SexID;
            _ObjProfile.CellPhone = CellPhone;
            _ObjProfile.Phone = Phone;
            _ObjProfile.Fax = Fax;
            GoProGoDC.ProfileDC.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });  
        }
    }
    public string FirstName
    {
        get
        {
            return rtbFirstName.Text.Trim();
        }
        set
        {
            rtbFirstName.Text = value;
        }
    }
    public string LastName
    {
        get
        {
            return rtbLastName.Text.Trim();
        }
        set
        {
            rtbLastName.Text = value;
        }
    }

    public int? SexID
    {
        get
        {
            return int.Parse(cmbSex.SelectedItem.Value);
        }
        set
        {
            cmbSex.SelectedValue = value.ToString();
        }
    }

    public string CellPhone
    {
        get
        {
            return tbCellPhone.Text.Trim();
        }
        set
        {
            tbCellPhone.Text = value;
        }
    }
    public string Phone
    {
        get
        {
            return tbPhone.Text.Trim();
        }
        set
        {
            tbPhone.Text = value;
        }
    }
    public string Fax
    {
        get
        {
            return tbFax.Text.Trim();
        }
        set
        {
            tbFax.Text = value;
        }
    }
}
