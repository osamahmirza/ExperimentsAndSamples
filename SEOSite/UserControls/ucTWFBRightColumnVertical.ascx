<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTWFBRightColumnVertical.ascx.cs"
    Inherits="UserControls_ucTWFBRightColumnVertical" %>
<div style="float: right; padding-top: 10px">
    <script src="http://widgets.twimg.com/j/2/widget.js"></script>
    <script>
        new TWTR.Widget({
            version: 2,
            type: 'faves',
            rpp: 10,
            interval: 6000,
            title: 'Latest at',
            subject: 'aNewWebOrder.com',
            width: 250,
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
    <br />
    <div style="width: 250px; background: #8D6932; color: #FFFFCC; font-family: Arial;
        padding-top: 10px;">
        <p style="color: #FFFFCC; padding-bottom: 8px; padding-left: 8px; padding-top: 4px;
            line-height: 0px; font-size: 11px">
            Our Community</p>
        <p style="color: #FFFFCC; padding-bottom: 8px; padding-left: 8px; font-weight: bold;
            font-size: 18px">
            Join us on Facebook</p>
    </div>
    <div style="color: #FFFFCC">
        <div id="fb-root">
        </div>
        <script src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
        <fb:like-box href="http://www.facebook.com/pages/Toronto-Ontario/ANewWebOrder/118032454943639"
            width="250" show_faces="true" stream="true" header="false"></fb:like-box>
    </div>
</div>
