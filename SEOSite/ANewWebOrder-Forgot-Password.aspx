<%@ Page Title="" Language="C#" MasterPageFile="~/Main-SubHead.master" AutoEventWireup="true"
    CodeFile="ANewWebOrder-Forgot-Password.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contents">
        <div class="clear">
        </div>
        <div id="stdcontents">
            <p>
                <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
                    <UserNameTemplate>
                        <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <table cellpadding="0">
                                        <tr>
                                            <%--<td align="center" colspan="2" class="label">
                                                    Forgot Your Password?
                                                </td>--%>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" class="label">
                                                Enter your User Name to receive your password.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="label">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                                <br />
                                                <asp:TextBox ID="UserName" runat="server" class="textfield"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <br />
                                                <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit" class="button"
                                                    ValidationGroup="PasswordRecovery1" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </UserNameTemplate>
                </asp:PasswordRecovery>
            </p>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
