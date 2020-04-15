<%@ Page Title="" Language="C#" MasterPageFile="~/Main-SubHead.master" AutoEventWireup="true"
    CodeFile="ANewWebOrder-Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="contents">
        <div class="clear">
        </div>
        <div id="stdcontents">
            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Members/CyberHawkList.aspx"
                CreateUserUrl="ANewWebOrder-Registration.aspx" PasswordRecoveryUrl="~/ANewWebOrder-Forgot-Password.aspx"
                PasswordRecoveryText="Forget Password?" CreateUserText="Register" RememberMeSet="true">
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <%--<td align="center" colspan="2">
                                    Log In</td>--%>
                                    </tr>
                                    <tr>
                                        <td align="right" class="label">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="label">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <asp:CheckBox ID="RememberMe" runat="server" Checked="True" CssClass="label" Text=" Remember me next time." />
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
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        <br />
                                            <asp:HyperLink ID="CreateUserLink" runat="server" NavigateUrl="ANewWebOrder-Registration.aspx">Register</asp:HyperLink>
                                            <br />
                                            <asp:HyperLink ID="PasswordRecoveryLink" runat="server" NavigateUrl="~/ANewWebOrder-Forgot-Password.aspx">Forget Password?</asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
