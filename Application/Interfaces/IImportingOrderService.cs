using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IImportingOrderService
    {
         IEnumerable<ImportingOrderDto> GetAll();
         ImportingOrderDto GetOrder(int id);
         void CreateOrder(ImportingOrderDto order);
         void UpdateOrder(ImportingOrderDto order);
         void DeleteOrder(ImportingOrderDto order);
         bool OrderExists(int id);
    }
}