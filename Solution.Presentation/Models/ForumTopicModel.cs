using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class ForumTopicModel
    {
        public ForumCRM forum { get; set; }
        public IEnumerable<PostCRM> Posts { get; set; }
    }
}