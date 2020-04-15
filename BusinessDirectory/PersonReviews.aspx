<%@ Page Title="" Language="C#" MasterPageFile="~/PublicProfile.master" AutoEventWireup="true" CodeFile="PersonReviews.aspx.cs" Inherits="PersonReviews" %>

<%@ Register src="Controls/ucPubProf_Personality.ascx" tagname="ucPubProf_Personality" tagprefix="uc1" %>
<%@ Register src="Controls/ucPubProf_Reviews.ascx" tagname="ucPubProf_Reviews" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:ucPubProf_Reviews ID="ucPubProf_Reviews1" runat="server" />
</asp:Content>

