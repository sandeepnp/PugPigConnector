using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using PugPigConnector.Models.Properties;

namespace PugPigConnector.Models.Pages
{
    [SiteContentType(
          GUID = "170f594c-70f7-4a2f-842c-0efb7692e04c", 
          GroupName = Global.GroupNames.Products)]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-product.png")]
    public class ProductPage : StandardPage
    {
        //[Required]
        //[BackingType(typeof(PropertyStringList))]
        //[Display(Order = 305)]
        //public virtual string[] UniqueSellingPoints { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 330)]
        [CultureSpecific]
        public virtual ContentArea RelatedContentArea { get; set; }
    }
}