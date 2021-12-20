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
    public class ObjCounterConfiguration : IEntityTypeConfiguration<ObjCounter>
    {
        public void Configure(EntityTypeBuilder<ObjCounter> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
