using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class ImportingOrderConfiguration : IEntityTypeConfiguration<ImportingOrder>
    {
        public void Configure(EntityTypeBuilder<ImportingOrder> builder)
        {
            builder.Property(o => o.CreatedDate)
                .HasColumnType("Date");

            builder.Property(o => o.NameCode)
                .IsRequired();

            builder.HasOne(o => o.Vendor)
                .WithMany()
                .HasForeignKey(o => o.VendorId);

            builder.HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmployeeId);

            builder.HasMany(o => o.ImportingTransactions)
                .WithOne();
                
        }
    }
}