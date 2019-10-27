using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class ProductConfiguration:EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            //onetomany 0..1 -> *
          //  HasOptional(p => p.Category).WithMany(c => c.Products).         //Product * 0..1 Category
               // HasForeignKey(p => p.CategoryId).WillCascadeOnDelete(false);
            //onetomany 1..1 -> *
            /* HasRequired(p => p.Category).WithMany(c => c.Products).         //Product * 1..1 Category
                 HasForeignKey(p => p.CategoryId).WillCascadeOnDelete(false);*/

            //manytomany
           // HasMany(p => p.Providers).WithMany(p => p.Products).
             //   Map(t => {
                //    t.ToTable("Providings"); //class d'associations Providings
                //    t.MapRightKey("Product"); //table courant nom attribut
                 //   t.MapLeftKey("Provider");
             //   });
            //Heritage :TPH table par hierarchie
            /* Map<Chemical>(p => p.Requires("IsBiological").HasValue(0));
             Map<Biological>(p => p.Requires("IsBiological").HasValue(1));*/

        }
    
}
}
