<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRecentlyAdded.ascx.cs" Inherits="UserControls_ucRecentlyAdded" %>
<asp:Repeater ID="rptRecentlyAdded" runat="server" OnItemDataBound="rptRecentlyAdded_ItemDataBound">
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
