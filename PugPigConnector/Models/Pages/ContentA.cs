using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "ContentA", Description = "")]
    public class ContentA : PageData
    {
        [Required]
        [Display(Name = "Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string Title { get; set; }

        [Required]
        [Display(Name = "Body Content",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString BodyContent { get; set; }

        [Required]
        [Display(Name = "Page Summary",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual string Summary { get; set; }
    }
}