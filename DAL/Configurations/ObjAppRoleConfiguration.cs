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
    public class ObjAppRoleConfiguration : IEntityTypeConfiguration<ObjAppRole>
    {
        public void Configure(EntityTypeBuilder<ObjAppRole> builder)
        {
            builder.Property(x => x.Definition).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.HasData(new ObjAppRole[]
            {
                new()
                {
                    Definition="SuperAdmin",
                    Id=1,
                },
                new()
                {
                    Definition="Admin",
                    Id=2,
                },
                new()
                {
                    Definition="Member",
                    Id=3
                }

            });
        }
    }
}
