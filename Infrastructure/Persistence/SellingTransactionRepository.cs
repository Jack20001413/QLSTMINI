using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SellingTransactionRepository : EFRepository<SellingTransaction>, ISellingTransactionRepository
    {
        public SellingTransactionRepository(SupermarketDbContext db) : base(db)
        {
            
        }
        public IEnumerable<SellingTransaction> GetAll()
        {
            return _db.SellingTransactions.ToList();
        }

        public IEnumerable<SellingTransaction> GetTransactions(int orderId)
        {
            return _db.SellingTransactions.Where(t => t.SellingOrderId == orderId)
                    .Include(t => t.Product).ToList();
        }

        public void AddRange(IEnumerable<SellingTransaction> sellingTransactions)
        {
            foreach(var item in sellingTransactions)
            {
                _db.Add(item);
            }
            _db.SaveChanges();
        }
        
        public void RemoveRange(IEnumerable<SellingTransaction> sellingTransactions)
        {
            _db.RemoveRange(sellingTransactions);
            _db.SaveChanges();
        }
    }
}