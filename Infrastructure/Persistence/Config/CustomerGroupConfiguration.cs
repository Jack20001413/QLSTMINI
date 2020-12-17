using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class CustomerGroupConfiguration : IEntityTypeConfiguration<CustomerGroup>
    {
        public void Configure(EntityTypeBuilder<CustomerGroup> builder)
        {   
            builder.Property(g => g.Name)
                .HasMaxLength(20)
                .IsUnicode()
                .IsRequired();

            // builder.HasMany(g => g.Customers);
            //    .WithOne();
        }
    }
}