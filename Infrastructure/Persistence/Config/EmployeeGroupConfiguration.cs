using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class EmployeeGroupConfiguration : IEntityTypeConfiguration<EmployeeGroup>
    {
        public void Configure(EntityTypeBuilder<EmployeeGroup> builder)
        {
            builder.Property(g => g.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            // builder.HasMany(g => g.Employees)
            //     .WithOne();
        }
    }
}