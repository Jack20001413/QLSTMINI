using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
         IEnumerable<EmployeeDto> GetAll();
         EmployeeDto GetEmployee(int id);
         void CreateEmployee(EmployeeDto employee);
         void UpdateEmployee(EmployeeDto employee);
         void DeleteEmployee(EmployeeDto employee);
         bool IsEmployeeExisted(int id);
         EmployeeDto GetAdmin(string email);
    }
}