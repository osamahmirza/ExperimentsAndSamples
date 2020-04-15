using ANewWebOrder;
using ANWO.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucMainInfo : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string Header { set { hlWebsiteName.Text = value; } }
    public string Website { set { hlWebsiteName.NavigateUrl = value; } }
    public string LongDescription { set { lblDescription.Text = value; } }
    public string CompanyName
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
                lblCompanyName.Text = value;
            else
                lblCompanyName.Visible = false;
        }
    }
    public string Title
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
                lblSlogan.Text = value;
            else
                lblSlogan.Visible = false;
        }
    }
}