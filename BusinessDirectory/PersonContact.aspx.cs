using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Data.Entity.Profile;
using GoProGo.Presentation;

public partial class PersonContact : BasePage
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
            //TODO: Logging here
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
        ucPubProf_Contact1.OnError += new GoProGo.Presentation.UserControlBase.ControlError(ucPubProf_Contact1_OnError);
        ucPubProf_Contact1.OnAddKeywordsAndDescription += new GoProGo.Presentation.UserControlBase.AddKeywordAndDescription(ucPubProf_Contact1_OnAddKeywordsAndDescription);
        ucPubProf_Contact1.OnInquirySent += new EventHandler(ucPubProf_Contact1_OnInquirySent);
        
        ucPubProf_Contact1.ObjProfile = _ObjProfile;
    }

    void ucPubProf_Contact1_OnInquirySent(object sender, EventArgs e)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage("Your inquiry has been sent successfully.", MessageType.Information);
    }

    void ucPubProf_Contact1_OnAddKeywordsAndDescription(object sender, GoProGo.Presentation.KeywordAndDescriptionArgs args)
    {
        AddKeywordsAndDescription(args.Keyword, args.Description);
    }

    void ucPubProf_Contact1_OnError(object sender, GoProGo.Presentation.ControlErrorArgs args)
    {
        //TODO: Logging
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage("Inquiry cannot be sent.", MessageType.Error);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Contact", MyAccountType.None);
    }
}
