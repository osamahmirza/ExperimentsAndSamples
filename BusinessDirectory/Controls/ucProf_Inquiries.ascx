<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_Inquiries.ascx.cs"
    Inherits="Controls_ucProf_Inquiries" %>
<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
    PageSize="15" AllowPaging="True" AllowSorting="True" 
    OnItemDataBound="RadGrid1_ItemDataBound" 
    AllowMultiRowSelection="True" onitemcommand="RadGrid1_ItemCommand" 
    onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
    onsortcommand="RadGrid1_SortCommand">
    <MasterTableView DataKeyNames="ID">
        <RowIndicatorColumn Visible="True" Resizable="False">
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <Columns>
            <telerik:GridClientSelectColumn UniqueName="CheckboxSelectColumn" HeaderText="CheckboxSelect column <br />" />
            <telerik:GridTemplateColumn UniqueName="Subject" HeaderText="Subject">
                <ItemStyle Wrap="true" />
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="lnkSubject" Text='<%#Eval("Subject")%>' NavigateUrl="~/SharedProtected/InquiryDetail.aspx?Inquiry="/>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn UniqueName="Email" HeaderText="Email">
                <ItemStyle Wrap="true" />
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblEmail" Text='<%#Eval("Email")%>' />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn UniqueName="Phone" HeaderText="Phone">
                <ItemStyle Wrap="true" />
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblPhone" Text='<%#Eval("ContactNumber")%>' />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn UniqueName="Time" HeaderText="Time">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblTime"  />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridButtonColumn ConfirmText="Delete this inquiry?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                        UniqueName="DeleteColumn">
                        <ItemStyle HorizontalAlign="Right" />
                    </telerik:GridButtonColumn>
        </Columns>
    </MasterTableView>
    <ClientSettings>
        <Selecting AllowRowSelect="True" />
    </ClientSettings>
</telerik:RadGrid>
