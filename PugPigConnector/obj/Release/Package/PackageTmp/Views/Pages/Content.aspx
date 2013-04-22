<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.Content" CodeBehind="Content.aspx.cs" %>

<!DOCTYPE html>
<html manifest ="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
  <head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta content="user-scalable=no, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" name="viewport" />
    <title>
      <%= CurrentPage.Title %>
    </title>
    <link rel="stylesheet" href="/css/normalize.css" type="text/css" />
    <link rel="stylesheet" href="/css/agileMkt.css" type="text/css" />
    <script type="text/javascript" src="/js/vendor/jquery-1.8.2.min.js"></script>
</head>  
    <EPiServer:Property ID="Property1"  PropertyName="BodyContent" runat="server" />
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-40182928-1', 'valtechdigital.co.uk');
        ga('send', 'pageview');

    </script>
</html>