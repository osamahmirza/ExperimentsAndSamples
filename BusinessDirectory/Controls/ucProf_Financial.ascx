<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_Financial.ascx.cs" Inherits="ucProf_Financial" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<table style="width: 100%">
    <tr>
        <td >
            Service Category</td>
        <td >
            <telerik:RadComboBox ID="rcmbServiceCategory" Runat="server" Width="162px">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td >
            Minimum Rate
        </td>
        <td >
            <telerik:RadNumericTextBox ID="rmtbMinimumRate" Runat="server" 
                Culture="English (United States)" EmptyMessage="e.g. 22.25" 
                Width="160px">
            </telerik:RadNumericTextBox>
        </td>
    </tr>
    <tr>
        <td >
            Currency
        </td>
        <td >
            <telerik:RadComboBox ID="rcmbCurrency" Runat="server" Width="160px">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td >
            Job Unit</td>
        <td >
            <telerik:RadComboBox ID="rcmbJobUnit" Runat="server" Width="160px">
            </telerik:RadComboBox>
        </td>
    </tr>
    </table>
