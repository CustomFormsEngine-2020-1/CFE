using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class QuestionResultConfiguration : IEntityTypeConfiguration<QuestionResult>
    {
        public void Configure(EntityTypeBuilder<QuestionResult> builder)
        {
            //builder.ToTable("QuestionResult");
            //builder.HasKey(k => k.Id);
            //builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(100, 1);
            //builder.Property(p => p.QuestionId).IsRequired();
            //builder.Property(p => p.FormResultId).IsRequired();

            //builder.HasOne(x => x.FormResult).WithMany(y => y.QuestionResults).HasForeignKey(z => z.FormResultId).OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
