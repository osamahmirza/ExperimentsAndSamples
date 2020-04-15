using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoProGo.Utility;

namespace GoProGo
{
    /// <summary>
    /// Summary description for GoProGo
    /// </summary>
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        void Session_Start(object sender, EventArgs e)
        {
            try
            {
                //TODO: set or get what is the location of files for user on fileserver
                //http://www.velocityreviews.com/forums/t75517-access-to-the-fileserver-from-webserver.html
                //This will set users local settings
                UserLocalInfo info = new UserLocalInfo(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["GeoDatabase"].ToString()));
                SessionStateBag bag = new SessionStateBag();
                bag.UserBrowsingInfo = info;
            }
            catch (Exception ex)
            {
                //TODO: Logging here
                throw ex;
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }
    }
}