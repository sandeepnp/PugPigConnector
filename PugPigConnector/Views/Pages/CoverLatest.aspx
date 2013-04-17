<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.CoverLatest" CodeBehind="CoverLatest.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"     "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
<head id="Head1" runat="server">
 <title>Edition Title</title>
  <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link rel="stylesheet" type="text/css" href="/css/contents.css" />
</head>
<body style="background-color: white;">
    <h1><EPiServer:Property ID="Property1" runat="server" PropertyName="Title" /></h1>
  <section class="topstories">
    <ul>
       <EPiServer:Property ID="Property2" runat="server" PropertyName="TopArticlesArea" />
    </ul>

<%--      
      <li><a href="/New-Edition-List/January-2013/News/">
        <article>
          <h2>Lorizzle ipsizzle dolizzle</h2>
          <figure><img src="/img/article-a1.jpg" /></figure>
        </article>
      </a></li>
      <li>
        <a href="/New-Edition-List/January-2013/Sport/">
          <article>
            <h2>Cras accumsizzle</h2>
            <figure><img src="/img/article-b1.jpg" /></figure>
          </article>
        </a>
      </li>
      <li><a href="/New-Edition-List/January-2013/Entertainment/">
        <article>
          <h2>Sizzle go to hizzle</h2>
          <figure><img src="/img/article-c1.jpg" /></figure>
        </article>
      </a></li>
      <li><a href="/New-Edition-List/January-2013/Business/">
        <article>
          <h2>Lorizzle ipsizzle dolizzle</h2>
          <figure><img src="/img/article-d1.jpg" /></figure>
        </article>
      </a></li>
      <li><a href="/New-Edition-List/January-2013/Finance/">
        <article>
          <h2>Sizzle go to hizzle</h2>
          <figure><img src="/img/article-e1.jpg" /></figure>
        </article>
      </a></li>
    </ul>
--%>

  </section>
  <section class="sections">
    <ul>
      <EPiServer:Property ID="Property3" runat="server" PropertyName="ArticleListArea" />  
<%--      
      <li class="section-a"><a href="/New-Edition-List/January-2013/News-List/">News</a></li>
      <li class="section-b"><a href="/New-Edition-List/January-2013/Sport-List/">Sport</a></li>
      <li class="section-c"><a href="/New-Edition-List/January-2013/Entertainment-List/">Entertainment</a></li>
      <li class="section-d"><a href="/New-Edition-List/January-2013/Business-List/">Business</a></li>
      <li class="section-e"><a href="/New-Edition-List/January-2013/Finance-List/">Finance</a></li>
--%>
    </ul>
  </section>    
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
</body>
</html>