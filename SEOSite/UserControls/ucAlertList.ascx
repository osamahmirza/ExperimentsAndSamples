<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAlertList.ascx.cs" Inherits="UserControls_Alerts" %>
<asp:GridView ID="gvAlerts" runat="server" DataKeyNames="ID" AllowPaging="true" GridLines="None"
    AutoGenerateColumns="false" PageSize="10" DataSourceID="ObjectDataSource1" CssClass="mGrid"
    PagerStyle-CssClass="pgr">
    <PagerSettings Position="Bottom" Mode="NumericFirstLast"></PagerSettings>
    <Columns>
        <asp:TemplateField HeaderText="Subject">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkSubject" Text='<%#Eval("Subject")%>' CommandArgument='<%#Eval("ID")%>'
                    CommandName="Select" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date">
            <ItemTemplate>
                <asp:Label runat="server" ID="tbDateCreated" Text='<%#Eval("FormattedDateCreated")%>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton runat="server" CommandName="Delete" AlternateText="Delete" ImageUrl="~/App_Themes/Default/images/delete.gif"
                    OnClientClick="javascript: return confirm('Are you sure you want to delete?')"
                    CommandArgument='<%#Eval("ID")%>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ANewWebOrder.tblAlert"
    SelectMethod="SelectPage" SelectCountMethod="SelectCount" EnablePaging="true"
    DeleteMethod="Delete"></asp:ObjectDataSource>
<hr />
<asp:Label runat="server" ID="lblSubject" />
<br />
<asp:Label runat="server" ID="lblDateTime" />
<br />
<asp:Label runat="server" ID="lblMessage" />
