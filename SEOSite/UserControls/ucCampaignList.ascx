<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCampaignList.ascx.cs"
    Inherits="UserControls_ucCampaignList" %>
<asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" AllowPaging="True"
    GridLines="None" AutoGenerateColumns="False" PageSize="10" DataSourceID="ObjectDataSource1"
    CssClass="mGrid" PagerStyle-CssClass="pgr">
    <PagerSettings Position="Bottom" Mode="NumericFirstLast"></PagerSettings>
    <Columns>
        <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Members/CyberHawkEdit.aspx?ID={0}"
            DataTextField="Website" HeaderText="Website" />
        <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Members/CyberHawkEdit.aspx?ID={0}"
            DataTextField="Website" HeaderText="Website" />
        <asp:BoundField DataField="GeographicScopeName" HeaderText="Geographic Scope" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
        <asp:CheckBoxField DataField="IsLive" HeaderText="IsLive" />
        <asp:BoundField DataField="LastUpdated" HeaderText="Last Updated" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ANewWebOrder.vwCampaign"
    SelectMethod="SelectPage" SelectCountMethod="SelectCount" EnablePaging="true">
</asp:ObjectDataSource>
