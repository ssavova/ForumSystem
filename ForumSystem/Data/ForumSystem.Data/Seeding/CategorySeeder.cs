namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)>
            { ("Sport", "https://assets.2ser.com/wp-content/aws/uploads/2017/12/28031943/academysport.jpg"),
                ("CoronaVirus", "https://kingcounty.gov/depts/health/communicable-diseases/disease-control/~/media/depts/health/communicable-diseases/images/banner-coronavirus.ashx"),
                ("News", "https://cdn.shortpixel.ai/client/q_glossy,ret_img,w_1600/https://www.abbiati.com/wp-content/uploads/2018/09/news-latest-news-business.jpg"),
                ("Music", "https://images.macrumors.com/article-new/2018/05/apple-music-note-800x420.jpg"),
                ("Programming", "https://image.shutterstock.com/image-photo/software-developer-programming-code-abstract-260nw-577183882.jpg"),
                ("Cats","https://icatcare.org/app/uploads/2018/06/Layer-1704-1920x840.jpg"),
                ("Dogs" , "https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2020/02/322868_1100-1100x628.jpg")
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Name,
                    Title = category.Name,
                    ImageUrl = category.ImageUrl,
                });
            }
        }
    }
}
