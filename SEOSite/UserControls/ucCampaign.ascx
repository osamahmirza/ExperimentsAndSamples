<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucCampaign.ascx.cs" Inherits="ucCampaign" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="ucProductAndService.ascx" TagName="ucProductAndService" TagPrefix="uc1" %>
<%@ Register Src="ucLinks.ascx" TagName="ucLinks" TagPrefix="uc2" %>
<%@ Register Src="ucConnect.ascx" TagName="ucConnect" TagPrefix="uc4" %>
<%@ Register Src="ucPayment.ascx" TagName="ucPayment" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ucBusinessInfo.ascx" TagName="ucBusinessInfo" TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/ucWebsiteInfo.ascx" TagName="ucWebsiteInfo" TagPrefix="uc6" %>
<asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
</asp:ToolkitScriptManager>
<asp:Label ID="lblCaption" runat="server"></asp:Label>
<asp:TabContainer ID="TabContainer1" runat="server" Width="864"
    ActiveTabIndex="4">
    <asp:TabPanel ID="tabPanel0" runat="server" HeaderText="Bus. / Org. Info" Enabled="true"
        ScrollBars="Auto" OnDemandMode="Once">
        <ContentTemplate>
            <div>
                <h2>
                    <a id="websiteinfo" name="websiteinfo"></a>
                </h2>
                <div class="cyberHawkRow-Heading">
                    <div class="cyberHawkRow-left">
                        Business / Organization
                    </div>
                    <div class="cyberHawkRow-right">
                        Tips
                    </div>
                </div>
                <uc5:ucBusinessInfo ID="ucBusinessInfo" runat="server" />
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Mission Statement*<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="tbMissionStatement" ErrorMessage="Mission Statement is required."
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox ID="tbMissionStatement" runat="server" Width="100%" MaxLength="256"
                            Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>A mission statement is a brief description of a company's fundamental purpose. A
                                    mission statement should answers following questions: </li>
                                <li>Your mission or vision statement should answer following questions:<br />
                                    <ul style="list-style-type: lower-greek; list-style-position: inside">
                                        <li>What do we do?</li>
                                        <li>Why do we do it?</li>
                                        <li>For who do we do it?</li>
                                    </ul>
                                    Mission statement is not a slogan! </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Describe Your Business / Organization *<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="tbBusinessDefinition" ErrorMessage="Describe Your Business is required."
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox ID="tbBusinessDefinition" runat="server" Height="150px" MaxLength="1024"
                            TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>The description of your business should clearly identify goals and objectives, and
                                    it should clarify why you are, or why you want to be, in business.</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Search Phrases*<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="tbSearchPhrase" ErrorMessage="Search Phrase is required."
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox ID="tbSearchPhrase" runat="server" MaxLength="256" Width="100%" Height="50px"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>Summary attempts to extract the search string used by a visitor at a major search
                                    engine to find your site. This information is extracted from the referrer. The entire
                                    string is called the search phrase.</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Who Is Your Target Audience*<asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                runat="server" ControlToValidate="tbTarget" ErrorMessage="Target Audience is required."
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox ID="tbTarget" runat="server" Height="150px" MaxLength="1024" TextMode="MultiLine"
                            Width="100%"></asp:TextBox>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>Who are your best customers, not company names but by type of business or consumer
                                    profile if you have one. Why are they the best?</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Is Live
                            <asp:RadioButton runat="server" ID="rbIsLiveYes" Text="Yes" GroupName="IsLive" />
                            <asp:RadioButton runat="server" ID="rbIsLiveNo" Text="No" GroupName="IsLive" />
                        </div>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>Make your campaign live or bring it offline.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:TabPanel>
    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Product/Service/Cause" Enabled="true"
        ScrollBars="Auto" OnDemandMode="None">
        <ContentTemplate>
            <div>
                <h2>
                    <a id="productservicecause" name="productservicecause"></a>
                </h2>
                <div class="cyberHawkRow-Heading">
                    <div class="cyberHawkRow-left">
                        Product / Service / Cause
                    </div>
                    <div class="cyberHawkRow-right">
                        Tips
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Category Name for Product/Service/Cause*<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                ControlToValidate="tbProductCategoryName" ErrorMessage="Category Name for Product/Service/Cause is required."
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox ID="tbProductCategoryName" runat="server" Width="100%" MaxLength="128"></asp:TextBox>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>In this field you will put a name which will identify the category of the links of your webpages you will be putting in next section. You may want to call it Portfolio, Services, Products, Causes, Special Offers, etc.</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            What Do You Offer*
                        </div>
                        <uc1:ucProductAndService ID="ucProductAndService1" runat="server" />
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>In rank order of priority to the importance of the success of your business, list
                                    the products or services that you provide, put at least 2 words in &#39;Offering&#39;
                                    field and minimum of 2 words in &#39;Description&#39; field (Data entered in Offering
                                    and Description fields will serve the purpose of search keywords and search phrases
                                    on a search engine). </li>
                                <li>Considerations regarding importance: gross profit , growth potential, unique competitive
                                    niche, what you are best known for, what you do best, what you want to do more of.
                                </li>
                                <li>Use as few or as many spaces as you need. For nonprofits, enter your key issues or
                                    causes in rank order of importance to the success of your efforts.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:TabPanel>
    <asp:TabPanel ID="tabPanel1" runat="server" HeaderText="Website Info" Enabled="true" ScrollBars="Auto" OnDemandMode="None">
        <ContentTemplate>
            <div>
                <h2>
                    <a id="A1" name="websiteinfo"></a>
                </h2>
                <div class="cyberHawkRow-Heading">
                    <div class="cyberHawkRow-left">
                        Website Info
                    </div>
                    <div class="cyberHawkRow-right">
                        Tips
                    </div>
                </div>
                <uc6:ucWebsiteInfo runat="server" ID="ucWebsiteInfo" />
                <%--<div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Search Phrases*<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                ControlToValidate="tbSearchPhrase" ErrorMessage="Search Phrase is required."
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox ID="TextBox4" runat="server" MaxLength="256" Width="100%" Height="50px"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>Summary attempts to extract the search string used by a visitor at a major search
                                    engine to find your site. This information is extracted from the referrer. The entire
                                    string is called the search phrase.</li>
                            </ul>
                        </div>
                    </div>
                </div>--%>
            </div>
        </ContentTemplate>
    </asp:TabPanel>
    <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Linking and Connecting" Enabled="true"
        ScrollBars="Auto" OnDemandMode="None">
        <ContentTemplate>
            <div>
                <h2>
                    <a id="linkingandconnecting" name="linkingandconnecting"></a>
                </h2>
                <div class="cyberHawkRow-Heading">
                    <div class="cyberHawkRow-left">
                        Linking and Connecting
                    </div>
                    <div class="cyberHawkRow-right">
                        Tips
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Category Name for Links to Other Webpages*<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="tbLinkCategoryName" ErrorMessage="Category Name for Links to Other Webpages is required."
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox ID="tbLinkCategoryName" runat="server" Width="100%" MaxLength="128"></asp:TextBox>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>In this field you will put a name which will identify the category of the links of your webpages you will be putting in next section.</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Links To Other Webpages*
                        </div>
                        <uc2:ucLinks ID="ucLinks1" runat="server" />
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>In rank order of priority to the importance of the content of your website, provide
                                    complete webpage links that you have on your website and give a brief description
                                    about that webpage, which should be the extract of the content on a given webpage.</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Other Connection Options
                        </div>
                        <uc4:ucConnect ID="ucConnect1" runat="server" />
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>Please provide your profile links to as many social networks or blogging sites you
                                    are registered at.</li>
                                <li>Networking and blogging is part of marketing and promotions
                                        and a necessity for business and professional growth. Meeting new people, getting
                                        to know them, and exchanging business cards happens at Rotary Club dinners, conferences,
                                        and business meetings daily. Social networking and blogging is no different except
                                        that it happens online where the world is open to anyone with a computer.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:TabPanel>
    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Audience Scope" Enabled="true"
        ScrollBars="Auto" OnDemandMode="None">
        <ContentTemplate>
            <div>
                <h2>
                    <a id="audiencescope" name="audiencescope"></a>
                </h2>
                <div class="cyberHawkRow-Heading">
                    <div class="cyberHawkRow-left">
                        Audience Scope
                    </div>
                    <div class="cyberHawkRow-right">
                        Tips
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Business Category*<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ControlToValidate="ddlCategory" ErrorMessage="Business Category is required."
                                InitialValue="-1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="175px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                        <div class="label">
                            Sub-Category*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="ddlSubCategory" ErrorMessage="Sub-Category is required."
                                InitialValue="-1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:DropDownList ID="ddlSubCategory" runat="server" Width="175px">
                        </asp:DropDownList>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>Which Business Category Defines Your Business The Most?</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Geographic Scope*<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ControlToValidate="ddlGeographicScope" ErrorMessage="Geographic Scope is required."
                                InitialValue="-1" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:DropDownList ID="ddlGeographicScope" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGeographicScope_SelectedIndexChanged"
                            Width="175px">
                        </asp:DropDownList>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>What Is The Geographic Scope Of Your Market?</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="cyberHawkRow">
                    <div class="cyberHawkRow-left">
                        <div class="label">
                            Geographic Location(s)*<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="tbGeographicLocation" ErrorMessage="Geographic Location(s) is required.">*</asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox ID="tbGeographicLocation" runat="server" Height="150px" TextMode="MultiLine"
                            Width="100%" MaxLength="2048" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="cyberHawkRow-right">
                        <div class="label">
                            <ul>
                                <li>Clarify your markets as selected above. What we are looking for are countries, states
                                    or provinces, city names for your market areas for targeting the geography in your
                                    keywords and phrases. For example, if you are selling widgets in New England, what
                                    are the target states you cover in New England in rank order? We are looking for
                                    naming priorities for search engines.</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:TabPanel>
