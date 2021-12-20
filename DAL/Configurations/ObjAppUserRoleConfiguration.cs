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
    public class ObjAppUserRoleConfiguration : IEntityTypeConfiguration<ObjAppUserRole>
    {
        public void Configure(EntityTypeBuilder<ObjAppUserRole> builder)
        {
            builder.HasIndex(x => new
            {
                x.AppRoleId,
                x.AppUserId
            }).IsUnique();

            builder.HasOne(x => x.ObjAppRole).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppRoleId);
            builder.HasOne(x => x.ObjAppUser).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppUserId);
        }
    }
}
