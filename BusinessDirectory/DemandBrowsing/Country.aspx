<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleMaster.master" AutoEventWireup="true" CodeFile="Country.aspx.cs" Inherits="Category" %>

<%@ Register src="~/Controls/DemandSearch/ucSearch_Country.ascx" tagname="ucSearch_Country" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucSearch_Country ID="ucSearch_Country1" runat="server" />
</asp:Content>

