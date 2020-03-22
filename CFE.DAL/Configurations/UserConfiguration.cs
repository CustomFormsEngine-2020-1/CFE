using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CFE.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(p => p.Login).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
        }
    }
}
