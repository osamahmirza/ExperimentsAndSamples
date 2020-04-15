<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTopNavItems.ascx.cs"
    Inherits="UserControls_ucTopNavItems" %>
<span class="topnavitems">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
            Welcome back,
            <asp:LoginName ID="LoginName1" runat="server" /> - <asp:LoginStatus ID="LoginStatus2" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" />
        </LoggedInTemplate>
        <AnonymousTemplate>
            Hello Guest -
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </AnonymousTemplate>
    </asp:LoginView>
    | <asp:HyperLink runat="server" NavigateUrl="~/Members/RegistrationInfo.aspx" Text="My Account" /> <label id="lblVerticalBar" runat="server">|</label> <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="../ANewWebOrder-Registration.aspx" Text="Register" />
</span>