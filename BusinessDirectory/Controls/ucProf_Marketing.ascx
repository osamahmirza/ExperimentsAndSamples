<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_Marketing.ascx.cs" Inherits="ucProf_Marketing" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<table style="width: 100%">
    <tr>
        <td >
            Slogan
        </td>
        <td >
            <telerik:RadTextBox ID="rtbSlogan" Runat="server" 
                EmptyMessage="e.g. There is only one chef" Width="200px">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td  style="vertical-align: top">
            Search Tags
        </td>
        <td >
            <telerik:RadTextBox ID="rtbSearchTags" Runat="server" 
                EmptyMessage="Seperate each tag with space, e.g. Plumbing Repair Cheap Fix" 
                Height="91px" MaxLength="1024" TextMode="MultiLine" Width="200px">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td  style="vertical-align: top">
            Make Public
        </td>
        <td >
            <asp:RadioButton ID="rbYes" runat="server" Text="Yes" GroupName="MakePublic" />
            <asp:RadioButton ID="rbNo" runat="server" Text="No" GroupName="MakePublic" />
        </td>
    </tr>
    <tr>
        <td  style="vertical-align: top">
            Website
        </td>
        <td >
            <telerik:RadTextBox ID="rtbWebsite" Runat="server" 
                EmptyMessage="e.g. www.yourdomain.com" Width="200px">
            </telerik:RadTextBox>
        </td>
    </tr>
    </table>
