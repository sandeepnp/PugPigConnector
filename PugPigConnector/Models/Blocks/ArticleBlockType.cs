using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PugPigConnector.Models.Blocks
{
    [ContentType(DisplayName = "ArticleBlockType", GUID = "dae02435-7459-42e2-8bf4-c0253d162749", Description = "")]
    public class ArticleBlockType : BlockData
    {
        [Required]
        [Display(Name = "Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string Title { get; set; }

        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 2)]
        public virtual Url Image { get; set; }

        [Required]
        [Display(Name = "Body Content",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual XhtmlString BodyContent { get; set; }

        [Required]
        [Display(Name = "Body Style",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 4)]
        public virtual string BodyStyle { get; set; }
    }
}