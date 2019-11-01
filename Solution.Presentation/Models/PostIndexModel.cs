using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class PostIndexModel
    {
        public IEnumerable<PostCRM> PostList { get; set; }
    }
}
