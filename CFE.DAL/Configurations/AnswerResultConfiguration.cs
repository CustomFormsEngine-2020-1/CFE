using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class AnswerResultConfiguration : IEntityTypeConfiguration<AnswerResult>
    {
        public void Configure(EntityTypeBuilder<AnswerResult> builder)
        {
            builder.ToTable("AnswerResult");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(100, 1);
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.QuestionResultId).IsRequired();

            builder.HasOne(x => x.QuestionResult).WithMany(y => y.AnswerResults).HasForeignKey(z => z.QuestionResultId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
