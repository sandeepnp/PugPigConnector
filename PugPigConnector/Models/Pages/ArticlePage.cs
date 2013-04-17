using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using PugPigConnector.Models.Blocks;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "ArticlePage", GUID = "95f64d6f-972a-40c6-885a-0dfb7b26e2fd", Description = "")]
    public class ArticlePage : PageData
    {
        [Required]
        [Display(Name = "Page Content Area",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual ContentArea PageContentArea { get; set; }

        [Required]
        [Display(Name = "Article Summary",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 2)]
        public virtual string Summary { get; set; }
    }
}