<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true" CodeFile="Hits.aspx.cs" Inherits="SharedProtected_Hits" %>
<%@ Register Src="~/Controls/ucProf_Hits.ascx" TagName="ucHits" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" Width="100%"
        OnButtonClick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdRefresh" Text="Refresh">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <uc3:ucHits ID="ucHits" runat="server" />
</asp:Content>

