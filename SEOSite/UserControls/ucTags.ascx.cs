using ANewWebOrder;
using ANWO.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucTags : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string SearchTags { set { lblSearchTags.Text = value; } }
    public string BizTags { set { lblBizTags.Text = value; } }
    public string GeoTags { set { lblGeoTags.Text = value; } }
}