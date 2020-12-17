using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ImportingTransactionRepository : EFRepository<ImportingTransaction>, IImportingTransactionRepository
    {
        public ImportingTransactionRepository(SupermarketDbContext db) : base(db)
        {
        }

        public IEnumerable<ImportingTransaction> GetByImportingId(int id)
        {
            var importingTransactions = _db.ImportingTransactions.Where(t => t.ImportingOrderId == id).Include(t => t.Product).ToList();
            return importingTransactions;
        }

        public void AddRange(IEnumerable<ImportingTransaction> importingTransactions)
        {
            foreach(var item in importingTransactions)
            {
                _db.Add(item);
            }
            _db.SaveChanges();
        }
        
        public void RemoveRange(IEnumerable<ImportingTransaction> importingTransactions)
        {
            _db.RemoveRange(importingTransactions);
            _db.SaveChanges();
        }
    }
}