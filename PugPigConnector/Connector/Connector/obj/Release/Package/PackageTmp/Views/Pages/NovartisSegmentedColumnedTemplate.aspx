<%@ Page Language="c#" Inherits="Connector.Views.Pages.NovartisSegmentedColumnedTemplate" CodeBehind="NovartisSegmentedColumnedTemplate.aspx.cs" %>

<!DOCTYPE html>
<html>

    <head id="Head1" runat="server">
      <title>Segmented columned</title>
      <meta name="viewport" content="user-scalable=no, initial-scale=1.0, maximum-scale=1.0" />
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <!-- To get rid of the URL and button bars -->
      <meta name="apple-mobile-web-app-capable" content="yes" />
      <!-- Status Bar Style (default, black, black-translucent) -->
      <meta name="apple-mobile-web-app-status-bar-style" content="black" />
      <link rel="stylesheet" type="text/css" href="/css/segmented-columned.css" />
    </head>

<body class="section-a">
  <header>
    <EPiServer:Property ID="Header" CustomTagName="h1" PropertyName="Header" runat="server" /> <!--News-->
  </header>
  
  <article>
  
    <section class="image_wrap">
      <header>
        <EPiServer:Property ID="Header2" CustomTagName="h1" PropertyName="Header2" runat="server" />
        <!--<h1>Multiple articles with small amount of copy, split into two short columns</h1>-->
        <p class="byline">By George Author</p>
      </header>
    </section>
	
    <section class="copy">
      <EPiServer:Property ID="ParagraphText" CustomTagName="p" PropertyName="ParagraphText" runat="server" />
      <!--<p>Lorizzle ipsizzle dolizzle sizzle amet, consectetuer adipiscing fo shizzle my nizzle. Nullizzle crazy velizzle, you son of a bizzle volutpizzle, suscipit quizzle, gravida vizzle, we gonna chung. Pellentesque funky fresh tortor. Sizzle erizzle. Yo at dolizzle boom shackalack turpis tempizzle izzle. Crazy pellentesque ass that's the shizzle fo shizzle. Bow wow wow in yo. Pellentesque eleifend rhoncizzle nisi. Stuff hac habitasse yo mamma dictumst. Crackalackin dapibus. You son of a bizzle yippiyo urna, pretizzle eu, fo shizzle ac, eleifend vitae, uhuh ... yih!. Sheezy suscipizzle. Integer sempizzle velit sed fizzle. Stuff hac habitasse yo mamma dictumst. Crackalackin dapibus. You son of a bizzle yippiyo urna, pretizzle eu, fo shizzle ac, eleifend vitae, uhuh ... yih!. Sheezy suscipizzle. Integer sempizzle velit sed fizzle.</p>-->
    </section>
      <figure> 
         <img src="/img/a2.jpg" />
      </figure>
	  
    <section class="copy">
      <p>Sed porttitor tellus non condimentum laoreet. In nisl lacus, posuere ac ornare sed, pellentesque in turpis. Sed in tincidunt eros, ut fermentum neque. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ornare pellentesque convallis. Nunc vitae viverra eros. In in rutrum eros, sit amet dapibus erat. Quisque id tellus mi. Integer ultricies sapien neque, at ullamcorper erat accumsan vitae. Nam lacinia viverra bibendum. Quisque ornare sapien in imperdiet molestie. In eget dapibus magna.</p>
    </section>
      <figure> 
         <img src="/img/a1.jpg" />
      </figure>
	  
    <section class="copy">
      <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas risus ligula, lobortis quis iaculis vitae, adipiscing sagittis eros. Sed eu tempor metus. Integer fermentum eget tortor at rutrum. Phasellus mi velit, dapibus vitae euismod sed, vulputate ac libero. Morbi tempus tempus justo vitae tristique. Donec lacinia magna lacus, at scelerisque augue blandit dignissim. Integer at imperdiet magna. Nunc nec odio arcu. Maecenas nulla massa, dapibus nec posuere non, adipiscing quis leo. Morbi sollicitudin ligula elit, id accumsan nulla egestas sed. Sed est augue, rhoncus ut vehicula nec, aliquet eget urna. Maecenas vehicula pretium sagittis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur felis turpis, feugiat mattis placerat nec, vestibulum et eros. Aliquam pellentesque interdum orci eu volutpat. Cras pellentesque ac diam non dignissim.</p>
      <p>Maecenas izzle dizzle. Nizzle erizzle. Go to hizzle condimentizzle, turpis nizzle yo consectetizzle, metus libero consequat mofo, ass ullamcorpizzle you son of a bizzle mi nizzle quizzle. Cool faucibizzle dizzle. Duis ghetto for sure, shizznit shut the shizzle up, for sure pimpin', porttitizzle bizzle, tellus. Prizzle sed urna. Break it down bizzle mi in rizzle. Hizzle hendrerizzle euismizzle felis. Shizzle my nizzle crocodizzle ultrices crackalackin phat ass. Etizzle posuere lacinia mi. Ut mauris. Check it out nisl fo shizzle, euismizzle stuff, eleifend sizzle, malesuada dang, nisi. Dawg stuff dizzle nisl.</p>
    </section>
      <figure class="left"> 
         <img src="/img/a2.jpg" />
      </figure>
	  
    <section class="copy">
      <p>Sed porttitor tellus non condimentum laoreet. In nisl lacus, posuere ac ornare sed, pellentesque in turpis. Sed in tincidunt eros, ut fermentum neque. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ornare pellentesque convallis. Nunc vitae viverra eros. In in rutrum eros, sit amet dapibus erat. Quisque id tellus mi. Integer ultricies sapien neque, at ullamcorper erat accumsan vitae. Nam lacinia viverra bibendum. Quisque ornare sapien in imperdiet molestie. In eget dapibus magna.</p>
    </section>
      <figure class="left"> 
         <img src="/img/a3.jpg" />
      </figure>
	  
    <section class="copy">
      <p>Phasellus congue felis a eleifend ultrices. Pellentesque vitae justo neque. Vestibulum ultricies massa id nibh egestas, non faucibus urna dignissim. Fusce justo nisi, scelerisque id sapien in, porta vulputate lorem. Nullam luctus quis leo nec fringilla. Integer porta faucibus varius. In mauris erat, laoreet quis scelerisque et, laoreet sed turpis. Integer odio nibh, ultrices ut volutpat quis, luctus eget felis. Nullam vehicula risus lacinia augue elementum mattis. Quisque nec mollis velit.</p>
    </section>
      <figure> 
         <img src="/img/a1.jpg" />
      </figure>
	  
  </article>
</body>



</html> 