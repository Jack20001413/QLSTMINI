using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class CustomerGroupService : ICustomerGroupService
    {   
        private readonly ICustomerGroupRepository customerGroupRepository;

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository)
        {
            this.customerGroupRepository = customerGroupRepository;
        }
        public void CreateCustomerGroup(CustomerGroupDto customerGroupDto)
        {
            customerGroupRepository.Add(customerGroupDto.MappingGroup());
        }

        public void DeleteCustomerGroup(CustomerGroupDto customerGroupDto)
        {
            customerGroupRepository.Delete(customerGroupDto.MappingGroup());
        }

        public IEnumerable<CustomerGroupDto> GetAll()
        {
            return customerGroupRepository.GetAll().MappingDtos();
        }

        public CustomerGroupDto GetCustomerGroup(int id)
        {
            return customerGroupRepository.GetBy(id).MappingDto();
        }

        public void UpdateCustomerGroup(CustomerGroupDto customerGroupDto)
        {
            customerGroupRepository.Update(customerGroupDto.MappingGroup());
        }

        public bool CustomerGroupExists(int id)
        {
            return customerGroupRepository.GetBy(id) != null;
        }
    }
}