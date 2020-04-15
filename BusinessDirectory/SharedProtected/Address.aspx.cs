using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;

public partial class SharedProtected_Address : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public override void Load_Events()
    {
        ucProfile1a1.OnError += new UserControlBase.ControlError(ucProfile1a1_OnError);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Address", MyAccountType.None);
    }

    void ucProfile1a1_OnError(object sender, ControlErrorArgs args)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }
    protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
    {
        string commandName = e.Item.Text;
        if (commandName == "Save")
            ucProfile1a1.SaveProfile();
    }

   
}
