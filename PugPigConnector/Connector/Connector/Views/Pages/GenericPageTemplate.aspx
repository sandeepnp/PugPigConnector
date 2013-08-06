<%@ Page Language="c#" Inherits="Connector.Views.Pages.GenericPageTemplate" CodeBehind="GenericPageTemplate.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>StandardPage</title>
    </head>
    <body>
        <form id="Form1" runat="server">
            <div>
                <EPiServer:Property ID="Image" runat="server" PropertyName="Image" />
            </div>
            <br />
            <div>
                <EPiServer:Property ID="Summary" runat="server" PropertyName="Summary" />
            </div>
        </form>
    </body>
</html>