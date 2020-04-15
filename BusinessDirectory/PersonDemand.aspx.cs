using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Data.Entity.Profile;
using GoProGo.Presentation;

public partial class PersonDemand : BasePage
{
    string _ProfileID = string.Empty;
    int _ProfID = 0;
    string _DemandID = string.Empty;
    int _DmdID = 0;

    private tblProfile _ObjProfile;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            _ProfileID = Request.QueryString["ProfileID"];
            _DemandID = Request.QueryString["DemandID"];
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
        if (_DemandID != null)
            int.TryParse(_DemandID, out _DmdID);

        if (int.TryParse(_ProfileID, out _ProfID))
        {
            _ObjProfile = GoProGo.Data.GoProGoDC.ProfileDC.GetProfileByID(_ProfID).FirstOrDefault<tblProfile>();
        }
        else
            throw new Exception("Invalid ProfileID provided. ProfileID:" + _ProfileID);
    }

    public override void Load_Events()
    {
        ucPubProf_Demand1.OnError += new UserControlBase.ControlError(ucPubProf_Supply1_OnError);
        ucPubProf_Demand1.OnAddKeywordsAndDescription += new UserControlBase.AddKeywordAndDescription(ucPubProf_Demand1_OnAddKeywordsAndDescription);
        ucPubProf_Demand1.DemandID = _DmdID;
        ucPubProf_Demand1.ObjProfile = _ObjProfile;
    }

    void ucPubProf_Demand1_OnAddKeywordsAndDescription(object sender, KeywordAndDescriptionArgs args)
    {
        AddKeywordsAndDescription(args.Keyword, args.Description);
    }

    void ucPubProf_Supply1_OnError(object sender, ControlErrorArgs args)
    {
        //Logging here
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Service(s) Demand", MyAccountType.None);
    }
}
