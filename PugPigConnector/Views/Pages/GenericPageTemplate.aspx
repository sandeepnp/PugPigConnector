<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.GenericPageTemplate" CodeBehind="GenericPageTemplate.aspx.cs" %>

<!DOCTYPE html>
<html manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">

    <head id="Head1" runat="server">
        <title>Column Test</title>
        <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link rel="stylesheet" type="text/css" href="/css/general.css" />
        <link rel="stylesheet" type="text/css" href="/css/responsive.css" />
    </head>

    <body>
      <EPiServer:Property ID="ContentArea" runat="server" PropertyName="ContentArea" />
    </body>

</html> 