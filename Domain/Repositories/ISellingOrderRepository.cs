using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISellingOrderRepository : IRepository<SellingOrder>
    {
         IEnumerable<SellingOrder> GetAll();
        //  IQueryable<SellingOrder> GetOrderQueries();
        IEnumerable<SellingOrder> GetStatistics(DateTime startDate, DateTime endDate);
    }
}