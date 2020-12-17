using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SellingOrderRepository : EFRepository<SellingOrder>, ISellingOrderRepository
    {
        public SellingOrderRepository(SupermarketDbContext db) : base(db)
        {
            
        }

        public IEnumerable<SellingOrder> GetAll()
        {
            return _db.SellingOrders.Include(o => o.Customer).Include(o => o.Employee).ToList();
        }

        public IEnumerable<SellingOrder> GetStatistics(DateTime startDate, DateTime endDate)
        {
            return _db.SellingOrders.Include(r => r.Customer).Include(r => r.Employee)
                    .Where(p => (p.CreatedDate >= startDate && p.CreatedDate <= endDate));
        }

    }
}