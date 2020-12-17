using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEmployeeGroupRepository : IRepository<EmployeeGroup>
    {
         IEnumerable<EmployeeGroup> GetGroups();
         EmployeeGroup FindGroup(int id);
    }
}