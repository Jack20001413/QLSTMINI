using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IImportingTransactionRepository : IRepository<ImportingTransaction>
    {
         IEnumerable<ImportingTransaction> GetByImportingId(int id);
         void AddRange(IEnumerable<ImportingTransaction> importingTransactions);
         void RemoveRange(IEnumerable<ImportingTransaction> importingTransactions);
    }
}