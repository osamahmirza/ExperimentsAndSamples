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
    public override void Load_Events()
    {
        ucCategories.OnError += ucCategories_OnError;
        ucRecentlyAdded1.OnError += ucRecentlyAdded1_OnError;
        ucRecentlyUpdated1.OnError += ucRecentlyUpdated1_OnError;
    }

    void ucRecentlyUpdated1_OnError(object sender, ANWO.Common.ControlErrorArgs args)
    {
        ((IMessage)Master).ShowMessage(args.Message);
    }

    void ucRecentlyAdded1_OnError(object sender, ANWO.Common.ControlErrorArgs args)
    {
        ((IMessage)Master).ShowMessage(args.Message);
    }

    void ucCategories_OnError(object sender, ANWO.Common.ControlErrorArgs args)
    {
        ((IMessage)Master).ShowMessage(args.Message);
    }
}