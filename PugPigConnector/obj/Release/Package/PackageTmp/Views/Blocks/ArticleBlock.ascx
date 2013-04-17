<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleBlock.ascx.cs" Inherits="PugPigConnector.Views.Blocks.ArticleBlock" %>

    <body class="<%= CurrentBlock.BodyStyle %>">
      <header>
        <h1><EPiServer:Property ID="Property1"  PropertyName="Title" runat="server" /></h1>
      </header>  
      <article>
        <figure>
           <div><EPiServer:Property ID="Property2"  PropertyName="Image" runat="server" /></div>
        </figure>
        <EPiServer:Property ID="Property3" runat="server" PropertyName="BodyContent" />
      </article> 
    </body>