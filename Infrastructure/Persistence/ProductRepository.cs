using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public ProductRepository(SupermarketDbContext db) : base(db)
        {
            
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.Include(p => p.Category).Include(p => p.Brand).ToList();
        }

        public IEnumerable<Product> Search(string parm)
        {
            return _db.Products.Where(p => p.Name.Contains(parm)).Include(p => p.Category).Include(p => p.Brand).ToList();
        }

        public void UpdateQuantity(IEnumerable<Product> products)
        {
            _db.Products.UpdateRange(products);
            _db.SaveChanges();
        }
    }
}