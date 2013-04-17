<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleListItem2Block.ascx.cs" Inherits="PugPigConnector.Views.Blocks.ArticleListItem2Block" %>

      <li>
        <h3>
            <a href='<%=GetPage(CurrentBlock.ArticlePageLink).LinkURL%>'>
                <EPiServer:Property ID="Property2"  PropertyName="Title" runat="server" />
            </a>
        </h3>
        <p>
            <EPiServer:Property ID="Property3"  PropertyName="BodyContent" runat="server" />
        </p>
      </li>
