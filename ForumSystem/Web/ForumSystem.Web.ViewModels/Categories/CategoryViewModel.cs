﻿namespace ForumSystem.Web.ViewModels.Categories
{
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using System.Collections.Generic;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<PostInCategoryViewModel> ForumPosts { get; set; }
    }
}
