using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            //builder.ToTable("Question");
            //builder.HasKey(k => k.Id);
            //builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(100, 1);
            //builder.Property(p => p.Name).IsRequired();
            //builder.Property(p => p.FormId).IsRequired();
            //builder.Property(p => p.ElementId).IsRequired();

            // builder.HasOne(x => x.Form).WithMany(y => y.Questions).HasForeignKey(z => z.FormId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
