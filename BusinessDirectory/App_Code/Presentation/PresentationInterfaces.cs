using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoProGo.Utility;
using System.Web.Security;

namespace GoProGo.Presentation
{
    //Implement directly on page
    public interface ICommon
    {
        void ShowMessage(string message, MessageType type);
        void ClearMessage();
        void SetHeader(string message, MyAccountType type);
    }
    //Apply this on Master Pages
    public interface IMetaTag
    {
        //Will execute from load page or constructor of base page

        //Dim metaTag As New HtmlMeta
        //metaTag.HttpEquiv = "Refresh"
        //metaTag.Content = "2;URL=http://www.OdeToCode.com"
        //Header.Controls.Add(metaTag)
        void SetMetaTags();
        //Dim cssLink As New HtmlLink()
        //cssLink.Href = "~/styles.css"
        //cssLink.Attributes.Add("rel", "stylesheet")
        //cssLink.Attributes.Add("type", "text/css")
        //Header.Controls.Add(cssLink)
        void SetDocumentLinks();
    }
    public interface ISessionBag
    {
        SessionStateBag SessionBag { get; }
    }
    public interface IMemberOperation
    {
        MembershipUser MembershipUser { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string UserName { get; }
        void UpdateMembershipUser();
    }
}
