using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class PostTopicModel
    {
        public PostCRM Post { get; set; }
        public IEnumerable<PostReplyCRM> PostReplies { get; set; }
    }
}