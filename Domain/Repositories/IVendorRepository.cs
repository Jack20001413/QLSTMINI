using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IVendorRepository : IRepository<Vendor>
    {
         IEnumerable<Vendor> GetAll();
    }
}