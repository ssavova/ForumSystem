namespace ForumSystem.Services.Data
{
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using System.Threading.Tasks;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepo)
        {
            this.postsRepository = postsRepo;
        }

        public async Task<int> CreateAsync(string title, string content, int categoryId, string userId)
        {
            var newPost = new Post()
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                UserId = userId,
            };

            await this.postsRepository.AddAsync(newPost);
            await this.postsRepository.SaveChangesAsync();

            return newPost.Id;
        }
    }
}
