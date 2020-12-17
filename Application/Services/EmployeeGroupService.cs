using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class EmployeeGroupService : IEmployeeGroupService
    {   
        private readonly IEmployeeGroupRepository employeeGroupRepository;

        public EmployeeGroupService(IEmployeeGroupRepository employeeGroupRepository)
        {
            this.employeeGroupRepository = employeeGroupRepository;
        }
        
        public void CreateEmployeeGroup(EmployeeGroupDto employeeGroupDto)
        {
            employeeGroupRepository.Add(employeeGroupDto.MappingGroup());
        }

        public void DeleteEmployeeGroup(EmployeeGroupDto employeeGroupDto)
        {
            employeeGroupRepository.Delete(employeeGroupDto.MappingGroup());
        }

        public IEnumerable<EmployeeGroupDto> GetAll()
        {
            return employeeGroupRepository.GetGroups().MappingDtos();
        }

        public EmployeeGroupDto GetEmployeeGroup(int id)
        {
            return employeeGroupRepository.GetBy(id).MappingDto();
        }

        public void UpdateEmployeeGroup(EmployeeGroupDto employeeGroupDto)
        {
            employeeGroupRepository.Update(employeeGroupDto.MappingGroup());
        }

        public bool EmployeeGroupExists(int id)
        {
            return employeeGroupRepository.GetBy(id) != null;
        }
    }
}