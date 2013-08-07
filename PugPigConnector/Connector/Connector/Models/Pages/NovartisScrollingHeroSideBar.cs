using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Connector.Models.Pages
{
    [ContentType(DisplayName = "Novartis Scrolling Hero SideBar", Description = "Novartis Scrolling Hero SideBar")]
    public class NovartisScrollingHeroSideBar : PageData
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
        [Display(Name = "Header",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual string Header { get; set; }

        [Required]
        [Display(Name = "Header2",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 4)]
        public virtual string Header2 { get; set; }

        [Required]
        [Display(Name = "Paragraph Text",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 5)]
        public virtual string ParagraphText { get; set; }
    }   
}
