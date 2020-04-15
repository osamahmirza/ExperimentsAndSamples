<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearch_MainSearch.ascx.cs"
    Inherits="Controls_ucSearch_MainSearch" %>
<asp:Panel ID="pnlScript" runat="server">

    <script type="text/javascript">
        function onClicking(sender, eventArgs) {
            var item = eventArgs.get_item();

            if (item.get_text() == 'Advanced') {
                eventArgs.set_cancel(true);
            }
        }
        function showSupplyMenu(e) {
            var contextMenu = $find('<%#rmSupplyOptions.ClientID%>');

            if ((!e.relatedTarget) || (!$telerik.isDescendantOrSelf(contextMenu.get_element(), e.relatedTarget))) {
                contextMenu.show(e);
            }

            $telerik.cancelRawEvent(e);
        }
        function showDemandMenu(e) {
            var contextMenu = $find('<%#rmDemandOptions.ClientID%>');

            if ((!e.relatedTarget) || (!$telerik.isDescendantOrSelf(contextMenu.get_element(), e.relatedTarget))) {
                contextMenu.show(e);
            }

            $telerik.cancelRawEvent(e);
        }
    </script>

</asp:Panel>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
    <table>
        <tr>
            <td style="text-align: center; vertical-align: middle">
                Search:<asp:RadioButton ID="rbServiceProviders" runat="server" AutoPostBack="True"
                    GroupName="ServiceSearch" OnCheckedChanged="Main_SearchOptions" Text="Service Providers" />
                <asp:RadioButton ID="rbServiceTakers" runat="server" AutoPostBack="True" GroupName="ServiceSearch"
                    OnCheckedChanged="Main_SearchOptions" Text="Service Demands" />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <table>
                    <tr>
                        <td style="width: 444px">
                            <asp:Panel ID="pnlMainSearch" runat="server">
                                <telerik:RadTextBox ID="tbMainSearch" runat="server" Width="439px">
                                </telerik:RadTextBox>
                            </asp:Panel>
                            <asp:Panel ID="pnlNameSearch" runat="server" Visible="false">
                                <div style="float: left">
                                    <telerik:RadTextBox ID="tbFirstName" runat="server" EmptyMessage="First Name" Width="215">
                                    </telerik:RadTextBox>
                                </div>
                                <div style="float: right">
                                    <telerik:RadTextBox ID="tbLastName" runat="server" EmptyMessage="Last Name" Width="215">
                                    </telerik:RadTextBox>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlCategorySearch" runat="server" Visible="false">
                                <div style="float: left">
                                    <telerik:RadTextBox ID="tbCategorySearch" runat="server" EmptyMessage="e.g. Plumber, Car Mechanic, Dentist..."
                                        Width="310">
                                    </telerik:RadTextBox>
                                </div>
                                <div style="float: right">
                                    <telerik:RadComboBox ID="cmbCategory" runat="server" AutoPostBack="True" EmptyMessage="Select Category"
                                        Width="120px">
                                    </telerik:RadComboBox>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDistanceSearch" runat="server" Visible="false">
                                <div style="float: left">
                                    <telerik:RadTextBox ID="tbDistanceSearch" runat="server" Width="355px">
                                    </telerik:RadTextBox>
                                </div>
                                <div style="float: right">
                                    <telerik:RadTextBox ID="tbZip" runat="server" EmptyMessage="Zip/Postal" Width="75px">
                                    </telerik:RadTextBox>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDemandType" runat="server" Visible="false">
                                <div style="float: left">
                                    <telerik:RadTextBox ID="tbDemandTypeSearch" runat="server" Width="270px">
                                    </telerik:RadTextBox>
                                </div>
                                <div style="float: right">
                                    <telerik:RadComboBox ID="cmbDemandType" runat="server" AutoPostBack="True" EmptyMessage="Select Demand Type"
                                        Width="160px">
                                    </telerik:RadComboBox>
                                </div>
                            </asp:Panel>
                        </td>
                        <td>
                            <asp:Panel ID="pnlSupplyMenu" runat="server" onclick="showSupplyMenu(event)" Style="cursor: pointer;
                                font-size: smaller; color: Maroon">
                                more options</asp:Panel>
                            <asp:Panel ID="pnlDemandMenu" runat="server" onclick="showDemandMenu(event)" Style="cursor: pointer;
                                font-size: smaller; color: Maroon">
                                more options</asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="text-align: center">
                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                    Width="75px" />
                            </div>
                            <div style="float: right; width: 0px; text-align: left">
                                <telerik:RadContextMenu ID="rmSupplyOptions" runat="server" OnItemClick="rmSupplyOptions_ItemClick">
                                    <Items>
                                        <telerik:RadMenuItem runat="server" Selected="true" Text="Main Search">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" Text="Name Search">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" Text="Category Search">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" Text="Distance Search">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadContextMenu>
                                <telerik:RadContextMenu ID="rmDemandOptions" runat="server" OnItemClick="rmDemandOptions_ItemClick">
                                    <Items>
                                        <telerik:RadMenuItem runat="server" Selected="true" Text="Main Search">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" Text="Category Search">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem runat="server" Text="Demand Type Search">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadContextMenu>
                            </div>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <table>
                    <tr>
                        <td>
                            <telerik:RadComboBox ID="cmbCountry" runat="server" AutoPostBack="True" EmptyMessage="Select Country"
                                Width="146px">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cmbRegion" runat="server" AutoPostBack="True" EmptyMessage="Select State/Province"
                                Width="145px">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <telerik:RadComboBox ID="cmbCity" runat="server" EmptyMessage="Select City" Width="145px">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</telerik:RadAjaxPanel>
