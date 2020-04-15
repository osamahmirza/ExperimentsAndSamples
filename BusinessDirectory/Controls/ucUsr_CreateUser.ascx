<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUsr_CreateUser.ascx.cs"
    Inherits="ucUsr_CreateUser" %>
<asp:Panel runat="server" ID="pnlCreateUser">
    <table>
        <tr>
            <td>
                User Name
            </td>
            <td>
                <asp:TextBox ID="tbUserName" runat="server" Width="168px"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="tbUserName"
                    ErrorMessage="*"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="tbEmail" runat="server" Width="168px"></asp:TextBox>
                <%--<asp:RegularExpressionValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail"
                    ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server" Width="168px" TextMode="Password"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword"
                    ErrorMessage="Mandatory">*</asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password
            </td>
            <td>
                <asp:TextBox ID="tbConfirmPassword" runat="server" Width="168px" TextMode="Password"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="tbConfirmPassword"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="tbPassword"
                    ControlToValidate="tbConfirmPassword" ErrorMessage="*"></asp:CompareValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidationGroup="ABC" 
                    Width="80px" onclick="btnCancel_Click" />
                &nbsp;<asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click"
                    Text="Create User" Width="84px" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel runat="server" ID="pnlConfirmationMessage" Visible="false">
    <div>
        You account has been created successfuly. To activate your account please follow
        the instructions sent to your email:
        <asp:Label runat="server" ID="lblEmail"></asp:Label>
        <br />
        <br />
        Goto:
        <asp:HyperLink ID="hlHome" runat="server">Home</asp:HyperLink>
    </div>
</asp:Panel>
