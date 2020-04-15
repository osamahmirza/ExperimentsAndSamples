using ANewWebOrder;
using ANWO.Common;
using ANWO.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucLinksPublic : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
    }

    private void Initialize()
    {
        if (!IsPostBack)
        {
            if (Phone.Length > 4)
                lbPhone.Text = Phone.Substring(0, Phone.Length - 4) + "XXXX";
            else
                pnlPhone.Visible = false;

            if (Fax.Length > 4)
                lbFax.Text = Fax.Substring(0, Fax.Length - 4) + "XXXX";
            else
                pnlFax.Visible = false;
        }
    }


    public string Phone
    {
        get
        {
            if (ViewState["phone"] == null)
                return string.Empty;
            else
                return ViewState["phone"].ToString();
        }
        set
        {
            ViewState["phone"] = value;
        }
    }

    public string Fax
    {
        get
        {
            if (ViewState["fax"] == null)
                return string.Empty;
            else
                return ViewState["fax"].ToString();
        }
        set
        {
            ViewState["fax"] = value;
        }
    }
    protected void lbPhone_Click(object sender, EventArgs e)
    {
        lbPhone.Text = Phone;
    }
    protected void lbFax_Click(object sender, EventArgs e)
    {
        lbFax.Text = Fax;
    }
}