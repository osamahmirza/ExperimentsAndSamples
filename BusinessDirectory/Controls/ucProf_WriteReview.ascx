<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_WriteReview.ascx.cs" Inherits="Controls_ucProf_WriteReview" %>
<div><asp:Label runat="server" ID="lblWriteReview" Text="Write review for:"/>&nbsp;<asp:HyperLink runat="server" ID="hlPersonName" /></div>
<div><telerik:RadRating ID="rrProfileRating" runat="server" AutoPostBack="False" Precision="Half" Width="190px" Skin="Default" /></div>
<div>
    <telerik:RadTextBox ID="rtbComment" runat="server" Height="56px" MaxLength="500" TextMode="MultiLine" Width="680px">
    </telerik:RadTextBox>
</div>
<div style="width: 680px; text-align:right">
    <asp:Button ID="btnPost" runat="server" Text="Post" onclick="btnPost_Click" />
</div>