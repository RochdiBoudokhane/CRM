using Solution.Data.Configurations;
using Solution.Data.CustomConventions;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext:DbContext
    {
        public MyContext():base("name=CRM")
        {

        }
        //DbSet<> ...
        public DbSet<Product> Products { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReply> PostReplies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Devis> Devis { get; set; }
        public DbSet<Bill> Bills { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // config + customConventions
            /*modelBuilder.Configurations.Add(.....);
            modelBuilder.Conventions.Add(....);*/
            modelBuilder.Conventions.Add(new DateTime2Convention());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new PostReplyConfiguration());

        }
    }
}
