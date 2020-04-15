<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_Favourites.ascx.cs"
    Inherits="ucProf_Favourites" %>
<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
    PageSize="15" AllowPaging="True" AllowSorting="True" 
    OnItemDataBound="RadGrid1_ItemDataBound" 
    AllowMultiRowSelection="True" onitemcommand="RadGrid1_ItemCommand" 
    onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
    onsortcommand="RadGrid1_SortCommand">
    <MasterTableView DataKeyNames="ID" AllowMultiColumnSorting="true">
        <RowIndicatorColumn Visible="True" Resizable="False">
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <Columns>
            <telerik:GridClientSelectColumn UniqueName="CheckboxSelectColumn"  HeaderText="CheckboxSelect column <br />" />

            <telerik:GridTemplateColumn UniqueName="Picture" HeaderText="Picture">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn UniqueName="Name" HeaderText="Name" SortExpression="FirstName">
                <ItemStyle Wrap="true" />
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="lnkName" NavigateUrl="~/Profile.aspx?ID=" />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn UniqueName="Rate" HeaderText="Rate" SortExpression="MinimumRate">
                <ItemStyle Wrap="true" />
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblRate" />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn UniqueName="ServiceCategory" HeaderText="Category" SortExpression="Category">
                <ItemStyle Wrap="true" />
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblCategory" Text='<%#Eval("Category")%>' />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn UniqueName="Gender" HeaderText="Gender" SortExpression="Sex">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblGender" Text='<%#Eval("Sex")%>' />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridButtonColumn ConfirmText="Delete this favourite?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                        UniqueName="DeleteColumn">
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridButtonColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings>
        <Selecting AllowRowSelect="True" />
    </ClientSettings>
</telerik:RadGrid>




