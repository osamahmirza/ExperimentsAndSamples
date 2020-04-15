<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMainInfo.ascx.cs" Inherits="ucMainInfo" %>
<h1>
    <asp:HyperLink ID="hlWebsiteName" runat="server">websitename and website address</asp:HyperLink>
</h1>
<p>
    <i><asp:Label ID="lblSlogan" runat="server" Text=""></asp:Label></i>
</p>
<%--Company name should be in footer--%>
<p>
Registered: <u><asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label></u>
</p>
<p>
    <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
</p>
