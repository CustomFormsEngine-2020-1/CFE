﻿using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class AttributeConfiguration : IEntityTypeConfiguration<CFE.Entities.Models.Attribute>
    {
        public void Configure(EntityTypeBuilder<CFE.Entities.Models.Attribute> builder)
        {
            builder.ToTable("Attribute");
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.DisplayName).IsRequired();
            builder.Property(p => p.ElementId).IsRequired();

            builder.HasOne(x => x.Element).WithMany(y => y.Attributes).HasForeignKey(z => z.ElementId).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}