using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class PersonSupply : BasePage
{
    string _ProfileID = string.Empty;
    int _ProfID = 0;

    private tblProfile _ObjProfile;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            _ProfileID = Request.QueryString["ProfileID"];
            ParseProperties();
        }
        catch (Exception ex)
        {
            //Logging here
            ((ICommon)Master).ClearMessage();
            ((ICommon)Master).ShowMessage("Invalid page request.", MessageType.Error);
        }
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
        ucPubProf_Supply1.OnError += new UserControlBase.ControlError(ucPubProf_Supply1_OnError);
        ucPubProf_Supply1.OnAddKeywordsAndDescription += new UserControlBase.AddKeywordAndDescription(ucPubProf_Supply1_OnAddKeywordsAndDescription);
        ucPubProf_Supply1.ObjProfile = _ObjProfile;
    }

    void ucPubProf_Supply1_OnAddKeywordsAndDescription(object sender, KeywordAndDescriptionArgs args)
    {
        AddKeywordsAndDescription(args.Keyword, args.Description);
    }

    void ucPubProf_Supply1_OnError(object sender, ControlErrorArgs args)
    {
        //TODO: Logging here
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Service(s) Offering", MyAccountType.None);
    }
}
