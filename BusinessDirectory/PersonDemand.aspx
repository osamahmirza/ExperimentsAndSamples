<%@ Page Title="" Language="C#" MasterPageFile="~/PublicProfile.master" AutoEventWireup="true" CodeFile="PersonDemand.aspx.cs" Inherits="PersonDemand" %>

<%@ Register src="Controls/ucPubProf_Demand.ascx" tagname="ucPubProf_Demand" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucPubProf_Demand ID="ucPubProf_Demand1" runat="server" />
</asp:Content>

