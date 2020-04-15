<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPubProf_Reviews.ascx.cs"
    Inherits="Controls_ucPubProf_Reviews" %>
<div>
    <asp:Label ID="lblReviews" runat="server" Text=""></asp:Label></div>
<div>
    <div style="width: 690px">
        <div style="float: left; height: 105px; vertical-align: bottom">
            <asp:Label ID="lblAvgScoreCaption" runat="server" Text="Avg. Score:"></asp:Label>
            <asp:Label ID="lblAvgScore" runat="server"></asp:Label>
            <telerik:RadRating ID="RadRating1" runat="server" AutoPostBack="False" Precision="Half" Width="170px" Skin="Default" />
            <asp:Label ID="lblTotalReviewsCap" runat="server" Text="Total Reviews:"></asp:Label>
            <asp:Label ID="lblTotalReviews" runat="server"></asp:Label>
            <asp:HyperLink ID="hlWriteReview" runat="server" Text="Write Review" NavigateUrl="~/SharedProtected/WriteReview.aspx?ProfileID={0}"/>
        </div>
    </div>
</div>
<div>
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowCustomPaging="true" AllowPaging="True"
        AutoGenerateColumns="False" GridLines="None" PageSize="5" ShowHeader="false"
        OnItemDataBound="RadGrid1_ItemDataBound" OnNeedDataSource="RadGrid1_NeedDataSource">
        <MasterTableView DataKeyNames="ID">
            <Columns>
                <telerik:GridTemplateColumn UniqueName="Header">
                    <ItemStyle Wrap="true" />
                    <ItemTemplate>
                        <div style="width: 690px">
                            <div style="float: left; height: 105px; width: 210px; vertical-align: bottom">
                                <%--Do not provide link to Reviewers profile. It is conflict of intrest--%>
                                <asp:Label ID="lblReviewerName" runat="server" />
                                <br />
                                <asp:Label ID="lblRatingCaption" runat="server" Text="Score"></asp:Label>
                                <telerik:RadRating ID="RadRating2" runat="server" AutoPostBack="False" Precision="Half" Width="150px" Skin="Default" />
                                <asp:Label ID="lblScore" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </div>
                            <div style="float: right; height: 105px; width: 475px; text-align: left">
                                <asp:Label ID="lblReview" runat="server" />
                            </div>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>
