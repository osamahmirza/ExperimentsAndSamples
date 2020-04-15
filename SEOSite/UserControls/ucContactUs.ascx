<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucContactUs.ascx.cs" Inherits="ucUserControls_ContactUs" %>
<div id="contents">
    <div class="clear">
    </div>
    <table style="float: left; width: 400px">
        <tr>
            <td colspan="4">
                <div class="regular">
                    <h2>
                        Quickly contact aNewWebOrder.com, Inc
                    </h2>
                    <hr />
                </div>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Inquiry Type</div>
                <asp:DropDownList ID="ddlRecipients" runat="server" Width="346px">
                    <asp:ListItem Selected="True" Value="1">General Inquiries</asp:ListItem>
                    <asp:ListItem Value="3">Customer Support</asp:ListItem>
                    <asp:ListItem Value="2">Sales</asp:ListItem>
                    <asp:ListItem Value="4">Webmaster</asp:ListItem>
                    <asp:ListItem Value="4">Billing</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td rowspan="7" style="vertical-align:top">
                <script src="http://widgets.twimg.com/j/2/widget.js"></script>
                <script>
                    new TWTR.Widget({
                        version: 2,
                        type: 'faves',
                        rpp: 10,
                        interval: 6000,
                        title: 'Latest at',
                        subject: 'aNewWebOrder.com',
                        width: 240,
                        height: 250,
                        theme: {
                            shell: {
                                background: '#8D6932',
                                color: '#FFFFCC'
                            },
                            tweets: {
                                background: '#F8F2DA',
                                color: '#666666',
                                links: '#333333'
                            }
                        },
                        features: {
                            scrollbar: true,
                            loop: true,
                            live: true,
                            hashtags: true,
                            timestamp: true,
                            avatars: true,
                            behavior: 'all'
                        }
                    }).render().setUser('anewweborder').start();
                </script>
            </td>
            <td rowspan="7" style="vertical-align: top">
                <div style="width: 240px; background: #8D6932; color: #FFFFCC; font-family: Arial;
                    padding-top: 10px; margin-left: 10px">
                    <p style="color: #FFFFCC; padding-bottom: 8px; padding-left: 8px; padding-top: 4px;
                        line-height: 0px; font-size: 11px">
                        Our Community</p>
                    <p style="color: #FFFFCC; padding-bottom: 8px; padding-left: 8px; font-weight: bold;
                        font-size: 18px">
                        Join us on Facebook</p>
                </div>
                <div style="color: #FFFFCC; float: right">
                    <div id="fb-root">
                    </div>
                    <script src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
                    <fb:like-box href="http://www.facebook.com/pages/Toronto-Ontario/ANewWebOrder/118032454943639"
                        width="240" height="287" show_faces="true" stream="true" header="false"></fb:like-box>
                </div>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Your Email</div>
                <asp:TextBox ID="txtEmail" runat="server" Width="340px"></asp:TextBox>
            </td>
            <td style="vertical-align: top">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is required">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Subject</div>
                <asp:TextBox ID="txtSubject" runat="server" Width="340px"></asp:TextBox>
            </td>
            <td style="vertical-align: top">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                    ErrorMessage="Subject is required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <div class="label">
                    Message</div>
                <asp:TextBox ID="txtMessage" runat="server" Height="132px" Width="340px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td style="vertical-align: top">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMessage"
                    ErrorMessage="Message is required">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="padding-top:10px">
                <asp:Button ID="btnSend" Width="75px" runat="server" Text="Send" OnClick="btnSend_Click" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div style="float: left">
                    <h2>
                        Contact us via Fax: +1(905) 481-0931
                    </h2>
                </div>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <div class="clear">
    </div>
</div>
