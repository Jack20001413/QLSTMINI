using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class SellingTransactionConfiguration : IEntityTypeConfiguration<SellingTransaction>
    {
        public void Configure(EntityTypeBuilder<SellingTransaction> builder)
        {
            builder.Property(t => t.Quantity)
                .IsRequired();

            builder.Property(t => t.UnitPrice)
                .IsRequired();

            builder.Property(t => t.TotalPrice)
                .IsRequired();

            builder.HasOne(t => t.SellingOrder)
                .WithMany(t => t.SellingTransactions)
                .HasForeignKey(t => t.SellingOrderId);
            
            builder.HasOne(t => t.Product)
                .WithMany()
                .HasForeignKey(t => t.ProductId);
        }
    }
}