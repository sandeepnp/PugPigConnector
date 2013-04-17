using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PugPigConnector.Models.Blocks
{
    [ContentType(DisplayName = "ArticleListItem2BlockType")]
    public class ArticleListItem2BlockType : BlockData
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
        [Display(Name = "Article Page Link",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual PageReference ArticlePageLink { get; set; }
    }
}