using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;

public partial class Main_MainHead : PublicBaseMasterPage, IMessage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ShowMessage(string message)
    {
    }

    public void ClearMessage()
    {
    }

    public override void GenerateControlBasedMetaData(string header)
    {
        ucPageHeader1.SetHeader(header);
    }


}
