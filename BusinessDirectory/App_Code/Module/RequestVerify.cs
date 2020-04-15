using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GoProGo
/// </summary>
namespace GoProGo.Module
{
    public class RequestVerify : IHttpModule
    {
       

        #region IHttpModule Members

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            //TODO: Change logic in such a way that we would make sure if right picutre is accessed
            //By looking at the name of handler
            //HttpApplication app = (HttpApplication)sender;
            //if (app.Request.Url.ToString().ToLower().IndexOf("userdata") != -1)
            //{
            //    if (app.User == null || !app.User.Identity.IsAuthenticated || app.Request.Url.ToString().ToLower().IndexOf(app.User.Identity.Name.ToLower()) == -1)
            //    {
            //        app.Response.StatusCode = 404;
            //        app.Response.End();
            //    }
            //}
        }

        #endregion
    }
}