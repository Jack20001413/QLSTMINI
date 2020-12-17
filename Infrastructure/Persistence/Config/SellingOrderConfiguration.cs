using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class SellingOrderConfiguration : IEntityTypeConfiguration<SellingOrder>
    {
        public void Configure(EntityTypeBuilder<SellingOrder> builder)
        {
            builder.Property(o => o.TotalPrice)
                .IsRequired();

            builder.Property(o => o.CreatedDate)
                .HasColumnType("Date");

            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            builder.HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmployeeId);

            builder.HasMany(o => o.SellingTransactions)
                .WithOne();
        }
    }
}