using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
         IEnumerable<Employee> GetAll();
         Employee GetAdmin(string email);
    }
}