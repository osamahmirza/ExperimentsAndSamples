using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANWO.Presentation;
using System.Web.Security;

/// <summary>
/// Summary description for BasePage
/// </summary>
public abstract class BasePage : PageBase
{
    protected override void OnPreInit(EventArgs e)
    {
        Page.Theme = "Default";
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Load_Events();

    }
    public abstract void Load_Events();
}
