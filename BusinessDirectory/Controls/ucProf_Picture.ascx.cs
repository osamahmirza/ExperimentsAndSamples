using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using GoProGo.Utility;
using System.IO;
using GoProGo.Presentation;
using GoProGo.Data.Entity.Profile;
using GoProGo.VirtualFileSystem;


public partial class ucProf_Picture : UserControlBase
{
    public event EventHandler OnPictureUploaded;

    private const string PICTURE_HANDLER = @"~\PublicFile.ashx?ProfPicture=";

    private tblProfile _ObjProfile;
    public tblProfile ObjProfile
    {
        get
        {
            return _ObjProfile;
        }
        set
        {
            _ObjProfile = value;
            if (!IsPostBack)
                Initialize();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        SetObj();
    }
    private void SetObj()
    {
        //tblProfile prof = GoProGo.Data.GoProGoDC.ProfileDC.tblProfiles.First(pro => pro.UserID.ToString() == MembershipUser.ProviderUserKey.ToString());
        ////This will trigger Initialize if !IsPostback
        //ObjProfile = prof;

        ObjProfile = SessionBag.Profile;

    }
    private void Initialize()
    {
        if (ObjProfile != null && !string.IsNullOrEmpty(ObjProfile.NormalProfilePicture))
        {
            ShowPicture(Path.GetFileName(ObjProfile.NormalProfilePicture));
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string tempFileName = string.Empty;
        string tempFileNameAndPath = string.Empty;
        string currentFileStorage = ConfigurationManager.AppSettings["CurrentFileStorage"].ToString();
        string tempFileStorage = ConfigurationManager.AppSettings["TempFileStorage"].ToString();
        string normalAspectSize = ConfigurationManager.AppSettings["NormalPicAspect"].ToString();
        string smallAspectSize = ConfigurationManager.AppSettings["SmallPicAspect"].ToString();
        string profilePictureFolder = ConfigurationManager.AppSettings["ProfilePictureFolder"].ToString();

        System.Drawing.Image normalImage = null;
        System.Drawing.Image smallImage = null;

        string normalFullName = string.Empty;
        string smallFullName = string.Empty;

        //System Folder
        tblFileInformation sysFolder;
        //Temporary System Folder
        tblFileInformation tempSysFolder;

        long normalImageLength;
        long smallImageLength;

        if (FileUpload1.HasFile)
            try
            {
                using (Impersonator imp = new Impersonator())
                {
                    tempFileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToLongDateString();
                    tempFileNameAndPath = tempFileStorage + tempFileName;
                    FileUpload1.SaveAs(tempFileNameAndPath);

                    normalImage = Common.ResizePic(tempFileNameAndPath, ImageFormat.Jpeg, int.Parse(normalAspectSize));
                    smallImage = Common.ResizePic(tempFileNameAndPath, ImageFormat.Jpeg, int.Parse(smallAspectSize));

                    smallFullName = currentFileStorage + Guid.NewGuid().ToString() + "_small.jpg";
                    normalFullName = currentFileStorage + Guid.NewGuid().ToString() + "_normal.jpg";

                    normalImage.Save(normalFullName);
                    smallImage.Save(smallFullName);

                    normalImageLength = new FileInfo(normalFullName).Length;
                    smallImageLength = new FileInfo(smallFullName).Length;

                    //Virtual File System
                    //GoProGo.FileSystem.VirtualFileSystem fileSys = new GoProGo.FileSystem.VirtualFileSystem();

                    sysFolder = VirtualFS.FindFolderByName(this.MembershipUser.UserName, ObjProfile.ID);
                    if (sysFolder == null)
                        sysFolder = VirtualFS.CreateFolder(this.MembershipUser.UserName, ObjProfile.ID, null);

                    //Check first if folder exist, if it does then don't create it
                    tempSysFolder = VirtualFS.FindFolderByName(profilePictureFolder, ObjProfile.ID);
                    if (tempSysFolder == null)
                        sysFolder = VirtualFS.CreateFolder(profilePictureFolder, ObjProfile.ID, sysFolder.ID);
                    else
                        sysFolder = tempSysFolder;

                    //To be on safe side, clean files in folder if already existing
                    List<tblFileInformation> files = VirtualFS.GetAllFilesInFolder(sysFolder, ObjProfile.ID);
                    foreach (tblFileInformation item in files)
                    {
                        File.Delete(item.FullPath);
                    }
                    //Delete files from database
                    VirtualFS.DeleteFiles(files);

                    VirtualFS.CreateFile(sysFolder.ProfileID, normalFullName, normalImageLength, GoProGo.VirtualFileSystem.AccessTypes.Public, GoProGo.VirtualFileSystem.FileTypes.File, GoProGo.VirtualFileSystem.FileExtensions.jpg, sysFolder);
                    VirtualFS.CreateFile(sysFolder.ProfileID, smallFullName, smallImageLength, GoProGo.VirtualFileSystem.AccessTypes.Public, GoProGo.VirtualFileSystem.FileTypes.File, GoProGo.VirtualFileSystem.FileExtensions.jpg, sysFolder);

                    ObjProfile.NormalProfilePicture = normalFullName;
                    ObjProfile.SmallProfilePicture = smallFullName;
                    GoProGo.Data.GoProGoDC.ProfileDC.SubmitChanges();

                    //Finally delete temporary file
                    File.Delete(tempFileNameAndPath);

                    ShowPicture(normalFullName);

                    if (OnPictureUploaded != null)
                        OnPictureUploaded(this, null);
                }
            }
            catch (Exception ex)
            {
                Image1.Visible = false;
                ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });

            }
            finally
            {
                normalImage.Dispose();
                smallImage.Dispose();
            }
        else
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = new Exception(), Message = "No selected file.", Severity = 5 });
        }
    }

    private void ShowPicture(string normalFullName)
    {
        //Show uploaded picture
        Image1.ImageUrl = PICTURE_HANDLER + Path.GetFileName(normalFullName);
        Image1.Visible = true;
    }
}
