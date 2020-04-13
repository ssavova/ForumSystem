using ForumSystem.Data.Models;
using ForumSystem.Services.Mapping;
using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumSystem.Web.ViewModels.Posts
{
    public class PostCommentsViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}
