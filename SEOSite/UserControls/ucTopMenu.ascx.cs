using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;

public partial class UserControls_ucTopMenu : UserControlBase
{
    private const string _ACTIVE_CLASS = "class='active'";
    private const string _MENU = @"<li #home#><a href='Default.aspx'>Home</a></li> 
                                   <li #howto#><a href='ANewWebOrder-HOWTO.aspx'>How To</a></li>
                                   <li #seotips#><a href='ANewWebOrder-SEO-Tips.aspx'>SEO Tips</a></li>
                                   <li #contactus#><a href='ANewWebOrder-Contact-Us.aspx'>Contact Us</a></li>";

    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeMenu();
    }

    private void InitializeMenu()
    {
        string filename = System.IO.Path.GetFileName(Request.PhysicalPath);

        pnlMenu.Controls.Clear();

        if (filename.ToLower().Contains("default.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("home")));
        }
        else if (filename.ToLower().Contains("anewweborder-contact-us.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("contactus")));
        }
        else if (filename.ToLower().Contains("anewweborder-howto.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("howto")));
        }
        else if (filename.ToLower().Contains("anewweborder-seo-tips.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("seotips")));
        }
        else
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks(string.Empty)));
        }
    }

    private string ParsedLinks(string key)
    {
        string temp = _MENU;

        temp = temp.Replace("#" + key + "#", _ACTIVE_CLASS);

        temp = temp.Replace("#home#", "");
        temp = temp.Replace("#howto#", "");
        temp = temp.Replace("#seotips#", "");
        temp = temp.Replace("#contactus#", "");

        return temp;
    }
}