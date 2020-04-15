<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTWFBRightTwoColumns.ascx.cs" Inherits="UserControls_ucTWFBRightTwoColumns" %>
<div style="float: right; padding-top: 10px; width:500px">
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
    <div style="width: 250px; background: #8D6932; color: #FFFFCC; font-size: 18px; font-weight: bold;
        display: block; font-family: Arial; padding-top: 8px; float:right">
        <p style="color: #FFFFCC; padding-bottom: 8px; padding-left: 8px">
            Find us on Facebook</p>
    </div>
    <div style="color: #FFFFCC;float:right">
        <div id="fb-root">
        </div>
        <script src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
        <fb:like-box href="http://www.facebook.com/pages/Toronto-Ontario/ANewWebOrder/118032454943639"
            width="250" show_faces="true" stream="true" header="false"></fb:like-box>
    </div>
</div>

