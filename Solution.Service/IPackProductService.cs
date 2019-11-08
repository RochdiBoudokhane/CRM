using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    interface IPackProductService : IService<PackProduct>
    {
        IEnumerable<PackProduct> GetPackProductByProduct(int IdProduct);
        IEnumerable<PackProduct> GetPackProductByPack(int IdPack);

    }
}
