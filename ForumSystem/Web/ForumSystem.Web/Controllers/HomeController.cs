namespace ForumSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using ForumSystem.Data;
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels;
    using ForumSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Services.Data;

    public class HomeController : BaseController
    {

        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoryService)
        {
            this.categoriesService = categoryService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Categories = this.categoriesService.GetAll<IndexCategoryViewModel>();

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
