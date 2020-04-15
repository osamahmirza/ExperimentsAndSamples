using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;

public partial class ucPageHeader : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Header))
            this.Visible = false;
    }

    public void SetHeader(string header, MyAccountType type)
    {
        Header = header;
        Type = type;
        if (!string.IsNullOrEmpty(_Header))
        {
            this.Visible = true;
            this.Page.Title = _Header;
        }
        else
        {
            this.Visible = false;
        }
    }

    private MyAccountType _Type;
    public MyAccountType Type 
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
                case MyAccountType.Profile:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.Favourite:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.Messages:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.Traffic:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.CommentsAndScore:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.ChangePassword:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.SMSAlerts:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.Advertisments:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.Billing:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.MembershipStatus:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                case MyAccountType.None:
                    imgHeader.ImageUrl = "~/App_Themes/Default/Images/PageIcons/Calculator.png";
                    break;
                default:
                    break;
            }
        }
    }
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
            lblHeader.Text = _Header;
        }
    }
}
