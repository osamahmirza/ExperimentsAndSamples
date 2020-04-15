<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucLinksPublic.ascx.cs" Inherits="UserControls_ucLinksPublic" %>
<asp:Panel ID="pnlPhone" runat="server">
    <asp:Label ID="lblPhone" runat="server">Phone: </asp:Label>
    <asp:LinkButton ID="lbPhone" runat="server" OnClick="lbPhone_Click"></asp:LinkButton>
</asp:Panel>
<asp:Panel ID="pnlFax" runat="server">
    <asp:Label ID="lblFax" runat="server">Fax: </asp:Label>
    <asp:LinkButton ID="lbFax" runat="server" OnClick="lbFax_Click"></asp:LinkButton>
</asp:Panel>
