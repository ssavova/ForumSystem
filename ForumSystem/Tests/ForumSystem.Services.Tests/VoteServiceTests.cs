namespace ForumSystem.Services.Tests
{
    using ForumSystem.Data;
    using ForumSystem.Data.Models;
    using ForumSystem.Data.Repositories;
    using ForumSystem.Services.Data;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class VoteServiceTests
    {
        [Fact]
        public async Task TwoDownVotesShouldCountOnce()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("testVotes");

            var repository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));

            var service = new VotesService(repository);

            await service.VoteAsync(1, "1", false);
            await service.VoteAsync(1, "1", false);

            var votes = service.GetVotes(1);

            Assert.Equal(-1, votes);
        }
    }
}
