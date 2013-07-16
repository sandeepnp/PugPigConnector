using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "Novartis Content Page", Description = "Novartis Content Page")]
    public class NovartisContentPage : PageData
    {
        [Required]
        [Display(Name = "Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string Title { get; set; }

        [Required]
        [Display(Name = "Summary",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 2)]
        public virtual string Summary { get; set; }

        [Required]
        [Display(Name = "Figure",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual ContentArea Figure { get; set; }

        [Required]
        [Display(Name = "Article Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 4)]
        public virtual ContentArea ArticleTitle { get; set; }

        [Required]
        [Display(Name = "Text Content",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 5)]
        public virtual ContentArea TextContent { get; set; }
    }
}