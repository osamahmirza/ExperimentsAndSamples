<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUsr_UpdateEmail.ascx.cs"
    Inherits="ucUsr_UpdateEmail" %>
<table>
    <tr>
        <td>
            Email:
        </td>
        <td>
            <telerik:RadTextBox ID="rtbChangeEmail" Runat="server" 
                EmptyMessage="Type your email address here" Width="203px">
            </telerik:RadTextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="Invalid email address" ControlToValidate="rtbChangeEmail" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Email is required" ControlToValidate="rtbChangeEmail">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    </table>
