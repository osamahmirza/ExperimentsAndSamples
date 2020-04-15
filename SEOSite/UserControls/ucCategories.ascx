<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCategories.ascx.cs" Inherits="UserControls_ucCategories" %>
<asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
    <HeaderTemplate>
        <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="padding: 5px"><strong>
                <asp:Panel runat="server" ID="pnlContent1"></asp:Panel>
            </strong></td>
            <td style="padding: 5px"><strong>
                <asp:Panel runat="server" ID="pnlContent2"></asp:Panel>
            </strong></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
