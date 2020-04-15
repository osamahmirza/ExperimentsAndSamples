using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using ANWO.Presentation;
using ANWO.Utility;
using ANWO.Common;

public partial class ANewWebOrder_Contact_Us : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void Load_Events()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        ucContactUs1.OnError += new ControlError(ucContactUs1_OnError);
        ucContactUs1.OnSuccess += new EventHandler(ucContactUs1_OnSuccess);
    }

    void ucContactUs1_OnSuccess(object sender, EventArgs e)
    {
           
    }

    void ucContactUs1_OnError(object sender, ControlErrorArgs args)
    {
        ((IMessage)Master).ClearMessage();
        ((IMessage)Master).ShowMessage(args.Message);
    }
}