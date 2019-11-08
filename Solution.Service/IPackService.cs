using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface IPackService : IService<Pack>
    {
        IEnumerable<Pack> GetProductByPack(int IdOffer);
        List<Pack> GetPacksearch(string search, string date);
    }
    
}
