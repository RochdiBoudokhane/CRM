using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class PostReplyConfiguration : EntityTypeConfiguration<PostReply>
    {
        public PostReplyConfiguration()
        {
              HasOptional(r => r.Post).
                WithMany(p => p.Replies).
                HasForeignKey(r => r.PostId).
                WillCascadeOnDelete(true);
        }
    }
}
