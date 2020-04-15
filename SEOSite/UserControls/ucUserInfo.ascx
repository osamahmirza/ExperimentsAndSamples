<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUserInfo.ascx.cs" Inherits="UserInfo" %>
<div id="contents">
    <table>
        <tr>
            <td>
                <div class="label">
                    User Name*<asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="tbUserName"
                        ErrorMessage="User Name is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    (4 to 16 charecters)
                </div>
                <div>
                    <asp:TextBox ID="tbUserName" runat="server" Width="225px" MaxLength="16"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Email*<asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail"
                        ErrorMessage="Email is required.">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail"
                        ErrorMessage="Invalid Email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbEmail" runat="server" Width="225px" MaxLength="255"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Confirm Email*<asp:CompareValidator ID="cvEmail" runat="server" ControlToCompare="tbEmail"
                        ControlToValidate="tbConfirmEmail" ErrorMessage="Email comparison failed.">*</asp:CompareValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbConfirmEmail" runat="server" Width="225px" MaxLength="255"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    <label id="lblPassword" runat="server">
                        Password*</label><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="tbPassword"
                            ErrorMessage="Password is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <label id="lblHelp" runat="server">
                        (6 to 16 charecters)</label>
                </div>
                <div>
                    <asp:TextBox ID="tbPassword" runat="server" Width="225px" MaxLength="16" 
                        TextMode="Password"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    <label id="lblConfirmPassword" runat="server">
                        Confirm Password*</label><asp:CompareValidator ID="cvEmail0" runat="server" ControlToCompare="tbPassword"
                            ControlToValidate="tbConfirmPassword" ErrorMessage="Password comparison failed.">*</asp:CompareValidator>
                </div>
                <div>
                    <asp:TextBox ID="tbConfirmPassword" runat="server" Width="225px" 
                        TextMode="Password"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
</div>
