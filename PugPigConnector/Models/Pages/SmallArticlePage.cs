using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "SmallArticlePage", GUID = "34a0244e-5ee1-44dc-9bcf-d86469e9e0a5", Description = "")]
    public class SmallArticlePage : PageData
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