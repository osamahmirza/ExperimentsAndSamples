<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearch_SupplyList.ascx.cs"
    Inherits="ucSearch_FreeSupplyList" %>
<style type='text/css'>
    .wrapper
    {
        /*position: relative;*/
        float: left;
        left: 517px;
        width: 623px;
        margin-bottom: 0px;
    }
    .left1
    {
        position: relative;
        float: left;
        left: 0px;
        width: 207px;
        height: 25px;
    }
    .left2
    {
        position: relative;
        float: left;
        left: 0px;
        width: 240px;
        height: 25px;
    }
    .right
    {
        position: relative;
        float: right;
        right: 0px;
        width: 174px;
        height: 25px;
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
                        <div style="width: 700px; height: 100px">
                            <div style="float: left; height: 100px; width: 75px; vertical-align: bottom">
                                <asp:HyperLink ID="hlLink" runat="server">
                                    <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" Style="padding-top: 2px" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: right; height: 105px; width: 625px; text-align: left">
                                <div style="height: 20px">
                                    <div style="float: left; overflow: hidden; width: 448px">
                                        <asp:HyperLink ID="hlNameCategory" runat="server" Text="" />
                                        <asp:HyperLink ID="hlMapit" Text="map it" runat="server" />
                                    </div>
                                    <div style="float: right; overflow: hidden; width: 174px">
                                        <strong>Min Rate: </strong>
                                        <asp:Label ID="lblMinRate" runat="server" Text="" />
                                    </div>
                                </div>
                                <div style="padding: 0px; overflow: hidden; height: 20px">
                                    <asp:Label ID="lblSlogan" runat="server" Text="" />
                                </div>
                                <div style="height: 35px; padding: 0px; overflow: hidden">
                                    <strong>Description: </strong>
                                    <asp:Label ID="lblDescription" runat="server" Text="" />
                                </div>
                                <div class="wrapper">
                                    <div class="left1">
                                        <asp:Label ID="lblLocation" runat="server" Text="" />
                                    </div>
                                    <div class="left2">
                                        <div style="float:left; width:100px; height:23px; vertical-align:top">
                                            <telerik:RadRating ID="RadRating1" runat="server" ItemCount="5" AutoPostBack="false"
                                                ReadOnly="true" Precision="Half" Skin="Default" Width="150" />
                                        </div>
                                        <div style="float:none; width:100px; height:20px; padding-top:3px; padding-left:2px">
                                            <asp:Label ID="lblReviewCount" runat="server" />
                                        </div>
                                    </div>
                                    <div class="right">
                                        <asp:Label ID="lblDistance" runat="server" Text="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>
