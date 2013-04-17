using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using PugPigConnector.Models.Blocks;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "ArticleListPage")]
    public class ArticleListPage : PageData
    {
        [Required]
        [Display(Name = "Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string Title { get; set; }

        [Required]
        [Display(Name = "Article Summary",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 2)]
        public virtual string Summary { get; set; }

        [Required]
        [Display(Name = "Body Style",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual string BodyStyle { get; set; }

        [Required]
        [Display(Name = "Upper Page Content Area",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 4)]
        public virtual ContentArea UpperPageContentArea { get; set; }

        [Required]
        [Display(Name = "Lower Page Content Area",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 5)]
        public virtual ContentArea LowerPageContentArea { get; set; }

    }
}