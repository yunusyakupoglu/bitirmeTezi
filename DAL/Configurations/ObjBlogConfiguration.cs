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
    public class ObjBlogConfiguration : IEntityTypeConfiguration<ObjBlog>
    {
        public void Configure(EntityTypeBuilder<ObjBlog> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnType("Date").HasDefaultValueSql("getDate()");
            builder.Property(x => x.ImagePath).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
