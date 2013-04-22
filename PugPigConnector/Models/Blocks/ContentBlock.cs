using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace PugPigConnector.Models.Blocks
{
    [ContentType(DisplayName = "Content Block", Description = "")]
    public class ContentBlock : BlockData
    {
        [Required]
        [Display(Name = "Body Content",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString BodyContent { get; set; }
    }
}