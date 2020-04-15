using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class SharedProtected_ProfilePicture : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Initialize();
        RegisterEvents();
    }
    private void RegisterEvents()
    {
        ucProfile41.OnError += new UserControlBase.ControlError(ucProfile41_OnError);
    }

    void ucProfile41_OnError(object sender, ControlErrorArgs args)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }

    private void Initialize()
    {
        ((ICommon)Master).SetHeader("Profile Picture", MyAccountType.None);
    }
}
