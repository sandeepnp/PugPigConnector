<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.NovartisContentsPageTemplate" CodeBehind="NovartisContentsPageTemplate.aspx.cs" %>

<!DOCTYPE html>
<html manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">
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
 
<body class="news">
  <header>
    <h1>Contents</h1>
  </header>
  <div class="clearfix"></div>

  <div id="options" class="clearfix">
    <div class="option-combo">
      <ul id="filter" class="option-set clearfix" data-option-key="filter">
        <li><a href="#show-all" data-option-value="*" class="selected">show all</a></li>
        <li class="news"><a href="#elements" data-option-value=".news">health article</a></li>
        <li class="politics"><a href="#features" data-option-value=".politics">case studies</a></li>
        <li class="travel"><a href="#examples" data-option-value=".travel">medical news</a></li>
      </ul>
    </div>
  </div>

  <div id="container">
    <section class="news">
    <a href="/New-Edition-List/Novartis/Segmented-Columned">
      <img src="/img/a1.jpg">
      <p class="cat">Health Article</p>
      <h1>The incredible shrinking groceries rip-off</h1>
      <p></p>
    </a>
  </section>
    <section class="news">
    <a href="/New-Edition-List/Novartis/Segmented-Columned">
      <img src="/img/a2.jpg">
      <p class="cat">Health Article</p>
      <h1>Cyprus has four days to come up with new plan, says European Central bank</h1>
    </a>
  </section>
    <section class=" news">
    <a href="/New-Edition-List/Novartis/Segmented-Columned">
      <img src="/img/a3.jpg">
      <p class="cat">Health Article</p>
      <h1>100 academics savage Education Secretary Michael Gove for 'conveyor-belt curriculum' for schools</h1>
    </a>
  </section>
    <section class="news">
    <a href="/New-Edition-List/Novartis/Segmented-Columned">
      <img src="/img/a4.jpg">
      <p class="cat">Health Article</p>
      <h1>That's reassuring: Nasa chief Charles Bolden's advice on asteroid heading for Earth - just pray</h1>
    </a>
  </section>
    <section class="news">
    <a href="/New-Edition-List/Novartis/Segmented-Columned">
      <img src="/img/article-c1.jpg">
      <p class="cat">Health Article</p>
      <h1>Jim Davidson arrested over new sexual offence claims</h1>
    </a>
  </section>
    <section class=" news"> 
    <a href="/New-Edition-List/Novartis/Segmented-Columned">
      <img src="/img/gal4.jpg">
      <p class="cat">Health Article</p>
      <h1>urying bad news on Budget day? It's bumper bonuses for Barclays fat cats</h1>
    </a>
  </section>
    <section class="politics">
    <a href="/New-Edition-List/Novartis/Scrolling-Hero-Sidebar">
      <img src="/img/article-a1.jpg">
      <p class="cat">Case Studies</p>
      <h1>Budget 2013: Last-minute cuts spare George Osborne's deficit blushes</h1>
      <p></p>
    </a>
  </section>
    <section class="politics">
    <a href="/New-Edition-List/Novartis/Scrolling-Hero-Sidebar">
      <img src="/img/article-d1.jpg">
      <p class="cat">Case Studies</p>
      <h1>Budget: Tax threshold will rise to £10,000 to 'help hard workers'</h1>
      <p></p>
    </a>
  </section>
    <section class="politics">
    <a href="/New-Edition-List/Novartis/Scrolling-Hero-Sidebar">
      <img src="/img/article-e1.jpg">
      <p class="cat">Case Studies</p>
      <h1>Budget 2013: Osborne defends his 'Drown Your Sorrows' Budget by saying things could be worse</h1>
      <p></p>
    </a>
  </section>
    <section class="travel">
    <a href="/New-Edition-List/Novartis/Scrolling-Hero-Sidebar">
      <img src="/img/a4.jpg">
      <p class="cat">Medical News</p>
      <h1>Simon Calder's Holiday Helpdesk: The allure of the Istrian peninsula in the far north-west</h1>
      <p></p>
    </a>
  </section>
    <section class=" travel">
    <a href="/New-Edition-List/Novartis/Scrolling-Large-Image">
      <img src="/img/a3.jpg">
      <p class="cat">Medical News</p>
      <h1>Shhhhh! This sounds like a nice place to visit</h1>
      <p></p>
    </a>
  </section>
    <section class="travel">
    <a href="scrolling-hero.html">
      <img src="/img/gal3.jpg">
      <p class="cat">Medical News</p>
      <h1>Tourism: The Girls girls' new TV tour</h1>
      <p></p>
    </a>
  </section>
    <section class="travel">
    <a href="/New-Edition-List/Novartis/Scrolling-Large-Image">
      <img src="/img/article-b1.jpg">
      <p class="cat">Medical News</p>
      <h1>Wet and Wild in Wales</h1>
      <p></p>
    </a>
  </section>
    <section class="wide travel">
    <a href="/New-Edition-List/Novartis/Scrolling-Large-Image">
      <img src="/img/article-a1.jpg">
      <p class="cat">Medical News</p>
      <h1>No need to fume about flight risks or budget airlines</h1>
      <p></p>
    </a>
  </section>
    <section class="travel">
    <a href="/New-Edition-List/Novartis/Scrolling-Large-Image">
      <img src="/img/article-b1.jpg">
      <p class="cat">Medical News</p>
      <h1>Colorado dreamin', in Vail</h1>
      <p></p>
    </a>
  </section>
    <section class="travel">
    <a href="/New-Edition-List/Novartis/Scrolling-Large-Image">
      <img src="/img/a1.jpg">
      <p class="cat">Medical News</p>
      <h1>My life in travel: Anthony Horowitz</h1>
      <p></p>
    </a>
  </section>
    <section class="travel">
    <a href="/New-Edition-List/Novartis/Scrolling-Large-Image">
      <img src="/img/a2.jpg">
      <p class="cat">Medical News</p>
      <h1>ATraveller's guide: The Ring of Kerry</h1>
      <p></p>
    </a>
  </section>    
  </div>

<!-- content -->
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