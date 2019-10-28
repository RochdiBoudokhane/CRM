using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumCRM> ForumList { get; set; }
    }
}