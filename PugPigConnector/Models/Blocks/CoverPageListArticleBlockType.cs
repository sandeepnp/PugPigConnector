using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PugPigConnector.Models.Blocks
{
    [ContentType(DisplayName = "CoverPageListArticleBlockType")]
    public class CoverPageListArticleBlockType : BlockData
    {
        [Required]
        [Display(Name = "Title",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 1)]
        public virtual string Title { get; set; }

        [Required]
        [Display(Name = "Css Class",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 2)]
        public virtual string CssClass { get; set; }

        [Display(Name = "Article Page",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual PageReference ArticlePage { get; set; }
    }
}