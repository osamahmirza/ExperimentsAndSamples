<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucLinks.ascx.cs" Inherits="Links" %>
<div class="section">
    <div class="highlabelnopad">
        <asp:Label ID="lblTotal" runat="server" Text="Link Count:" />
        <asp:Label ID="lblCount" runat="server" Text="<%# LinkCount %>" /><asp:Label ID="lblTotalCount"
            runat="server" Text=" / 5" />
    </div>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <table class="highsection" style="width:330px; margin-bottom: 4px;">
                <tr>
                    <td style="width: 100%" class="highlabel">
                        <div>
                            <asp:Label runat="server" ID="tbLink" Text='<%# Eval("Link") %>' />
                        </div>
                    </td>
                    <td class="uclinksdelete">
                        <asp:LinkButton runat="server" ID="btnDelete" ValidationGroup="Links" Text="Delete"
                            CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ModifiedID")  %>' />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="label">
                            <asp:Label runat="server" Width="100%" ID="tbDescription" Text='<%# Eval("Description") %>' />
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <table class="highsection" style="width: 330px">
        <tr>
            <td style="width: 100%">
                <div class="label" style="width: 100%">
                    Web Link*
                    <div style="float: right">
                        <asp:LinkButton runat="server" ID="lnkTestLink" Text="Test Link" ValidationGroup="Link" />
                        &nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="btnAdd" Text="Add" CommandName="Add" OnClick="btnAdd_Click"
                            ValidationGroup="Link" />
                    </div>
                </div>
                <asp:TextBox runat="server" Width="100%" ID="tbLink" Text="" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Link Description*
                </div>
                <asp:TextBox runat="server" Width="100%" ID="tbDescription" Text="" />
            </td>
        </tr>
    </table>
</div>
