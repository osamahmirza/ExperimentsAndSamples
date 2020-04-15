using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Utility;
using System.Web.Security;
using GoProGo.Data;
using GoProGo.Data.Entity.Profile;
using System.IO;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Data.SqlClient;
using System.Data.Linq;
using GoProGo.Business.GoogleGeoCoder;

public partial class ucUsr_CreateUser : UserControlBase
{
    public event EventHandler OnBeforeUserCreate;
    public event EventHandler OnAfterUserCreate;
    public event EventHandler OnBeforeProfileCreate;
    public event EventHandler OnAfterProfileCreate;
    public event EventHandler OnCancelUserCreate;
    public event ControlError OnError;

    protected void Page_Load(object sender, EventArgs e)
    {
        hlHome.NavigateUrl = ConfigurationManager.AppSettings["HomeAddress"].ToString();
    }

    #region Properties
    public string Email
    {
        get
        {
            return tbEmail.Text.Trim();
        }
        set
        {
            tbEmail.Text = value;
        }
    }
    public string UserName
    {
        get
        {
            return tbUserName.Text.Trim();
        }
        set
        {
            tbUserName.Text = value;
        }
    }
    public string Password
    {
        get
        {
            return tbPassword.Text.Trim();
        }
        set
        {
            tbPassword.Text = value;
        }
    }
    public string ConfirmPassword
    {
        get
        {
            return tbConfirmPassword.Text.Trim();
        }
        set
        {
            tbConfirmPassword.Text = value;
        }
    }
    #endregion

    public void btnCreateUser_Click(object sender, EventArgs e)
    {
        if (OnBeforeUserCreate != null)
            OnBeforeUserCreate(this, new EventArgs());

        string userName = UserName.Trim();
        string email = Email.Trim();
        string password = Password.Trim();
        string confPassword = ConfirmPassword.Trim();
        MembershipCreateStatus createStatus = MembershipCreateStatus.UserRejected;
        MembershipUser user;

        try
        {
            if (password == confPassword)
            {
                if (password == confPassword)
                {
                    user = Membership.CreateUser(userName, password, email, null, null, false, out createStatus);
                    if (createStatus != MembershipCreateStatus.Success)
                        throw new Exception("User creation failed: " + createStatus.ToString());
                }
                else
                    throw new Exception("Password Comparison failed.");

                Roles.AddUsersToRole(new string[] { userName }, "Members");

                if (OnAfterUserCreate != null)
                    OnAfterUserCreate(this, new EventArgs());

                //Right after creating user create a new profile for this user
                if (OnBeforeProfileCreate != null)
                    OnBeforeProfileCreate(this, null);

                tblProfile prof = new tblProfile()
                {
                    UserID = new Guid(user.ProviderUserKey.ToString())
                    ,
                    RegistrationDate = DateTime.Parse(DateTime.Now.ToShortDateString())
                    ,
                    IsActive = false
                    ,
                    IsCompleted = false
                    ,
                    IsPublic = false
                    ,
                    MemberShipTypeID = (int)GoProGo.Business.Entities.MemberShipType.Standard
                    ,
                    Longitude = 0
                    ,
                    Latitude = 0
                };
                GoProGoDC.ProfileDC.tblProfiles.InsertOnSubmit(prof);
                GoProGoDC.ProfileDC.SubmitChanges();

                tblActivationRequest activation = new tblActivationRequest()
                {
                    ActivationID = Guid.NewGuid()
                    ,
                    Email = this.Email
                    ,
                    IsFulfilled = false
                    ,
                    ProfileID = prof.ID
                    ,
                    CreationDate = DateTime.Now
                };
                prof.tblActivationRequests.Add(activation);
                GoProGoDC.ProfileDC.SubmitChanges();


                pnlConfirmationMessage.Visible = true;
                pnlCreateUser.Visible = false;
                lblEmail.Text = Email;

                //if (OnAfterProfileCreate != null)
                //    OnAfterProfileCreate(this, null);
            }
            else
            {
                throw new Exception("Password comparison failed.");
            }
        }
        catch (SqlException ex)
        {
            if (createStatus == MembershipCreateStatus.Success)
                Membership.DeleteUser(userName);
            if (this.OnError != null)
                OnError(this, new ControlErrorArgs() { Severity = 10, Message = "General sql exception." });
        }
        catch (Exception ex)
        {
            if (createStatus == MembershipCreateStatus.Success)
                Membership.DeleteUser(userName);
            if (this.OnError != null)
                OnError(this, new ControlErrorArgs() { InnerException = ex });
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (OnCancelUserCreate != null)
            OnCancelUserCreate(this, null);
    }
   
}
