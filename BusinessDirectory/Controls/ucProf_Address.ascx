<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_Address.ascx.cs" Inherits="ucProf_Address" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table style="width: 100%">
    <tr>
        <td>
            Line 1
        </td>
        <td>
            <telerik:RadTextBox ID="tbAddressLine1" runat="server" Width="159px" EmptyMessage="Address line 1">
            </telerik:RadTextBox>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Line 2
        </td>
        <td>
            <telerik:RadTextBox ID="tbAddressLine2" runat="server" Width="159px" EmptyMessage="Address line 2">
            </telerik:RadTextBox>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Postal Code
        </td>
        <td>
            <telerik:RadTextBox ID="rtbPostal" runat="server" Width="159px">
            </telerik:RadTextBox>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Country
        </td>
        <td>
            <telerik:RadComboBox ID="cmbCountry" runat="server" AutoPostBack="True">
            </telerik:RadComboBox>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Prov/State
        </td>
        <td>
            <telerik:RadComboBox ID="cmbRegion" runat="server" AutoPostBack="True">
            </telerik:RadComboBox>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            City
        </td>
        <td>
            <telerik:RadComboBox ID="cmbCity" runat="server">
            </telerik:RadComboBox>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    </table>
