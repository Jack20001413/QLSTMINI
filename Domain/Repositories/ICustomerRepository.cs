using System.Collections;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
         IEnumerable<Customer> GetAll();
    }
}