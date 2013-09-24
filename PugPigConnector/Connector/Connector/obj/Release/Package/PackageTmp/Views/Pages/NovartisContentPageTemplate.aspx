<%@ Page Language="c#" Inherits="Connector.Views.Pages.NovartisContentPageTemplate" CodeBehind="NovartisContentPageTemplate.aspx.cs" %>

<!DOCTYPE html>
<html>
    <head id="Head1" runat="server">
        <title>Article 1</title>
        <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <!-- To get rid of the URL and button bars -->
        <meta name="apple-mobile-web-app-capable" content="yes" />
        <!-- Status Bar Style (default, black, black-translucent) --> 
        <meta name="apple-mobile-web-app-status-bar-style" content="black" />
        <link rel="stylesheet" type="text/css" href="/css/general.css" />
        <link rel="stylesheet" type="text/css" href="/css/responsive.css" />
    </head>

    <body>  
       <header>
         <h1>Title of page</h1>
       </header> 
       <article> 
         <EPiServer:Property ID="Figure"  PropertyName="Figure" runat="server" />         
         <div class="small-article">
           <EPiServer:Property ID="ArticleTitle"  PropertyName="ArticleTitle" runat="server" />        
           <EPiServer:Property ID="TextContent"  PropertyName="TextContent" runat="server" />        
         </div>
       </article> 
    </body>

</html> 