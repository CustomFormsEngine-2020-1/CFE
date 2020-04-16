using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class FormResultConfiguration : IEntityTypeConfiguration<FormResult>
    {
        public void Configure(EntityTypeBuilder<FormResult> builder)
        {
            builder.ToTable("FormResult");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1);
            builder.Property(p => p.DTResult).IsRequired();
            builder.Property(p => p.FormId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            // builder.HasOne(x => x.User).WithMany(y => y.FormResults).HasForeignKey(z => z.UserId).OnDelete(DeleteBehavior.Restrict);
            // builder.HasOne(x => x.Form).WithMany(y => y.FormResults).HasForeignKey(z => z.FormId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
