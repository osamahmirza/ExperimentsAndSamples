using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class PublicMaster : MasterPage, ICommon
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region IMyAccount Members

    public void ClearMessage()
    {
        ucMessageBox1.ClearMessage();
    }
    public void ShowMessage(string message, MessageType type)
    {
        ucMessageBox1.SetMessage(message, type);
    }

    public void SetHeader(string message, MyAccountType type)
    {
        ucPageHeader1.SetHeader(message, type);
    }


    #endregion
}
