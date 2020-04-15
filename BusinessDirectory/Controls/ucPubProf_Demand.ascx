<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPubProf_Demand.ascx.cs"
    Inherits="Controls_ucPubProf_Demand" %>
<div>
    <asp:Label ID="lblWhatIWant" runat="server" Text=""></asp:Label></div>
<div>
    <asp:Panel ID="pnlDemandList" runat="server">
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowCustomPaging="true" AllowPaging="True"
            AutoGenerateColumns="False" GridLines="None" PageSize="5" ShowHeader="false"
            OnItemDataBound="RadGrid1_ItemDataBound" OnNeedDataSource="RadGrid1_NeedDataSource">
            <MasterTableView DataKeyNames="ID" Width="700px">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="Header">
                        <ItemStyle Wrap="true" />
                        <ItemTemplate>
                            <div>
                                <div>
                                    <div style="width: 698px">
                                        <asp:Label ID="lblTitleCap" runat="server" Text="Title:"></asp:Label>
                                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                        <asp:HyperLink ID="hlDetail" runat="server" Text="Detail..." NavigateUrl="~/PersonDemand.aspx?ProfileID={0}&DemandID={1}"></asp:HyperLink>
                                    </div>
                                </div>
                                <div>
                                    <div style="float: left; width: 345px">
                                        <asp:Label ID="lblPostDateCap" runat="server" Text="Posted:"></asp:Label>
                                        <asp:Label ID="lblPostDate" runat="server"></asp:Label>
                                    </div>
                                    <div style="float: right; width: 345px">
                                        <asp:Label ID="lblEndDateCap" runat="server" Text="Expires:"></asp:Label>
                                        <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div>
                                    <div style="float: left; width: 345px">
                                        <asp:Label ID="lblDemandTypeCap" runat="server" Text="Demand Type:"></asp:Label>
                                        <asp:Label ID="lblDemandType" runat="server"></asp:Label>
                                    </div>
                                    <div style="float: right; width: 345px">
                                        <asp:Label ID="lblBudgetCap" runat="server" Text="Budget:"></asp:Label>
                                        <asp:Label ID="lblBudget" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div>
                                    <div style="width: 698px">
                                        <asp:Label ID="lblLocationCap" runat="server" Text="Location:"></asp:Label>
                                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </asp:Panel>
    <asp:Panel ID="pnlDemand" runat="server" Visible="false">
        <div>
            <asp:HyperLink ID="lnkBackToList" runat="server" Text="Back to List"></asp:HyperLink>
        </div>
        <div style="width: 700px">
            <div>
                <div style="width: 698px">
                    <asp:Label ID="lblTitleCap" runat="server" Text="Title:"></asp:Label>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </div>
            </div>
            <div>
                <div style="float: left; width: 345px">
                    <asp:Label ID="lblPostDateCap" runat="server" Text="Post Date:"></asp:Label>
                    <asp:Label ID="lblPostDate" runat="server"></asp:Label>
                </div>
                <div style="float: right; width: 345px">
                    <asp:Label ID="lblEndDateCap" runat="server" Text="Post Date:"></asp:Label>
                    <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                </div>
            </div>
            <div>
                <div style="float: left; width: 345px">
                    <asp:Label ID="lblDemandTypeCap" runat="server" Text="Demand Type:"></asp:Label>
                    <asp:Label ID="lblDemandType" runat="server"></asp:Label>
                </div>
                <div style="float: right; width: 345px">
                    <asp:Label ID="lblBudgetCap" runat="server" Text="Budget:"></asp:Label>
                    <asp:Label ID="lblBudget" runat="server"></asp:Label>
                </div>
            </div>
            <div>
                <div style="width: 698px">
                    <asp:Label ID="lblLocationCap" runat="server" Text="Location:"></asp:Label>
                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                </div>
            </div>
            <div>
                <div style="width: 698px">
                    <asp:Label ID="lblDemandDescriptionCap" runat="server" Text="Job Description:"></asp:Label>
                </div>
            </div>
            <div>
                <div style="width: 698px">
                    <asp:Label ID="lblDemandDescription" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </asp:Panel>
</div>
