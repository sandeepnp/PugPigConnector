<%@ Page Language="c#" Inherits="Connector.Views.Pages.NovartisStartPageTemplate" CodeBehind="NovartisStartPageTemplate.aspx.cs" %>

<!DOCTYPE html>
<html>
    <head id="Head1" runat="server">
        <title>Hero Sidebar</title>
        <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <!-- To get rid of the URL and button bars -->
        <meta name="apple-mobile-web-app-capable" content="yes" />
        <!-- Status Bar Style (default, black, black-translucent) -->
        <meta name="apple-mobile-web-app-status-bar-style" content="black" />
        <link rel="stylesheet" type="text/css" href="/css/start-page.css" />
        <meta name="callbackWhenSnapshotFinished" content="IND.init" />
        <script src="/js/jquery.js"></script>
        <link rel="stylesheet" href="/isotope/css/style.css" />
        <script type="text/javascript">
         window.IND = {};
        </script>
    </head>
 
   <body class="startbg news">
    <header>
      <h1>Start screen with Key message or opening statement</h1>
    </header>
    <div class="clearfix"></div>  
    <div id="container">
  
  <section class="news">
    <a href="/New-Edition-List/Novartis/Scrolling-Large-Image">
      <img src="/img/start1.jpg">
      <p class="cat">Health article</p>
    </a>
  </section>
  
  <section class="news right">
    <a href="/New-Edition-List/Novartis/Segmented-Columned">
      <img src="/img/start2.jpg">
      <p class="cat">Patient case study</p>
    </a>
  </section>
  
  <section class="news">
    <a href="/New-Edition-List/Novartis/Scrolling-Hero-Sidebar">
      <img src="/img/start3.jpg">
      <p class="cat">Patient follow up</p>
    </a>
  </section>
  
  <section class="news right">
    <a href="/New-Edition-List/Novartis/Scrolling-Hero-Sidebar">
      <img src="/img/start4.jpg">
      <p class="cat">Industry news</p>
    </a>
  </section>
  
  </div>  
    <script src="/isotope/jquery.isotope.min.js"></script>
    <script>
    $(window).load(function () {

        IND.init = function () {

            var $container = $('#container');

            $container.isotope({
                masonry: {
                    //columnWidth: 90
                }
            });

            var $optionSets = $('#options .option-set'),
            $optionLinks = $optionSets.find('a');

            $optionLinks.click(function () {
                var $this = $(this);
                // don't proceed if already selected
                if ($this.hasClass('selected')) {
                    return false;
                }
                var $optionSet = $this.parents('.option-set');
                $optionSet.find('.selected').removeClass('selected');
                $this.addClass('selected');

                // make option object dynamically, i.e. { filter: '.my-filter-class' }
                var options = {},
                    key = $optionSet.attr('data-option-key'),
                    value = $this.attr('data-option-value');
                // parse 'false' as false boolean
                value = value === 'false' ? false : value;
                options[key] = value;
                if (key === 'layoutMode' && typeof changeLayoutMode === 'function') {
                    // changes in layout modes need extra logic
                    changeLayoutMode($this, options)
                } else {
                    // otherwise, apply new options
                    $container.isotope(options);
                }

                return false;
            });


            function relayoutGrid() {
                var $container = $('#container');
                $container.isotope('reLayout');
            }

            $(window).on('orientationchange', relayoutGrid);

        }

    });

</script>
   </body>

</html> 