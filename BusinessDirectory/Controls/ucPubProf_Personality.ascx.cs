using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class Controls_ucPubProf_Personality : UserControlBase
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
            int? profileID = ObjProfile.ID;
            vwPersonality personality = GoProGo.Data.GoProGoDC.ProfileDC.GetPersonalityByProfileID(profileID).SingleOrDefault();
            //Gender
            if (ObjProfile.SexID != null)
            {
                tlkpSex sex = GoProGo.Business.Lookup.Profile.GetAllSexes().Where(a => a.ID == ObjProfile.SexID).SingleOrDefault();
                lblGender.Text = sex.Name;
            }
            else
            {
                lblGender.Visible = false;
                lblGenderCap.Visible = false;
            }
            //Relationship
            if (personality.RelationshipID != null)
                lblRelationship.Text = personality.RelationshipType;
            else
            {
                lblRelationship.Visible = false;
                lblRelationshipCap.Visible = false;
            }
            //GrewupTown
            if (!string.IsNullOrEmpty(personality.GrewUpTown))
                lblGrewup.Text = personality.GrewUpTown;
            else
            {
                lblGrewup.Visible = false;
                lblGrewUpCap.Visible = false;
            }
            //Age
            if (personality.DateOfBirth != null)
                lblAge.Text = (DateTime.Today.Year - ((DateTime)personality.DateOfBirth).Year).ToString();
            else
            {
                lblAge.Visible = false;
                lblAgeCap.Visible = false;
            }
            //MissionStatement
            if (!string.IsNullOrEmpty(personality.MissionStatement.Trim()))
                lblMissionStatement.Text = personality.MissionStatement;
            else
            {
                lblMissionStatement.Visible = false;
                lblMissionStatementCap.Visible = false;
            }
            //FavouriteQuote
            if (!string.IsNullOrEmpty(personality.FavQuote.Trim()))
                lblFavQoute.Text = personality.FavQuote;
            else
            {
                lblFavQoute.Visible = false;
                lblFavQuoteCap.Visible = false;
            }
            //Hobbies
            if (!string.IsNullOrEmpty(personality.Hobbies.Trim()))
                lblHobbies.Text = personality.Hobbies;
            else
            {
                lblHobbies.Visible = false;
                lblHobbiesCap.Visible = false;
            }
            //Sports
            if (!string.IsNullOrEmpty(personality.Sports.Trim()))
                lblSports.Text = personality.Sports;
            else
            {
                lblSports.Visible = false;
                lblSportsCap.Visible = false;
            }
            //FavBook
            if (!string.IsNullOrEmpty(personality.FavBook.Trim()))
                lblFavBooks.Text = personality.FavBook;
            else
            {
                lblFavBooks.Visible = false;
                lblFavBooksCap.Visible = false;
            }
            //FavMovie
            if (!string.IsNullOrEmpty(personality.FavMovie.Trim()))
                lblFavMovie.Text = personality.FavMovie;
            else
            {
                lblFavMovie.Visible = false;
                lblFavMovieCap.Visible = false;
            }
            //FavTVShow
            if (!string.IsNullOrEmpty(personality.FavTvShow.Trim()))
                lblFavTvShow.Text = personality.FavTvShow;
            else
            {
                lblFavTvShow.Visible = false;
                lblFavTvShowCap.Visible = false;
            }

            _Description = ObjProfile.FirstName + " " + ObjProfile.LastName + " Personality and Personal Information";
            _Keywords = ObjProfile.FirstName + " " + ObjProfile.LastName + " Personality and Personal Information";

        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Can not load personality.", Severity = 3 });
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
}
