<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoverPageArticleBlock.ascx.cs" Inherits="PugPigConnector.Views.Blocks.CoverPageArticleBlock" %>
    <li>
     <a href="<% = GetPage(CurrentBlock.ArticlePage).LinkURL %>">
       <article>
        <h2><EPiServer:Property ID="Property2" PropertyName="Title" runat="server" /></h2>
        <figure><EPiServer:Property ID="Property1" PropertyName="Image" runat="server" /></figure>
       </article>
     </a>
    </li>