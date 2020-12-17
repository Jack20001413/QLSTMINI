using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsUnicode()
                .IsRequired();
            
            builder.Property(p => p.Unit)
                .IsUnicode()
                .IsRequired();

            builder.Property(p => p.ImportPrice)
                .IsRequired();

            builder.Property(p => p.SalePrice)
                .IsRequired();
            
            builder.Property(p => p.Description)
                .IsUnicode()
                .IsRequired();

            builder.HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);
        }
    }
}