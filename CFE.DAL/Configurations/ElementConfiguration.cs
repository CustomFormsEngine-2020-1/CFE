using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class ElementConfiguration : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.ToTable("Element");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(100, 1);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
