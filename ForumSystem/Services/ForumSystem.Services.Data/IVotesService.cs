using System.Threading.Tasks;

namespace ForumSystem.Services.Data
{
    public interface IVotesService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <param name="isUpVote">If true - Up Vote, else - Down Vote.</param>
        /// <returns></returns>
        Task VoteAsync(int postId, string userId, bool isUpVote);

        int GetVotes(int postId);
    }
}
