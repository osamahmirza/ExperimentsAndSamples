<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucWebsiteInfo.ascx.cs" Inherits="UserControls_ucWebsiteInfo" %>
<div class="cyberHawkRow">
    <div class="cyberHawkRow-left">
        <div class="label">
            Website Name*<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="tbWebsiteName" ErrorMessage="Website Name is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </div>
        <asp:TextBox ID="tbWebsiteName" runat="server" MaxLength="255" Width="100%"></asp:TextBox>
    </div>
    <div class="cyberHawkRow-right">
        <ul>
            <li>Name of your website with spaces, e.g. if your domain name is like www.somecoolbusiness.com
                then you should type Some Cool Business in the text box.</li>
        </ul>
    </div>
</div>
<div class="cyberHawkRow">
    <div class="cyberHawkRow-left">
        <div class="label" style="width: 100%">
            Website Address*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="tbWebsite" ErrorMessage="Website Address is required." SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbWebsite"
                ErrorMessage="Website Address is not valid." SetFocusOnError="True" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?">*</asp:RegularExpressionValidator>
            <div style="float: right">
                <asp:LinkButton runat="server" ID="lnkTestLink" Text="Test Link" ValidationGroup="Link" OnClick="lnkTestLink_Click" />
            </div>
        </div>
        <asp:TextBox ID="tbWebsite" runat="server" MaxLength="255" Width="100%"></asp:TextBox>
        <asp:Label runat="server" ID="lblWebsiteError" Text="" Visible="false"></asp:Label>
    </div>
    <div class="cyberHawkRow-right">
        <ul>
            <li>Please type your full website address, e.g. http://www.somecoolwebsite.com </li>
            <li>Make sure you do not put url of any page, doing so will have a bad impact on your
                website ranking.</li>
        </ul>
    </div>
</div>
<div class="cyberHawkRow">
    <div class="cyberHawkRow-left">
        <div class="label">
            Website Description*<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                runat="server" ControlToValidate="tbWebsiteDescription" ErrorMessage="Website Description is required."
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
        </div>
        <asp:TextBox ID="tbWebsiteDescription" runat="server" Width="100%" MaxLength="69"></asp:TextBox>
    </div>
    <div class="cyberHawkRow-right">
        <div class="label">
            <ul>
                <li>A very brief description of your website. It could have the mention of your service(s),
                                    location or it could be the most highly ranked search phrases suiteable for your
                                    website. e.g. 'Chartered Accountant Toronto, Mississauga Tax, Accounting Services
                                    GTA'. Notice, in given example, there are three search pharases people could use
                                    in any search engine.</li>
            </ul>
        </div>
    </div>
</div>
