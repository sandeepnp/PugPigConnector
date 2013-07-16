<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.NovartisGenericPageTemplate" CodeBehind="NovartisGenericPageTemplate.aspx.cs" %>

<!DOCTYPE html>
<html manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
    <head id="Head1" runat="server">
        <title>section-index</title>
        <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link rel="stylesheet" type="text/css" href="/css/general.css" />
        <link rel="stylesheet" type="text/css" href="/css/responsive.css" />
    </head>

    <body class="section-a">  
       <header>
         <h1>Section index</h1>
       </header> 
       <article>                
         <EPiServer:Property ID="Content"  PropertyName="Content" runat="server" />               
       </article>       
    </body>

</html> 