using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class ObjBlogAppUserStatusConfiguration : IEntityTypeConfiguration<ObjBlogAppUserStatus>
    {
        public void Configure(EntityTypeBuilder<ObjBlogAppUserStatus> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(500).IsRequired();
        }
    }
}
