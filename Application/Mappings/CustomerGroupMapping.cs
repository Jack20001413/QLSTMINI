using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class CustomerGroupMapping
    {
        public static CustomerGroupDto MappingDto(this CustomerGroup customerGroup)
        {
            return new CustomerGroupDto
            {
                Id = customerGroup.Id,
                Name = customerGroup.Name,
            };
        }

        //Map from Dto to Entity
        public static CustomerGroup MappingGroup(this CustomerGroupDto customerGroupDto)
        {
            return new CustomerGroup
            {
                Id = customerGroupDto.Id,
                Name = customerGroupDto.Name
            };
        }

        //Map from Dto to Entity
        public static void MappingGroup(this CustomerGroupDto customerGroupDto, CustomerGroup customerGroup)
        {
            customerGroup.Id = customerGroupDto.Id;
            customerGroup.Name = customerGroupDto.Name;
        }

        //Map from Entity List to Dto List
        public static IEnumerable<CustomerGroupDto> MappingDtos(this IEnumerable<CustomerGroup> customerGroups)
        {
            foreach(var group in customerGroups)
            {
                yield return group.MappingDto();
            }
        }
    }
}