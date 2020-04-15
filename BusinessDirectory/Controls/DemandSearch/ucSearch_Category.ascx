<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearch_Category.ascx.cs"
    Inherits="Controls_ucSearch_Category" %>

<div>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <span>Quick Select:</span>
        <telerik:RadComboBox ID="RadComboBox1" runat="server" Width="250px" Height="150px"
            EmptyMessage="Select a Category" EnableLoadOnDemand="True" ShowMoreResultsBox="true"
            EnableVirtualScrolling="true" OnItemsRequested="RadComboBox1_ItemsRequested"
            AutoPostBack="True" OnSelectedIndexChanged="RadComboBox1_SelectedIndexChanged">
        </telerik:RadComboBox>
        &nbsp;<asp:LinkButton id="btnGo" runat="server" visible="false" Text="Go"/>
    </telerik:RadAjaxPanel>
</div>
<div>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="4">
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/DemandBrowsing/Country.aspx?CategoryID=" + Eval("ID").ToString()%>'
                            Text='<%#Eval("Name")%>'></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</div>
