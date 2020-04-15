using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using ANWO;
using ANWO.Utility;
using ANewWebOrder;
using System.Reflection;
using System.Configuration;
using ANWO.Common;
using System.Net.Mail;

public partial class UserControls_ucPayment : UserControlBase
{
    int _CampID = 0;
    Data _Data = new Data();
    tblProfile _Profile;
    tblCampaign _Campaign;
    tblPlan _Plan;
    tblInvoice _Invoice;
    SessionStateBag _SessionBag = new SessionStateBag();
    string _PayPalMode = string.Empty;


    private const string _no_shipping = "<input type='hidden' name='no_shipping' value='#no_shipping#' />";
    //If user presses cancel
    private const string _cancel_return = "<input type='hidden' name='cancel_return' value='#cancel_return#' />";
    //Auto Return should be enabled, success message, if you use following, then user will have to click on link to come back, not automatically
    //private const string _return = "<input type='hidden' name='return' value='#return#' />";
    //IPN handler
    private const string _notify_url = "<input type='hidden' name='notify_url' value='#notify_url#' />";

    private const string _cmd = "<input type='hidden' name='cmd' value='#cmd#'>";
    private const string _business = "<input type='hidden' name='business' value='#business#'>";
    private const string _lc = "<input type='hidden' name='lc' value='#lc#'>";
    private const string _item_name = "<input type='hidden' name='item_name' value='#item_name#'>";
    private const string _item_number = "<input type='hidden' name='item_number' value='#item_number#'>";
    private const string _amount = "<input type='hidden' name='amount' value='#amount#'>";
    private const string _currency_code = "<input type='hidden' name='currency_code' value='#currency_code#'>";
    private const string _button_subtype = "<input type='hidden' name='button_subtype' value='#button_subtype#'>";
    private const string _tax_rate = "<input type='hidden' name='tax_rate' value='#tax_rate#'>";
    private const string _shipping = "<input type='hidden' name='shipping' value='#shipping#'>";
    private const string _bn = "<input type='hidden' name='bn' value='#bn#'>";
    private const string _custom = "<input type='hidden' name='custom' value='#custom#'>";

    protected void Page_Load(object sender, EventArgs e)
    {
        _PayPalMode = _SessionBag.PayPalMode;

        GetQueryStringParamsAndPopulateControl();
    }

