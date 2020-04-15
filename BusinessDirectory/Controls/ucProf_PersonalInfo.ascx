<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucProf_PersonalInfo.ascx.cs"
    Inherits="ucProf_PersonalInfo" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<table style="width: 100%">
    <tr>
        <td>
            First Name
        </td>
        <td >
            <telerik:RadTextBox ID="rtbFirstName" Runat="server" Width="159px" 
                EmptyMessage="First Name">
            </telerik:RadTextBox>
        </td>
        <td>
            Last Name</td>
        <td >
            <telerik:RadTextBox ID="rtbLastName" Runat="server" Width="159px" 
                EmptyMessage="Last Name">
            </telerik:RadTextBox>
        </td>
        
    </tr>
    <tr>
        <td>
            Sex</td>
        <td >
            <telerik:RadComboBox ID="cmbSex" Runat="server">
            </telerik:RadComboBox>
        </td>
        <td>
            &nbsp;</td>
        <td >
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Cell Phone</td>
        <td >
            <telerik:RadTextBox ID="tbCellPhone" Runat="server" 
                EmptyMessage="10 digit phone nubmer" Width="159px">
            </telerik:RadTextBox>
        </td>
        <td>
            Phone</td>
        <td >
            <telerik:RadTextBox ID="tbPhone" Runat="server" 
                EmptyMessage="10 digit phone nubmer" Width="159px">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td>
            Fax</td>
        <td >
            <telerik:RadTextBox ID="tbFax" Runat="server" EmptyMessage="10 digit phone nubmer" 
                Width="159px">
            </telerik:RadTextBox>
        </td>
        <td>
            &nbsp;</td>
        <td >
            &nbsp;</td>
    </tr>
    </table>
