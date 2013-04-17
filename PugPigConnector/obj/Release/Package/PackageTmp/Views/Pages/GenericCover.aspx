<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.GenericCover" CodeBehind="GenericCover.aspx.cs" %>
<%@ Import Namespace="EPiServer.Core" %>

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
      <li>
        <a href='<%= GetPage(CurrentPage.LinkStory1).LinkURL %>'>
         <article>
          <h2><EPiServer:Property ID="Property1"  PropertyName="HeaderStory1" runat="server" /></h2>
          <figure><EPiServer:Property ID="Property2"  PropertyName="ImageStory1" runat="server" /></figure>
         </article>
        </a>
      </li>
      <li><a href='<%= GetPage(CurrentPage.LinkStory2).LinkURL %>'>
          <article>
            <h2><EPiServer:Property ID="Property3"  PropertyName="HeaderStory2" runat="server" /></h2>
            <figure><EPiServer:Property ID="Property4"  PropertyName="ImageStory2" runat="server" /></figure>
          </article>
        </a>
      </li>
      <li><a href="<%= GetPage(CurrentPage.LinkStory3).LinkURL %>">
          <article>
            <h2><EPiServer:Property ID="Property5"  PropertyName="HeaderStory3" runat="server" /></h2>
            <figure><EPiServer:Property ID="Property6"  PropertyName="ImageStory3" runat="server" /></figure>
          </article>
        </a>
      </li>
      <li><a href="<%= GetPage(CurrentPage.LinkStory4).LinkURL %>">
          <article>
            <h2><EPiServer:Property ID="Property7"  PropertyName="HeaderStory4" runat="server" /></h2>
            <figure><EPiServer:Property ID="Property8"  PropertyName="ImageStory4" runat="server" /></figure>
          </article>
        </a>
      </li>
      <li><a href="<%= GetPage(CurrentPage.LinkStory5).LinkURL %>">
          <article>
            <h2><EPiServer:Property ID="Property9"  PropertyName="HeaderStory5" runat="server" /></h2>
            <figure><EPiServer:Property ID="Property10"  PropertyName="ImageStory5" runat="server" /></figure>
          </article>
        </a>
      </li>
    </ul>
  </section>
  <section class="sections">
    <ul>
      <li class="section-a"><a href="<%= GetPage(CurrentPage.CategoryListLink1).LinkURL %>"><EPiServer:Property ID="Property11"  PropertyName="CategoryName1" runat="server" /></a></li>
      <li class="section-b"><a href="<%= GetPage(CurrentPage.CategoryListLink2).LinkURL %>"><EPiServer:Property ID="Property12"  PropertyName="CategoryName2" runat="server" /></a></li>
      <li class="section-c"><a href="<%= GetPage(CurrentPage.CategoryListLink3).LinkURL %>"><EPiServer:Property ID="Property13"  PropertyName="CategoryName3" runat="server" /></a></li>
      <li class="section-d"><a href="<%= GetPage(CurrentPage.CategoryListLink4).LinkURL %>"><EPiServer:Property ID="Property14"  PropertyName="CategoryName4" runat="server" /></a></li>
      <li class="section-e"><a href="<%= GetPage(CurrentPage.CategoryListLink5).LinkURL %>"><EPiServer:Property ID="Property15"  PropertyName="CategoryName5" runat="server" /></a></li>
    </ul>
  </section>    

</body>
</html>