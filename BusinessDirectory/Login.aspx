<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMaster.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Login ID="Login1" runat="server" onloggedin="Login1_LoggedIn">
    </asp:Login>
</asp:Content>
