using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;

public partial class UserControls_ucTopNavItems : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                lblVerticalBar.Visible = false;
                hlRegister.Visible = false;
            }
            else
            {
                lblVerticalBar.Visible = true;
                hlRegister.Visible = true;
            }


        }
    }
}