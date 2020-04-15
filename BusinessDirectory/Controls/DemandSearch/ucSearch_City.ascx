<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearch_City.ascx.cs"
    Inherits="Controls_ucSearch_City" %>
<div>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <span>Quick Select:</span>
        <telerik:RadComboBox ID="RadComboBox1" runat="server" Width="250px" Height="150px"
            EmptyMessage="Select a City" EnableLoadOnDemand="True" ShowMoreResultsBox="true"
            EnableVirtualScrolling="true" OnItemsRequested="RadComboBox1_ItemsRequested"
            AutoPostBack="True" OnSelectedIndexChanged="RadComboBox1_SelectedIndexChanged">
        </telerik:RadComboBox>
        &nbsp;<asp:LinkButton ID="btnGo" runat="server" Visible="false" Text="Go" />
    </telerik:RadAjaxPanel>
</div>
<asp:DataList ID="DataList1" runat="server" RepeatColumns="6">
    <ItemTemplate>
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"~/DemandBrowsing/CategoryCityList.aspx?CityID=" + Eval("ID").ToString()+ "&CategoryID=" + CategoryID + "&Type=CategoryBrowsing"  %>'
                        Text='<%#Eval("City")%>'></asp:HyperLink>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>