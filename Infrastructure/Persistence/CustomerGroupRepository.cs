using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class CustomerGroupRepository : EFRepository<CustomerGroup>, ICustomerGroupRepository
    {   
        public CustomerGroupRepository(SupermarketDbContext db) : base(db)
        {
            
        }

        public IEnumerable<CustomerGroup> GetAll()
        {
            return _db.CustomerGroups.ToList();
        }
    }
}