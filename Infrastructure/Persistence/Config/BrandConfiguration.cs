using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name)
                .IsUnicode()
                .IsRequired();
            
            builder.Property(b => b.Address)
                .IsUnicode()
                .IsRequired();
            
            builder.Property(b => b.Phone)
                .IsRequired();
        }
    }
}