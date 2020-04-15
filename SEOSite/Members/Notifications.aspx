<%@ Page Title="" Language="C#" MasterPageFile="~/Members/Members.master" AutoEventWireup="true" CodeFile="Notifications.aspx.cs" Inherits="Members_Notifications" %>

<%@ Register src="../UserControls/ucAlertList.ascx" tagname="ucAlertList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucAlertList ID="ucAlertList1" runat="server" />
</asp:Content>

