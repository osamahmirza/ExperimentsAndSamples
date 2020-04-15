using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class SharedProtected_InquiryDetail : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public override void Load_Events()
    {
        ucProf_InquiryDetail1.OnError += new GoProGo.Presentation.UserControlBase.ControlError(ucProf_InquiryDetail1_OnError);
        ucProf_InquiryDetail1.OnForwardInquiryCompleted += new EventHandler(ucProf_InquiryDetail1_OnForwardInquiryCompleted);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Inquiry Detail", MyAccountType.None);
    }

    void ucProf_InquiryDetail1_OnForwardInquiryCompleted(object sender, EventArgs e)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage("Your message has been forwarded to your email successfuly.", MessageType.Information);
    }

    void ucProf_InquiryDetail1_OnError(object sender, GoProGo.Presentation.ControlErrorArgs args)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }

    protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
    {
        string commandName = e.Item.Text;
        if (commandName == "Forward to email")
        {
            ucProf_InquiryDetail1.ForwardToEmail();
        }
    }
}
