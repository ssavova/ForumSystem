using ForumSystem.Data.Models;
using ForumSystem.Services.Data;
using ForumSystem.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumSystem.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService service;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(ICommentsService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentInputModel input)
        {
            int? parentId = input.ParentId == 0 ? (int?)null : input.ParentId;

            if (parentId.HasValue)
            {
                if (!this.service.IsInPostId(parentId.Value, input.PostId))
                {
                    return this.BadRequest();
                }
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.service.Create(input.PostId, userId, input.Content, parentId);
            return this.RedirectToAction("ById", "Posts", new { id = input.PostId });
        }
    }
}
