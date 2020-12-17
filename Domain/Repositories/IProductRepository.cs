using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
         IEnumerable<Product> GetAll();
         IEnumerable<Product> Search(string parm);
         void UpdateQuantity(IEnumerable<Product> products);
    }
}