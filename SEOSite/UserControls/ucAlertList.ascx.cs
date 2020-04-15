using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANewWebOrder;
using ANWO;

public partial class UserControls_Alerts : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        gvAlerts.RowCommand += new GridViewCommandEventHandler(gvAlerts_RowCommand);
        gvAlerts.RowCreated += new GridViewRowEventHandler(gvAlerts_RowCreated);
        gvAlerts.PageIndexChanged += new EventHandler(gvAlerts_PageIndexChanged);
    }

    void gvAlerts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbutton = (LinkButton)e.Row.FindControl("lnkSubject");
            Label lblLabel = (Label)e.Row.FindControl("tbDateCreated");

            tblAlert alert = e.Row.DataItem as tblAlert;

            if (alert != null && alert.IsRead == false)
            {
                lnkbutton.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
                lblLabel.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
            }
        }
    }

    void gvAlerts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string id = e.CommandArgument.ToString();
            int intID = Convert.ToInt32(id);
            
            Data data = new Data();
            var alert = data.NWODC.tblAlerts.SingleOrDefault(a => a.ID == intID);
            alert.IsRead = true;
            data.NWODC.SubmitChanges();
            
            FillAlertMessage(alert);
            gvAlerts.DataBind();
        }
    }

    private void FillAlertMessage(tblAlert alert = null)
    {
        if (alert != null)
        {
            lblSubject.Text = alert.Subject;
            lblDateTime.Text = alert.FormattedDateCreated;
            lblMessage.Text = alert.Message;
        }
        else
        {
            lblSubject.Text = string.Empty;
            lblDateTime.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }
    }

    void gvAlerts_PageIndexChanged(object sender, EventArgs e)
    {
        FillAlertMessage();
    }
    
}