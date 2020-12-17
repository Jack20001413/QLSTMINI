using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {   
            // builder.Property(e => e.Id)
            //     .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.Fullname)
                .IsRequired(false);

            builder.Property(e => e.CardId)
                .HasColumnType("varchar(9,15")
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.Password)
                .IsRequired();

            builder.Property(e => e.Phone)
                .IsRequired();

            builder.Property(e => e.Address)
                .IsRequired(); 

            builder.Property(e => e.BirthDate)
                .HasColumnType("Date");

            builder.HasOne(e => e.EmployeeGroup)
                .WithMany()
                .HasForeignKey(e => e.EmployeeGroupId);

            // builder.HasMany(e => e.ImportingOrders)
            //     .WithOne();
        }
    }
}