using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public String Title { get; set; }
        public String Location { get; set; }

        // prop de navigation
       /* public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("ProductFK")]
        public virtual Product Product { get; set; }*/

    }
}
