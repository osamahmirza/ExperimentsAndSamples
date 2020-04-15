<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMediaTopBar.ascx.cs"
    Inherits="UserControls_Media" %>
<!-- AddThis Button BEGIN -->
<div class="mediaTopBarLeft">
    <div class="addthis_toolbox addthis_default_style">
        <a href="http://www.addthis.com/bookmark.php?v=250&amp;username=xa-4b4d2ba065a98a85"
            class="addthis_button_compact" style="color: #8D6932; text-decoration: none">Share</a>
        <span class="addthis_separator">|</span> <a class="addthis_button_facebook"></a>
        <a class="addthis_button_myspace"></a><a class="addthis_button_google"></a><a class="addthis_button_twitter">
        </a>
    </div>
    <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#username=xa-4b4d2ba065a98a85"></script>
</div>
<div class="mediaTopBarRight">
    Keep an eye on us: 
    <a href="http://anewweborder.blogspot.com/" target="_blank" alt="Read us on Blogger">
        <asp:Image ID="i3" CssClass="" BorderWidth="0" ImageAlign="AbsMiddle" AlternateText="Read us on Blogger"
            runat="server" ImageUrl="~/App_Themes/Default/images/icon-blogger.jpg" /></a>
    <a href="http://www.facebook.com/pages/Toronto-Ontario/ANewWebOrder/118032454943639"
        target="_blank" alt="Join us on Facebook">
        <asp:Image ID="i1" BorderWidth="0" ImageAlign="AbsMiddle" AlternateText="Join us on Facebook"
            runat="server" ImageUrl="~/App_Themes/Default/images/icon-facebook.gif" /></a>
    <a href="http://twitter.com/anewweborder" target="_blank" alt="Follow us on Twitter">
        <asp:Image ID="i2" CssClass="" BorderWidth="0" ImageAlign="AbsMiddle" AlternateText="Follow us on Twitter"
            runat="server" ImageUrl="~/App_Themes/Default/images/icon-twitter.gif" /></a>
</div> 
