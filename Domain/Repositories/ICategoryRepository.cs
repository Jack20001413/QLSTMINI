using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAll();
    }
}