<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CoverPageListArticleBlock.ascx.cs" Inherits="PugPigConnector.Views.Blocks.CoverPageListArticleBlock" %>

<li class="<%= CurrentBlock.CssClass%>">
    <a href="<%= GetPage(CurrentBlock.ArticlePage).LinkURL%>"><EPiServer:Property ID="Property1" PropertyName="Title" runat="server" /></a>
</li>