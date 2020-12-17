using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class GrantPermissionConfiguration : IEntityTypeConfiguration<GrantPermission>
    {
        public void Configure(EntityTypeBuilder<GrantPermission> builder)
        {
            
        }
    }
}