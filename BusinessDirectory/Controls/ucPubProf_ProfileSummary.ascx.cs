using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;
using System.IO;
using GoProGo.Data.Entity.Geo;
using GoProGo.Data;

public partial class ucPubProf_ProfileSummary : UserControlBase
{
    private const string PICTURE_HANDLER = @"~\PublicFile.ashx?ProfPicture=";
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

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //Worfflow of control starts here
    private void StartWF()
    {
        if (!IsPostBack)
            PopulateControls();
    }

    private void PopulateControls()
    {
        try
        {
            vwSummary summary = GoProGoDC.ProfileDC.GetSummaryByProfileID(ObjProfile.ID).SingleOrDefault<vwSummary>();

            Image1.ImageUrl = GetPicturePath(summary.NormalProfilePicture);
            lblMinRate.Text = string.Format("{0:0,0.00} ({1}) / {2} ", summary.MinimumRate, summary.CurrencyCode, summary.JobUnitName);
            lblNameCategory.Text = string.Format("<strong>{0} {1}</strong> ({2})", summary.FirstName, summary.LastName, summary.CategoryName);
            lblSlogan.Text = summary.Slogan;
            lblLocation.Text = string.Format("{0},{1}", summary.City, summary.Region);
            lblPrimaryPhone.Text = summary.CellPhone;
            lblSecondaryPhone.Text = summary.Phone;

            if (summary.ReviewCount != null)
                lblReviews.Text = summary.ReviewCount.ToString();
            else
                lblReviews.Text = "0";

            if (summary.ReviewScore != null)
                RadRating1.Value = Double.Parse(summary.ReviewScore.ToString());
            else
                RadRating1.Value = 0;
            RadRating1.ReadOnly = true;


            //Address
            string _ProfileAddress = string.Format("{0} {1},{2},{3},{4}", summary.AddressLine1, summary.AddressLine2, summary.City, summary.Region, summary.Country);
            _ProfileAddress = "http://mapof.it/" + _ProfileAddress;
            hlAddress.NavigateUrl = _ProfileAddress;
            hlAddress.Target = "_blank";
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Can not load profile.", Severity = 2 });
        }
    }
    private string GetPicturePath(string normalFullName)
    {
        //if picture is not found then load simple picture from website
        return PICTURE_HANDLER + Path.GetFileName(normalFullName);
    }
}
