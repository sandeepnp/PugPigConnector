using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "Regular Page D")]
    public class RegularPageD : PageData
    {
        [Required]
        [Display(Name = "Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string Title { get; set; }
        
        [Display(Name = "Summary",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 2)]
        public virtual string Summary { get; set; }

        [UIHint(UIHint.Image)]
        [Display(Name = "Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual Url Image { get; set; }
    }
}