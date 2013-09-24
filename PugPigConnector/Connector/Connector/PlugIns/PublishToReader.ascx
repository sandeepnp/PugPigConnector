<%@ Control Language="c#" Codebehind="PublishToReader.ascx.cs" AutoEventWireup="False" Inherits="Connector.PlugIns.PublishToReader" %>

<asp:Button ID="publishButton" Text="Publish this edition" OnClick="publishButton_Click" runat="server" />
<asp:Label ID="publishLabel" Text="" runat="server" Visible="false" />