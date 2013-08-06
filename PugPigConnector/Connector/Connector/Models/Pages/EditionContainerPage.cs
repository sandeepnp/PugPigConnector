using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Connector.Models.Pages
{
    [ContentType(DisplayName = "Edition Container", GUID = "f9357589-f149-43cb-af17-425bd4a020e3", Description = "Edition Container")]
    public class EditionContainerPage : PageData
    {
        [Required]
        [Display(Name = "Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string Title { get; set; }
    }
}