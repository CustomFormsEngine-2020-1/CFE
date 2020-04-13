using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answer");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(1, 1);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.QuestionId).IsRequired();

            // builder.HasOne(x => x.Question).WithMany(y => y.Answers).HasForeignKey(z => z.QuestionId).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
