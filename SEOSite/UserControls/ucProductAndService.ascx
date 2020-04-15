<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProductAndService.ascx.cs"
    Inherits="ProductAndService" %>
<div class="section">
    <div class="highlabelnopad">
        <asp:Label ID="lblTotal" runat="server" Text="Product / Service / Cause Count: " /><asp:Label
            ID="lblCount" runat="server" Text="<%# ProductCount %>" />&nbsp;/ 5</div>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <table class="highsection" style="width: 330px; margin-bottom:4px">
            <tr>
                <td style="width: 100%">
                    <div class="highlabel">
                        <asp:Label runat="server" Width="100%" ID="tbProductOrService" Text='<%# Eval("ProductOrService") %>' />
                    </div>
                </td>
                <td style="padding-left:4px;vertical-align:top">
                    <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" ValidationGroup="ProductAndService" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ModifiedID")  %>' />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="label">
                        <asp:Label runat="server" Width="100%" ID="tbSearchPhrase" Text='<%# Eval("SearchPhraseForProductOrService") %>' />
                    </div>
                </td>
            </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <table class="highsection" style="width: 330px">
        <tr>
            <td>
                <div class="label" style="width: 100%">
                    Offering*
                    <div style="float: right">
                        <asp:LinkButton runat="server" ID="btnAdd" Text="Add" ValidationGroup="ProductAndService" CommandName="Add" OnClick="btnAdd_Click" />
                    </div>
                </div>
                <asp:TextBox runat="server" Width="100%" ID="tbProductOrService" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Description
                </div>
                <asp:TextBox runat="server" Width="100%" ID="tbSearchPhrase" Text='<%# Eval("SearchPhraseForProductOrService") %>' />
            </td>
        </tr>
    </table>
</div>
