using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANWO.Utility;

public partial class UserControls_ucBusinessInfo : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public string CompanyName
    {
        get
        {
            return tbCompanyName.Text;
        }
        set
        {
            tbCompanyName.Text = value;
        }
    }

    public string Email
    {
        get
        {
            return tbEmail.Text;
        }
        set
        {
            tbEmail.Text = value;
        }
    }

    public string Name
    {
        get
        {
            return tbName.Text;
        }
        set
        {
            tbName.Text = value;
        }
    }

    public string Fax 
    {
        get
        {
            return tbFax.Text;
        }
        set
        {
            tbFax.Text = value;
        }
    }

    public string Phone 
    {
        get
        {
            return tbPhone.Text;
        }
        set
        {
            tbPhone.Text = value;
        }
    }
}