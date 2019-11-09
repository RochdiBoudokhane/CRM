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
        public String Name { get; set; }
        public int NumTel { get; set; }
        public String Email { get; set; }
        public String Type { get; set; }
        public String ImageUrl { get; set; }

        public String Message { get; set; }

        public DateTime CreatedDate { get; set; }
        public int State { get; set; }

        /* [ForeignKey("UserFK")]
         public virtual User User { get; set; }*/
        public int allTimenbrReclamation()
        {
            return 2;
        }
    }
}
