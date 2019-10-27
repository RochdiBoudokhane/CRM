using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class PostReplyCRM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
        public virtual User User { get; set; }
        public int? PostId { get; set; }
    }
}