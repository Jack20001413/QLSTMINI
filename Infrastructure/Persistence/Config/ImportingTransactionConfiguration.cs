using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class ImportingTransactionConfiguration : IEntityTypeConfiguration<ImportingTransaction>
    {
        public void Configure(EntityTypeBuilder<ImportingTransaction> builder)
        {
            builder.Property(t => t.TotalPrice)
                .IsRequired();

            builder.Property(t => t.UnitPrice)
                .IsRequired();

            builder.Property(t => t.Quantity)
                .IsRequired();

            builder.HasOne(t => t.ImportingOrder)
                .WithMany(t => t.ImportingTransactions)
                .HasForeignKey(t => t.ImportingOrderId);

            builder.HasOne(t => t.Product)
                .WithMany()
                .HasForeignKey(t => t.ProductId);
        }
    }
}