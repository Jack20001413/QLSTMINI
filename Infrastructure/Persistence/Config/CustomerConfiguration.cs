using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {   
        
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Fullname)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(c => c.CardId)
                .IsRequired()
                .HasMaxLength(15);
                
            builder.Property(c => c.Email)
                .IsRequired();
            
            builder.Property(c => c.Phone)
                .IsRequired();

            builder.HasOne(c => c.CustomerGroup)
                .WithMany(g => g.Customers)
                .HasForeignKey(c => c.CustomerGroupId);
        }
    }
}