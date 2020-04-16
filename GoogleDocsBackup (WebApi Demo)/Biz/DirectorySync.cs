using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Diagnostics;
using Google.Apis.Drive.v2.Data;

namespace DocumentListAPI.Entities
{
    public class DirectorySync
    {
        static DataClasses1DataContext db = new DataClasses1DataContext();

        public static void SynchronizeDir(ContextType ctxType)
        {
            PrincipalContext pc = LDAPConnector.Connect(ctxType);
            UserPrincipal up = new UserPrincipal(pc);
            PrincipalSearcher ps = new PrincipalSearcher();
            ps.QueryFilter = up;



            foreach (var item in ps.FindAll())
            {
                if (db.tbl_Users.Where(a => a.UserID == item.Guid.Value.ToString()).FirstOrDefault() == null && !string.IsNullOrEmpty(item.UserPrincipalName))
                {
                    db.tbl_Users.InsertOnSubmit(new tbl_User()
                                                {
                                                    UserID = item.Guid.Value.ToString(),
                                                    LastUpdated = DateTime.Now,
                                                    IsStudent = item.UserPrincipalName.ToLower().EndsWith("student.tdsb.net"),
                                                    Email = item.UserPrincipalName
                                                });

                }
                db.SubmitChanges();
            }

        }

        internal static List<tbl_User> GetAllUsers()
        {
            return db.tbl_Users.ToList();
        }

        internal static void PushFiles(string userID, List<Google.Apis.Drive.v2.Data.File> results, List<PermissionLight> permLight)
        {
            foreach (var item in results.Where(a => !a.MimeType.ToLower().Contains("folder")))
            {

                try
                {
                    string parentReference = SerializeDeSerialize<ParentReferenceCloneList>.ToStr(new ParentReferenceCloneList(item.Parents)); 
                    string ownerReference = SerializeDeSerialize<UserReferenceCloneList>.ToStr(new UserReferenceCloneList(item.Owners));
                    
                    tbl_Doc doc = new tbl_Doc()
                                    {
                                        OwnerID = userID,
                                        Title = item.Title,
                                        FilePath = item.AlternateLink,
                                        IsShared = (bool)(item.Shared == null ? false : item.Shared),
                                        MimeType = item.MimeType,
                                        DocPath = item.AlternateLink,
                                        CreationDate = DateTime.Parse(item.CreatedDate),
                                        LastUpdated = DateTime.Parse(item.ModifiedDate),
                                        DocID = item.Id,
                                        LastUpdatedBy = item.LastModifyingUserName,
                                        WebContentLink = item.WebContentLink,
                                        WebViewLink = item.WebViewLink,
                                        ThumbnailLink = item.ThumbnailLink,
                                        QuotaBytesUsed = item.QuotaBytesUsed,
                                        FileSize = item.FileSize,
                                        FileExtension = item.FileExtension,
                                        IconLink = item.IconLink,
                                        IsWritersCanShare = item.WritersCanShare,
                                        Kind = item.Kind,
                                        OrignalFileName = item.OriginalFilename,
                                        Owners = ownerReference,
                                        Parents = parentReference,
                                        AppDataContent = item.AppDataContents,
                                        DownloadUrl = item.DownloadUrl,
                                        Editable = item.Editable,
                                        EmbedLink = item.EmbedLink,
                                        ETag = item.ETag,
                                        ExplicitlyTrashed = item.ExplicitlyTrashed,
                                        ExportableLinks = (item.ExportLinks != null) ? string.Join("<break>", item.ExportLinks.ToList()) : string.Empty
                                    };

                    db.tbl_Docs.InsertOnSubmit(doc);
                    db.SubmitChanges();

                    var perm = permLight.Where(a => a.DocID.Trim() == item.Id.Trim()).SingleOrDefault();

                    if (perm != null && perm.Permissions != null)
                    {

                        var permissions = (from per in perm.Permissions.Items
                                           where perm.DocID == doc.DocID
                                           select new tbl_Permission()
                                           {
                                               AdditionalRoles = per.AdditionalRoles != null ? string.Join(";", per.AdditionalRoles) : null,
                                               AuthKey = per.AuthKey,
                                               DocID = doc.ID,
                                               ETag = per.ETag,
                                               Kind = per.Kind,
                                               Name = per.Name,
                                               PermissionID = per.Id,
                                               PhotoLink = per.PhotoLink,
                                               Role = per.Role,
                                               SelfLink = per.SelfLink,
                                               Type = per.Type,
                                               Value = per.Value,
                                               WithLink = per.WithLink != null ? per.WithLink.ToString() : "False"
                                           }).ToList();

                        foreach (var p in permissions)
                        {
                            db.tbl_Permissions.InsertOnSubmit(p);
                        }
                        db.SubmitChanges();
                    }
                    
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    
                }
            }
        }

        internal static void UpdateUserMetadata(Google.Apis.Drive.v2.Data.About about, string email)
        {
            var usr = db.tbl_Users.Where(a => a.Email.ToLower().Trim() == email.ToLower().Trim()).SingleOrDefault();

            usr.DomainSharingPolicy = about.DomainSharingPolicy;
            usr.ETag = about.ETag;
            usr.IsCurrentAppInstalled = about.IsCurrentAppInstalled;
            usr.Kind = about.Kind;
            usr.LargestChangeID = about.LargestChangeId;
            usr.Name = about.Name;
            usr.PermissionID = about.PermissionId;
            usr.QuotaBytesTotal = about.QuotaBytesTotal;
            usr.QuotaBytesUsed = about.QuotaBytesUsed;
            usr.QuotaBytesUsedInTrash = about.QuotaBytesUsedInTrash;
            usr.RootFolderID = about.RootFolderId;

            db.SubmitChanges();
        }
    }
}