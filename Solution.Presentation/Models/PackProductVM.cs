using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class PackProductVM
    {
        [Key]
        [Column(Order = 1)]
        public int PackId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        public Pack Pack { get; set; }
        public Product Product { get; set; }
    }
}