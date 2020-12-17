using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class EmployeeGroupRepository : EFRepository<EmployeeGroup>, IEmployeeGroupRepository
    {
        public EmployeeGroupRepository(SupermarketDbContext db) : base(db)
        {
        }

        public EmployeeGroup FindGroup(int id)
        {
            return _db.EmployeeGroups.Find(id);
        }

        public IEnumerable<EmployeeGroup> GetGroups()
        {
            return _db.EmployeeGroups.ToList();
        }
    }
}