using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;

public partial class Main_SubHead : PublicBaseMasterPage, IMessage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region ICommon
    public void ShowMessage(string message)
    {
        ucMessageBox1.SetMessage(message);
    }

    public void ClearMessage()
    {
        ucMessageBox1.ClearMessage();
    }

    #endregion


    public override void GenerateControlBasedMetaData(string header)
    {
        ucPageHeader1.SetHeader(header);
    }
}
