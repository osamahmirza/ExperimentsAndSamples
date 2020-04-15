<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPubProf_Contact.ascx.cs"
    Inherits="Controls_ucPubProf_Contact" %>
<table>
    <tr>
        <td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidateInput" />
        </td>
    </tr>
    <tr>
        <td>
            <div>
                Phone:
                <br />
                <telerik:RadTextBox ID="rtbPhone" runat="server" EmptyMessage="Enter your phone # here"
                    Width="192px">
                </telerik:RadTextBox>
            </div>
            <div>
                Email:
                <br />
                <telerik:RadTextBox ID="rtbEmail" runat="server" EmptyMessage="Enter your email here"
                    Width="192px">
                </telerik:RadTextBox><asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="rtbEmail"
                    ErrorMessage="Email address cannot be left empty." SetFocusOnError="True" ValidationGroup="ValidateInput">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="rtbEmail"
                    ErrorMessage="Invalid email left address." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="ValidateInput">*</asp:RegularExpressionValidator>
            </div>
        </td>
    </tr>
    <tr>
        <td>
            Message:
            <br />
            <telerik:RadTextBox ID="txtMessage" runat="server" Height="150px" MaxLength="1024"
                TextMode="MultiLine" Width="550px" EmptyMessage="Enter your message here.">
            </telerik:RadTextBox>
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:CheckBox ID="chkSubscribe" runat="server" Text="Stay up to date about me (weekly alert)."
                Visible="False" />
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadCaptcha ID="RadCaptcha1" runat="server" CaptchaLinkButtonText="Refresh"
                CaptchaMaxTimeout="60" ErrorMessage="Invalid code." ValidationGroup="ValidateInput"
                MinTimeout="5">
            </telerik:RadCaptcha>
            <div style="text-align:right">
                <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" 
                    ValidationGroup="ValidateInput" onclick="btnSendMessage_Click" />
            </div>
        </td>
    </tr>
</table>
