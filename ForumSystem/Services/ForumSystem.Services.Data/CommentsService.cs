namespace ForumSystem.Services.Data
{
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParrentId = parentId,
                PostId = postId,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsInPostId(int commentId, int postId)
        {
            var commentPostId = this.commentsRepository.All().Where(x => x.Id == commentId)
                .Select(p => p.PostId).FirstOrDefault();

            return commentPostId == postId;
        }
    }
}
