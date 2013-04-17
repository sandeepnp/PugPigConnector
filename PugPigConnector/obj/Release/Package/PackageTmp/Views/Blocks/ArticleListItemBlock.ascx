<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleListItemBlock.ascx.cs" Inherits="PugPigConnector.Views.Blocks.ArticleListItemBlock" %>

      <li>
        <a href='<%=GetPage(CurrentBlock.ArticlePageLink).LinkURL%>'>
             <EPiServer:Property ID="Property1"  PropertyName="Image" runat="server" />
        </a>
        <h3>
            <a href='<%=GetPage(CurrentBlock.ArticlePageLink).LinkURL%>'>
                <EPiServer:Property ID="Property2"  PropertyName="Title" runat="server" />
            </a>
        </h3>
        <p>
            <EPiServer:Property ID="Property3"  PropertyName="BodyContent" runat="server" />
        </p>
      </li>
