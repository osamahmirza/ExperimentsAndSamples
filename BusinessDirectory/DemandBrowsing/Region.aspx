<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleMaster.master" AutoEventWireup="true" CodeFile="Region.aspx.cs" Inherits="Region" %>

<%@ Register src="~/Controls/DemandSearch/ucSearch_Region.ascx" tagname="ucSearch_Region" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucSearch_Region ID="ucSearch_Region1" runat="server" />
</asp:Content>

