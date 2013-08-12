<%@ Page Language="c#" Inherits="Connector.Views.Pages.Edition" CodeBehind="Edition.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Edition Page</title>
         <script type="text/javascript" src="/js/jquery.js"></script>

         <script type="text/javascript">             
             var transactions = (function ($) {
                 "use strict";
                 var my = {},
                     that = {};

                 my.publishClick = function () {                     
                     my.$messageArea.text("Publishing...");
                     my.isStillRetriving = setInterval(my.retrievingTicker, 500);
                 };

                 my.retrievingTicker = function () {
                     var waitMessage = my.$messageArea.text();
                     if (my.$messageArea.text().length > 13) {
                         my.$messageArea.text(waitMessage.slice(0, 10));
                     } else {
                         my.$messageArea.text(waitMessage + ".");
                     }
                 };

                 that.init = function ($container) {
                     my.$publish = $container.find("#publish")
                                             .click(my.publishClick);
                     my.$messageArea = $container.find("p");                     
                 };
                 return that;
             }(jQuery));
             $(function () {
                 "use strict";
                 transactions.init($("#message"));
             });
         </script>

    </head>
    <body>
        <form id="form" runat="server">    
          <div id="message">       
            <asp:Button ID="publishButton" Text="Publish this edition" OnClick="publishButton_Click" runat="server" />                      
            <input type="button" id="publish" value="Publish"/><p></p>                     
            <asp:Label ID="publishLabel" Text="" runat="server" Visible="false" />
          </div>
        </form>
    </body>
</html>