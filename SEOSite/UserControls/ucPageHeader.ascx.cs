using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;

public partial class ucPageHeader : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Header))
            this.Visible = false;
    }

    public void SetHeader(string header)
    {
        Header = header;
        if (!string.IsNullOrEmpty(_Header))
        {
            this.Visible = true;
        }
        else
        {
            this.Visible = false;
        }
    }

    //public void Set
   
    private string _Header;
    public string Header 
    {
        get
        {
            return _Header;
        }
        private set
        {
            _Header = value;
            LiteralControl control = new LiteralControl(_Header);
            pnlHeader.Controls.Add(control);
        }
    }
}
