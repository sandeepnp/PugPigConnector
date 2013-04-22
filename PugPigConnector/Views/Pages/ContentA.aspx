<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.ContentA" CodeBehind="ContentA.aspx.cs" %>

<!DOCTYPE html>
<html manifest ="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
  <head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta content="user-scalable=no, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" name="viewport" />
    <title>
      <%= CurrentPage.Title %>
    </title>
    <link rel="stylesheet" href="/css/normalize.css" type="text/css" />
    <link rel="stylesheet" href="/css/agileMkt.css" type="text/css" />
    <script type="text/javascript" src="/js/vendor/jquery-1.8.2.min.js"></script>
    <!-- Add fancyBox JS and CSS -->
	<script type="text/javascript" src="/js/vendor/jquery.fancybox.js?v=2.1.3"></script>
	<link rel="stylesheet" href="/css/jquery.fancybox.css" type="text/css" />
	<script type="text/javascript">
	    $(document).ready(function () {
	        $(".various").fancybox({
	            maxWidth: 800,
	            maxHeight: 300,
	            fitToView: false,
	            width: '70%',
	            height: '70%',
	            autoSize: false,
	            closeClick: false,
	            openEffect: 'none',
	            closeEffect: 'none'
	        });
	    });
	</script>
</head>  
    <EPiServer:Property ID="Property1"  PropertyName="BodyContent" runat="server" />
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-40182928-1', 'valtechdigital.co.uk');
        ga('send', 'pageview');

    </script>    
</html>