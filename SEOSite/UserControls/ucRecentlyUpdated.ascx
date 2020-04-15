<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRecentlyUpdated.ascx.cs" Inherits="UserControls_ucRecentlyUpdated" %>
<asp:Repeater ID="rptRecentlyUpdated" runat="server" OnItemDataBound="rptRecentlyAdded_ItemDataBound">
    <HeaderTemplate>
        <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="padding: 3px">
                <ul>
                    <li>
                        <asp:Panel runat="server" ID="pnlContent1"></asp:Panel>
                    </li>
                </ul>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
