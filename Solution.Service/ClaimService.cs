using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class ClaimService : Service<Claim>, IClaimService
    {
        //private readonly MyContext myContext;
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public ClaimService() : base(UTK)
        {

        }
        public IEnumerable<Claim> GetClaimByClaimId(string claimId)
        {
            return GetMany(c => c.Name.Contains(claimId));


        }
    }
}

