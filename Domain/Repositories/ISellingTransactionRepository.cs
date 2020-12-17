using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISellingTransactionRepository : IRepository<SellingTransaction>
    {
         IEnumerable<SellingTransaction> GetAll();
         IEnumerable<SellingTransaction> GetTransactions(int orderId);
         void RemoveRange(IEnumerable<SellingTransaction> sellingTransactions);
         void AddRange(IEnumerable<SellingTransaction> sellingTransactions);
    }
}