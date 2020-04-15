<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUsr_ChangePassword.ascx.cs"
    Inherits="ucUsr_ChangePassword" %>
<table>
    <tr>
        <td>
            Password
        </td>
        <td>
            <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Current password is required" ControlToValidate="tbPassword">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            New Password
        </td>
        <td>
            <asp:TextBox ID="tbNewPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="New password is required" ControlToValidate="tbNewPassword">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Confirm Password
        </td>
        <td>
            <asp:TextBox ID="tbConfirmPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="Confirm password is required">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ErrorMessage="Password comparison failed">*</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnChange" runat="server" Text="Change" />
        </td>
    </tr>
</table>
