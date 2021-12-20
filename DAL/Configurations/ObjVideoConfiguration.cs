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
    public class ObjVideoConfiguration : IEntityTypeConfiguration<ObjVideo>
    {
        public void Configure(EntityTypeBuilder<ObjVideo> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.VideoPath).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
