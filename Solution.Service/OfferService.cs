using Service.Pattern;
using Solution.Data;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class OfferService : Service<Offer>, IOfferService
    {
        private MyContext db = new MyContext();
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public OfferService() : base(UTK)
        {

        }
        public IEnumerable<Offer> GetProductByOffer(int IdOffer)
        {
            return GetMany(o => o.OfferId == IdOffer);
           

        }
        public List<Product> GetTtireId()
        {
            return db.Products.ToList();

        }
    }
}
