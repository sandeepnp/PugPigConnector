using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PugPigConnector.Models.Blocks
{
    [ContentType(DisplayName = "ArticleListItemBlockType", GUID = "378dd0dc-3306-4ebb-8b78-8e1595bbdf3b", Description = "")]
    public class ArticleListItemBlockType : BlockData
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
        [Display(Name = "Article Page Link",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 4)]
        public virtual PageReference ArticlePageLink { get; set; }
    }
}