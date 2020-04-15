using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;
using System.Configuration;
using GoProGo.Data;

public partial class Controls_ucProf_InquiryDetail : UserControlBase
{
    string _DateTimeFormat = string.Empty;
    string _StrInquiryID = string.Empty;
    int _InquiryID = 0;
    public event EventHandler OnForwardInquiryCompleted;
    protected void Page_Load(object sender, EventArgs e)
    {
        SetObj();
    }
    private void SetObj()
    {


        ObjProfile = SessionBag.Profile;

        _StrInquiryID = Request.QueryString["Inquiry"].ToString();
        if (!string.IsNullOrEmpty(_StrInquiryID))
        {
            int.TryParse(_StrInquiryID, out _InquiryID);
            if (_InquiryID > 0)
                Inquiry = ObjProfile.tblInquiries.Where(a => a.ID == _InquiryID).SingleOrDefault<tblInquiry>();
            PopulateControl();
        }
    }

    private void PopulateControl()
    {
        _DateTimeFormat = ConfigurationManager.AppSettings["DateTimeFormat"].ToString();

        lblEmail.Text = Inquiry.Email;
        lblContactNumber.Text = Inquiry.ContactNumber;
        lblSubject.Text = Inquiry.Subject;
        lblTime.Text = Inquiry.TimeStamp.ToString(_DateTimeFormat);
        rtbMessage.Text = Inquiry.Message;

        //Mark read
        Inquiry.IsRead = true;
        GoProGoDC.ProfileDC.SubmitChanges();
    }

    public void ForwardToEmail()
    {
        GoProGoDC.ProfileDC.ForwardInquiriesToEmail(ObjProfile.ID, _StrInquiryID);
        if (OnForwardInquiryCompleted != null)
            OnForwardInquiryCompleted(this, null);
    }
    public void Reply()
    {
        //Show the other panel which has send button in it too
        //Keep replies in a new table called replies
    }

    public tblProfile ObjProfile { get; set; }
    public tblInquiry Inquiry { get; set; }
}
