<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.ComplexCover" CodeBehind="ComplexCover.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"     "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
<head id="Head1" runat="server">
 <title>Edition Title</title>
  <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link rel="stylesheet" type="text/css" href="/css/contents.css" />
</head>
<body style="background-color: white;">
    <h1>Pugpig Gazette</h1>
  <section class="topstories">
    <ul>
      <li><a href="/New-Edition-List/January-2013/News/">
        <article>
          <h2>Lorizzle ipsizzle dolizzle</h2>
          <figure><img src="/img/article-a1.jpg" /></figure>
        </article>
      </a></li>
    </ul>
    <ul>
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
<%--<li><a href="article-d2.html">
        <article>
          <h2>Cras accumsizzle</h2>
          <figure><img src="/img/article-d2.jpg" /></figure>
        </article>
      </a></li>--%>
      <li><a href="/New-Edition-List/January-2013/Finance/">
        <article>
          <h2>Sizzle go to hizzle</h2>
          <figure><img src="/img/article-e1.jpg" /></figure>
        </article>
      </a></li>
    </ul>
  </section>
  <section class="sections">
    <ul>
      <li class="section-a"><a href="/New-Edition-List/January-2013/News-List/">News</a></li>
      <li class="section-b"><a href="/New-Edition-List/January-2013/Sport-List/">Sport</a></li>
      <li class="section-c"><a href="/New-Edition-List/January-2013/Entertainment-List/">Entertainment</a></li>
      <li class="section-d"><a href="/New-Edition-List/January-2013/Business-List/">Business</a></li>
      <li class="section-e"><a href="/New-Edition-List/January-2013/Finance-List/">Finance</a></li>
    </ul>
  </section>    

</body>
</html>