<%@Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true" CodeFile="Inquiries.aspx.cs" Inherits="SharedProtected_Inquiries" %>

<%@ Register src="../Controls/ucProf_Inquiries.ascx" tagname="ucProf_Inquiries" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" 
        Width="100%" onbuttonclick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdRefresh" Text="Refresh">
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server" CommandName="cmdForwardToEmail" Text="Forward to email">
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server" CommandName="cmdDelete" Text="Delete">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <br />
    <uc1:ucProf_Inquiries ID="ucProf_Inquiries1" runat="server" />
</asp:Content>

