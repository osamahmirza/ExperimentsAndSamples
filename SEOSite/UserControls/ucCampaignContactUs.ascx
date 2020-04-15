<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCampaignContactUs.ascx.cs" Inherits="ucCampaignContactUs" %>
<div class="label">
    From Email
</div>
<p>
    <asp:TextBox ID="tbFromAddress" runat="server" Width="220px"></asp:TextBox>
</p>
<div class="label">
    Subject
</div>
<p>
    <asp:TextBox ID="tbSubject" runat="server" Width="220px"></asp:TextBox>
</p>
<div class="label">
    Message
</div>
<p>
    <asp:TextBox ID="tbBody" runat="server" Height="150" TextMode="MultiLine" Width="220px"></asp:TextBox>
</p>

<p>
    <asp:Button ID="btnSend" Width="75px" runat="server" Text="Send" OnClick="btnSend_Click" />
</p>

