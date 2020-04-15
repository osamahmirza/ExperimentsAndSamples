using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANewWebOrder;
using ANWO;

public partial class UserControls_Bills : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        gvInvoice.RowCommand += new GridViewCommandEventHandler(gvAlerts_RowCommand);
        gvInvoice.RowCreated += new GridViewRowEventHandler(gvAlerts_RowCreated);
        gvInvoice.PageIndexChanged += new EventHandler(gvAlerts_PageIndexChanged);
    }

    void gvAlerts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        
    }

    void gvAlerts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string id = e.CommandArgument.ToString();
            
            Data data = new Data();
            var invoice = data.NWODC.tblInvoices.SingleOrDefault(a => a.ID == id);

            FillAlertMessage(invoice);
            gvInvoice.DataBind();
        }
    }

    private void FillAlertMessage(tblInvoice invoice = null)
    {
        if (invoice != null)
        {
            lblTransaction.Text = invoice.Invoice.ToString();
            lblPaymentDate.Text = invoice.FormattedCreatedDate;
            lblFormattedAmountPaid.Text = invoice.FormattedMCGross;
            lblStatus.Text = invoice.PaymentStatus;
        }
        else
        {
            lblTransaction.Text = string.Empty;
            lblPaymentDate.Text = string.Empty;
            lblFormattedAmountPaid.Text = string.Empty;
            lblStatus.Text = string.Empty;
        }
    }

    void gvAlerts_PageIndexChanged(object sender, EventArgs e)
    {
        FillAlertMessage();
    }
    
}