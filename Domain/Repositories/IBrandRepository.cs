using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        IEnumerable<Brand> GetAll();
    }
}