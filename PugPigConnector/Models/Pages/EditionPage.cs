using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "Edition Page")]
    public class EditionPage : PageData
    {
        [Required]
        [Display(Name = "SubTitle",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string SubTitle { get; set; }
        
        [Display(Name = "Summary",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 2)]
        public virtual string Summary { get; set; }

        [Required]
        [Display(Name = "Issued",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual DateTime Issued { get; set; }

        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 4)]
        public virtual Url Image { get; set; }

        [Display(Name = "Paid For", 
                 Description = "", 
                 GroupName = SystemTabNames.Content, 
                 Order = 5)]
        public virtual Boolean PaidFor { get; set; }
    }
}