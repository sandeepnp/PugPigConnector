using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using EPiServer.Web.WebControls;
using PugPigConnector.Models.Pages;

namespace PugPigConnector.Views.Pages
{
    public partial class ProductPageTemplate : SiteTemplatePage<ProductPage>
    {
        //protected override void OnLoad(System.EventArgs e)
        //{
        //    base.OnLoad(e);

        //    // List of unique selling points should have styling based on the current product's theme

        //    var productThemeCssClasses = string.Concat(string.Join(" ", CurrentPage.GetThemeCssClassNames()), " ", UniqueSellingPointsContainer.Attributes["class"]); // Append theme class to any existing CSS classes
        //    UniqueSellingPointsContainer.Attributes["class"] = productThemeCssClasses;
        //}
    }
}