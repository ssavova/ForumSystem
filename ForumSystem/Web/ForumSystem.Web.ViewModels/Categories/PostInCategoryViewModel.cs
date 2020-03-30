namespace ForumSystem.Web.ViewModels.Categories
{
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    public class PostInCategoryViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content?.Length > 200
                    ? content.Substring(0, 200) + "..."
                    : content;
            }
        }
            

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }

    }
}
