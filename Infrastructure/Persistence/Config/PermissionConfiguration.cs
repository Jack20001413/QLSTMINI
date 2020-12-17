using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Code);

            builder.Property(p => p.Name)
                .IsUnicode()
                .IsRequired();

            builder.Property(p => p.Description)
                .IsUnicode()
                .IsRequired();
        }
    }
}