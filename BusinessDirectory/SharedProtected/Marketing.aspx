<%@ Page Title="" Language="C#" MasterPageFile="~/MyAccount.master" AutoEventWireup="true"
    CodeFile="Marketing.aspx.cs" Inherits="SharedProtected_Marketing" %>
<%@ Register Src="~/Controls/ucProf_Marketing.ascx" TagName="ucMarketing" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadToolBar ID="RadToolBar1" runat="server" Orientation="Horizontal" Width="100%"
        OnButtonClick="RadToolBar1_ButtonClick">
        <Items>
            <telerik:RadToolBarButton runat="server" CommandName="cmdSave" Text="Save">
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <uc3:ucMarketing ID="ucProfile21" runat="server" />
</asp:Content>
