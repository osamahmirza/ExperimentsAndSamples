using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Diagnostics;

public class Impersonator : IDisposable
{
    string user = ConfigurationManager.AppSettings["User"].ToString();
    string password = ConfigurationManager.AppSettings["Pwd"].ToString();
    string userDomain = ConfigurationManager.AppSettings["Domain"].ToString();

    IntPtr userHandle = new IntPtr(0);
    WindowsImpersonationContext impersonatedUser = null;

    //Impersonate user right in constructor
    public Impersonator()
    {
        bool returnValue = LogonUser(
         user,
         userDomain,
         password,
         LOGON32_LOGON_INTERACTIVE,
         LOGON32_PROVIDER_DEFAULT,
         ref userHandle
         );

        if (!returnValue)
        {
            //TODO: Log it with high severity
            throw new Exception("Invalid Username. ERROR: 3202");
        }

        WindowsIdentity newId = new WindowsIdentity(userHandle);
        impersonatedUser = newId.Impersonate();
        //Debug.WriteLine(WindowsIdentity.GetCurrent().Name);
    }


    #region IDisposable Members
    //Undo impersonation
    public void Dispose()
    {
        impersonatedUser.Undo();
        CloseHandle(userHandle);
    }

    #endregion

    public const int LOGON32_LOGON_INTERACTIVE = 2;
    public const int LOGON32_LOGON_SERVICE = 3;
    public const int LOGON32_PROVIDER_DEFAULT = 0;

    [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
    public static extern bool LogonUser(
      String lpszUserName,
      String lpszDomain,
      String lpszPassword,
      int dwLogonType,
      int dwLogonProvider,
      ref IntPtr phToken
    );

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public extern static bool CloseHandle(IntPtr handle);


}
