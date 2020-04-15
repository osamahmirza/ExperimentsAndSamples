using ANWO.Presentation;
using ANWO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucWebsiteInfo : UserControlBase
{

    public string WebsiteName
    {
        get
        {
            return tbWebsiteName.Text;
        }
        set
        {
            tbWebsiteName.Text = value;
        }
    }
    public string WebsiteDescription
    {
        get
        {
            return tbWebsiteDescription.Text;
        }
        set
        {
            tbWebsiteDescription.Text = value;
        }
    }

    public string Website
    {
        get
        {
            return tbWebsite.Text;
        }
        set
        {
            tbWebsite.Text = value;
        }
    }

    protected void lnkTestLink_Click(object sender, EventArgs e)
    {
        if (UtilityFunctions.UrlExists(tbWebsite.Text.Trim()))
        {
            lblWebsiteError.ForeColor = System.Drawing.Color.Green;
            lblWebsiteError.Text = "Valid Website Address";
            lblWebsiteError.Visible = true;
        }
        else
        {
            lblWebsiteError.ForeColor = System.Drawing.Color.Red;
            lblWebsiteError.Text = "Invalid Website Address";
            lblWebsiteError.Visible = true;
        }
    }
}