<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCampaignPublic.ascx.cs" Inherits="UserControls_ucCampaignPublic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/ucMainInfo.ascx" TagPrefix="uc1" TagName="ucMainInfo" %>
<%@ Register Src="~/UserControls/ucTags.ascx" TagPrefix="uc1" TagName="ucTags" %>
<%@ Register Src="~/UserControls/ucCampaignContactUs.ascx" TagPrefix="uc1" TagName="ucCampaignContactUs" %>
<%@ Register Src="~/UserControls/ucConnectPublic.ascx" TagPrefix="uc1" TagName="ucConnectPublic" %>
<%@ Register Src="~/UserControls/ucPhoneAndFax.ascx" TagPrefix="uc1" TagName="ucPhoneAndFax" %>


<asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
</asp:ToolkitScriptManager>
<div id="contents">
    <asp:TabContainer ID="TabContainer1" runat="server" Width="880"
        ActiveTabIndex="0">
        <asp:TabPanel ID="tabHome" runat="server" HeaderText="Home" Enabled="true"
            ScrollBars="Auto" OnDemandMode="Once">
            <ContentTemplate>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-public-left">
                        <uc1:ucMainInfo runat="server" ID="ucMainInfo" />
                    </div>
                    <div class="cyberHawkRow-public-right">
                        <uc1:ucPhoneAndFax runat="server" ID="ucPhoneAndFax" />
                        <uc1:ucCampaignContactUs runat="server" ID="ucCampaignContactUs" />
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <uc1:ucTags runat="server" ID="ucTags" />
                </div>
                <div class="cyberHawkRow">
                    <uc1:ucConnectPublic runat="server" ID="ucConnectPublic" />
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="tabOffers" runat="server" HeaderText="Offers" Enabled="true"
            ScrollBars="Auto" OnDemandMode="Once">
            <ContentTemplate>
               <div class="cyberHawkRow">
                    <div class="cyberHawkRow-public-left">
                        <uc1:ucMainInfo runat="server" ID="ucMainInfo1" />
                    </div>
                    <div class="cyberHawkRow-public-right">
                        <uc1:ucPhoneAndFax runat="server" ID="ucPhoneAndFax1" />
                        <uc1:ucCampaignContactUs runat="server" ID="ucCampaignContactUs1" />
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <uc1:ucTags runat="server" ID="ucTags1" />
                </div>
                <div class="cyberHawkRow">
                    <uc1:ucConnectPublic runat="server" ID="ucConnectPublic1" />
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="tabLinks" runat="server" HeaderText="Links" Enabled="true"
            ScrollBars="Auto" OnDemandMode="Once">
            <ContentTemplate>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-public-left">
                        <uc1:ucMainInfo runat="server" ID="ucMainInfo2" />
                    </div>
                    <div class="cyberHawkRow-public-right">
                        <uc1:ucPhoneAndFax runat="server" ID="ucPhoneAndFax2" />
                        <uc1:ucCampaignContactUs runat="server" ID="ucCampaignContactUs2" />
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <uc1:ucTags runat="server" ID="ucTags2" />
                </div>
                <div class="cyberHawkRow">
                    <uc1:ucConnectPublic runat="server" ID="ucConnectPublic2" />
                </div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="tabMission" runat="server" HeaderText="Home" Enabled="true"
            ScrollBars="Auto" OnDemandMode="Once">
            <ContentTemplate>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-public-left">
                        <uc1:ucMainInfo runat="server" ID="ucMainInfo3" />
                    </div>
                    <div class="cyberHawkRow-public-right">
                        <uc1:ucPhoneAndFax runat="server" ID="ucPhoneAndFax3" />
                        <uc1:ucCampaignContactUs runat="server" ID="ucCampaignContactUs3" />
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <uc1:ucTags runat="server" ID="ucTags3" />
                </div>
                <div class="cyberHawkRow">
                    <uc1:ucConnectPublic runat="server" ID="ucConnectPublic3" />
                </div>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</div>
