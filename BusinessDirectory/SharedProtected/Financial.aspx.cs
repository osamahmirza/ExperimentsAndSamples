using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class SharedProtected_Financial : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    void ucProfile21_OnError(object sender, GoProGo.Presentation.ControlErrorArgs args)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }


    protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
    {
        string commandName = e.Item.Text;
        if (commandName == "Save")
            ucProfile21.SaveProfile();
    }

    public override void Load_Events()
    {
        ucProfile21.OnError += new GoProGo.Presentation.UserControlBase.ControlError(ucProfile21_OnError);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Financial", MyAccountType.None);
    }
}
