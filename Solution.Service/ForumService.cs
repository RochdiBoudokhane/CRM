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
    public class ForumService:Service<Forum>, IForumService
    {
        //private readonly MyContext myContext;
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public ForumService():base(UTK)
        {

        }

        public IEnumerable<Forum> GetAll()
        {
            throw new NotImplementedException();
        }


        public Forum GetById(int IdForum)
        {
            throw new NotImplementedException();
        }

    }
}
