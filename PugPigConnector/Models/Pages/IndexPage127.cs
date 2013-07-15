using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "Index Page", Description = "Article List Page")]
    public class IndexPage127 : PageData
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

        
        [Display(Name = "Figure",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual ContentArea Figure { get; set; }

        [Required]
        [Display(Name = "Article  List",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 4)]
        public virtual ContentArea ArticleList { get; set; }
    }
}