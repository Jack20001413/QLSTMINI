using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence.Config
{
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SupermarketDbContext db) : base(db)
        {
            
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}