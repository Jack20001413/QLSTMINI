using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerGroupRepository : IRepository<CustomerGroup>
    {
        IEnumerable<CustomerGroup> GetAll();
    }
}