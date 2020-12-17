using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISellingTransactionService
    {
         IEnumerable<SellingTransactionDto> GetAll();
         SellingTransactionDto GetTransaction(int id);
         void CreateTransaction(SellingTransactionDto transaction);
         void UpdateTransaction(SellingTransactionDto transaction);
         void DeleteTransaction(SellingTransactionDto transaction);
    }
}