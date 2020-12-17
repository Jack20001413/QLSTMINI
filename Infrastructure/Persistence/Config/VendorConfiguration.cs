using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(v => v.Name)
                .IsUnicode()
                .IsRequired();

            builder.Property(v => v.Address)
                .IsUnicode()
                .IsRequired();
            
            builder.Property(v => v.Phone)
                .IsRequired();
        }
    }
}