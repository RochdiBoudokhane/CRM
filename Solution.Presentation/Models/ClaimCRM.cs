using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class ClaimCRM
    {
        [Key]
        public int ClaimId { get; set; }
        public String Name { get; set; }
        public int NumTel { get; set; }
        public String Email { get; set; }
        public String ImageUrl { get; set; }
        
        public String Type { get; set; }
        public String Message { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public int State { get; set; }

    }
}