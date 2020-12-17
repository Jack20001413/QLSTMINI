using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SupermarketDbContext db) : base(db)
        {
        }

        public IEnumerable<Customer> GetAll()
        {
           var customers = _db.Customers.Include(c => c.CustomerGroup).ToList();
           return customers;
        }
    }
}