using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options)
        {
            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<EmployeeGroup> EmployeeGroups { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<GrantPermission> GrantPermissions { get; set; }

        public DbSet<ImportingOrder> ImportingOrders { get; set; }

        public DbSet<ImportingTransaction> ImportingTransactions { get; set; }

        public DbSet<SellingOrder> SellingOrders { get; set; }

        public DbSet<SellingTransaction> SellingTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            

            //modelBuilder.Entity<Customer>()


            //Create Data Seed
            modelBuilder.Entity<CustomerGroup>().HasData(
                new CustomerGroup{
                    Id = 1,
                    Name = "Thường"
                },
                new CustomerGroup{
                    Id = 2,
                    Name = "Vip"
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category{
                    Id = 1,
                    Name = "Thực phẩm"
                },
                new Category{
                    Id = 2,
                    Name = "Áo"
                }
            );
            modelBuilder.Entity<EmployeeGroup>().HasData(
                new EmployeeGroup{
                    Id = 1,
                    Name = "Admin"
                },
                new EmployeeGroup{
                    Id = 2,
                    Name = "Nhân viên"
                }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee{
                    Id = 1,
                    Fullname = "Admin",
                    BirthDate = DateTime.Parse("2020-03-14"),
                    CardId = "023141222",
                    Email = "admin@gmail.com",
                    Password = "123456",
                    Phone = "0908860370",
                    Address = "12/3 Lê Khôi P.11 Q.10",
                    EmployeeGroupId = 1,
                }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer{
                    Id = 1,
                    Fullname = "Trần Vĩ Văn",
                    BirthDate = DateTime.Parse("2020-03-14"),
                    CardId = "023141222",
                    Email = "vivantran2000@gmail.com",
                    Phone = "09128860370",
                    Address = "12/3 Dương Tử Giang P.12 Q.5",
                    CustomerGroupId = 1,
                }
            );
            
        }
    }
}
