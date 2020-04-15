using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using ANWO.Presentation;
using ANWO;
using ANWO.Common;
using ANewWebOrder;
using ANWO.Utility;
using System.Net.Mail;
using ANWO.Biz.Entities;

public partial class Registration : BasePage
{
    MembershipUser _User = null;
    private const string _NOREPLYEMAILADDRESS = "no-reply@anewweborder.com";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
            Response.Redirect("default.aspx", false);
        if (!IsPostBack)
            Initialize();
    }

    private void Initialize()
    {
        if (SessionBag.RegistrationInfo != null)
            PersonInfo1.NWOProfile = SessionBag.RegistrationInfo;

        //TODO: Make it more solid than this
        tbTermsAndConditions.Text = DataContext.NWODC.tblAgreements.Where(a => a.tlkpAgreementType.Name == "Registration").SingleOrDefault().Agreement;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (chkIAgree.Checked)
            UserInfo1.SaveUser();
        else
        {
            ((IMessage)Master).ClearMessage();
            ((IMessage)Master).ShowMessage("Please accept the end user license agreement.");
        }
    }

    void PersonInfo1_OnError(object sender, ControlErrorArgs args)
    {
        ((IMessage)Master).ClearMessage();
        ((IMessage)Master).ShowMessage(args.Message);

        UserInfo1.Rollback();
    }

    void PersonInfo1_OnSuccess(object sender, EventArgs e)
    {
        tblUserActivationRequest request = null;

        try
        {
            request = new tblUserActivationRequest()
            {
                RequestID = Guid.NewGuid(),
                UserID = _User.ProviderUserKey.ToString(),
                IsFulfilled = false,
                ExpirationDate = DateTime.Now.Add(new TimeSpan(48, 0, 0))
            };

            DataContext.NWODC.tblUserActivationRequests.InsertOnSubmit(request);

            DataContext.NWODC.SubmitChanges();

            EmailMessage message = ANWO.Biz.EmailMessageFactory.GetAccountActivation("ACCOUNTACTIVATION", request.RequestID.ToString(), _User.Email);

            EmailSender.SendEmail(message.FromEmail, message.ToEmail, message.Title, message.Message, MailPriority.Normal, MailSendContext.Contact);

            Response.Redirect("~/ANewWebOrder-Account-Success.aspx", false);

        }
        catch (Exception ex)
        {
            ANWOLogger.WriteExceptionLog("Activation Request Failed", ex, LogCategory.Registration, 1);
            ((IMessage)Master).ClearMessage();
            ((IMessage)Master).ShowMessage(ex.Message);
        }
        //Create Activation request.
        //_User.P
        //Response.Redirect("~/Members/CampaignList.aspx");
        //Move to next page
    }

    void UserInfo1_OnError(object sender, ControlErrorArgs args)
    {
        ((IMessage)Master).ClearMessage();
        ((IMessage)Master).ShowMessage(args.Message);
    }

    void UserInfo1_OnSuccess(object sender, EventArgs e)
    {
        _User = sender as System.Web.Security.MembershipUser;
        PersonInfo1.SaveProfile(_User);
    }

    #region ICommon

    public override void Load_Events()
    {
        PersonInfo1.OnError += new ControlError(PersonInfo1_OnError);
        PersonInfo1.OnSuccess += new EventHandler(PersonInfo1_OnSuccess);
        UserInfo1.OnError += new ControlError(UserInfo1_OnError);
        UserInfo1.OnSuccess += new EventHandler(UserInfo1_OnSuccess);
    }

    #endregion

}