using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class ChangePassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    void ChangePassword1_ChangePasswordError(object sender, EventArgs e)
    {
        ((ICommon)Master).ShowMessage("Password can not be changed.", MessageType.Error);
    }

    void ChangePassword1_CancelButtonClick(object sender, EventArgs e)
    {
        //Redirect to profile main page
    }

    public override void Load_Events()
    {
        ChangePassword1.CancelButtonClick += new EventHandler(ChangePassword1_CancelButtonClick);
        ChangePassword1.ChangePasswordError += new EventHandler(ChangePassword1_ChangePasswordError);
    }

    public override void Load_Header()
    {
        ((ICommon)Master).SetHeader("Change Password", MyAccountType.None);
    }
}
