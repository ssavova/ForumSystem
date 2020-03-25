namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class PostsController : Controller
    {
        private readonly IPostsService postsService;

        private readonly UserManager<ApplicationUser> userManager;

        public PostsController( UserManager<ApplicationUser> userManager, IPostsService postsService)
        {
            this.postsService = postsService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult ById(int id)
        {
            //TO DO.....
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var postId = await this.postsService.CreateAsync(input.Title, input.Content, input.CategoryId, user.Id);
            return this.RedirectToAction("ById", new { id = postId });
        }
    }
}
