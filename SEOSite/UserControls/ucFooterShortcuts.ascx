<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucFooterShortcuts.ascx.cs"
    Inherits="UserControls_ucFooterShortcuts" %>
<div id="footer">
    <div id="footercontent">
        <div id="previews">
            <div class="item">
                <asp:HyperLink ID="h1" runat="server" NavigateUrl="~/Default.aspx">
                    <asp:Image ID="i1" runat="server" ImageUrl="~/Images/100x100/HomePage.png" alt="Home" /></asp:HyperLink>
                <span class="caption">Home</span>
            </div>
            <div class="item">
                <asp:HyperLink ID="h2" runat="server" NavigateUrl="~/ANewWebOrder-Registration.aspx">
                    <asp:Image ID="i2" runat="server" ImageUrl="~/Images/100x100/Register.png" alt="Register" /></asp:HyperLink>
                <span class="caption">Register</span>
            </div>
            <div class="item">
                <asp:HyperLink ID="h3" runat="server" NavigateUrl="~/ANewWebOrder-HowTo.aspx">
                    <asp:Image ID="i3" runat="server" ImageUrl="~/Images/100x100/HowTo.png" alt="How To" /></asp:HyperLink>
                <span class="caption">How To</span>
            </div>
            <div class="item">
                <asp:HyperLink ID="h4" runat="server" NavigateUrl="~/ANewWebOrder-Contact-Us.aspx">
                    <asp:Image ID="i4" runat="server" ImageUrl="~/Images/100x100/ContactUs.png" alt="Contact Us" /></asp:HyperLink>
                <span class="caption">Contact Us</span>
            </div>
            <div class="item">
                <asp:HyperLink ID="h5" runat="server" NavigateUrl="http://anewweborder.blogspot.com/"
                    Target="_blank">
                    <asp:Image ID="i5" runat="server" ImageUrl="~/Images/100x100/BlogSpot.png" alt="Read our Blog" /></asp:HyperLink>
                <span class="caption">Read Us</span>
            </div>
            <div class="item">
                <asp:HyperLink ID="h6" runat="server" NavigateUrl="http://www.facebook.com/pages/Toronto-Ontario/ANewWebOrder/118032454943639"
                    Target="_blank">
                    <asp:Image ID="i6" runat="server" ImageUrl="~/Images/100x100/Facebook.png" alt="Join Us on Facebook" /></asp:HyperLink>
                <span class="caption">Join Us</span>
            </div>
            <div class="item">
                <asp:HyperLink ID="h7" runat="server" NavigateUrl="http://twitter.com/#!/anewweborder"
                    Target="_blank">
                    <asp:Image ID="i7" runat="server" ImageUrl="~/Images/100x100/Twitter.png" alt="Follow us on Twitter" /></asp:HyperLink>
                <span class="caption">Follow Us</span>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="copyright">
            <strong>CyberHawk&trade;</strong> and <strong>Virtual Search Engine Optimization&trade;</strong>
            are trademarks of <strong>aNewWebOrder.com</strong> &reg;
        </div>
    </div>
</div>
