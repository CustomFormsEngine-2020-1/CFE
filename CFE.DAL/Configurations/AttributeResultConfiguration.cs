using CFE.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFE.DAL.Configurations
{
    public class AttributeResultConfiguration : IEntityTypeConfiguration<AttributeResult>
    {
        public void Configure(EntityTypeBuilder<AttributeResult> builder)
        {
            builder.ToTable("AttributeResult");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn(100, 1);
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.AttributeId).IsRequired();
        }
    }
}
