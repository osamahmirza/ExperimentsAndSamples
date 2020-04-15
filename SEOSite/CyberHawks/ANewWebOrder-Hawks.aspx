<%@ Page Title="" Language="C#" MasterPageFile="~/Directory-SubHead.master" AutoEventWireup="true" CodeFile="ANewWebOrder-Hawks.aspx.cs" Inherits="ANewWebOrder_Categories" %>
<%@ Register Src="~/UserControls/ucCampaignPublic.ascx" TagPrefix="uc1" TagName="ucCampaignPublic" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contents">
        <div class="clear">
        </div>
        <uc1:ucCampaignPublic runat="server" id="ucCampaignPublic" />
        <div class="clear">
        </div>
        &nbsp;
    </div>
</asp:Content>

