using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace PugPigConnector.Models.Pages
{
    [ContentType(DisplayName = "Generic Cover Page")]
    public class GenericCoverPage : PageData
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
        [Display(Name = "Story 1 - Header",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 3)]
        public virtual string HeaderStory1 { get; set; }

        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Story 1 - Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 4)]
        public virtual Url ImageStory1 { get; set; }

        [Required]
        [Display(Name = "Story 1 - Link",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 5)]
        public virtual PageReference LinkStory1 { get; set; }

        [Required]
        [Display(Name = "Story 2 - Header",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 6)]
        public virtual string HeaderStory2 { get; set; }

        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Story 2 - Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 7)]
        public virtual Url ImageStory2 { get; set; }

        [Required]
        [Display(Name = "Story 2 - Link",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 8)]
        public virtual PageReference LinkStory2 { get; set; }

        [Required]
        [Display(Name = "Story 3 - Header",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 9)]
        public virtual string HeaderStory3 { get; set; }

        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Story 3 - Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 10)]
        public virtual Url ImageStory3 { get; set; }

        [Required]
        [Display(Name = "Story 3 - Link",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 11)]
        public virtual PageReference LinkStory3 { get; set; }

        [Required]
        [Display(Name = "Story 4 - Header",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 12)]
        public virtual string HeaderStory4 { get; set; }

        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Story 4 - Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 13)]
        public virtual Url ImageStory4 { get; set; }

        [Required]
        [Display(Name = "Story 4 - Link",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 14)]
        public virtual PageReference LinkStory4 { get; set; }

        [Required]
        [Display(Name = "Story 5 - Header",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 15)]
        public virtual string HeaderStory5 { get; set; }

        [Required]
        [UIHint(UIHint.Image)]
        [Display(Name = "Story 5 - Image",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 16)]
        public virtual Url ImageStory5 { get; set; }

        [Required]
        [Display(Name = "Story 5 - Link",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 17)]
        public virtual PageReference LinkStory5 { get; set; }

        [Required]
        [Display(Name = "Category List Link 1",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 18)]
        public virtual PageReference CategoryListLink1 { get; set; }

        [Required]
        [Display(Name = "Category List Link 2",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 19)]
        public virtual PageReference CategoryListLink2 { get; set; }

        [Required]
        [Display(Name = "Category List Link 3",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 20)]
        public virtual PageReference CategoryListLink3 { get; set; }

        [Required]
        [Display(Name = "Category List Link 4",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 21)]
        public virtual PageReference CategoryListLink4 { get; set; }

        [Required]
        [Display(Name = "Category List Link 5",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 22)]
        public virtual PageReference CategoryListLink5 { get; set; }

        [Required]
        [Display(Name = "Category Name 1",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 23)]
        public virtual string CategoryName1 { get; set; }

        [Required]
        [Display(Name = "Category Name 2",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 24)]
        public virtual string CategoryName2 { get; set; }

        [Required]
        [Display(Name = "Category Name 3",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 25)]
        public virtual string CategoryName3 { get; set; }

        [Required]
        [Display(Name = "Category Name 4",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 26)]
        public virtual string CategoryName4 { get; set; }

        [Required]
        [Display(Name = "Category Name 5",
                 Description = "",
                 GroupName = SystemTabNames.Content,
                 Order = 27)]
        public virtual string CategoryName5 { get; set; }
    }
}