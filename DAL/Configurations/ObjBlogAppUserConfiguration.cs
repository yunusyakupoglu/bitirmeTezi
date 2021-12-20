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
    public class ObjBlogAppUserConfiguration : IEntityTypeConfiguration<ObjBlogAppUser>
    {
        public void Configure(EntityTypeBuilder<ObjBlogAppUser> builder)
        {
            //tekrarlı kaydın önüne geçti.
            builder.HasIndex(x => new
            {
                x.BlogId,
                x.AppUserId
            }).IsUnique();

            builder.HasOne(x => x.ObjBlogAppUserStatus).WithMany(x => x.BlogAppUsers).HasForeignKey(x => x.BlogAppUserStatusId);
            builder.HasOne(x => x.ObjAppUser).WithMany(x => x.BlogAppUsers).HasForeignKey(x => x.AppUserId);
        }
    }
}
