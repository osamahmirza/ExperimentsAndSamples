using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using System.Web.UI.HtmlControls;
using GoProGo.Data.Entity.Profile;
using GoProGo.Data;
using GoProGo.VirtualFileSystem;
using System.Data.Linq;
using System.Web.Security;

public partial class ActivateAccount : PageBase
{
    string _ID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
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
                tblActivationRequest actReq = (from req in GoProGoDC.ProfileDC.tblActivationRequests
                                               where req.ActivationID.ToString() == _ID && !req.IsFulfilled
                                               select req).SingleOrDefault<tblActivationRequest>();

                if (actReq != null && actReq.IsFulfilled == false)
                {
                    MembershipUser user = Membership.GetUser(actReq.tblProfile.UserID);
                    if (!user.IsApproved)
                    {
                        //Approved user account first
                        user.IsApproved = true;
                        Membership.UpdateUser(user);
                        
                        //Following line will submit changes in DB for creating file
                        tblFileInformation fileInfo = VirtualFS.CreateFolder(user.UserName, actReq.tblProfile.ID, null);
                        actReq.tblProfile.RootFolderID = fileInfo.ID;
                        actReq.IsFulfilled = true;
                        //Following line will submit changes to update Profile

                        GoProGoDC.ProfileDC.SubmitChanges(ConflictMode.FailOnFirstConflict);
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
                throw new Exception("Invalid request.");
            }
        }
        catch (Exception ex)
        {
            ((PublicMaster)this.Master).ShowMessage(ex.Message, MessageType.Error);
        }
    }
}
