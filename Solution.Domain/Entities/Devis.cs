using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Devis
    {
        public int DevisId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
