using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {   
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeGroupRepository employeeGroupRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,IEmployeeGroupRepository employeeGroupRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeGroupRepository = employeeGroupRepository;
        }

        public void CreateEmployee(EmployeeDto employeeDto)
        {   
            employeeRepository.Add(employeeDto.MappingEmployee());
        }

        public void DeleteEmployee(EmployeeDto employeeDto)
        {
            employeeRepository.Delete(employeeDto.MappingEmployee());
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            return employeeRepository.GetAll().MappingDtos();
        }

        public EmployeeDto GetEmployee(int id)
        {
            var employee = employeeRepository.GetBy(id);
            employee.EmployeeGroup = employeeGroupRepository.GetBy(employee.EmployeeGroupId);
            return employee.MappingDto();
        }

        public void UpdateEmployee(EmployeeDto employeeDto)
        {
            employeeRepository.Update(employeeDto.MappingEmployee());
        }

        public bool IsEmployeeExisted(int id)
        {
            return employeeRepository.GetBy(id) != null;
        }

        public EmployeeDto GetAdmin(string email)
        {
            return employeeRepository.GetAdmin(email).MappingDto();
        }
    }
}