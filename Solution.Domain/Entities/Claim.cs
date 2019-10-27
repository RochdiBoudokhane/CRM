using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Claim
    {
        public int ClaimId { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public String Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int State { get; set; }

       /* [ForeignKey("UserFK")]
        public virtual User User { get; set; }*/
    }
}
