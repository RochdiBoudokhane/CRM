using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class ForumCRM
    {
        public int ForumId { get; set; }
        public string Title { get; set; }
        public string Descripition { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
    }
}