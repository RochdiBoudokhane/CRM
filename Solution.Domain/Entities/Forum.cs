using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Forum
    {
        public int ForumId { get; set; }
        public string Title { get; set; }
        public string Descripition { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Post> Posts { get; set; }    
    }
}
