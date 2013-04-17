<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.ArticleList" CodeBehind="ArticleList.aspx.cs" %>

<!DOCTYPE html>
<html manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
    <head id="Head1" runat="server">
        <title><%= CurrentPage["Title"] %></title>
        <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link rel="stylesheet" type="text/css" href="/css/section-index.css" />
    </head>
    <body class="<%= CurrentPage["BodyStyle"] %>">
     <header>
       <h1><%= CurrentPage["Summary"] %></h1>
     </header>
     <article>
         <ol class='articles-list first'>
            <EPiServer:Property ID="Property1" runat="server" PropertyName="UpperPageContentArea" />
         </ol>
         <ol class='articles-list second'>
            <EPiServer:Property ID="Property2" runat="server" PropertyName="LowerPageContentArea" />
         </ol>
     </article>
    </body>
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