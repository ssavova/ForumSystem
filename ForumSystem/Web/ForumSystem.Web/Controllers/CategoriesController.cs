namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 2;

        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postService;

        public CategoriesController(ICategoriesService categoriesService, IPostsService postService)
        {
            this.categoriesService = categoriesService;
            this.postService = postService;
        }

        public IActionResult ByName(string name, int page = 1)
        {
            var viewModel = this.categoriesService.GetCategoryByName<CategoryViewModel>(name);
            viewModel.ForumPosts = this.postService.GetByCategoryId<PostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);

            int count = this.postService.GetCountInCategory(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page; 

            return this.View(viewModel);
        }
    }
}
