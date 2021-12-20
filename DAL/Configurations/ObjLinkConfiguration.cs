﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class ObjLinkConfiguration : IEntityTypeConfiguration<ObjLink>
    {
        public void Configure(EntityTypeBuilder<ObjLink> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
