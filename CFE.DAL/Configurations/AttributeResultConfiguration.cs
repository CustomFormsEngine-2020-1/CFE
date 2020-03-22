using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class AttributeResultConfiguration : IEntityTypeConfiguration<AttributeResult>
    {
        public void Configure(EntityTypeBuilder<AttributeResult> builder)
        {
            builder.ToTable("AttributeResult");
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.AttributeId).IsRequired();
        }
    }
}
