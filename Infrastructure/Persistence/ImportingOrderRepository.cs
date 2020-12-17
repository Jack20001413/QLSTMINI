using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ImportingOrderRepository : EFRepository<ImportingOrder>, IImportingOrderRepository
    {
        public ImportingOrderRepository(SupermarketDbContext db) : base(db)
        {
        }

        public IEnumerable<ImportingOrder> GetAll()
        {
            var importingOrders = _db.ImportingOrders.Include(e => e.Employee).Include(e => e.Vendor).ToList();
            return importingOrders;
        }
    }
}