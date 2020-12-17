using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class VendorRepository : EFRepository<Vendor>, IVendorRepository
    {   
        public VendorRepository(SupermarketDbContext db) : base(db)
        {
            
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _db.Vendors.ToList();
        }
    }
}