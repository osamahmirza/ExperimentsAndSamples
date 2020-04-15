<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true"
    CodeFile="EmailAddress.aspx.cs" Inherits="SharedProtected_EmailAddress" %>

<%@ Register Src="~/Controls/ucUsr_UpdateEmail.ascx" TagName="ucUpdateEmail" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" Width="100%"
        OnButtonClick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdSave" Text="Save">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <uc1:ucUpdateEmail ID="ucUpdateEmail1" runat="server" />
</asp:Content>
