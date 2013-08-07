<%@ Page Language="c#" Inherits="Connector.Views.Pages.Edition" CodeBehind="Edition.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Edition Page</title>
    </head>
    <body>
        <form id="form" runat="server">
          <asp:Button ID="publishButton" Text="Publish this edition" OnClick="publishButton_Click" runat="server" />
          <asp:Label ID="publishLabel" Text="" runat="server" Visible="false" />
        </form>
    </body>
</html>