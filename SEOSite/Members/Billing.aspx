<%@ Page Title="" Language="C#" MasterPageFile="~/Members/Members.master" AutoEventWireup="true" CodeFile="Billing.aspx.cs" Inherits="Members_Billing" %>

<%@ Register src="../UserControls/ucBillList.ascx" tagname="ucBillList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <uc1:ucBillList ID="ucBillList1" runat="server" />
    
</asp:Content>

