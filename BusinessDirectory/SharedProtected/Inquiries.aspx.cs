using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class SharedProtected_Inquiries : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    public override void Load_Events()
    {
        ucProf_Inquiries1.OnError += new UserControlBase.ControlError(ucProfile1a1_OnError);
        ucProf_Inquiries1.OnForwardInquiriesCompleted += new EventHandler(ucProf_Inquiries1_OnForwardInquiriesCompleted);
    }

    void ucProf_Inquiries1_OnForwardInquiriesCompleted(object sender, EventArgs e)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage("Your messages have been forwarded to your email successfuly.", MessageType.Information);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Inquiries", MyAccountType.None);
    }

    void ucProfile1a1_OnError(object sender, ControlErrorArgs args)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }
    protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
    {
        string commandName = e.Item.Text;
        if (commandName == "Refresh")
        {
            ucProf_Inquiries1.Refresh();
        }
        if(commandName == "Forward to email")
        {
            ucProf_Inquiries1.ForwardToEmail();
        }
        if (commandName == "Delete")
        {
            ucProf_Inquiries1.DeleteSelected();
        }
    }

}
