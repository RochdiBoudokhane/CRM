using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class PostCRM
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
        public virtual User User { get; set; }
        public ForumCRM Forum { get; set; }
        public int RepliesCount { get; set; }
    }
}