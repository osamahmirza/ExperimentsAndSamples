using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CategoryBrowsing : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public override void Load_Events()
    {
        ucSearch_Category1.OnError += new GoProGo.Presentation.UserControlBase.ControlError(ucSearch_Category1_OnError);
    }

    void ucSearch_Category1_OnError(object sender, GoProGo.Presentation.ControlErrorArgs args)
    {
        
    }

    public override void Load_Header()
    {

    }
}
