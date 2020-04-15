<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleMaster.master" AutoEventWireup="true" CodeFile="City.aspx.cs" Inherits="City" %>
<%@ Register src="~/Controls/SupplySearch/ucSearch_City.ascx" tagname="ucSearch_City" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucSearch_City ID="ucSearch_City1" runat="server" />
</asp:Content>

