using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IEmployeeGroupService
    {
         IEnumerable<EmployeeGroupDto> GetAll();
         EmployeeGroupDto GetEmployeeGroup(int id);
         void CreateEmployeeGroup(EmployeeGroupDto employeeGroup);
         void UpdateEmployeeGroup(EmployeeGroupDto employeeGroup);
         void DeleteEmployeeGroup(EmployeeGroupDto employeeGroup);
         bool EmployeeGroupExists(int id);
    }
}