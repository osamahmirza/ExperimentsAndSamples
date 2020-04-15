<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMaster.master" AutoEventWireup="true"
    CodeFile="CreateAccount.aspx.cs" Inherits="CreateAccount" %>

<%@ Register Src="Controls/ucMessageBox.ascx" TagName="ucMessageBox" TagPrefix="uc1" %>
<%@ Register Src="Controls/ucUsr_CreateUser.ascx" TagName="ucCreateUser" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:ucCreateUser ID="ucCreateUser1" runat="server" />
</asp:Content>
