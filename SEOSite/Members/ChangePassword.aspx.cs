using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;

public partial class Members_ChangePassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public override void Load_Events()
    {
    }

    protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/CyberHawkList.aspx",false);
    }
}