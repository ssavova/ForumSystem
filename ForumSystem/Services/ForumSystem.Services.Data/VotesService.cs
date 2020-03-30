namespace ForumSystem.Services.Data
{
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepo;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepo = votesRepository;
        }

        public int GetVotes(int postId)
        {
            return this.votesRepo.All().Where(v => v.PostId == postId).Sum(v => (int)v.Type);
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = this.votesRepo.All().FirstOrDefault(v => v.PostId == postId && v.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = postId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepo.AddAsync(vote);
            }

            await this.votesRepo.SaveChangesAsync();
        }
    }
}
