<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="SharedProtected_Address" %>
<%@ Register src="~/Controls/ucProf_Address.ascx" tagname="ucAddress" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" 
        Width="100%" onbuttonclick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdSave" Text="Save">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <br />
    <uc1:ucAddress ID="ucProfile1a1" runat="server" />
    
</asp:Content>

