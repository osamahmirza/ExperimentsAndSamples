<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DocumentListAPI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        for Google Doc Audit
    </h2>
    <p>
        <asp:Label ID="lblTotalUsers" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblTotalUsersExternal" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblTotalQuotaUsed" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblSharedDomainWithLink" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblSharedDomainWithoutLink" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblSharedpublicwithlink" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblSharedPublic" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblDocsSharedWithUs" runat="server">What documents have been shared with us can be determined</asp:Label>
    </p>
    
</asp:Content>
