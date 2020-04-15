using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANewWebOrder;
using ANWO;
using System.Web.Security;
using ANWO.Presentation;
using ANWO.Utility;

public partial class ANewWebOrder_Activate_Account : BasePage
{
    string _ID = string.Empty;
    Data data = new Data();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public override void Load_Events()
    {
        this.AddMetaTag("EXPIRES", DateTime.Now.ToLongDateString());

        GetIDAndActivate();
    }
    private void GetIDAndActivate()
    {
        try
        {
            _ID = Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(_ID))
            {
                tblUserActivationRequest actReq = (from req in data.NWODC.tblUserActivationRequests
                                                    where req.RequestID.ToString() == _ID && !req.IsFulfilled
                                                   select req).SingleOrDefault<tblUserActivationRequest>();

                if (actReq != null && actReq.IsFulfilled == false)
                {
                    Guid guid = new Guid(actReq.UserID);
                    MembershipUser user = Membership.GetUser(guid);
                    if (!user.IsApproved)
                    {
                        //Approved user account first
                        user.IsApproved = true;
                        Membership.UpdateUser(user);

                        pnlSuccess.Visible = true;
                    }
                }
                else
                {
                    pnlFailure.Visible = true;
                }
            }
            else
            {
                Exception ex = new Exception("Invalid ID Provided.");
                ANWOLogger.WriteExceptionLog("Account Activation: Invalid ID Provided", ex, LogCategory.General, 3, System.Diagnostics.TraceEventType.Error);
                throw ex;
            }
        }
        catch (Exception ex)
        {
            ((IMessage)this.Master).ClearMessage();
            ((IMessage)this.Master).ShowMessage(ex.Message);
        }
    }
}