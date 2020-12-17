using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class CustomerMapping
    {
        public static CustomerDto MappingDto(this Customer customer)
        {
            return new CustomerDto()
            {
                Id = customer.Id,
                Fullname = customer.Fullname,
                CardId = customer.CardId,
                Email = customer.Email,
                CardNumber = customer.CardNumber,
                Phone = customer.Phone,
                BirthDate = customer.BirthDate,
                Address = customer.Address,
                CustomerGroupId = customer.CustomerGroupId,
                CustomerGroup = new CustomerGroupDto()
                {
                    Id = customer.CustomerGroup.Id,
                    Name = customer.CustomerGroup.Name
                }
            };
        }

        public static Customer MappingCustomer(this CustomerDto customerDto)
        {
            return new Customer()
            {
                Id = customerDto.Id,
                Fullname = customerDto.Fullname,
                CardId = customerDto.CardId,
                Email = customerDto.Email,
                CardNumber = customerDto.CardNumber,
                Phone = customerDto.Phone,
                BirthDate = (System.DateTime)customerDto.BirthDate,
                Address = customerDto.Address,
                CustomerGroupId = customerDto.CustomerGroupId
            };
        }

        public static void MappingCustomer(this CustomerDto customerDto,Customer customer)
        {
            customer.Id = customerDto.Id;
            customer.Fullname = customerDto.Fullname;
            customer.CardId = customerDto.CardId;
            customer.Email = customerDto.Email;
            customer.CardNumber = customerDto.CardNumber;
            customer.Phone = customerDto.Phone;
            customer.BirthDate = (System.DateTime)customerDto.BirthDate;
            customer.Address = customerDto.Address;
            customer.CustomerGroupId = customerDto.CustomerGroupId;
        }

        public static IEnumerable<CustomerDto> MappingDtos(this IEnumerable<Customer> customers)
        {
            foreach(var customer in customers)
            {
                yield return customer.MappingDto();
            }
        }
    }
}