<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucBusinessInfo.ascx.cs" Inherits="UserControls_ucBusinessInfo" %>
<div class="cyberHawkRow">
    <div class="cyberHawkRow-left">
        <div class="label">
            CyberHawk Name*<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                ControlToValidate="tbName" ErrorMessage="CyberHawk Name is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </div>
        <asp:TextBox ID="tbName" runat="server" MaxLength="64" Width="100%"></asp:TextBox>
    </div>
    <div class="cyberHawkRow-right">
        <ul>
            <li>Please provide a unique name to your CyberHawk. </li>
        </ul>
    </div>
</div>
<div class="cyberHawkRow">
    <div class="cyberHawkRow-left">
        <div class="label">
            Company Name
        </div>
        <asp:TextBox ID="tbCompanyName" runat="server" Width="100%" MaxLength="128"></asp:TextBox>
    </div>
    <div class="cyberHawkRow-right">
        <div class="label">
            <ul>
                <li>Your registered company name under which your website is being operated, if you
                    have any. Registered company shows more evidence of the ownership and genuinity
                    of your website. It's also a constructive notice of the website's claim. </li>
            </ul>
        </div>
    </div>
</div>
<div class="cyberHawkRow">
    <div class="cyberHawkRow-left">
        <div class="label">
            Email
        </div>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbEmail"
            ErrorMessage="Website's Email is not valid." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <asp:TextBox ID="tbEmail" runat="server" Width="100%" MaxLength="256"></asp:TextBox>
    </div>
    <div class="cyberHawkRow-right">
        <div class="label">
            <ul>
                <li>The email address you are providing on your website or you want to let your target
                    audiance get hold of you by.</li>
            </ul>
        </div>
    </div>
</div>
<div class="cyberHawkRow">
    <div class="cyberHawkRow-left">
        <div class="label">
            Phone
        </div>
        <asp:TextBox ID="tbPhone" runat="server" Width="100%" MaxLength="14"></asp:TextBox>
    </div>
    <div class="cyberHawkRow-right">
        <div class="label">
            <ul>
                <li>The phone number you are providing on your website, or you want your target audiance
                    to contact you at.</li>
            </ul>
        </div>
    </div>
</div>

<div class="cyberHawkRow">
    <div class="cyberHawkRow-left">
        <div class="label">
            Fax
        </div>
        <asp:TextBox ID="tbFax" runat="server" Width="100%" MaxLength="14"></asp:TextBox>
    </div>
    <div class="cyberHawkRow-right">
        <div class="label">
            <ul>
                <li>The fax number you are providing on your website, or you want your target audiance
                    to contact you at.</li>
            </ul>
        </div>
    </div>
</div>



