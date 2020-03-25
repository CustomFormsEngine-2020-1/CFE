using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.ToTable("Form");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DTCreate).IsRequired();
            builder.Property(p => p.IsPrivate).IsRequired();
            builder.Property(p => p.IsAnonymity).IsRequired();
            builder.Property(p => p.IsEditingAfterSaving).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.HasOne(x => x.User).WithMany(y => y.Forms).HasForeignKey(z => z.UserId).OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
