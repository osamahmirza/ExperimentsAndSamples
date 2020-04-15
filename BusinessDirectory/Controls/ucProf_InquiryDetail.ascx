<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_InquiryDetail.ascx.cs" Inherits="Controls_ucProf_InquiryDetail" %>
<style type="text/css">
    .style1
    {
        width: 100%;
        height: 132px;
    }

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

.RadInput_Default
{
	vertical-align:middle;
	font:12px "segoe ui",arial,sans-serif;
}

</style>
<table class="style1">
    <tr>
        <td>
            Email</td>
        <td>
            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Contact Number</td>
        <td>
            <asp:Label ID="lblContactNumber" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Subject</td>
        <td>
            <asp:Label ID="lblSubject" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Time</td>
        <td>
            <asp:Label ID="lblTime" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            Message</td>
        <td>
            <telerik:RadTextBox ID="rtbMessage" Runat="server" Width="390px" Height="143px" 
                ReadOnly="True" TextMode="MultiLine">
            </telerik:RadTextBox>
        </td>
    </tr>
</table>
