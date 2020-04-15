<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMaster.master" AutoEventWireup="true" CodeFile="ActivateAccount.aspx.cs" Inherits="ActivateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlSuccess" runat="server" Visible="False">
        Your account has been activated successfuly!
        <br />
        <asp:HyperLink runat="server" ID="hlMyAccount" Text="My Account" NavigateUrl="~/SharedProtected/MyAccount.aspx" />
        &nbsp;
        <asp:HyperLink runat="server" ID="hlHome1" Text="Home" NavigateUrl="~/Default.aspx" />
    </asp:Panel>
    <asp:Panel ID="pnlFailure" runat="server" Visible="False">
        Invalid activation request
        <br />
        <asp:HyperLink runat="server" ID="hlHome2" Text="Home" NavigateUrl="~/Default.aspx" />
    </asp:Panel>
</asp:Content>

