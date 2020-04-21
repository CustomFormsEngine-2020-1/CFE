using CFE.Entities.Models;
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
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(100, 1);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.DisplayName).IsRequired();
            builder.Property(p => p.QuestionId).IsRequired();

            // builder.HasOne(x => x.Element).WithMany(y => y.Attributes).HasForeignKey(z => z.ElementId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
