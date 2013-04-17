<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.Regular" CodeBehind="Regular.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"     "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
<head id="Head1" runat="server"><title>Edition Title</title></head>
<body style="background-color: white;">
    <form id="Form1" runat="server">
        <div>
            <h1><EPiServer:Property runat="server" PropertyName="Title" /></h1>
        </div>

        <div>
            <EPiServer:Property runat="server" PropertyName="Summary" />
        </div>
    </form>
</body>
</html>