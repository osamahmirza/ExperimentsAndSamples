<%@ Page Title="" Language="C#" MasterPageFile="~/Main-SubHead.master" AutoEventWireup="true"
    CodeFile="ANewWebOrder-Account-Success.aspx.cs" Inherits="ANewWebOrder_Account_Success" %>

<%@ Register Src="UserControls/ucTWFBRightColumnVertical.ascx" TagName="ucTWFBRightColumnVertical"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contents">
        <div class="clear">
        </div>
        <div id="stdcontents">
            <p>
                Thank you for registering at aNewWebOrder.com. An email has been sent to your provided
                email address. Please click on a link sent in that email to activate your account
                within 48 hours. Thanks.
            </p>
        </div>
        <uc1:ucTWFBRightColumnVertical ID="ucTWFBRightColumnVertical1" runat="server" />
        <div class="clear">
        </div>
    </div>
</asp:Content>
