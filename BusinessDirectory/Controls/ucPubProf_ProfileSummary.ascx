<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPubProf_ProfileSummary.ascx.cs"
    Inherits="ucPubProf_ProfileSummary" %>
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
<div style="width: 750px; height: 100px">
    <div style="float: left; height: 100px; width: 125px; vertical-align: bottom">
        <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" Style="padding-top: 2px" />
    </div>
    <div style="float: right; height: 105px; width: 625px; text-align: left">
        <div style="height: 20px">
            <div style="float: left; overflow: hidden; width: 448px">
                <asp:Label ID="lblNameCategory" runat="server" Text="" />
            </div>
            <div style="float: right; overflow: hidden; width: 174px">
                <strong>Rate: </strong>
                <asp:Label ID="lblMinRate" runat="server" Text="" />
            </div>
        </div>
        <div style="padding: 0px; overflow: hidden; height: 20px">
            <asp:Label ID="lblSlogan" runat="server" Text="" />
        </div>
        <div class="wrapper">
            <div class="left1">
                <asp:Label ID="lblPrimaryPhone" runat="server" Text="" />
            </div>
            <div class="left2">
                <asp:Label ID="lblSecondaryPhone" runat="server" Text="" />
            </div>
            <div class="right">
                <asp:Label ID="lblLocation" runat="server" Text="" />
                <asp:HyperLink ID="hlAddress" runat="server" Text="(mapit)" />
            </div>
        </div>
        <div class="wrapper">
            <div class="left1">
                <telerik:RadRating ID="RadRating1" runat="server" AutoPostBack="False" Precision="Half"
                    Width="150px" Skin="Default" />
            </div>
            <div class="left2">
                <asp:Label ID="lblReviews" runat="server" Text="" />
            </div>
            <div class="right">
                <asp:Label ID="lblHits" runat="server" Text="" />
            </div>
        </div>
    </div>
</div>
