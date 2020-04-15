using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANWO.Common;

public partial class Members_CyberHawkEdit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.ClientScript.IsClientScriptIncludeRegistered("domtabscript"))
        {
            Page.ClientScript.RegisterClientScriptInclude("domtabscript", "../Scripts/DOMTab/domtab.js");
        }
    }

    void ucCampaign1_OnError(object sender, ControlErrorArgs args)
    {
        ((IMessage)Master).ShowMessage(args.Message);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ucCampaign1.Save();
    }

    void PersonInfo1_OnSuccess(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/CyberHawkList.aspx",false);
        //Move to next page
    }

    void UserInfo1_OnError(object sender, ControlErrorArgs args)
    {
        ((IMessage)Master).ShowMessage(args.Message);
    }

    void ucCampaign1_OnSuccess(object sender, EventArgs e)
    {

    }

    public override void Load_Events()
    {
        ucCampaign1.OnError += new ControlError(ucCampaign1_OnError);
        ucCampaign1.OnSuccess += new EventHandler(ucCampaign1_OnSuccess);
    }
}