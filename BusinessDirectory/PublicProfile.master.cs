using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class PubProfile : MasterPage, ICommon
{
    string _ProfileID = string.Empty;
    int _ProfID = 0;

    tblProfile _ObjProfile = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        _ProfileID = Request.QueryString["ProfileID"];
        ParseProperties();
        Load_Events();
        if (!IsPostBack)
            PopulateControl();

    }

    private void PopulateControl()
    {
        ucPubProf_ProfileSummary1.ObjProfile = _ObjProfile;
        foreach (Telerik.Web.UI.RadTab item in RadTabStrip1.Tabs)
        {
            item.NavigateUrl = string.Format(item.NavigateUrl, _ProfileID);
        }
        SelectTab();
    }
    //Select Tab according to page name.
    private void SelectTab()
    {
        if (Request.Url.AbsoluteUri.Contains("PersonSupply"))
            RadTabStrip1.Tabs[0].Selected = true;
        else if (Request.Url.AbsoluteUri.Contains("PersonDemand"))
            RadTabStrip1.Tabs[1].Selected = true;
        else if (Request.Url.AbsoluteUri.Contains("PersonPersonality"))
            RadTabStrip1.Tabs[2].Selected = true;
        else if (Request.Url.AbsoluteUri.Contains("PersonReviews"))
            RadTabStrip1.Tabs[3].Selected = true;
        else if (Request.Url.AbsoluteUri.Contains("PersonContact"))
            RadTabStrip1.Tabs[4].Selected = true;
    }

    private void Load_Events()
    {
        ucPubProf_ProfileSummary1.OnError += new UserControlBase.ControlError(ucPubProf_ProfileSummary1_OnError);
    }

    void ucPubProf_ProfileSummary1_OnError(object sender, ControlErrorArgs args)
    {
        ShowMessage(args.Message, MessageType.Error);
    }

    private void ParseProperties()
    {
        try
        {
            if (int.TryParse(_ProfileID, out _ProfID))
            {
                _ObjProfile = GoProGo.Data.GoProGoDC.ProfileDC.GetProfileByID(_ProfID).FirstOrDefault<tblProfile>();
            }
            else
                throw new Exception("Invalid ProfileID provided. ProfileID:" + _ProfileID);
        }
        catch (Exception ex)
        {
            //Logging here
            ClearMessage();
            ShowMessage("Invalid page request.", MessageType.Error);
        }
    }

    #region ICommon Members

    public void ClearMessage()
    {
        ucMessageBox1.ClearMessage();
    }
    public void ShowMessage(string message, MessageType type)
    {
        ucMessageBox1.SetMessage(message, type);
    }

    public void SetHeader(string message, MyAccountType type)
    {
        ucPageHeader1.SetHeader(message, type);
    }

    #endregion
}
