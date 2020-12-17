using System.Collections;
using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class EmployeeMapping
    {
        //Map from Entity to Dto
        public static EmployeeDto MappingDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Fullname = employee.Fullname,
                CardId = employee.CardId,
                Email = employee.Email,
                Password = employee.Password,
                Phone = employee.Phone,
                Address = employee.Address,
                BirthDate = employee.BirthDate,
                EmployeeGroupId = employee.EmployeeGroupId,
                EmployeeGroup = new EmployeeGroupDto
                {
                    Id = employee.EmployeeGroup.Id,
                    Name = employee.EmployeeGroup.Name
                },
            };
        }

        //Map from Dto to Entity
        public static Employee MappingEmployee(this EmployeeDto employeeDto)
        {
            return new Employee
            {
                Id = employeeDto.Id,
                Fullname = employeeDto.Fullname,
                CardId = employeeDto.CardId,
                Email = employeeDto.Email,
                Password = employeeDto.Password,
                Phone = employeeDto.Phone,
                Address = employeeDto.Address,
                BirthDate = (System.DateTime)employeeDto.BirthDate,
                EmployeeGroupId = employeeDto.EmployeeGroupId,
            };
        }

        //Map from Dto to Entity
        public static void MappingEmployee(this EmployeeDto employeeDto, Employee employee)
        {
            employee.Id = employeeDto.Id;
            employee.Fullname = employeeDto.Fullname;
            employee.CardId = employeeDto.CardId;
            employee.Email = employeeDto.Email;
            employee.Password = employeeDto.Password;
            employee.Phone = employeeDto.Phone;
            employee.Address = employeeDto.Address;
            employee.BirthDate = (System.DateTime)employeeDto.BirthDate;
            employee.EmployeeGroupId = employeeDto.EmployeeGroupId;
        }

        //Map from Entity List to Dto List
        public static IEnumerable<EmployeeDto> MappingDtos(this IEnumerable<Employee> employees)
        {
            foreach(var employee in employees)
            {
                yield return employee.MappingDto();
            }
        }
    }
}