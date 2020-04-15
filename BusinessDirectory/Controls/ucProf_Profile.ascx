<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_Profile.ascx.cs" Inherits="ucProf_Profile" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadToolTipManager ID="RadToolTipManager1" runat="server">
</telerik:RadToolTipManager>
<table style="width: 686px">
    <tr>
        <td style="vertical-align: top;">
            Profile (Sell your services here)&nbsp; TODO: Put an icon here to show tooltip about
            how to be effective.
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top;">
            <%--If spell check doesn't work, install MS-Word on Server or Give ASP.NET service account full rights on App_Data/RadSpell folder--%>
            <telerik:RadEditor ID="RadEditor1" runat="server" EditModes="All" ImageManager-EnableImageEditor="false"
                StripFormattingOptions="All" 
                ToolsFile="~/RadControlConfigs/ToolsFile.xml" 
                SpellCheckSettings-AllowAddCustom="false">
<SpellCheckSettings AllowAddCustom="False"></SpellCheckSettings>
<Content>
</Content>

<ImageManager EnableImageEditor="False"></ImageManager>
            </telerik:RadEditor>
        </td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            Profile Summary: (will be displayed in search results)
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadTextBox ID="rtbProfileDescription" runat="server" Height="56px" MaxLength="500"
                TextMode="MultiLine" Width="680px">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td>
            Max 500 charecters.
        </td>
    </tr>
    <tr>
        <td>
        <telerik:RadSpell ID="RadSpell1" runat="server" CustomDictionarySuffix="-John" AllowAddCustom="false"
                ButtonType="PushButton" ControlsToCheck="rtbProfileDescription" SupportedLanguages="en-US,English" />
        </td>
    </tr>
</table>
