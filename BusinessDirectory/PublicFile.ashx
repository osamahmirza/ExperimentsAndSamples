<%@ WebHandler Language="C#" Class="PublicFile" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Data.Entity.Profile;
using GoProGo.Presentation;

public class PublicFile : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string pictureName = context.Request.QueryString["ProfPicture"];

        tblFileInformation file = GoProGo.Data.GoProGoDC.FileDC.tblFileInformations.FirstOrDefault<tblFileInformation>(a => a.PhysicalFileName == pictureName);

        if (file != null)
        {
            context.Response.ContentType = file.tblFileExtension.ContentType;

            using (Impersonator imp = new Impersonator())
            {
                context.Response.WriteFile(file.FullPath, true);
            }

            context.Response.End();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}