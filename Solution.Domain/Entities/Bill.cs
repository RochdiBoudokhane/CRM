using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime DateCreated { get; set; }
        public int State { get; set; }
    }
}
