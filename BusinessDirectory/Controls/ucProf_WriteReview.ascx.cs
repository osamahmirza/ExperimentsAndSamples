using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;
using GoProGo.Data;


public partial class Controls_ucProf_WriteReview : UserControlBase
{
    public event ControlError OnError;
    protected void Page_Load(object sender, EventArgs e)
    {
        SetObj();
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

    private void SetObj()
    {
        try
        {
            string profileID = Request.QueryString["ProfileID"];
            int profID = int.Parse(profileID);

            ObjProfile = GoProGoDC.ProfileDC.GetProfileByID(profID).Single<tblProfile>();
        }
        catch (Exception ex)
        {
            if (OnError != null)
                OnError(this, new ControlErrorArgs() { InnerException = ex, Message = "Invalid Profile.", Severity = 2 });
        }
    }

    private void Initialize()
    {
        //Setting dictionary types and stuff
        hlPersonName.Text = _ObjProfile.FirstName + " " + _ObjProfile.LastName;
        hlPersonName.NavigateUrl = string.Format("~/PersonSupply.aspx?ProfileID={0}", _ObjProfile.ID.ToString());
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            if (SessionBag.Profile.ID.Equals(_ObjProfile.ID))
            {
                throw new Exception("You can not post review to yourself!");
            }
            else
            {
                tblReview review = new tblReview()
                {
                    IsApproved = false,
                    CreatedDate = DateTime.Now,
                    IPAddress = SessionBag.UserBrowsingInfo.IP,
                    ProfileID = _ObjProfile.ID,
                    ReviewerProfileID = SessionBag.Profile.ID,
                    Review = rtbComment.Text,
                    Score = Decimal.Parse(rrProfileRating.Value.ToString()),
                };
                GoProGoDC.ProfileDC.tblReviews.InsertOnSubmit(review);
                GoProGoDC.ProfileDC.SubmitChanges();

                Server.Transfer(string.Format("~/PersonSupply.aspx?ProfileID={0}", _ObjProfile.ID.ToString()));
            }
        }
        catch (Exception ex)
        {
            if (OnError != null)
                OnError(this, new ControlErrorArgs() { InnerException = ex });
        }
    }
}
