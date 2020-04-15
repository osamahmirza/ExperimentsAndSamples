<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleMaster.master" AutoEventWireup="true"
    CodeFile="CategoryBrowsing.aspx.cs" Inherits="CategoryBrowsing" %>

<%@ Register src="~/Controls/SupplySearch/ucSearch_Category.ascx" tagname="ucSearch_Category" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <uc1:ucSearch_Category ID="ucSearch_Category1" runat="server" />
    
</asp:Content>
