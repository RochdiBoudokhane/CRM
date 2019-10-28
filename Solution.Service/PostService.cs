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
    public class PostService:Service<Post>, IPostService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public PostService():base(UTK)
        {

        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Post> IPostService.GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Post> IPostService.GetPostsByForum(int id)
        {
            return GetMany(f => f.PostId == id);
        }
    }
}
