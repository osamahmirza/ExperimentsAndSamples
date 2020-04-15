<%@ Application Language="C#" %>
<script RunAt="server">

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
        // Code that runs when a new session is started
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {

            ANWO.Data data = new ANWO.Data();
            ANWO.Utility.SessionStateBag session = new ANWO.Utility.SessionStateBag();
            ANewWebOrder.tblProfile profile = null;

            if (session.Profile == null)
            {
                ANewWebOrder.aspnet_User user = data.NWODC.aspnet_Users.Where(a => a.LoweredUserName.Equals(HttpContext.Current.User.Identity.Name.ToLower())).SingleOrDefault();

                if (user != null)
                {
                    profile = data.NWODC.tblProfiles.Where(a => a.UserID.ToString() == user.UserId.ToString()).SingleOrDefault();
                }

                if (profile != null)
                    session.Profile = data.NWODC.tblProfiles.Where(a => a.UserID == user.UserId).SingleOrDefault();
            }
        }
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
