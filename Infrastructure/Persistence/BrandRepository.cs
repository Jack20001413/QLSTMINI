using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class BrandRepository : EFRepository<Brand>, IBrandRepository
    {
        public BrandRepository(SupermarketDbContext db) : base(db)
        {
            
        }

        public IEnumerable<Brand> GetAll()
        {
            return _db.Brands.ToList();
        }
    }
}