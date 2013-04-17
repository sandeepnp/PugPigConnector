<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.GenericRegularSmall" CodeBehind="GenericRegularSmall.aspx.cs" %>

<!DOCTYPE html>
<html manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
    <head id="Head1" runat="server">
       <title><%= CurrentPage["Title"] %></title>
       <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
       <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
       <!-- To get rid of the URL and button bars -->
       <meta name="apple-mobile-web-app-capable" content="yes" />
       <!-- Status Bar Style (default, black, black-translucent) -->
       <meta name="apple-mobile-web-app-status-bar-style" content="black" />
       <link rel="stylesheet" type="text/css" href="/css/smallarticle.css" />
    </head>
    <body class="<%= CurrentPage["BodyStyle"] %>">
      <header>
        <h1><%= CurrentPage["Summary"] %></h1>
      </header>
      <article>
        <figure>
           <div><EPiServer:Property ID="Property2"  PropertyName="Image" runat="server" /></div>
        </figure>
        <EPiServer:Property ID="Property3" runat="server" PropertyName="BodyContent" />
      </article>
    </body>
</html>