    private void SetBuyNowPostAddress()
    {
        if (_PayPalMode == "dev")
            imgbtnBuyNow.PostBackUrl = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "buynow_sandbox").Setting;
        else
            imgbtnBuyNow.PostBackUrl = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "buynow").Setting;

        imgbtnBuyNow.ImageUrl = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "buynow_img_url").Setting;
    }

    private void CreateInvoice()
    {

        if (!IsPostBack)
        {
            _Invoice = new tblInvoice();
            UpdateInvoiceData();
            _Data.NWODC.tblInvoices.InsertOnSubmit(_Invoice);
        }
        else
        {
            _Invoice = _Data.NWODC.tblInvoices.SingleOrDefault<tblInvoice>(a => a.ID == InvoiceID);
            if (_Invoice == null)
                ThrowError(this, new ControlErrorArgs() { Message = "Invoice is not found. Please contact webmaster.", Severity = 1 });

            UpdateInvoiceData();
        }

        _Data.NWODC.SubmitChanges();
    }

    private void UpdateInvoiceData()
    {
        _Invoice.ID = InvoiceID;
        _Invoice.CampaignID = _Campaign.ID;
        _Invoice.ProfileID = _Profile.ID;
        _Invoice.PlanID = _Plan.ID;
        _Invoice.MCGross = _Plan.TotalAmount.ToString();
        _Invoice.ItemName = _Plan.Name;
        _Invoice.ItemNumber = _Plan.ID.ToString();
        _Invoice.CreatedDate = DateTime.Now;
        _Invoice.CustomerIP = Request.UserHostAddress;
    }

    private void CreatePaypalHiddenFields()
    {
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_no_shipping, "no_shipping")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_cancel_return, "cancel_return")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_notify_url, "notify_url"))); //<--IPN
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_cmd, "cmd")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_business, "business")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_lc, "lc")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_item_name, "item_name")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_item_number, "item_number")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_amount, "amount")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_currency_code, "currency_code")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_button_subtype, "button_subtype")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_tax_rate, "tax_rate")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_shipping, "shipping")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_bn, "bn")));
        pnlHiddenVariables.Controls.Add(new LiteralControl(BindToExpression(_custom, "custom")));
    }

    private string BindToExpression(string expression, string property)
    {
        PropertyInfo pInfo = this.GetType().GetProperty(property);
        object value = pInfo.GetValue(this, null);

        string toReturn = expression.Replace("#" + property + "#", value.ToString());

        return toReturn;
    }

    private void GetQueryStringParamsAndPopulateControl()
    {
        string campID = Request.QueryString["ID"];

        _CampID = TryToParse(campID);

        if (!ValidateCampaignAndProfile())
        {
            ThrowError(this, new ControlErrorArgs()
            {
                InnerException = new Exception("Validation failed for CampaignID " +
                                              campID + " provided by user. Request came from user: " +
                                              this.MembershipUser.UserName +
                                              " from IP: " +
                                              Request.UserHostAddress),
                Message = "Invalid CyberHawk.",
                Severity = 1
            });
            this.Visible = false;
        }
        else
        {
            this.Visible = true;
            FetchCampaign();
            ProcceedWorkflow();
            PopulateControlsBasedOnPlan();
            CreateInvoice();
            CreatePaypalHiddenFields();
            SetBuyNowPostAddress();
        }
    }

    private void FetchCampaign()
    {
        _Profile = _Campaign.tblProfile;
    }

    private void ProcceedWorkflow()
    {
        if (!IsPostBack)
        {

            BindCombobox();
            //select an option
            ddlPaymentOption.SelectedIndex = 1;
            lblCampaign.Text = "Title: " + _Campaign.Title + ", Header: " + _Campaign.Header;
        }
    }


    private bool ValidateCampaignAndProfile()
    {
        bool result = true;
        //setting campaign
        _Campaign = _Data.NWODC.tblCampaigns.Where(a => a.ID == _CampID).SingleOrDefault();

        if (_Campaign == null)
            result = false;
        //setting profile
        return result;
    }

    private int TryToParse(string value)
    {
        int number;
        bool result = Int32.TryParse(value, out number);
        if (!result)
        {
            number = 0;
        }
        return number;
    }


    private void BindCombobox()
    {
        //Find out if user has consumed free plantypes or if he can

        _Profile = _Campaign.tblProfile;

        PlanType expectedPlansType = _Profile.GetConsumedDiscountedPlanTypes();


        ddlPaymentOption.DataSource = tblPlan.GetPlansAfterFilter(expectedPlansType);

        ddlPaymentOption.DataTextField = "PlanDisplayName";
        ddlPaymentOption.DataValueField = "ID";

        ddlPaymentOption.DataBind();
    }
    protected void ddlPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateControlsBasedOnPlan();
    }

    private void PopulateControlsBasedOnPlan()
    {
        _Plan = _Data.NWODC.tblPlans.Where(a => a.ID == Convert.ToInt32(ddlPaymentOption.SelectedValue)).SingleOrDefault();
        if (_Plan != null)
        {
            if (_Plan.ID != 1)
            {
                imgbtnBuyNow.Enabled = true;
                imgbtnBuyNow.Visible = true;
                btnApplyFreeOffer.Enabled = false;
                btnApplyFreeOffer.Visible = false;
            }
            else
            {
                imgbtnBuyNow.Enabled = false;
                imgbtnBuyNow.Visible = false;
                btnApplyFreeOffer.Enabled = true;
                btnApplyFreeOffer.Visible = true;
            }

            lblTotal.Text = string.Format("{0:C}", _Plan.TotalAmount);
            lblMonths.Text = _Plan.Units.ToString();

            if (_Campaign.ExpiryDate == null)
                lblEstimatedExpirationDate.Text = string.Format("{0:ddd, MMM d, yyyy}", DateTime.Now.AddMonths(_Plan.Units));
            else
                lblEstimatedExpirationDate.Text = string.Format("{0:ddd, MMM d, yyyy}", ((DateTime)_Campaign.ExpiryDate).AddMonths(_Plan.Units));
        }
        else
        {
            imgbtnBuyNow.Enabled = false;
            ThrowError(this, new ControlErrorArgs()
            {
                InnerException = new Exception("Validation of Plan for ProfileID" +
                                              ddlPaymentOption.SelectedValue + ", " + _Profile.ID + " has been provided by user. Request came from user: " +
                                              this.MembershipUser.UserName +
                                              " from IP: " +
                                              Request.UserHostAddress),
                Message = "Invalid Profile.",
                Severity = 1
            });
        }
    }

    protected void imgbtnBuyNow_Click(object sender, ImageClickEventArgs e)
    {

    }

    public string custom
    {
        get
        {
            return InvoiceID;
        }
    }

    public string notify_url
    {
        get
        {
            if (_PayPalMode == "dev")
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "notify_url_sandbox").Setting;
            else
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "notify_url").Setting; ;
        }
    }

    public string cancel_return
    {
        get
        {
            if (_PayPalMode == "dev")
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "cancel_return_sandbox").Setting;
            else
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "cancel_return").Setting;
        }
    }

    //Prompt customer for shipping address. 
    //Default or 0: customer is prompted to include a shipping address. 
    //1: customer is not asked for a shipping address. 
    //2: customer must provide a shipping address.
    public string no_shipping
    {
        get
        {
            return "1";
        }
    }

    public string currency_code
    {
        get
        {
            if (_PayPalMode == "dev")
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "currency_code_sandbox").Setting;
            else
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "currency_code").Setting;
        }
    }

    public string shipping { get { return "0.00"; } }

    public string tax_rate { get { return "0.00"; } }

    public string button_subtype
    {
        get
        {
            if (_PayPalMode == "dev")
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "button_subtype_sandbox").Setting;
            else
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "button_subtype").Setting;
        }
    }

    public string amount
    {
        get
        {
            return Math.Round(_Plan.TotalAmount, 2).ToString();
        }
    }

    public string item_name
    {
        get
        {
            return _Plan.Name;
        }
    }


    public string item_number
    {
        get
        {
            return _Plan.ID.ToString();
        }
    }

    public string bn
    {
        get
        {
            if (_PayPalMode == "dev")
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "bn_sandbox").Setting;
            else
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "bn").Setting;
        }
    }

    public string cmd
    {
        get
        {
            if (_PayPalMode == "dev")
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "cmd_sandbox").Setting;
            else
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "cmd").Setting;
        }
    }

    public string business
    {
        get
        {
            if (_PayPalMode == "dev")
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "business_sandbox").Setting;
            else
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "business").Setting;
        }
    }

    public string lc
    {
        get
        {
            if (_PayPalMode == "dev")
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "lc_sandbox").Setting;
            else
                return _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "lc").Setting;
        }
    }

    public string InvoiceID
    {
        get
        {
            if (ViewState["InvoiceID"] == null)
                ViewState["InvoiceID"] = Guid.NewGuid().ToString("N") + "-" + Session.SessionID;
            return ViewState["InvoiceID"].ToString();
        }
    }
    protected void btnApplyFreeOffer_Click(object sender, EventArgs e)
    {
        try
        {
            var invoice = _Data.NWODC.tblInvoices.Where(a => a.ID == InvoiceID).SingleOrDefault();
            invoice.MCGross = "0.0";
            invoice.Quantity = "1";
            invoice.Shipping = "0";
            invoice.Tax = "0";
            invoice.PaymentDate = DateTime.Now.ToString();
            invoice.PaymentStatus = "Completed";
            invoice.ItemNumber = "1";
            invoice.TxnID = Guid.NewGuid().ToString();

            ANewWebOrder.tblCampaign camp = invoice.tblCampaign;

            camp.LastPaymentDate = DateTime.Now;
            camp.LastUpdated = DateTime.Now;
            camp.IsPendingSetup = false;
            camp.IsLive = true;

            ANewWebOrder.tblPlan plan = invoice.tblPlan;

            if (plan.PlanDurationUnitTypeID == 1)
                camp.ExpiryDate = DateTime.Now.AddYears(plan.Units);
            else if (plan.PlanDurationUnitTypeID == 2)
                camp.ExpiryDate = DateTime.Now.AddMonths(plan.Units);
            else if (plan.PlanDurationUnitTypeID == 3)
                camp.ExpiryDate = DateTime.Now.AddDays(plan.Units * 7);
            else if (plan.PlanDurationUnitTypeID == 4)
                camp.ExpiryDate = DateTime.Now.AddDays(plan.Units);

            _Data.NWODC.SubmitChanges();

            ANWOLogger.WritePaymentLog("Free Payment Completed.", invoice, invoice, LogCategory.HighAlert, 1);

            ANWO.Biz.Entities.EmailMessage message = ANWO.Biz.EmailMessageFactory.GetPaymentInvoice("PAYMENTINVOICE", invoice.ID);

            ANWO.Utility.EmailSender.SendEmail(message.FromEmail, message.ToEmail, message.Title, message.Message, MailPriority.High, MailSendContext.PaypalHandler);

            ANWOLogger.WritePaymentLog("Sent Email to Payer for Payment - Free!", invoice, invoice, LogCategory.HighAlert, 1);

            Response.Redirect("~/ANewWebOrder-PaymentSuccess.aspx",false);
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Invalid Invoice.", Severity = 1 });
        }
    }
}