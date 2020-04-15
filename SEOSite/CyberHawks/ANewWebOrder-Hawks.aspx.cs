using ANewWebOrder;
using ANWO.Biz.Entities;
using ANWO.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ANewWebOrder_Categories : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    void ucCampaignPublic_OnError(object sender, ANWO.Common.ControlErrorArgs args)
    {
        ((IMessage)Master).ShowMessage(args.Message);
    }

    public override void Load_Events()
    {
        ucCampaignPublic.OnError += ucCampaignPublic_OnError;
    }
}