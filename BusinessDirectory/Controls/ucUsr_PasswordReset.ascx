<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUsr_PasswordReset.ascx.cs"
    Inherits="ucUsr_PasswordReset" %>
<table>
    <tr>
        <td>
            Email:
        </td>
        <td>
            <asp:TextBox ID="tbEmail" runat="server" Width="170px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbEmail" ErrorMessage="Email is required">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="tbEmail" ErrorMessage="Invalid email address" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                Text="Cancel" ValidationGroup="Cancel" />
&nbsp;<asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
                Text="Reset" />
        </td>
    </tr>
</table>
