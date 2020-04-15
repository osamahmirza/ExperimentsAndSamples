<%@ Page Title="" Language="C#" MasterPageFile="~/Main-SubHead.master" AutoEventWireup="true"
    CodeFile="ANewWebOrder-Activate-Account.aspx.cs" Inherits="ANewWebOrder_Activate_Account" %>

<%@ Register Src="UserControls/ucTWFBRightColumnVertical.ascx" TagName="ucTWFBRightColumnVertical"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contents">
    <div class="clear"></div>
        <div id="stdcontents">
            <asp:Panel ID="pnlSuccess" runat="server" Visible="False">
                Your account has been activated successfuly!
                <br />
                <asp:HyperLink ID="hlMyAccount" runat="server" NavigateUrl="~/Members/RegistrationInfo.aspx"
                    Text="My Account" />
                &nbsp;
                <asp:HyperLink ID="hlHome1" runat="server" NavigateUrl="~/Default.aspx" Text="Home" />
            </asp:Panel>
            <asp:Panel ID="pnlFailure" runat="server" Visible="False">
                Invalid activation request
                <br />
                <asp:HyperLink runat="server" ID="hlHome2" Text="Home" NavigateUrl="~/Default.aspx" />
            </asp:Panel>
        </div>
        <uc1:ucTWFBRightColumnVertical ID="ucTWFBRightColumnVertical1" runat="server" />
        <div class="clear"></div>
    </div>
</asp:Content>
