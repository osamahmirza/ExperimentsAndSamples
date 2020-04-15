<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true" CodeFile="Favourites.aspx.cs" Inherits="SharedProtected_Favourites" %>

<%@ Register src="../Controls/ucProf_Favourites.ascx" tagname="ucProf_Favourites" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" 
        Width="100%" onbuttonclick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdRefresh" Text="Refresh">
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server" CommandName="cmdDelete" Text="Delete">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <uc1:ucProf_Favourites ID="ucProf_Favourites1" runat="server" />
    
</asp:Content>

