using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
         IEnumerable<Permission> GetAll();
    }
}