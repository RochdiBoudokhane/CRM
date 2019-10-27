using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public String Title { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int Type { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }

        // prop de navigation
      /*  public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("ProductFK")]
        public virtual Product Product { get; set; }*/
    }
}
