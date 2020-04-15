<%@ Page Title="" Language="C#" MasterPageFile="~/Main-SubHead.master" AutoEventWireup="true"
    CodeFile="ANewWebOrder-Payment-Success.aspx.cs" Inherits="ANewWebOrder_PaymentSuccess" %>
    <%@ Register Src="UserControls/ucTWFBRightColumnVertical.ascx" TagName="ucTWFBRightColumnVertical"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contents">
        <div class="clear">
        </div>
        <div id="stdcontents">
            <p>
                Thank you for your payment. Your transaction has been completed, and a receipt for
                your purchase has been emailed to you. You may log into your account at www.paypal.com
                to view details of this transaction.
            </p>
        </div>
        <uc1:ucTWFBRightColumnVertical ID="ucTWFBRightColumnVertical1" runat="server" />
        <div class="clear">
        </div>
    </div>
</asp:Content>
