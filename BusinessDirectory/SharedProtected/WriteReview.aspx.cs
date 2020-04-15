using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class SharedProtected_WriteReview : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public override void Load_Events()
    {
        ucProf_WriteReview1.OnError += new GoProGo.Presentation.UserControlBase.ControlError(ucProf_WriteReview1_OnError);
    }

    void ucProf_WriteReview1_OnError(object sender, GoProGo.Presentation.ControlErrorArgs args)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Write Review", MyAccountType.None);
    }
}
