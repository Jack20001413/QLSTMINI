using System;
using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISellingOrderService
    {
         IEnumerable<SellingOrderDto> GetAll();
         SellingOrderDto GetOrder(int id);
         void CreateOrder(SellingOrderDto order);
         void UpdateOrder(SellingOrderDto order);
         void DeleteOrder(SellingOrderDto order);
        IEnumerable<SellingOrderDto> GetStatistics(DateTime startTime, DateTime endTime);
        bool OrderExists(int id);
    }
}