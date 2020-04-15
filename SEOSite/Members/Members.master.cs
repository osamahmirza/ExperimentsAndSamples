using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANWO;

public partial class CampaignEdit_Master : MemberBaseMasterPage, IMessage //, IHeader
{
    public override void PopulateNotifications()
    {
        
    }

    public void ShowMessage(string message)
    {
        ClearMessage();
        ucMessageBox1.SetMessage(message);
    }

    public void ClearMessage()
    {
        ucMessageBox1.ClearMessage();
    }

    public override void GenerateControlBasedMetaData(string header)
    {
        ucPageHeader1.SetHeader(header);
    }
}
