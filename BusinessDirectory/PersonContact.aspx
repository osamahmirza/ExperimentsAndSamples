<%@ Page Title="" Language="C#" MasterPageFile="~/PublicProfile.master" AutoEventWireup="true" CodeFile="PersonContact.aspx.cs" Inherits="PersonContact" %>

<%@ Register src="Controls/ucPubProf_Contact.ascx" tagname="ucPubProf_Contact" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:ucPubProf_Contact ID="ucPubProf_Contact1" runat="server" />
    
</asp:Content>

