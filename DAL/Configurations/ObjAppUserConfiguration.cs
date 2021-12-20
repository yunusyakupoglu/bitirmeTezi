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
    public class ObjAppUserConfiguration : IEntityTypeConfiguration<ObjAppUser>
    {
        public void Configure(EntityTypeBuilder<ObjAppUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.SurName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(300).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
