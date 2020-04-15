<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMessageBox.ascx.cs" Inherits="ucMessageBox" %>
<div>
    <asp:Image ID="imgIcon" runat="server" />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
</div>