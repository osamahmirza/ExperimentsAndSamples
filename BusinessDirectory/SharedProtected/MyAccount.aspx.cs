using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Data.Entity.Profile;
using GoProGo.Presentation;

public partial class MyAccount : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Scenario of postback is handled when ObjProfile Property is set
        if (!IsPostBack)
        {
            tblProfile prof = GoProGo.Data.GoProGoDC.ProfileDC.tblProfiles.First(pro => pro.UserID.ToString() == MembershipUser.ProviderUserKey.ToString());
            //ucProfile11.ObjProfile = prof;
            //ucProfile11a.ObjProfile = prof;
            //ucProfile21.ObjProfile = prof;
            //ucProfile31.ObjProfile = prof;
            //ucProfile41.ObjProfile = prof;
        }

    }
}
