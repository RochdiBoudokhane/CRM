using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class OrderVm
    {
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        [Key, Column(Order = 1)]
        public int CustomerId { get; set; }

        [Key, Column(Order = 2)]
        [DataType(DataType.Date)]
        public DateTime Dateres { get; set; }
        public int Quantity { get; set; }
    }
}