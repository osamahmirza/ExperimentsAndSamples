using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoProGo.Data;

/// <summary>
/// Summary description for File
/// </summary>
namespace GoProGo.VirtualFileSystem
{
    public class VirtualFS
    {
        //To support different kind of files, create an ASHX handler which will be used as "src" for image controls.
        //Put security in this File while fetching file that if file fetch is valid. Return invalid request error if get is un-authorized.
        //e.g. Profile picture will be a public file. to process Pictures a sperate ASHX handler will service
        //requests. 
        public VirtualFS()
        {
            
        }
        
        public static tblFileInformation FindFolderByName(string name, int profileID)
        {
            return GoProGoDC.FileDC.tblFileInformations.Where(a => a.PhysicalFileName == name && a.ProfileID == profileID).SingleOrDefault<tblFileInformation>();
        }

        public static tblFileInformation FindFolderByID(int FolderID, int profileID)
        {
            return GoProGoDC.FileDC.tblFileInformations.Where(a => a.ID == FolderID && a.ProfileID == profileID).SingleOrDefault<tblFileInformation>();
        }

        public static tblFileInformation FindFolderByParentID(int parentID, int profileID)
        {
            return GoProGoDC.FileDC.tblFileInformations.Where(a => a.ParentID == parentID && a.ProfileID == profileID).SingleOrDefault<tblFileInformation>();
        }

        public static List<tblFileInformation> GetAllFoldersInFolder(tblFileInformation folder, int profileID)
        {
            return GoProGoDC.FileDC.tblFileInformations.Where(a => a.ParentID == folder.ID && a.tblFileExtension.FileExtensionTypeID == (int)FileTypes.Folder && a.ProfileID == profileID).ToList<tblFileInformation>();
        }

        public static List<tblFileInformation> GetAllFolders(int profileID)
        {
            return GoProGoDC.FileDC.tblFileInformations.Where(a => a.tblFileExtension.FileExtensionTypeID == (int)FileTypes.Folder && a.ProfileID == profileID).ToList<tblFileInformation>();
        }

        public static List<tblFileInformation> GetAllFilesInFolder(tblFileInformation folder, int profileID)
        {
            return GoProGoDC.FileDC.tblFileInformations.Where(a => a.ParentID == folder.ID && a.ProfileID == profileID).ToList<tblFileInformation>();
        }

        public static tblFileInformation CreateFolder(string name, int profileID, int? parentID)
        {
            tblFileInformation fileInfo = new tblFileInformation()
            {
                AccessTypeID = 4,
                ContentLength = 0,
                FileExtensionID = 7,
                Path = string.Empty,
                PhysicalFileName = name,
                ProfileID = profileID,
                CreatedDate = DateTime.Now,
                ParentID = parentID,
                FullPath = name
            };

            GoProGoDC.FileDC.tblFileInformations.InsertOnSubmit(fileInfo);
            GoProGoDC.FileDC.SubmitChanges();
            return fileInfo;
        }

        public static tblFileInformation CreateFile(int? profileID, string path, long contentLength, AccessTypes accessType, FileTypes fileType, FileExtensions fileExtension, tblFileInformation folder)
        {
            tblFileInformation fileInfo = new tblFileInformation()
            {
                AccessTypeID = (int)accessType,
                ContentLength = contentLength,
                FileExtensionID = (int)fileExtension,
                Path = System.IO.Path.GetDirectoryName(path),
                PhysicalFileName = System.IO.Path.GetFileName(path),
                ProfileID = profileID,
                CreatedDate = DateTime.Now,
                ParentID = folder.ID,
                FullPath = path
            };

            GoProGoDC.FileDC.tblFileInformations.InsertOnSubmit(fileInfo);
            GoProGoDC.FileDC.SubmitChanges();
            return fileInfo;
        }

        public static bool DeleteFiles(List<tblFileInformation> files)
        {
            if (files != null && files.Count > 0)
                foreach (tblFileInformation info in files)
                {
                    GoProGoDC.FileDC.tblFileInformations.DeleteOnSubmit(info);
                }
            GoProGoDC.FileDC.SubmitChanges();
            return true;
        }

        public static bool DeleteFilesInFolder(tblFileInformation folder, int profileID)
        {
            List<tblFileInformation> files = GetAllFilesInFolder(folder, profileID);
            if(files != null && files.Count > 0)
                foreach (tblFileInformation info in files)
                {
                    GoProGoDC.FileDC.tblFileInformations.DeleteOnSubmit(info);
                }
            GoProGoDC.FileDC.SubmitChanges();
            return true;
        }
    }


    public enum FileTypes
    {
        Err = 1,
        File = 2,
        Folder = 3
    }
    public enum FileExtensions
    {
        Err = 1,
        jpg = 2,
        gif = 3,
        png = 4,
        bin = 5,
        xml = 6,
        fldr = 7
    }
    //Can do bitwise operation on it
    public enum AccessTypes
    {
        Err = 1,
        Private = 2,
        Public = 4,
        System = 8
    }
}

