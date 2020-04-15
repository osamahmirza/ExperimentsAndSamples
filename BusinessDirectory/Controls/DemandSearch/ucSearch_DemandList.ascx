<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearch_DemandList.ascx.cs"
    Inherits="ucSearch_FreeSupplyList" %>
<style type='text/css'>
    .wrapper
    {
        /*position: relative;*/
        float: left;
        left: 517px;
        width: 694px;
        margin-bottom: 0px;
        padding: 0px;
    }
    .left1
    {
        position: relative;
        float: left;
        left: 0px;
        width: 385px;
        height: 25px;
        margin-bottom: 0px;
        padding: 0px;
    }
    .left2
    {
        position: relative;
        float: left;
        left: 0px;
        width: 305px;
        height: 25px;
        margin-bottom: 0px;
        padding: 0px;
    }
    .right
    {
        position: relative;
        float: right;
        right: 0px;
        width: 0px;
        height: 25px;
        margin-bottom: 0px;
        padding: 0px;
    }
</style>
<div>
    <asp:Panel ID="pnlSearch" runat="server" Style="text-align: left; vertical-align: middle">
        Search:
        <telerik:RadTextBox ID="rtbSearch" runat="server" Width="350px" EmptyMessage="Refine your search">
        </telerik:RadTextBox>
        <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
    </asp:Panel>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" PageSize="10"
        AllowPaging="True" AllowCustomPaging="true" OnNeedDataSource="RadGrid1_NeedDataSource"
        GridLines="None" OnItemDataBound="RadGrid1_ItemDataBound" ShowHeader="false">
        <MasterTableView DataKeyNames="ID">
            <Columns>
                <telerik:GridTemplateColumn UniqueName="Header">
                    <ItemStyle Wrap="true" />
                    <ItemTemplate>
                        <%--Remove headings and stuff like "Title, Category, Description etc.--%>
                        <div style="width: 700px; height: 105px">
                            <div style="height: 100px; width: 697px; text-align: left">
                                <div style="padding: 0px; margin: 0px; height: 25px; width: 694px">
                                    <div style="float: left; width: 500px; height: 25px; overflow: hidden">
                                        <strong>
                                        <asp:HyperLink ID="hlTitle" runat="server" Text="" />
                                        </strong>
                                    </div>
                                    <div style="float: right; width: 180px; height: 25px; overflow: hidden">
                                        Job Type:
                                        <asp:Label ID="lblJobType" runat="server" Text="" />
                                    </div>
                                </div>
                                <div style="height: 30px; padding: 0px; overflow: hidden">
                                    <asp:Label ID="lblDescription" runat="server" Text="" />
                                </div>
                                <div style="padding: 0px; margin: 0px; height: 25px; width: 694px">
                                    <div style="float: left;height: 25px; padding: 0px; overflow: hidden">
                                        Category:
                                        <asp:Label ID="lblCategory" runat="server" Text="" />
                                    </div>
                                    <div style="float: right;height: 25px; padding: 0px; overflow: hidden">
                                       Budget:
                                        <asp:Label ID="lblBudget" runat="server" Text="" />
                                    </div>
                                    
                                </div>
                                <div class="wrapper">
                                    <div class="left1">
                                        Location:
                                        <asp:Label ID="lblLocation" runat="server" Text="" />
                                    </div>
                                    <div class="left2">
                                        <div style="float: left; width: 150px; height: 23px; vertical-align: top">
                                            Posted:
                                            <asp:Label ID="lblPostDate" runat="server" />
                                        </div>
                                        <div style="float: right; width: 150px; height: 23px; vertical-align: top">
                                            Expiry:
                                            <asp:Label ID="lblPostExpiry" runat="server" />
                                        </div>
                                    </div>
                                    <%--<div class="right">
                                        
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>
