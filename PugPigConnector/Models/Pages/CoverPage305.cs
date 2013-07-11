using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "CoverPage305", GUID = "c1eea468-e466-4385-a244-068a07fab1e1", Description = "")]
    public class CoverPage305 : PageData
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

        //[Required]
        //[Display(Name = "Articles Area",
        //         Description = "",
        //         GroupName = SystemTabNames.Content,
        //         Order = 3)]
        //public virtual ContentArea ArticlesArea { get; set; }
    }
}