﻿<%@ Page Language="c#" Inherits="PugPigConnector.Views.Pages.NovartisScrollingHeroSideBarTemplate" CodeBehind="NovartisScrollingHeroSideBarTemplate.aspx.cs" %>

<!DOCTYPE html>
<html manifest="/page.manifest?pageId=<%= CurrentPage.PageLink %>">

    <head id="Head1" runat="server">
      <title>Segmented columned</title>
      <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <!-- To get rid of the URL and button bars -->
      <meta name="apple-mobile-web-app-capable" content="yes" />
      <!-- Status Bar Style (default, black, black-translucent) -->
      <meta name="apple-mobile-web-app-status-bar-style" content="black" />
      <link rel="stylesheet" type="text/css" href="/css/scrolling-hero-sidebar.css" />
    </head>

<body class="section-a">
  <header>
    <EPiServer:Property ID="Header" CustomTagName="h1" PropertyName="Header" runat="server" />
  </header>
  <article>
    <figure>
       <div><img src="/img/a4.jpg" /></div>
    </figure>
    <section class="copy">
      <EPiServer:Property ID="Header2" CustomTagName="h1" PropertyName="Header2" runat="server" />
      <EPiServer:Property ID="ParagraphText" CustomTagName="p" PropertyName="ParagraphText" runat="server" />
      <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas risus ligula, lobortis quis iaculis vitae, adipiscing sagittis eros. Sed eu tempor metus. Integer fermentum eget tortor at rutrum. Phasellus mi velit, dapibus vitae euismod sed, vulputate ac libero. Morbi tempus tempus justo vitae tristique. Donec lacinia magna lacus, at scelerisque augue blandit dignissim. Integer at imperdiet magna. Nunc nec odio arcu. Maecenas nulla massa, dapibus nec posuere non, adipiscing quis leo. Morbi sollicitudin ligula elit, id accumsan nulla egestas sed. Sed est augue, rhoncus ut vehicula nec, aliquet eget urna. Maecenas vehicula pretium sagittis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur felis turpis, feugiat mattis placerat nec, vestibulum et eros. Aliquam pellentesque interdum orci eu volutpat. Cras pellentesque ac diam non dignissim.</p>
      <p>Maecenas mollis, massa quis faucibus congue, lectus eros laoreet arcu, in rhoncus odio neque et purus. Nulla sollicitudin sed sem sed mollis. Nunc pellentesque sed nulla a viverra. Integer at iaculis justo. Vestibulum faucibus augue id ultrices vestibulum. Donec ultricies aliquam leo, eu volutpat nisl. Sed augue dolor, laoreet non diam in, sodales bibendum nisl. Sed non sapien nec metus auctor viverra. Praesent tortor mauris, gravida ac tortor non, bibendum pharetra libero. Sed pharetra diam nec dolor fringilla, eu tincidunt velit aliquam. Praesent id libero a orci pulvinar ultricies at non risus. Sed tristique sed enim a mattis. Vivamus in feugiat nisi, malesuada auctor felis. Aliquam sollicitudin, nisi nec scelerisque molestie, dolor neque placerat magna, sed ultrices orci turpis at enim. Cras adipiscing mollis placerat.</p>
      <p>Sed porttitor tellus non condimentum laoreet. In nisl lacus, posuere ac ornare sed, pellentesque in turpis. Sed in tincidunt eros, ut fermentum neque. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ornare pellentesque convallis. Nunc vitae viverra eros. In in rutrum eros, sit amet dapibus erat. Quisque id tellus mi. Integer ultricies sapien neque, at ullamcorper erat accumsan vitae. Nam lacinia viverra bibendum. Quisque ornare sapien in imperdiet molestie. In eget dapibus magna.</p>
      <p>Phasellus congue felis a eleifend ultrices. Pellentesque vitae justo neque. Vestibulum ultricies massa id nibh egestas, non faucibus urna dignissim. Fusce justo nisi, scelerisque id sapien in, porta vulputate lorem. Nullam luctus quis leo nec fringilla. Integer porta faucibus varius. In mauris erat, laoreet quis scelerisque et, laoreet sed turpis. Integer odio nibh, ultrices ut volutpat quis, luctus eget felis. Nullam vehicula risus lacinia augue elementum mattis. Quisque nec mollis velit.</p>
      <p>Pellentesque feugiat nibh at velit interdum, eget condimentum tellus cursus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus tristique erat quis neque rhoncus tempus. Nullam ante nisl, iaculis non vulputate quis, vulputate nec nisi. Duis vehicula leo et eros tristique auctor. Integer quis enim lectus. Mauris vitae ante interdum, mattis nisi sed, pellentesque turpis. Donec non enim consectetur, sollicitudin lacus et, sodales augue. Ut in lacus et dui volutpat sodales vehicula a tortor. Pellentesque vestibulum ultrices eros.</p>
    </section>
    <aside>
      <figure>
        <div><img src="/img/article-d1.jpg" /></div>
      </figure>
      <h2>Sidebar headline</h2>
      <p>Sed porttitor tellus non condimentum laoreet. In nisl lacus, posuere ac ornare sed, pellentesque in turpis. Sed in tincidunt eros, ut fermentum neque. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ornare pellentesque convallis. Nunc vitae viverra eros. In in rutrum eros, sit amet dapibus erat. Quisque id tellus mi. Integer ultricies sapien neque, at ullamcorper erat accumsan vitae. Nam lacinia viverra bibendum. Quisque ornare sapien in imperdiet molestie. In eget dapibus magna.</p>s
      <p>Phasellus congue felis a eleifend ultrices. Pellentesque vitae justo neque. Vestibulum ultricies massa id nibh egestas, non faucibus urna dignissim. Fusce justo nisi, scelerisque id sapien in, porta vulputate lorem. Nullam luctus quis leo nec fringilla. Integer porta faucibus varius. In mauris erat, laoreet quis scelerisque et, laoreet sed turpis. Integer odio nibh, ultrices ut volutpat quis, luctus eget felis. Nullam vehicula risus lacinia augue elementum mattis. Quisque nec mollis velit.</p>
      <p>Pellentesque feugiat nibh at velit interdum, eget condimentum tellus cursus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus tristique erat quis neque rhoncus tempus. Nullam ante nisl, iaculis non vulputate quis, vulputate nec nisi. Duis vehicula leo et eros tristique auctor. Integer quis enim lectus. Mauris vitae ante interdum, mattis nisi sed, pellentesque turpis. Donec non enim consectetur, sollicitudin lacus et, sodales augue. Ut in lacus et dui volutpat sodales vehicula a tortor. Pellentesque vestibulum ultrices eros.</p>
    </aside>
  </article>
</body>



</html> 