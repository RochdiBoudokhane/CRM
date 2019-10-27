using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class ClaimConfiguration : EntityTypeConfiguration<Claim>
    {

        public ClaimConfiguration()
        {

        }
    }
}
