using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class PersonPersonality : BasePage
{
    string _ProfileID = string.Empty;
    int _ProfID = 0;

    tblProfile _ObjProfile = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        _ProfileID = Request.QueryString["ProfileID"];
        ParseProperties();
    }

    private void ParseProperties()
    {
        if (int.TryParse(_ProfileID, out _ProfID))
        {
            _ObjProfile = GoProGo.Data.GoProGoDC.ProfileDC.GetProfileByID(_ProfID).FirstOrDefault<tblProfile>();
        }
        else
            throw new Exception("Invalid ProfileID provided. ProfileID:" + _ProfileID);
    }

    public override void Load_Events()
    {
        ucPubProf_Personality1.OnError += new UserControlBase.ControlError(ucPubProf_Personality1_OnError);
        ucPubProf_Personality1.OnAddKeywordsAndDescription += new UserControlBase.AddKeywordAndDescription(ucPubProf_Personality1_OnAddKeywordsAndDescription);
        ucPubProf_Personality1.ObjProfile = _ObjProfile;
    }

    void ucPubProf_Personality1_OnAddKeywordsAndDescription(object sender, KeywordAndDescriptionArgs args)
    {
        AddKeywordsAndDescription(args.Keyword, args.Description);
    }

    void ucPubProf_Personality1_OnError(object sender, ControlErrorArgs args)
    {
        //TODO: Log it
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Personality", MyAccountType.None);   
    }
}
