namespace ForumSystem.Web.Controllers
{
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesService votesService;
        private readonly UserManager<ApplicationUser> usermanager;

        public VotesController(IVotesService votesService, UserManager<ApplicationUser> userManager)
        {
            this.votesService = votesService;
            this.usermanager = userManager;
        }

        // Post /api/votes
        // Request Body {"postId":1, "isUpVote":true}
        // Response Body {"votesCount":16}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> VotePost(VoteInputModel input)
        {
            var user = await this.usermanager.GetUserAsync(this.User);
            await this.votesService.VoteAsync(input.PostId, user.Id, input.IsUpVote);

            var votes = new VoteResponseModel()
            {
                VotesCount = this.votesService.GetVotes(input.PostId),
            };

            return votes;
        }
    }
}
