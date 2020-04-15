using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANWO.Presentation;
using System.Web.Security;
using System.Data.SqlClient;
using ANWO.Common;

public partial class UserInfo : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private MembershipUser _User;
    public MembershipUser User
    {
        get
        {
            return _User;
        }
        set
        {
            _User = value;
            if (!IsPostBack)
                FillEditableFields();
        }
    }

    private void FillEditableFields()
    {
        tbUserName.Text = User.UserName;
        tbEmail.Text = User.Email;
        tbConfirmEmail.Text = User.Email;
    }

    public bool Validate()
    {
        if (!IsEdit)
        {
            if (string.IsNullOrEmpty(UserNameOnPage) || string.IsNullOrEmpty(EmailOnPage) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword) || !Page.IsValid)
                return false;
            if (Password != ConfirmPassword)
                return false;
        }
        else
        {
            if (string.IsNullOrEmpty(EmailOnPage.Trim()))
                return false;
        }
        return true;
    }

    public void SaveUser()
    {
        if (IsEdit)
            UpdateUser();
        else
            CreateUser();

    }

    private void CreateUser()
    {
        if (!Validate())
            ThrowError(this, new ControlErrorArgs() { InnerException = new Exception("Validation Failed: One or more fields have invalid value."), Message = "One or more fields have invalid value.", Severity = 6 });
        else
        {
            MembershipCreateStatus createStatus = MembershipCreateStatus.UserRejected;
            MembershipUser user = null;
            try
            {
                user = Membership.CreateUser(UserNameOnPage, Password, EmailOnPage, null, null, false, out createStatus);

                switch (createStatus)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        throw new Exception("Duplicate Email.");
                    case MembershipCreateStatus.DuplicateUserName:
                        throw new Exception("Duplicate User Name.");
                    case MembershipCreateStatus.InvalidEmail:
                        throw new Exception("Invalid email.");
                    case MembershipCreateStatus.InvalidPassword:
                        throw new Exception("Invalid password.");
                    case MembershipCreateStatus.InvalidUserName:
                        throw new Exception("Invalid User Name.");
                    case MembershipCreateStatus.UserRejected:
                        throw new Exception("User rejected.");
                    default:
                        break;
                }

                //**Is Approved**//
                user.IsApproved = false;
                Membership.UpdateUser(user);

                if (createStatus != MembershipCreateStatus.Success)
                    ThrowError(this, new ControlErrorArgs() { Message = "User creation failed: " + createStatus.ToString(), Severity = 3 });

                Roles.AddUsersToRole(new string[] { UserNameOnPage }, "Members");
                ThrowSuccess(user, new EventArgs());

            }
            catch (SqlException ex)
            {
                if (createStatus == MembershipCreateStatus.Success)
                    Membership.DeleteUser(UserNameOnPage);
                ThrowError(this, new ControlErrorArgs() { InnerException = ex, Severity = 3, Message = "General sql exception." });
            }
            catch (Exception ex)
            {
                if (createStatus == MembershipCreateStatus.Success)
                    Membership.DeleteUser(UserNameOnPage);
                ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });
            }
        }
    }

    private void UpdateUser()
    {
        if (Validate())
        {
            MembershipUser user = SessionBag.MembershipUser;
            try
            {
                user.Email = tbEmail.Text.Trim();
                Membership.UpdateUser(user);
                SessionBag.MembershipUser = user;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("email"))
                    ThrowError(this, new ControlErrorArgs() { Severity = 6, Message = "Email already exists." });
                else
                    ThrowError(this, new ControlErrorArgs() { Severity = 6, Message = "User cannot be updated." });
            }
            ThrowSuccess(user, new EventArgs());
        }
        else
            ThrowError(this, new ControlErrorArgs() { Message = "Email is invalid.", Severity = 6 });
    }

    public void Rollback()
    {
        Membership.DeleteUser(UserNameOnPage);
    }

    public string UserNameOnPage
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

    public string EmailOnPage
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

    public string ConfirmEmail
    {
        get
        {
            return tbConfirmEmail.Text.Trim();
        }
        set
        {
            tbConfirmEmail.Text = value;
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

    private bool _IsEdit;
    public bool IsEdit
    {
        get
        {
            return _IsEdit;
        }
        set
        {
            _IsEdit = value;
            if (_IsEdit)
            {
                tbUserName.Enabled = false;
                tbPassword.Visible = false;
                tbConfirmPassword.Visible = false;
                rfvPassword.Visible = false;
                cvEmail0.Visible = false;
                lblPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                lblHelp.Visible = false;
            }
        }
    }

}