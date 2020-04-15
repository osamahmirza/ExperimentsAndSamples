<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true" CodeFile="InquiryDetail.aspx.cs" Inherits="SharedProtected_InquiryDetail" %>

<%@ Register src="../Controls/ucProf_InquiryDetail.ascx" tagname="ucProf_InquiryDetail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" 
        Width="100%" onbuttonclick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdForwardToEmail" Text="Forward to email">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <br />
    <uc1:ucProf_InquiryDetail ID="ucProf_InquiryDetail1" runat="server" />

</asp:Content>

