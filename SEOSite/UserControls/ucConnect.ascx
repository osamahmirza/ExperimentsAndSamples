<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucConnect.ascx.cs" Inherits="ucConnect" %>
<div class="section">
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <table class="highsection" style="width: 330px; margin-bottom: 4px">
                <tr>
                    <td style="width: 100%" class="highlabel">
                        <asp:ImageButton ID="imgConnect" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image")  %>'
                            AlternateText='<%# DataBinder.Eval(Container.DataItem, "Name")  %>' runat="server" />
                        <asp:Label ID="lblCaption" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")  %>' />
                    </td>
                    <td style="vertical-align: top">
                        <asp:LinkButton runat="server" ID="btnDelete" ValidationGroup="Connect" Text="Delete"
                            CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ModifiedID")  %>' />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label CssClass="label" runat="server" ID="lblTest" Text="Click the image to test your link." />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Panel ID="pnlAddConnection" runat="server">
        <table class="highsection" style="width: 330px">
            <tr>
                <td>
                    <div class="label" style="width: 100%">
                        Network
                        <div style="float: right">
                            <asp:LinkButton runat="server" ID="lnkTestLink" Text="Test Link" ValidationGroup="Link" />
                            &nbsp;&nbsp;
                            <asp:LinkButton runat="server" ID="btnAdd" Text="Add" CommandName="Add" OnClick="btnAdd_Click"
                                ValidationGroup="Connect" />
                        </div>
                    </div>
                    <asp:DropDownList runat="server" Width="100%" ID="ddlConnectionOption" />
                </td>
            </tr>
            <tr>
                <td>
                    <div class="label">
                        Link</div>
                    <asp:TextBox runat="server" Width="100%" ID="tbLink" Text="" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
