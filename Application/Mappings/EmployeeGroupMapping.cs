using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class EmployeeGroupMapping
    {
        //Map from Entity to Dto
        public static EmployeeGroupDto MappingDto(this EmployeeGroup employeeGroup)
        {
            return new EmployeeGroupDto
            {
                Id = employeeGroup.Id,
                Name = employeeGroup.Name,
            };
        }

        //Map from Dto to Entity
        public static EmployeeGroup MappingGroup(this EmployeeGroupDto employeeGroupDto)
        {
            return new EmployeeGroup
            {
                Id = employeeGroupDto.Id,
                Name = employeeGroupDto.Name
            };
        }

        //Map from Dto to Entity
        public static void MappingGroup(this EmployeeGroupDto employeeGroupDto, EmployeeGroup employeeGroup)
        {
            employeeGroup.Id = employeeGroupDto.Id;
            employeeGroup.Name = employeeGroupDto.Name;
        }

        //Map from Entity List to Dto List
        public static IEnumerable<EmployeeGroupDto> MappingDtos(this IEnumerable<EmployeeGroup> employeeGroups)
        {
            foreach(var group in employeeGroups)
            {
                yield return group.MappingDto();
            }
        }
    }
}