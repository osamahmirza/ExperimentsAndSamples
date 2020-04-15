using System;
using System.Web.Security;


/// <summary>
/// Summary description for ICommon
/// </summary>
namespace ANWO.Presentation
{
    public interface IMemberOperation
    {
        MembershipUser MembershipUser { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string UserName { get; }
        void UpdateMembershipUser();
    }
}