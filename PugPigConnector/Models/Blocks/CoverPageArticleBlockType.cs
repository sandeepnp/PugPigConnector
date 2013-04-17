using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PugPigConnector.Models.Blocks
{
    [ContentType(DisplayName = "CoverPageArticleBlockType", GUID = "94b64499-b517-4172-8af4-72bcfd33ecc1", Description = "")]
    public class CoverPageArticleBlockType : BlockData
    {
        [Required]
        [Display(Name = "Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string Title { get; set; }

        [UIHint(UIHint.Image)]
        [Display(Name = "Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 2)]
        public virtual Url Image { get; set; }

        [Display(Name = "Article Page",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual PageReference ArticlePage { get; set; }
    }
}