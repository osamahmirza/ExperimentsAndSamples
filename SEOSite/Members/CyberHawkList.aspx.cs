using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANewWebOrder;
using ANWO.Presentation;

public partial class Members_CyberHawkList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void Load_Events()
    {
        if (!IsPostBack)
            Initialize();
    }

    private void Initialize()
    {
    
    }
}