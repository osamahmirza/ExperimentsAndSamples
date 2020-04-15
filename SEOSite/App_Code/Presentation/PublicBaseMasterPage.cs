using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANWO.Presentation;
using System.Web.Security;
using System.Web.UI;
using ANWO;
using ANewWebOrder;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BasePage
/// </summary>
public abstract class PublicBaseMasterPage : CommonBaseMaster
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    public override void CommonBaseMaster_Load(string param)
    {
        GenerateControlBasedMetaData(param);
    }

    public abstract void GenerateControlBasedMetaData(string header);
}
