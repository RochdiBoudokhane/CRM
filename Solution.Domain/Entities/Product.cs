using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public  class Product
    {
        public int ProductId { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public float Price { get; set; }
        public String ImageUrl { get; set; }
        public long Quantity { get; set; }
    }
}
