using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerGroupRepository customerGroupRepository;

        public CustomerService(ICustomerRepository customerRepository, ICustomerGroupRepository customerGroupRepository)
        {
            this.customerRepository = customerRepository;
            this.customerGroupRepository = customerGroupRepository;
        }
        public void CreateCustomer(CustomerDto customerDto)
        {
            customerRepository.Add(customerDto.MappingCustomer());
        }

        public void DeleteCustomer(CustomerDto customerDto)
        {
            customerRepository.Delete(customerDto.MappingCustomer());
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            return customerRepository.GetAll().MappingDtos();
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = customerRepository.GetBy(id);
            customer.CustomerGroup = customerGroupRepository.GetBy(customer.CustomerGroupId);
            return customer.MappingDto();
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            customerRepository.Update(customerDto.MappingCustomer());
        }

        public bool IsCustomerExisted(int id)
        {
            return customerRepository.GetBy(id) != null;
        }
    }
}