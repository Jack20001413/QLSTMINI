using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICustomerGroupService
    {
         IEnumerable<CustomerGroupDto> GetAll();
         CustomerGroupDto GetCustomerGroup(int id);
         void CreateCustomerGroup(CustomerGroupDto customerGroup);
         void DeleteCustomerGroup(CustomerGroupDto customerGroup);
         void UpdateCustomerGroup(CustomerGroupDto customerGroup);
         bool CustomerGroupExists(int id);
    }
}