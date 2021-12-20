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
    public class ObjDocumentaryConfiguration : IEntityTypeConfiguration<ObjDocumentary>
    {
        public void Configure(EntityTypeBuilder<ObjDocumentary> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.VideoPath).IsRequired();
            builder.Property(x => x.Status).IsRequired();

        }
    }
}
