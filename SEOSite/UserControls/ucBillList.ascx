<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucBillList.ascx.cs" Inherits="UserControls_Bills" %>
<asp:GridView ID="gvInvoice" runat="server" DataKeyNames="ID" AllowPaging="True"
    GridLines="None" AutoGenerateColumns="False" PageSize="10" DataSourceID="ObjectDataSource1"
    CssClass="mGrid" PagerStyle-CssClass="pgr" SelectedRowStyle-CssClass="selected">
    <PagerSettings Position="Bottom" Mode="NumericFirstLast"></PagerSettings>
    <Columns>
        <asp:TemplateField HeaderText="Invoice#">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkTransactionNumber" Text='<%#Eval("Invoice")%>'
                    CommandArgument='<%#Eval("ID")%>' CommandName="Select" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Date">
            <ItemTemplate>
                <asp:Label runat="server" ID="tbPaymentDate" Text='<%#Eval("PaymentDate")%>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount Paid">
            <ItemTemplate>
                <asp:Label runat="server" ID="tbAmountPaid" Text='<%#Eval("FormattedMCGross")%>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="ANewWebOrder.tblInvoice"
    SelectMethod="SelectPage" SelectCountMethod="SelectCount" EnablePaging="true"
    DeleteMethod="Delete"></asp:ObjectDataSource>
<hr />
<asp:Label runat="server" ID="lblTransaction" />
<br />
<asp:Label runat="server" ID="lblPaymentDate" />
<br />
<asp:Label runat="server" ID="lblFormattedAmountPaid" />
<br />
<asp:Label runat="server" ID="lblStatus" Visible="False" />
<br />
