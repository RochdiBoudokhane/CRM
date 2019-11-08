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
    public class PackService : Service<Pack>, IPackService
    {
        private MyContext db = new MyContext();
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public PackService() : base(UTK)
        {

        }
        public IEnumerable<Pack> GetProductByPack(int IdPack)
        {
            return GetMany(o => o.PackId == IdPack);


        }
        public List<Product> GetTtireId()
        {
            return db.Products.ToList();

        }
        public List<Pack> GetPacksearch(string search, string date)
        {
            //DateTime dt = DateTime.ParseExact(s, "0:yyyy-MM-dd", CultureInfo.InvariantCulture);

            //DateTime date1 = DateTime.ParseExact(date,
            //              "yyyy-MM-dd", CultureInfo.InvariantCulture);/
            var students = from s in db.Packs
                           select s;
            if (!String.IsNullOrEmpty(search) && !String.IsNullOrEmpty(date))
            {

                DateTime date1 = Convert.ToDateTime(date);

                students = students.Where(s => s.Description.Contains(search)
                && s.StartDate == date1);

            }


            return students.ToList();


        }
    }
}
