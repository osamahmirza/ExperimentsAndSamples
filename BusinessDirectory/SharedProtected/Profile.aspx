<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true"
    CodeFile="Profile.aspx.cs" Inherits="SharedProtected_Profile" %>

<%@ Register Src="~/Controls/ucProf_Profile.ascx" TagName="ucProfile" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" 
        Width="100%" onbuttonclick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdSave" Text="Save">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <br />
    <uc4:ucProfile ID="ucProfile31" runat="server" />
</asp:Content>
