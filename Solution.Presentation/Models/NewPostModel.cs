using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class NewPostModel
    {
        [Key]
        public int PostId { get; set; }
        public String ForumTitle { get; set; }
        public int ForumId { get; set; }
        public String ForumImageUrl { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}