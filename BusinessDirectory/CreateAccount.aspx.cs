using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using GoProGo.Presentation;
using GoProGo.Utility;
using GoProGo.Data;
using System.Configuration;


public partial class CreateAccount : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucCreateUser1.OnCancelUserCreate += new EventHandler(ucCreateUser1_CancelUserCreate);
        ucCreateUser1.OnError += new GoProGo.Presentation.UserControlBase.ControlError(ucCreateUser1_OnError);
    }

    void ucCreateUser1_OnError(object sender, GoProGo.Presentation.ControlErrorArgs args)
    {
        if (args.InnerException != null)
            ((ICommon)this.Master).ShowMessage(args.InnerException.Message, MessageType.Error);
        else
        {
            ((ICommon)this.Master).ShowMessage(args.Message, MessageType.Error);
            if (args.Severity <= int.Parse(ConfigurationManager.AppSettings["Severity"].ToString()))
            {
                //DoLogging stuff here
            }
        }
    }

    void ucCreateUser1_CancelUserCreate(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
