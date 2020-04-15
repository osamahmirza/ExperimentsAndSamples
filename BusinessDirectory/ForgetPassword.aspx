<%@ Page Title="" Language="C#" MasterPageFile="~/PublicMaster.master" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" %>
<%@ Register src="Controls/ucUsr_PasswordReset.ascx" tagname="ucPasswordReset" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucPasswordReset ID="ucPasswordReset1" runat="server" />
</asp:Content>

