<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.Cover" CodeBehind="Cover.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"     "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
<head id="Head1" runat="server"><title>Edition Title</title></head>
<body style="background-color: white;">
    <form id="Form1" runat="server">
        <div>
            <h1><EPiServer:Property ID="Property1" runat="server" PropertyName="Title" /></h1>
        </div>
        <div>
            <EPiServer:Property  PropertyName="Image" runat="server" /><br/>
        </div>
        <br />
        <div>
            <EPiServer:Property ID="Property2" runat="server" PropertyName="Summary" />
        </div>
    </form>
</body>
</html>