using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Order
    {
        [Key,Column(Order=0)]
        public int ProductId { get; set; }
        [Key, Column(Order = 1)]
        public int CustomerId { get; set; }

        [Key, Column(Order = 2)]
        public DateTime Dateres { get; set; }
        public int Quantity { get; set; }
        
        //prop de navig
        [ForeignKey("ProductId")]
        public virtual Product Product{ get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
