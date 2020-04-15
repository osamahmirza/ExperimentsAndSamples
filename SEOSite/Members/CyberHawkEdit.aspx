<%@ Page Title="" Language="C#" MasterPageFile="~/Members/Members.master" AutoEventWireup="true"
    CodeFile="CyberHawkEdit.aspx.cs" Inherits="Members_CyberHawkEdit" %>

<%@ Register Src="../UserControls/ucCampaign.ascx" TagName="ucCampaign" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <uc1:ucCampaign ID="ucCampaign1" runat="server" />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
</asp:Content>
