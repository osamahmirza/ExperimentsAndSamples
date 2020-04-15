using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;

public partial class UserControls_ucTopMenu : UserControlBase
{
    //TODO: when its time put it back
    //Billing has been taken out
    //<li #billing#><a href='Billing.aspx'>Billing</a></li>

    private const string _ACTIVE_CLASS = "class='active'";
    private const string _MENU = @"<li #cyberhawks#><a href='CyberHawkList.aspx'>Directory Listings</a></li> 
                                   <li #notifications#><a href='Notifications.aspx'>#notification#</a></li>
                                   <li #registrationinfo#><a href='RegistrationInfo.aspx'>Registration Info</a></li>
                                   <li #changepassword#><a href='ChangePassword.aspx'>Change Password</a></li>";
    private string notification;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeMenu();
    }

    private void InitializeMenu()
    {
        int count = 0;
        var alerts = DataContext.NWODC.tblAlerts.Where(a => a.ProfileID == this.SessionBag.Profile.ID && a.IsRead == false);
        if (alerts != null)
            count = alerts.Count();

        if (count > 0)
            notification = "Notifications (" + count.ToString() + " new )";
        else
            notification = "Notifications";

        string filename = System.IO.Path.GetFileName(Request.PhysicalPath);

        pnlMenu.Controls.Clear();

        if (filename.ToLower().Contains("cyberhawklist.aspx") || filename.ToLower().Contains("cyberhawkedit.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("cyberhawks")));
        }
        else if (filename.ToLower().Contains("notifications.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("notifications")));
        }
        else if (filename.ToLower().Contains("billing.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("billing")));
        }
        else if (filename.ToLower().Contains("registrationinfo.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("registrationinfo")));
        }
        else if (filename.ToLower().Contains("changepassword.aspx"))
        {
            pnlMenu.Controls.Add(new LiteralControl(ParsedLinks("changepassword")));
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

        temp = temp.Replace("#cyberhawks#", "");
        temp = temp.Replace("#notifications#", "");
        //TODO: when its time put it back
        //temp = temp.Replace("#billing#", "");
        temp = temp.Replace("#registrationinfo#", "");
        temp = temp.Replace("#changepassword#", "");
        temp = temp.Replace("#notification#",notification);

        return temp;
    }
}