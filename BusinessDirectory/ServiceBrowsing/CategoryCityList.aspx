<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleMaster.master" AutoEventWireup="true" CodeFile="CategoryCityList.aspx.cs" Inherits="ServiceProviderList" %>

<%@ Register src="~/Controls/SupplySearch/ucSearch_SupplyList.ascx" tagname="ucSearch_SupplyList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucSearch_SupplyList ID="ucSearch_FreeServiceProviderList1" runat="server" />
</asp:Content>

