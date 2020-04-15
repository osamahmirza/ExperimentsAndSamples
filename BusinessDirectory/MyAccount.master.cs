using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class MyAccount : MasterPage, ICommon
{
    public const string XML_PANELBAR = "~/RadControlConfigs/PanelBars/MyAccount.xml";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            RadPanelBar1.LoadContentFile(XML_PANELBAR);
    }

    #region ICommon Members

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
