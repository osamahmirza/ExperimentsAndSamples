<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true"
    CodeFile="PersonalInfo.aspx.cs" Inherits="SharedProtected_PersonalInfo" %>

<%@ Register Src="../Controls/ucPageHeader.ascx" TagName="ucPageHeader" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ucProf_PersonalInfo.ascx" TagName="ucPersonalInfo" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" 
        Width="100%" onbuttonclick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdSave" Text="Save">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <br />
        <uc2:ucPersonalInfo ID="ucProfile11" Name="ucProfile11" runat="server" />
</asp:Content>
