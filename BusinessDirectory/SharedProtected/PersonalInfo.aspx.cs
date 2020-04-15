using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class SharedProtected_PersonalInfo : PageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Initialize();
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        ucProfile11.OnError += new UserControlBase.ControlError(ucProfile11_OnError);
    }

    void ucProfile11_OnError(object sender, ControlErrorArgs args)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }

    private void Initialize()
    {
        ((ICommon)Master).SetHeader("Personal Info", MyAccountType.None);
    }

    protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
    {
        string commandName = e.Item.Text;
        if (commandName == "Save")
            ucProfile11.SaveProfile();
    }
}
