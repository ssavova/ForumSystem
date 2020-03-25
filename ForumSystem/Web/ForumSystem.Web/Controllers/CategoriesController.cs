namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult ByName(string name)
        {
            var viewModel = this.categoriesService.GetCategoryByName<CategoryViewModel>(name);

            return this.View(viewModel);
        }
    }
}
