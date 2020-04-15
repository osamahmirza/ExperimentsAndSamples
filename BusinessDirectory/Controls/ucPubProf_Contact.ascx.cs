using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;
using GoProGo.Data;

public partial class Controls_ucPubProf_Contact : UserControlBase
{
    public event EventHandler OnInquirySent;

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
            _Keywords = ObjProfile.FirstName + " " + ObjProfile.LastName;
            _Description = ObjProfile.FirstName + " " + ObjProfile.LastName;
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
    protected void Page_Init(object sender, EventArgs e)
    {
        Page.LoadComplete += new EventHandler(Page_LoadComplete);
    }
    protected void btnSendMessage_Click(object sender, EventArgs e)
    {
        try
        {
            ObjProfile.tblInquiries.Add(new tblInquiry()
                                        {
                                            ContactNumber = rtbPhone.Text,
                                            Email = rtbEmail.Text,
                                            IsRead = false,
                                            IsReplied = false,
                                            Message = txtMessage.Text,
                                            Subject = "Inquiry from GoProGo.",
                                            TimeStamp = DateTime.Now
                                        });
            GoProGoDC.ProfileDC.SubmitChanges();
            if (OnInquirySent != null)
                OnInquirySent(this, null);
            
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 2});
        }
    }
}
