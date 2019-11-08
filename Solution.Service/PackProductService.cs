using Service.Pattern;
using Solution.Data;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class PackProductService :Service<PackProduct>, IPackProductService
    {
        private MyContext db = new MyContext();
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public PackProductService() : base(UTK)
        {

        }

        public IEnumerable<PackProduct> GetPackProductByProduct(int IdProduct)
        {
            return GetMany(o => o.ProductId == IdProduct);
        }
        public IEnumerable<PackProduct> GetPackProductByPack(int IdPack)
        {
            return GetMany(o => o.PackId == IdPack);
        }
    }
}
