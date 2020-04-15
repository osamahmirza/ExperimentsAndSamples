using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.GData.Client;
using Google.GData.Documents;
using Google.Apis.Authentication;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Requests;
using System.IO;
using DotNetOpenAuth.OpenId.RelyingParty;
using DocumentListAPI.Entities;
using DotNetOpenAuth.OAuth2;


namespace DocumentListAPI
{
    public partial class _Default : System.Web.UI.Page
    {

        string ClientID = "xxxxxxx.apps.googleusercontent.com";
        string ServiceAccountEmail = "xxxxxxxxx@developer.gserviceaccount.com";
        string KeyFile = "xxxxxxxxxxxx-privatekey.p12";
        string KeySecret = "notasecret";

        X509Certificate2 _Certificate;
        static DataClasses1DataContext db = new DataClasses1DataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateDashboard();
        }

        private void GenerateDashboard()
        {
            //Total Users
            lblTotalUsers.Text = "Total Users: " + db.tbl_Users.Count().ToString();

            //Total Quota
            Int64 totalQuota = 0;
            foreach (var item in db.tbl_Users)
            {
                if (item.QuotaBytesUsed != null)
                    totalQuota += Int64.Parse(item.QuotaBytesUsed);
            }
            lblTotalQuotaUsed.Text = "Total Quota used in MB: " + ((totalQuota / 1024) / 1024).ToString();

            //Total External Users
            var uPerm = (from a in db.tbl_Permissions
                         where a.Role == "owner"
                         select a
                         ).Distinct();
            var joinwithusers = (from perm in uPerm
                                 where !(db.tbl_Users.Any(entry => entry.PermissionID == perm.PermissionID))
                                 select new { PermissionID = perm.PermissionID, Name = perm.Name }).Distinct();
            lblTotalUsersExternal.Text = "External Users: " + joinwithusers.Count().ToString();

            //Domain Wide with Link
            var domainwidewithlink = (from perm in db.tbl_Permissions
                                      where perm.Type == "domain" && perm.WithLink == "True"
                                      select perm.PermissionID).Distinct();

            lblSharedDomainWithLink.Text = "Domain wide with link: " + domainwidewithlink.Count();

            //Domain wide
            var domainwide = (from perm in db.tbl_Permissions
                              where perm.Type == "domain" && perm.WithLink == "False"
                              select perm.PermissionID).Distinct();
            lblSharedDomainWithoutLink.Text = "Domain wide: " + domainwide.Count();

            //public with link
            var publicwithlink = (from perm in db.tbl_Permissions
                                  where perm.PermissionID == "anyoneWithLink" && perm.Type == "anyone" && perm.WithLink == "True"
                                  select perm.PermissionID).Distinct();
            lblSharedpublicwithlink.Text = "Public with link: " + publicwithlink.Count();

            //Domain wide
            var publicly = (from perm in db.tbl_Permissions
                            where perm.PermissionID == "anyone" && perm.Type == "anyone" && perm.WithLink == "False"
                            select perm.PermissionID).Distinct();
            lblSharedPublic.Text = "Public: " + publicly.Count();

            //Shared from ppl outside
            //var fromoutside = from a in db.tbl_Docs
            //                  from b in db.tbl_Permissions
            //                  where a.ID == b.DocID && b.Role == "owner"

        }

        private void LoadCertificate()
        {
            string combinedCertFileName = Path.Combine(HttpRuntime.AppDomainAppPath, KeyFile);

            _Certificate = new X509Certificate2(combinedCertFileName, KeySecret, X509KeyStorageFlags.Exportable);
        }

        private void SyncUsersWithDatabase()
        {
            DirectorySync.SynchronizeDir(System.DirectoryServices.AccountManagement.ContextType.ApplicationDirectory);
        }

        private DriveService CreateDriveService(string userEmail)
        {
            var auth = GetAuthenticator(userEmail);


            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                Authenticator = auth,
            });


            //Cache it in session
            return service;
        }

        private Oauth2Service CreateUserInfoService(string userEmail)
        {
            var auth = GetAuthenticator(userEmail);

            // Create the service.
            var service = new Oauth2Service(new BaseClientService.Initializer()
            {
                Authenticator = auth
            });

            //cache it in session
            return service;
        }

        private OAuth2Authenticator<AssertionFlowClient> GetAuthenticator(string userEmail)
        {
            var provider = new AssertionFlowClient(GoogleAuthenticationServer.Description, _Certificate)
            {
                ServiceAccountId = ServiceAccountEmail,
                // Scope = "https://www.googleapis.com/auth/userinfo.email", 
                // Scope = "https://www.googleapis.com/auth/userinfo.profile",
                // Scope = "https://docs.google.com/feeds/",
                Scope = "https://www.googleapis.com/auth/drive", //drive
                ServiceAccountUser = userEmail,
            };

            var auth = new OAuth2Authenticator<AssertionFlowClient>(provider, AssertionFlowClient.GetState);
            return auth;
        }

        public void RetrieveAllFiles()
        {
            List<tbl_User> list = DirectorySync.GetAllUsers();
            List<Google.Apis.Drive.v2.Data.File> result = new List<Google.Apis.Drive.v2.Data.File>();

            foreach (var item in list)
            {

                var drvService = CreateDriveService(item.Email);
                FilesResource.ListRequest request = drvService.Files.List();
                //request.Q = "'" + item.Email + "'" + " in owners";

                Google.Apis.Drive.v2.Data.About about = drvService.About.Get().Fetch();
                DirectorySync.UpdateUserMetadata(about, item.Email);
                result.Clear();

                do
                {
                    try
                    {
                        FileList files = request.Fetch();
                        result.AddRange(files.Items);
                        request.PageToken = files.NextPageToken;
                    }
                    catch (Exception e)
                    {
                        Response.Write("An error occurred: " + e.Message);
                        request.PageToken = null;
                    }
                }
                while (!String.IsNullOrEmpty(request.PageToken));

                if (result != null || result.Count > 0)
                {
                    PermissionList permList = new PermissionList();
                    List<PermissionLight> permLight = new List<PermissionLight>();
                    foreach (var f in result.Where(a => !a.MimeType.ToLower().Contains("folder")))
                    {
                        if (f.Shared == true)
                        {
                            permList = drvService.Permissions.List(f.Id).Fetch();

                            permLight.Add(new PermissionLight()
                                            {
                                                DocID = f.Id,
                                                Permissions = permList
                                            });
                        }
                    }

                    DirectorySync.PushFiles(item.UserID, result, permLight);
                }
            }
        }
    }
}
