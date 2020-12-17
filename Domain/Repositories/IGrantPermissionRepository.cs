using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IGrantPermissionRepository : IRepository<GrantPermission>
    {
          IEnumerable<GrantPermission> GetAll();
    }
}