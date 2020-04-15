using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class SharedProtected_Favourites : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void Load_Events()
    {
        ucProf_Favourites1.OnError += new GoProGo.Presentation.UserControlBase.ControlError(ucProf_Favourites1_OnError);
        ucProf_Favourites1.OnBatchDeleteCompleted += new EventHandler(ucProf_Favourites1_OnBatchDeleteCompleted);
    }

    void ucProf_Favourites1_OnBatchDeleteCompleted(object sender, EventArgs e)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage("Favourite(s) deleted.", MessageType.Information);
    }

    void ucProf_Favourites1_OnError(object sender, GoProGo.Presentation.ControlErrorArgs args)
    {
        ((ICommon)Master).ClearMessage();
        ((ICommon)Master).ShowMessage(args.Message, MessageType.Error);
    }

    public override void Load_Header()
    {
        
    }

    protected void RadToolBar1_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
    {
        string commandName = e.Item.Text;
        if (commandName == "Refresh")
        {
            ucProf_Favourites1.Refresh();
        }
        if (commandName == "Delete")
        {
            ucProf_Favourites1.DeleteSelected();
        }
    }
}
