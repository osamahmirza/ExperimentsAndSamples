<%@ Page Title="" Language="C#" MasterPageFile="~/Members/Members.master" AutoEventWireup="true"
    CodeFile="CyberHawkList.aspx.cs" Inherits="Members_CyberHawkList" %>
<%@ Register Src="../UserControls/ucCampaignList.ascx" TagName="ucCampaignList" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button ID="btnAddNew" runat="server" Text="Add New" />
    <uc1:ucCampaignList ID="ucCampaignList1" runat="server" />
</asp:Content>
