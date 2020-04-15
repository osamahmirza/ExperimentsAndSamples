<%@ Page Title="" Language="C#" MasterPageFile="~/Main-SubHead.master" AutoEventWireup="true"
    CodeFile="ANewWebOrder-Registration.aspx.cs" Inherits="Registration" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ Register Src="UserControls/ucPersonInfo.ascx" TagName="PersonInfo" TagPrefix="uc1" %>
<%@ Register Src="UserControls/ucUserInfo.ascx" TagName="UserInfo" TagPrefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td style="padding-right: 5px">
                <div class="regular">
                    <h2>
                        Personal Information</h2>
                    <hr />
                </div>
            </td>
            <td style="padding-right: 5px">
                <div class="regular">
                    <h2>
                        User Information</h2>
                    <hr />
                </div>
            </td>
            <td style="padding-right: 5px">
                <div class="regular">
                    <h2>
                        Information</h2>
                    <hr />
                </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <uc1:PersonInfo ID="PersonInfo1" runat="server" />
            </td>
            <td style="vertical-align: top">
                <uc2:UserInfo ID="UserInfo1" runat="server" />
            </td>
            <td rowspan="5" class="regular" style="vertical-align: top; padding: 2px">
                <p>
                    1 - All fields marked with '*' are Required</p>
                <p>
                    2 - We will not share your email address with any third parties. We will be using
                    your email address to contact you and to tell you about new offers, we may send
                    you exclusive news about our offerings.</p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="regular" style="padding-top: 5px">
                    <h2>
                        End user license agreement</h2>
                    <hr />
                </div>
                <div class="label">
                    Please read the agreement below:*
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="tbTermsAndConditions" runat="server" TextMode="MultiLine" Height="65px"
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="label">
                    <asp:CheckBox ID="chkIAgree" runat="server" Text=" I Agree to above mentioned end user license agreement.*" /></div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="regular" style="padding-top: 5px">
                    <h2>
                         Image verification</h2>
                    <hr />
                </div>
                <div class="label">
                    Completely Automated Public Turing Test To Tell Computers and Humans Apart (CAPTCHA).*
                </div>
                <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LehS8ASAAAAACIq8rtrglBggLRR2QFemNMG22QI"
                    PrivateKey="6LehS8ASAAAAAOGzaOw3NL0ePEGj2xIBIDMsiT5o" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:5px">
                <asp:Button ID="btnRegister" runat="server" Text="   Register   " OnClick="btnRegister_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
