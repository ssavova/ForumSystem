namespace ForumSystem.Services.Data
{
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using System.Collections.Generic;
    using System.Linq;
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

        public IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0)
        {
            var query = this.postsRepository.All()
                .OrderByDescending(p => p.CreatedOn)
                .Where(c => c.CategoryId == categoryId).Skip(0);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var post = this.postsRepository.All().Where(p => p.Id == id)
               .To<T>().FirstOrDefault();

            return post;
        }

        public int GetCountInCategory(int categoryId)
        {
            return this.postsRepository.All().Count(c => c.Id == categoryId);
        }
    }
}
