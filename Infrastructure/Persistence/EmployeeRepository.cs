using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class EmployeeRepository : EFRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SupermarketDbContext db) : base(db)
        {
        }

        public Employee GetAdmin(string email)
        {
            var _admin = _db.Employees.Where(s => s.Email == email).Include(s => s.EmployeeGroup).FirstOrDefault();
            return _admin;
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _db.Employees.Include(e => e.EmployeeGroup).ToList();
            return employees;
        }
    }
}