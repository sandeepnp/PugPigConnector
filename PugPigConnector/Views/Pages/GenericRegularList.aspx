<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.GenericRegularList" CodeBehind="GenericRegularList.aspx.cs" %>

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
          <% for (int i = 1; i <= 4; i++)
             {
          %>  
              <li>
                <a href='<%= GetPage(CurrentPage.SmallArticlePageLink).LinkURL %>'>
                    <EPiServer:Property ID="Property2"  PropertyName="Image" runat="server" />
                </a>
                <h3><a href='<%= GetPage(CurrentPage.SmallArticlePageLink).LinkURL %>'>
                        <%= CurrentPage["Title"] %>
                    </a>
                </h3>
                <p>
                    <EPiServer:Property ID="Property3" runat="server" PropertyName="BodyContent" />
                </p>
              </li>
          <% 
             }
          %>  
         </ol>

         <ol class='articles-list second'>
          <% for (int i = 1; i <= 3; i++)
             {
          %>   
              <li>
                <h3>
                    <a href='<%= GetPage(CurrentPage.SmallArticlePageLink).LinkURL %>'><%= CurrentPage["Title"] %></a>
                </h3>
                <p><EPiServer:Property ID="Property1" runat="server" PropertyName="BodyContent" /></p>
              </li>         
          <% 
             }
          %>                
         </ol>
     </article>
    </body>
</html>