</asp:TabContainer>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <%--<div class="domtab">
            <ul id="submenu" class="domtabs">
                <li><a href="#websiteinfo">Step 1</a></li>
                <li><a href="#linkingandconnecting">Step 2</a></li>
                <li><a href="#productservicecause">Step 3</a></li>
                <li><a href="#audiencescope">Step 4</a></li>
                <li><a href="#general">Step 5</a></li>
            </ul>
            <div style="height: 40px">
            </div>
            
            
        </div>--%>
        <br />
        <div class="cyberHawkRow" style="background-color: #EED8AE">
            <div class="label">
                Please Read The Agreement Below.*
            </div>
            <asp:TextBox ID="tbTermsAndConditions" runat="server" TextMode="MultiLine" Height="60px"
                Width="99%" />
            <br />
            <br />
            <asp:CheckBox ID="cbAgree" CssClass="label" runat="server" Text="&nbsp;&nbsp;I Agree to above mentioned end user license agreement.*" />
            <%--<table cellspacing="0">
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlExpirationDate" runat="server">
                            <asp:Label ID="lblExpirationDate" runat="server" />
                        </asp:Panel>
                        <asp:Panel ID="pnlPaymentRequired" runat="server">
                            <asp:Label ID="lnkPayment" Style="color: red" runat="server">Make a payment</asp:Label>
                            <uc3:ucPayment ID="ucPayment1" runat="server" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="label">
                            Please Read The Agreement Below.*</div>
                        <asp:TextBox ID="tbTermsAndConditions" runat="server" TextMode="MultiLine" Height="60px"
                            Width="98%" />
                        <br />
                        <br />
                        <asp:CheckBox ID="cbAgree" CssClass="label" runat="server" Text="&nbsp;&nbsp;I Agree to above mentioned end user license agreement.*" />
                    </td>
                </tr>
            </table>--%>
        </div>
        <br />
    </ContentTemplate>
</asp:UpdatePanel>
