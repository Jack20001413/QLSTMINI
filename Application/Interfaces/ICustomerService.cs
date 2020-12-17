using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
        CustomerDto GetCustomer(int id);
        void CreateCustomer(CustomerDto customer);
        void DeleteCustomer(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        bool IsCustomerExisted(int id);
    }
}