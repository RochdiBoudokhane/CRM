using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
        public virtual User User { get; set; }
        public int? ForumId { get; set; }
        [ForeignKey("ForumId")]
        public virtual Forum Forum { get; set; }
        public virtual ICollection<PostReply> Replies { get; set; }
    }
}
