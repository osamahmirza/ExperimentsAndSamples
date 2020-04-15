using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class ucMessageBox : UserControlBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Message))
        {
            this.Visible = false;
        }
    }

    public void SetMessage(string message, MessageType type)
    {
        Message = message;
        Type = type;

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
        Type = MessageType.None;
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

    private MessageType _Type;
    public MessageType Type 
    {
        get
        {
            return _Type;
        }
        private set
        {
            _Type = value;
            switch (_Type)
            {
                case MessageType.Information:
                    imgIcon.ImageUrl = "~/App_Themes/Default/Images/MessageBox/Information.gif";
                    imgIcon.Visible = true;
                    break;
                case MessageType.Warning:
                    imgIcon.ImageUrl = "~/App_Themes/Default/Images/MessageBox/Warning.gif";
                    imgIcon.Visible = true;
                    break;
                case MessageType.Error:
                    imgIcon.ImageUrl = "~/App_Themes/Default/Images/MessageBox/Error.gif";
                    imgIcon.Visible = true;
                    break;
                case MessageType.None:
                    imgIcon.ImageUrl = string.Empty;
                    imgIcon.Visible = false;
                    break;
                default:
                    break;
            }
        }
    }
}
