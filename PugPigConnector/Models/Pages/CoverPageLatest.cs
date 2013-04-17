using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "CoverPageLatest", GUID = "c349055b-b9f8-42ae-a7d8-cddcfdedee39", Description = "")]
    public class CoverPageLatest : PageData
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
        [Display(Name = "Top Articles Area",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual ContentArea TopArticlesArea { get; set; }

        [Required]
        [Display(Name = "Article List Area",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual ContentArea ArticleListArea { get; set; }
    }
}