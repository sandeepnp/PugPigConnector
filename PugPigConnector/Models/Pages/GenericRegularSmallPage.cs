using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "Generic Regular Small Page")]
    public class GenericRegularSmallPage : PageData
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
        [UIHint(UIHint.Image)]
        [Display(Name = "Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual Url Image { get; set; }

        [Required]
        [Display(Name = "Body Content",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual XhtmlString BodyContent { get; set; }

        [Required]
        [Display(Name = "Body Style",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 5)]
        public virtual string BodyStyle { get; set; }
    }
}