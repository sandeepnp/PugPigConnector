<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.NovartisCoverPageTemplate" CodeBehind="NovartisCoverPageTemplate.aspx.cs" %>

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
       <header>
         <h1>Contents page</h1>
       </header>       
         <EPiServer:Property ID="Stories"  PropertyName="Stories" runat="server" />         
         <EPiServer:Property ID="TextContent"  PropertyName="TextContent" runat="server" />               
    </body>

</html> 