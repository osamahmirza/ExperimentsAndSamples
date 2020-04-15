using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;

public partial class ucMessageBox : UserControlBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Message))
        {
            this.Visible = false;
        }
    }

    public void SetMessage(string message)
    {
        Message = message;

        if (!string.IsNullOrEmpty(Message))
        {
            this.Visible = true;
        }
        else
        {
            this.Visible = false;
        }
    }
    public void ClearMessage()
    {
        Message = string.Empty;
        this.Visible = false;
    }

    private string _Message;
    public string Message 
    {
        get
        {
            return _Message;
        }
        private set 
        {
            _Message = value;
            lblMessage.Text = _Message; 
        }
    }
}
