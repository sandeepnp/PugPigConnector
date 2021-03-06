﻿<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.CoverPageTemplate186" CodeBehind="CoverPageTemplate186.aspx.cs" %>

<!DOCTYPE html>
<html manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">

    <head id="Head1" runat="server">
        <title>Column Test</title>
        <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <!-- To get rid of the URL and button bars -->
        <meta name="apple-mobile-web-app-capable" content="yes" />
        <!-- Status Bar Style (default, black, black-translucent) --> 
        <meta name="apple-mobile-web-app-status-bar-style" content="black" />
        <link rel="stylesheet" type="text/css" href="/css/general.css" />
        <link rel="stylesheet" type="text/css" href="/css/responsive.css" />
    </head>

    <body class="<%= CurrentPage.BodyClass%>">    
      <EPiServer:Property ID="ContentArea"  PropertyName="ContentArea" runat="server" />
    </body>

</html> 